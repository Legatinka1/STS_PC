using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;

namespace BLEConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Ble.GetBLE.KnownDevicesChanged += BleHelper_KnownDevicesChanged;
            Ble.GetBLE.ServiceChanged += BleHelper_ServiceChanged;
            Ble.GetBLE.CharacteristicsChanged += BleHelper_CharacteristicsChanged;
            Ble.GetBLE.CharacteristicProperties += BleHelper_CharacteristicProperties;
            Ble.GetBLE.CharacteristicValue += BleHelper_CharacteristicValue;

            Ble.GetBLE.UserInfo += BleHelper_UserInfo;
            Ble.GetBLE.StartBleScan();

            ChoseDevice();

            Console.WriteLine();
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void ChoseDevice()
        {
            int deviceIndex = -1;
            bool reverse = false;
            while (deviceIndex == -1)
            {
                string newLine = Console.ReadLine();
                try
                {
                    deviceIndex = int.Parse(newLine);

                    if (deviceIndex >= AllDevices.Count || deviceIndex < 0)
                        deviceIndex = -1;
                }
                catch (Exception ex)
                {
                    if (newLine == "...")
                    {
                        reverse = true;
                        deviceIndex = 0;
                    }
                }
            }

            if (reverse)
            {
                Ble.GetBLE.StopBleScan();
                return;
            }
            else
            {

                Ble.GetBLE.KnownDevicesChanged -= BleHelper_KnownDevicesChanged;
                Ble.GetBLE.ConnectToDevice(AllDevices[deviceIndex]);

                ChoseService();
            }
        }
        private static void ChoseService()
        {
            int serviceIndex = -1;
            bool reverse = false;
            while (serviceIndex == -1)
            {
                string newLine = Console.ReadLine();
                try
                {
                    serviceIndex = int.Parse(newLine);

                    if (serviceIndex >= AllServices.Count || serviceIndex < 0)
                        serviceIndex = -1;
                }
                catch (Exception ex)
                {
                    if (newLine == "...")
                    {
                        reverse = true;
                        serviceIndex = 0;
                    }
                }
            }

            if (reverse)
            {
                AllDevices = null;
                Ble.GetBLE.KnownDevicesChanged += BleHelper_KnownDevicesChanged;
                ChoseDevice();
            }
            else
            {
                Ble.GetBLE.SelectGATTService(AllServices[serviceIndex]);
                ChoseCharacteristic();
            }
        }
        private static void ChoseCharacteristic()
        {
            int characteristicIndex = -1;
            bool reverse = false;
            while (characteristicIndex == -1)
            {
                string newLine = Console.ReadLine();
                try
                {
                    characteristicIndex = int.Parse(newLine);

                    if(characteristicIndex >= Allcharacteristics.Count || characteristicIndex < 0)
                        characteristicIndex = -1;
                }
                catch(Exception ex)
                {
                    if (newLine == "...")
                    {
                        reverse = true;
                        characteristicIndex = 0;
                    }
                }
            }

            if (reverse)
            {
                BleHelper_ServiceChanged(AllServices);
                ChoseService();
            }
            else
            {
                Ble.GetBLE.SelectGATTCharacteristic(Allcharacteristics[characteristicIndex]);
                ReadWriteNotify();
            }
        }

        private static void ReadWriteNotify()
        {
            string NewLine = Console.ReadLine();

            if (NewLine.Length >= 4 && NewLine.Substring(0, 4).Equals("Read")) // read value
            {
                Ble.GetBLE.ReadValue();
            }
            else if(NewLine.Length >= 5 && NewLine.Substring(0, 5).Equals("Write")) // write Value
            {
                var sl = NewLine.Split('.');
                if (sl[1].Length >= 8 && sl[1].Substring(0, 8).Equals("AsString")) // write as String
                {
                    try
                    {
                        Ble.GetBLE.WriteValueAsUTF(NewLine.Split(':')[1]);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else if (sl[1].Length >= 7 && sl[1].Substring(0, 7).Equals("AsASCII")) // write as ASCII
                {
                    try
                    {
                        Ble.GetBLE.WriteValueAsASCII(NewLine.Split(':')[1]);
                    }
                    catch(Exception ex)
                    {

                    }
                }
            }
            else if(NewLine.Length >= 6 && NewLine.Substring(0, 6).Equals("Notify")) // notify
            {
                try
                {
                    Ble.GetBLE.Notify(bool.Parse(NewLine.Split(':')[1]));
                }
                catch(Exception ex)
                {
                    
                }
            }

            if (NewLine.Length >= 3 && NewLine.Substring(0, 3).Equals("..."))
            {
                BleHelper_CharacteristicsChanged(Allcharacteristics);
                ChoseCharacteristic();
            }
            else
            {
                ReadWriteNotify();
            }
        }

        private static void BleHelper_UserInfo(string userInfo)
        {
            Console.WriteLine($"--> {userInfo}");
        }

        private static List<BluetoothLEDeviceDisplay> AllDevices = null;
        private static void BleHelper_KnownDevicesChanged(List<BluetoothLEDeviceDisplay> knownDevices)
        {
            if (!IsSame(AllDevices, knownDevices))
            {
                Console.WriteLine("_______________________");
                Console.WriteLine("Available Devices:");
                for (int i = 0; i < knownDevices.Count; i++)
                {
                    Console.Write($"{i}: {knownDevices[i].Name}");
                    if (knownDevices[i].Name.Equals(""))
                        Console.WriteLine($"{knownDevices[i].Id.Split('-')[1]}");
                    else
                        Console.WriteLine();
                }
                Console.WriteLine("_______________________");

                AllDevices = new List<BluetoothLEDeviceDisplay>();
                for (int i = 0; i < knownDevices.Count; i++)
                    AllDevices.Add(knownDevices[i]);
            }
        }

        public static bool IsSame(List<BluetoothLEDeviceDisplay> l1, List<BluetoothLEDeviceDisplay> l2)
        {
            if (l1 == null || l2 == null || l1.Count != l2.Count)
                return false;

            for (int i = 0; i < l1.Count; i++)
                if (!l1[i].Name.Equals(l2[i].Name))
                    return false;

            return true;
        }

        private static List<GaTTServices> AllServices;
        private static void BleHelper_ServiceChanged(List<GaTTServices> services)
        {
            Console.WriteLine("_______________________");
            Console.WriteLine("Available Services:");
            for (int i = 0; i < services.Count; i++)
                Console.WriteLine($"{i}: {Ble.GetServiceName(services[i])}");
            Console.WriteLine("_______________________");

            AllServices = services;
        }

        private static List<GaTTCharacteristics> Allcharacteristics;
        private static void BleHelper_CharacteristicsChanged(List<GaTTCharacteristics> characteristics)
        {
            Console.WriteLine("_______________________");
            Console.WriteLine("Available Characteristics:");
            for (int i = 0; i < characteristics.Count; i++)
                Console.WriteLine($"{i}: {Ble.GetCharacteristicName(characteristics[i])}");
            Console.WriteLine("_______________________");

            Allcharacteristics = characteristics;
        }

        private static (bool isRead, bool isWrite, bool isNotify) CharacteristicPropertie;
        private static void BleHelper_CharacteristicProperties(bool isRead, bool isWrite, bool isNotify)
        {
            Console.WriteLine("_______________________");
            Console.WriteLine("Characteristic Properties:");
            Console.WriteLine($"(isRead: {isRead}) (isWrite: {isWrite}) (isNotify: {isNotify})");
            Console.WriteLine("_______________________");

            CharacteristicPropertie.isRead = isRead;
            CharacteristicPropertie.isWrite = isWrite;
            CharacteristicPropertie.isNotify = isNotify;
        }

        private static void BleHelper_CharacteristicValue(byte[] characteristicValue)
        {
            Console.WriteLine("_______________________");
            Console.WriteLine("Characteristic Value:");
            Console.WriteLine(characteristicValue);
            Console.WriteLine("_______________________");
        }
    }
}
