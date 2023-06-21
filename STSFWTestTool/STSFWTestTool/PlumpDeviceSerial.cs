using System;
using System.Collections.Generic;
using System.IO.Ports;
using InterfacesLib;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonLib;
using static CommonLib.PlumpDeviceStatusStruct;
using MathUtils;

namespace STSFWTestTool
{
    public class PlumpDeviceSerial : BaseDevice
    {
        private SerialPort sp = null;

        public PlumpDeviceSerial()
        {
            sp = new SerialPort();
            sp.BaudRate = 921600;
            sp.ReceivedBytesThreshold = 5;
            sp.DtrEnable = true;
            sp.DataReceived += Sp_DataReceived;
            collectedBytes = new SerBuf();
            errorPacketsReceived = 0;
            totalPacketsReceived = 0;
        }

        public override Enum_TestCommunication GetCommunicationType()
        {
            return Enum_TestCommunication.Serial;
        }

        /*public class PlumpDeviceStatusStruct
        {
            int length; // Length of payload
            byte opcode; // Command opcode
            short[] samples; //= new short[lengt >> 1]; 
            ushort num_of_samples;
            ushort sample_type;
            ushort sample_counter;
            DateTime received_time;
            public ushort SampleType => sample_type;
            public ushort SampleCounter => sample_counter;
            public ushort NumOfSamples => num_of_samples;
            public byte Opcode => opcode;
            public short[] Samples => samples;
            public DateTime ReceivedTime => received_time;

            public bool Init(byte opcode_in, byte[] payload_in)
            {
                if (payload_in == null)
                    return false;
                length = payload_in.Length;
                if (length < 6)
                    return false;
                opcode = opcode_in;
                sample_type = BitConverter.ToUInt16(payload_in, 0);
                sample_counter = BitConverter.ToUInt16(payload_in, 2);
                num_of_samples = (ushort)((length - 4) >> 1);
                samples = new short[num_of_samples];
                for (int i = 0, j = 4; i < num_of_samples; i++, j += 2)
                    samples[i] = BitConverter.ToInt16(payload_in, j);
                received_time = DateTime.Now;
                return true;
            }
        }*/

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2} ", b);
            return hex.ToString();
        }

        protected override void SendCommandMessage(byte opcode, byte[] payload)
        {
            if (!sp.IsOpen)
                return;

            byte[] command = SerBuf.ComposeMessage(opcode, payload);
            if (command == null)
                return;

            try
            {
                // Console 
                Console.WriteLine(ByteArrayToString(command));
                sp.Write(command, 0, command.Length);
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

            if (sp.IsOpen)
            {
                SendStopCommandMessage();
                sp.Close();
                collectedBytes.Reset();
                InvokeDisconnected();
                InvokeConnectionLog(Enum_ConnectionLog.Disconnected);

                return true;
            }

            InvokeConnectionLog(Enum_ConnectionLog.Connecting);

            sp.PortName = comPort;
            try
            {
                collectedBytes.Reset();
                sp.Open();
            }
            catch (Exception ex)
            {
                InvokeConnectionFailed();
                InvokeConnectionLog(Enum_ConnectionLog.Failed);

                ex.GetType();
                return false;
            }
            InvokeConnectionSuccessFully();
            InvokeConnectionLog(Enum_ConnectionLog.Connected);
            return true;
        }

        public virtual string GetName()
        {
            return string.Empty;
        }
        private void Sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int n = sp.BytesToRead;
                byte[] recivedBytes = new byte[n];
                sp.Read(recivedBytes, 0, n);
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
