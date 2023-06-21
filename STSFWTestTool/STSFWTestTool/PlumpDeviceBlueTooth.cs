using BLEConsole;
using CommonLib;
using InterfacesLib;
using MathUtils;
//using NamedPipeWrapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using static CommonLib.PlumpDeviceStatusStruct;

namespace STSFWTestTool
{
    public class PlumpDeviceBlueTooth : BaseDevice
    {
        private static bool _isSub = false;

        public PlumpDeviceBlueTooth()
        {
            collectedBytes = new SerBuf();
            errorPacketsReceived = 0;
            totalPacketsReceived = 0;

            if (!_isSub)
            {
                Ble.GetBLE.CharacteristicValue += Ble_DataReceived;
                Ble.GetBLE.UserInfo += Ble_UserInfo;
                Ble.GetBLE.STSStatus += GetBLE_STSConnectionStatus;

                _isSub = true;
            }
        }

        public override Enum_TestCommunication GetCommunicationType()
        {
            return Enum_TestCommunication.BlueTooth;
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2} ", b);
            return hex.ToString();
        }

        protected override void SendCommandMessage(byte opcode, byte[] payload)
        {
            byte[] command = SerBuf.ComposeMessage(opcode, payload);

            if (command == null)
                return;

            Debug.WriteLine(ByteArrayToString(command));

            try
            {
                Ble.GetBLE.Write(command);
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        }

        public override bool Init(string comPort)
        {
            errorPacketsReceived = 0;
            totalPacketsReceived = 0;

            name = comPort;

            if (Ble.GetBLE.IsConneceted)
            {
                SendStopCommandMessage();
                Ble.DisconnectBLE();
                
                Ble.GetBLE.CharacteristicValue -= Ble_DataReceived;
                Ble.GetBLE.UserInfo -= Ble_UserInfo;
                Ble.GetBLE.STSStatus -= GetBLE_STSConnectionStatus;

                return true;
            }

            collectedBytes.Reset();

            InvokeConnectionLog(Enum_ConnectionLog.Connecting);

            // start sts ble 
            var devices = Ble.GetBLE.KnownDevices;
            for (int i = 0; i < devices.Count; i++)
                if (devices[i].Name.Equals(comPort))
                {
                    if (!Ble.GetBLE.STSConnect(devices[i]))
                    {
                        InvokeConnectionFailed();
                        InvokeConnectionLog(Enum_ConnectionLog.Failed);
                        return false;
                    }

                    return true;
                }

            InvokeConnectionFailed();
            InvokeConnectionLog(Enum_ConnectionLog.Failed);
            return false;
        }

        private void GetBLE_STSConnectionStatus(Status obj)
        {
            if (obj == Status.ConnectionSucceeded)
            {
                InvokeConnectionSuccessFully();
                InvokeConnectionLog(Enum_ConnectionLog.Connected);
            }
            else if (obj == Status.ConnectionFailed)
            {
                InvokeConnectionFailed();
                InvokeConnectionLog(Enum_ConnectionLog.Failed);
            }
            else if (obj == Status.Disconnected)
            {
                InvokeDisconnected();
                collectedBytes.Reset();
                InvokeConnectionLog(Enum_ConnectionLog.Disconnected);
            }
        }

        private void Ble_UserInfo(string userInfo)
        {
            if (userInfo.Equals("Device unreachable"))
            {
                InvokeConnectionFailed();
                InvokeConnectionLog(Enum_ConnectionLog.Failed);
            }


            Debug.WriteLine($"-->{userInfo}");
        }

        private void Ble_DataReceived(byte[] data)
        {
            try
            {
                byte[] recivedBytes = data;
                ProcessList(recivedBytes, Lpf);
            }
            catch (Exception ex)
            {
                errorPacketsReceived++;
                InvokeOnErrorPacket();
                ex.GetType();
            }
        }
    }
}
