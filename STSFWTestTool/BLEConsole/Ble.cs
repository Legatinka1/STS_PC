using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;

namespace BLEConsole
{
    public class Ble
    {
        private static Ble BlueToothHelper;

        public event Action<List<BluetoothLEDeviceDisplay>> KnownDevicesChanged;
        public event Action<List<GaTTServices>> ServiceChanged;
        public event Action<List<GaTTCharacteristics>> CharacteristicsChanged;
        public event Action<bool, bool, bool> CharacteristicProperties;
        public event Action<byte[]> CharacteristicValue;
        public event Action<string> UserInfo;
        public event Action<Status> STSStatus;

        private List<BluetoothLEDeviceDisplay> _knownDevices = new List<BluetoothLEDeviceDisplay>();
        private List<DeviceInformation> _unKnownDevices = new List<DeviceInformation>();

        private IReadOnlyList<GattDeviceService> _serviceList;
        private IReadOnlyList<GattCharacteristic> _characteristicsList;

        private DeviceWatcher _deviceWatcher;

        private (bool read, bool write, bool notify) _characteristicProperties = (false, false, false);


        public static Ble GetBLE
        {
            get
            {
                if (BlueToothHelper == null)
                    BlueToothHelper = new Ble();

                return BlueToothHelper;
            }
        }

        public static void DisconnectBLE()
        {
            GetBLE.Disconnect();

            BlueToothHelper = null;

            GC.Collect();

            GetBLE.StartBleScan();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StartBleScan()
        {
            StartDeviceWatcher();
        }

        public void StopBleScan()
        {
            StopBleDeviceWatcher();
        }

        public void ConnectToDevice(BluetoothLEDeviceDisplay device)
        {
            StartConnectingDevice(device);
        }

        public void SelectGATTService(GaTTServices service)
        {
            for (int i = 0; i < _serviceList.Count; i++)
                if (_serviceList[i].Uuid == service.Uuid)
                {
                    SelectService(_serviceList[i]);
                    break;
                }
        }

        public void SelectGATTCharacteristic(GaTTCharacteristics characteristics)
        {
            for (int i = 0; i < _characteristicsList.Count; i++)
                if (_characteristicsList[i].Uuid == characteristics.Uuid)
                {
                    SelectCharacteristic(_characteristicsList[i]);
                    break;
                }
        }

        public void ReadValue()
        {
            ReadValueFromCharacteristic();
        }

        public void WriteValueAsUTF(string value)
        {

        }

        public void WriteValueAsASCII(string value)
        {

        }

        public void Notify(bool sub)
        {

        }

        public List<BluetoothLEDeviceDisplay> KnownDevices => _knownDevices;
        public List<GaTTServices> Services
        {
            get
            {
                List<GaTTServices> services = new List<GaTTServices>();
                for (int i = 0; i < _serviceList.Count; i++)
                    services.Add(new GaTTServices(_serviceList[i]));

                return services;
            }
        }
        public List<GaTTCharacteristics> Characteristics
        {
            get
            {
                List<GaTTCharacteristics> chacteristics = new List<GaTTCharacteristics>();
                for (int i = 0; i < _characteristicsList.Count; i++)
                    chacteristics.Add(new GaTTCharacteristics(_characteristicsList[i]));

                return chacteristics;
            }
        }

        public bool IsConneceted => _isConnected;

        private void reset()
        {
            _knownDevices = new List<BluetoothLEDeviceDisplay>();
            _unKnownDevices = new List<DeviceInformation>();

            _serviceList = null;
            _characteristicsList = null;

            _deviceWatcher = null;

            _characteristicProperties = (false, false, false);

            //////////////////////////
            _selectedBleDeviceId = null;

            
            _bluetoothLeDevice?.Dispose();
            _bluetoothLeDevice = null;

            _selectedCharacteristic = null;

            _registeredCharacteristic = null;
            _presentationFormat = null;

            _subscribedForNotifications = false;

            _isConnected = false;
        }

        private bool Disconnect()
        {
            reset();

            GC.Collect();

            STSStatus?.Invoke(Status.Disconnected);

            //StartBleScan();

            return true;
        }

        public bool STSConnect(BluetoothLEDeviceDisplay connectDevice)
        {
            Ble.GetBLE.ServiceChanged -= GetBLE_ServiceChanged;
            Ble.GetBLE.ServiceChanged += GetBLE_ServiceChanged;
            StartConnectingDevice(connectDevice);

            return true;
        }

        private void GetBLE_ServiceChanged(List<GaTTServices> obj)
        {
            Ble.GetBLE.ServiceChanged -= GetBLE_ServiceChanged;

            string foundServiceByName = "Nordic_UART_Service";
            for (int i = 0; i < _serviceList.Count; i++)
                if (GetServiceName(new GaTTServices(_serviceList[i])).Equals(foundServiceByName)) {
                    Ble.GetBLE.CharacteristicsChanged -= GetBLE_CharacteristicsChanged;
                    Ble.GetBLE.CharacteristicsChanged += GetBLE_CharacteristicsChanged;
                    Ble.GetBLE.SelectService(_serviceList[i]);

                    return;
                }

            STSStatus?.Invoke(Status.ConnectionFailed);
        }

        private void GetBLE_CharacteristicsChanged(List<GaTTCharacteristics> obj)
        {
            Ble.GetBLE.CharacteristicsChanged -= GetBLE_CharacteristicsChanged;

            string foundcharacteristicByName = "TX_Characteristic";
            for (int i = 0; i < _characteristicsList.Count; i++)
                if (GetCharacteristicName(new GaTTCharacteristics(_characteristicsList[i])).Equals(foundcharacteristicByName))
                {
                    Ble.GetBLE.CharacteristicProperties -= GetBLE_CharacteristicProperties;
                    Ble.GetBLE.CharacteristicProperties += GetBLE_CharacteristicProperties;
                    Ble.GetBLE.SelectCharacteristic(_characteristicsList[i]);

                    return;
                }

            STSStatus?.Invoke(Status.ConnectionFailed);
        }

        private void GetBLE_CharacteristicProperties(bool arg1, bool arg2, bool arg3)
        {
            Ble.GetBLE.CharacteristicProperties -= GetBLE_CharacteristicProperties;
            SetNotify(true);

            STSStatus?.Invoke(Status.ConnectionSucceeded);
        }

        public bool SetNotify(bool isSub)
        {
            if (_subscribedForNotifications != isSub)
                ChangeNotify();

            return true;
        }

        public async void Write(byte[] sendData) 
        {
            if (_characteristicsList == null)
                return;

            if (!_characteristicProperties.write)
            {
                string foundcharacteristicByName = "RX_Characteristic";
                for (int i = 0; i < _characteristicsList.Count; i++)
                    if (GetCharacteristicName(new GaTTCharacteristics(_characteristicsList[i])).Equals(foundcharacteristicByName))
                    {
                        Ble.GetBLE.SelectCharacteristic(_characteristicsList[i]);

                        break;
                    }
            }

            try
            {
                IBuffer buff = sendData.AsBuffer();
                var writeSuccessful = await WriteBufferToSelectedCharacteristicAsync(buff);
                Debug.WriteLine($"writeSuccessful={writeSuccessful}");
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Could not find the device to write");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void StartDeviceWatcher()
        {
            // Additional properties we would like about the device.
            string[] requestedProperties = { "System.Devices.Aep.DeviceAddress", "System.Devices.Aep.IsConnected", "System.Devices.Aep.Bluetooth.Le.IsConnectable" };

            // BT_Code: Example showing paired and non-paired in a single query.
            string aqsAllBluetoothLEDevices = "(System.Devices.Aep.ProtocolId:=\"{bb7bb05e-5972-42b5-94fc-76eaa7084d49}\")";

            _deviceWatcher = DeviceInformation.CreateWatcher(aqsAllBluetoothLEDevices, requestedProperties, DeviceInformationKind.AssociationEndpoint);

            _deviceWatcher.Added += DeviceWatcher_Added;
            _deviceWatcher.Updated += DeviceWatcher_Updated;
            _deviceWatcher.Removed += DeviceWatcher_Removed;
            _deviceWatcher.EnumerationCompleted += DeviceWatcher_EnumerationCompleted;
            _deviceWatcher.Stopped += DeviceWatcher_Stopped;

            // Start over with an empty collection.
            _knownDevices.Clear();

            // Start the watcher. 
            _deviceWatcher.Start();
        }

        private void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation deviceInfo)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            //await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            //{
            lock (this)
            {
                //Debug.WriteLine(String.Format("Added {0}{1}", deviceInfo.Id, deviceInfo.Name));

                // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                if (sender == _deviceWatcher)
                {
                    // Make sure device isn't already present in the list.
                    if (FindBluetoothLEDeviceDisplay(deviceInfo.Id) == null)
                    {
                        if (deviceInfo.Name != string.Empty && deviceInfo.Name.StartsWith("STS"))
                        {
                            // If device has a friendly name display it immediately.
                            _knownDevices.Add(new BluetoothLEDeviceDisplay(deviceInfo));

                            //devices.Items.Add(new BluetoothLEDeviceDisplay(deviceInfo).Name);
                        }
                        else
                        {
                            // Add it to a list in case the name gets updated later. 
                            _unKnownDevices.Add(deviceInfo);
                        }
                    }

                }
            }
            //});
        }

        private void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate deviceInfoUpdate)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            //await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            //{
            lock (this)
            {
                //Debug.WriteLine(String.Format("Updated {0}{1}", deviceInfoUpdate.Id, ""));

                // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                if (sender == _deviceWatcher)
                {
                    BluetoothLEDeviceDisplay bleDeviceDisplay = FindBluetoothLEDeviceDisplay(deviceInfoUpdate.Id);
                    if (bleDeviceDisplay != null)
                    {
                        // Device is already being displayed - update UX.
                        //bleDeviceDisplay.Update(deviceInfoUpdate);
                        return;
                    }

                    DeviceInformation deviceInfo = FindUnknownDevices(deviceInfoUpdate.Id);
                    if (deviceInfo != null)
                    {
                        deviceInfo.Update(deviceInfoUpdate);
                        // If device has been updated with a friendly name it's no longer unknown.
                        if (deviceInfo.Name != String.Empty && deviceInfo.Name.StartsWith("STS"))
                        {
                            _knownDevices.Add(new BluetoothLEDeviceDisplay(deviceInfo));

                            _unKnownDevices.Remove(deviceInfo);
                        }
                    }
                }
            }
            //});
        }

        private void DeviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate deviceInfoUpdate)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            //await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            //{
            lock (this)
            {
                //Debug.WriteLine(String.Format("Removed {0}{1}", deviceInfoUpdate.Id, ""));

                // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                if (sender == _deviceWatcher)
                {
                    // Find the corresponding DeviceInformation in the collection and remove it.
                    BluetoothLEDeviceDisplay bleDeviceDisplay = FindBluetoothLEDeviceDisplay(deviceInfoUpdate.Id);
                    if (bleDeviceDisplay != null)
                    {
                        _knownDevices.Remove(bleDeviceDisplay);

                        if (_bluetoothLeDevice != null && !_bluetoothLeDevice.Name.Equals(bleDeviceDisplay.Name))
                            _knownDevices.Add(bleDeviceDisplay);

                        //devices.Items.Remove(bleDeviceDisplay.Name);
                    }

                    DeviceInformation deviceInfo = FindUnknownDevices(deviceInfoUpdate.Id);
                    if (deviceInfo != null)
                    {
                        _unKnownDevices.Remove(deviceInfo);
                    }
                }
            }
            //});
        }

        private void DeviceWatcher_EnumerationCompleted(DeviceWatcher sender, object e)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            //await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            //{
            // Protect against race condition if the task runs after the app stopped the deviceWatcher.
            if (sender == _deviceWatcher)
            {
                Debug.WriteLine($"{_knownDevices.Count} devices found");
            }
            //});
        }

        private void DeviceWatcher_Stopped(DeviceWatcher sender, object e)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            //await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            //{
            // Protect against race condition if the task runs after the app stopped the deviceWatcher.
            if (sender == _deviceWatcher)
            {
                //rootPage.NotifyUser($"No longer watching for devices.", sender.Status == DeviceWatcherStatus.Aborted ? NotifyType.ErrorMessage : NotifyType.StatusMessage);
                Debug.WriteLine("No longer watching for devices");
            }
            //});
        }

        private void StopBleDeviceWatcher()
        {
            if (_deviceWatcher != null)
            {
                // Unregister the event handlers.
                _deviceWatcher.Added -= DeviceWatcher_Added;
                _deviceWatcher.Updated -= DeviceWatcher_Updated;
                _deviceWatcher.Removed -= DeviceWatcher_Removed;
                _deviceWatcher.EnumerationCompleted -= DeviceWatcher_EnumerationCompleted;
                _deviceWatcher.Stopped -= DeviceWatcher_Stopped;
                
                // Stop the watcher.
                _deviceWatcher.Stop();
                _deviceWatcher = null;
            }
        }

        private BluetoothLEDeviceDisplay FindBluetoothLEDeviceDisplay(string id)
        {
            //Debug.WriteLine(KnownDevices.Count);
            DeleteAdditionalBlueTooth();

            foreach (BluetoothLEDeviceDisplay bleDeviceDisplay in _knownDevices)
            {
                if (bleDeviceDisplay.Id == id)
                {
                    return bleDeviceDisplay;
                }
            }
            return null;
        }

        private DeviceInformation FindUnknownDevices(string id)
        {
            foreach (DeviceInformation bleDeviceInfo in _unKnownDevices)
            {
                if (bleDeviceInfo.Id == id)
                {
                    return bleDeviceInfo;
                }
            }
            return null;
        }

        // delete duplicates(by name)
        private void DeleteAdditionalBlueTooth()
        {
            for (int i = 0; i < _knownDevices.Count; i++)
            {
                for (int j = 0; j < _knownDevices.Count; j++)
                {
                    if (i != j && _knownDevices.ElementAt(i).Name.Equals(_knownDevices.ElementAt(j).Name))
                    {
                        _knownDevices.RemoveAt(j);
                    }
                }
            }

            KnownDevicesChanged?.Invoke(_knownDevices);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string _selectedBleDeviceId;

        readonly int E_DEVICE_NOT_AVAILABLE = unchecked((int)0x800710df); // HRESULT_FROM_WIN32(ERROR_DEVICE_NOT_AVAILABLE)

        private BluetoothLEDevice _bluetoothLeDevice = null;
        private GattCharacteristic _selectedCharacteristic;

        private GattCharacteristic _registeredCharacteristic;
        private GattPresentationFormat _presentationFormat;

        private bool _subscribedForNotifications = false;

        private bool _isConnected = false;

        private async void StartConnectingDevice(BluetoothLEDeviceDisplay connectDevice)
        {
            UserInfo?.Invoke("Connecting....");

            if (!await ClearBluetoothLEDeviceAsync())
            {
                STSStatus?.Invoke(Status.ConnectionFailed);

                UserInfo?.Invoke("Error: Unable to reset state, try again");
                Debug.WriteLine("Error: Unable to reset state, try again");
                return;
            }

            _selectedBleDeviceId = connectDevice.Id;

            try
            {
                // BT_Code: BluetoothLEDevice.FromIdAsync must be called from a UI thread because it may prompt for consent.
                _bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync(_selectedBleDeviceId);

                _bluetoothLeDevice.GattServicesChanged -= _bluetoothLeDevice_GattServicesChanged;
                _bluetoothLeDevice.GattServicesChanged += _bluetoothLeDevice_GattServicesChanged;

                /*var test = await GattSession.FromDeviceIdAsync(_bluetoothLeDevice.BluetoothDeviceId);
                test.MaxPduSizeChanged -= Test_MaxPduSizeChanged;
                test.MaxPduSizeChanged += Test_MaxPduSizeChanged;*/

                //GattSession.MaxPduSize

                //_bluetoothLeDevice.


                if (_bluetoothLeDevice == null)
                {
                    STSStatus?.Invoke(Status.ConnectionFailed);

                    //userInfo.Text = "Failed to connect to device";
                    UserInfo?.Invoke("Failed to connect to device");
                    Debug.WriteLine("Failed to connect to device");
                }
            }
            catch (Exception ex) when (ex.HResult == E_DEVICE_NOT_AVAILABLE)
            {
                STSStatus?.Invoke(Status.ConnectionFailed);

                //userInfo.Text = "Bluetooth radio is not on";
                UserInfo?.Invoke("Bluetooth radio is not on");
                Debug.WriteLine("Bluetooth radio is not on");
            }

            if (_bluetoothLeDevice != null)
            {
                // Note: BluetoothLEDevice.GattServices property will return an empty list for unpaired devices. For all uses we recommend using the GetGattServicesAsync method.
                // BT_Code: GetGattServicesAsync returns a list of all the supported services of the device (even if it's not paired to the system).
                // If the services supported by the device are expected to change during BT usage, subscribe to the GattServicesChanged event.

                var result = await _bluetoothLeDevice.GetGattServicesAsync().AsTask();

                if (result.Status == GattCommunicationStatus.Success)
                {
                    var services = result.Services;
                    //userInfo.Text = String.Format("Found {0} services", services.Count);
                    UserInfo?.Invoke(String.Format("Found {0} services", services.Count));

                    Debug.WriteLine(String.Format("Found {0} services", services.Count));

                    _serviceList = services;

                    _characteristicsList = null;
                    _characteristicProperties = (false, false, false);

                    List<GaTTServices> service = new List<GaTTServices>();
                    for (int i = 0; i < _serviceList.Count; i++)
                        service.Add(new GaTTServices(_serviceList[i]));
                    ServiceChanged?.Invoke(service);

                    _isConnected = true;
                }
                else
                {
                    STSStatus?.Invoke(Status.ConnectionFailed);

                    //userInfo.Text = "Device unreachable";
                    UserInfo?.Invoke("Device unreachable");
                    Debug.WriteLine("Device unreachable");

                    _isConnected = false;
                }
            }
        }

        private void Test_MaxPduSizeChanged(GattSession sender, object args)
        {
            Debug.WriteLine($"!!!Pdu Size: { sender.MaxPduSize}");
        }

        private void _bluetoothLeDevice_GattServicesChanged(BluetoothLEDevice sender, object args)
        {
            if (sender.ConnectionStatus == BluetoothConnectionStatus.Disconnected)
            {
                STSStatus?.Invoke(Status.Disconnected);
                _isConnected = false;
            }
        }

        private async Task<bool> ClearBluetoothLEDeviceAsync()
        {
            if (_subscribedForNotifications)
            {
                // Need to clear the CCCD from the remote device so we stop receiving notifications
                var result = await _registeredCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.None);
                if (result != GattCommunicationStatus.Success)
                {
                    return false;
                }
                else
                {
                    _selectedCharacteristic.ValueChanged -= Characteristic_ValueChanged;
                    _subscribedForNotifications = false;
                }
            }
            _bluetoothLeDevice?.Dispose();
            _bluetoothLeDevice = null;
            return true;
        }

        private void Characteristic_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            // BT_Code: An Indicate or Notify reported that the value has changed.
            // Display the new value with a timestamp.
            var newValue = FormatValueByPresentation(args.CharacteristicValue, _presentationFormat);
            CharacteristicValue?.Invoke(newValue);

            /*var message = $"Value at {DateTime.Now:hh:mm:ss.FFF}: {newValue}";
            //await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => UserInfoString = message);//CharacteristicLatestValue.Text = message); !!!!!!!!!!!!!!!!
            CharacteristicValue?.Invoke(message);*/
        }

        private byte[] FormatValueByPresentation(IBuffer buffer, GattPresentationFormat format)
        {
            // BT_Code: For the purpose of this sample, this function converts only UInt32 and
            // UTF-8 buffers to readable text. It can be extended to support other formats if your app needs them.
            byte[] data;
            CryptographicBuffer.CopyToByteArray(buffer, out data);

            return data;

            /*_registeredCharacteristic = null; // not sure what to do else it only show this way
            if (format != null)
            {
                if (format.FormatType == GattPresentationFormatTypes.UInt32 && data.Length >= 4)
                {
                    return BitConverter.ToInt32(data, 0).ToString();
                }
                else if (format.FormatType == GattPresentationFormatTypes.Utf8)
                {
                    try
                    {
                        return Encoding.UTF8.GetString(data);
                    }
                    catch (ArgumentException)
                    {
                        return "(error: Invalid UTF-8 string)";
                    }
                }
                else
                {
                    // Add support for other format types as needed.
                    return "Unsupported format: " + CryptographicBuffer.EncodeToHexString(buffer);
                }
            }
            else if (data != null && _selectedCharacteristic != null)
            {
                // We don't know what format to use. Let's try some well-known profiles, or default back to UTF-8.
                if (_selectedCharacteristic.Uuid.Equals(GattCharacteristicUuids.HeartRateMeasurement)) /** !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
                {
                    try
                    {
                        return "Heart Rate: " + ParseHeartRateValue(data).ToString();
                    }
                    catch (ArgumentException)
                    {
                        return "Heart Rate: (unable to parse)";
                    }
                }
                else if (_selectedCharacteristic.Uuid.Equals(GattCharacteristicUuids.BatteryLevel))
                {
                    try
                    {
                        // battery level is encoded as a percentage value in the first byte according to
                        // https://www.bluetooth.com/specifications/gatt/viewer?attributeXmlFile=org.bluetooth.characteristic.battery_level.xml
                        return "Battery Level: " + data[0].ToString() + "%";
                    }
                    catch (ArgumentException)
                    {
                        return "Battery Level: (unable to parse)";
                    }
                }
                // This is our custom calc service Result UUID. Format it like an Int
                else if (_selectedCharacteristic.Uuid.Equals(Constants.ResultCharacteristicUuid))
                {
                    return BitConverter.ToInt32(data, 0).ToString();
                }
                // No guarantees on if a characteristic is registered for notifications.
                else if (_registeredCharacteristic != null)
                {
                    // This is our custom calc service Result UUID. Format it like an Int
                    if (_registeredCharacteristic.Uuid.Equals(Constants.ResultCharacteristicUuid))
                    {
                        return BitConverter.ToInt32(data, 0).ToString();
                    }
                }
                else
                {
                    try
                    {
                        return "Unknown format: " + Encoding.UTF8.GetString(data);
                    }
                    catch (ArgumentException)
                    {
                        return "Unknown format";
                    }
                }
            }
            else
            {
                return "Empty data received";
            }
            return "Unknown format";*/
        }

        private static ushort ParseHeartRateValue(byte[] data)
        {
            // Heart Rate profile defined flag values
            const byte heartRateValueFormat = 0x01;

            byte flags = data[0];
            bool isHeartRateValueSizeLong = ((flags & heartRateValueFormat) != 0);

            if (isHeartRateValueSizeLong)
            {
                return BitConverter.ToUInt16(data, 1);
            }
            else
            {
                return data[1];
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////

        private async void SelectService(GattDeviceService service)
        {
            RemoveValueChangedHandler();

            IReadOnlyList<GattCharacteristic> characteristics = null;

            if (service == null)
                return;

            try
            {
                // Ensure we have access to the device.
                var accessStatus = await service.RequestAccessAsync();
                if (accessStatus == DeviceAccessStatus.Allowed)
                {
                    // BT_Code: Get all the child characteristics of a service. Use the cache mode to specify uncached characterstics only 
                    // and the new Async functions to get the characteristics of unpaired devices as well.

                    var result = await service.GetCharacteristicsAsync().AsTask();
                    //Debug.WriteLine(result.Characteristics.Count);

                    if (result.Status == GattCommunicationStatus.Success)
                    {
                        Debug.WriteLine("Succussfully accessing service");
                        characteristics = result.Characteristics;
                    }
                    else
                    {
                        STSStatus?.Invoke(Status.ConnectionFailed);

                        Debug.WriteLine("Error accessing service");
                        //userInfo.Text = "Error accessing service";
                        UserInfo?.Invoke("Error accessing service");
                        // On error, act as if there are no characteristics.
                        characteristics = new List<GattCharacteristic>();
                    }
                }
                else
                {
                    STSStatus?.Invoke(Status.ConnectionFailed);

                    // Not granted access
                    Debug.WriteLine("Error accessing service");
                    //userInfo.Text = "Error accessing service";
                    UserInfo?.Invoke("Error accesing service");

                    // On error, act as if there are no characteristics.
                    characteristics = new List<GattCharacteristic>();

                }
            }
            catch (Exception ex)
            {
                STSStatus?.Invoke(Status.ConnectionFailed);

                // On error, act as if there are no characteristics.
                Debug.WriteLine($"Restricted service. Can't read characteristics: {ex.Message}");
                //userInfo.Text = "Error accessing service";
                UserInfo?.Invoke($"Restricted service. Can't read characteristics: {ex.Message}");
                characteristics = new List<GattCharacteristic>();
            }

            _characteristicsList = characteristics;
            _characteristicProperties = (false, false, false);

            List<GaTTCharacteristics> charact = new List<GaTTCharacteristics>();
            for (int i = 0; i < _characteristicsList.Count; i++)
                charact.Add(new GaTTCharacteristics(_characteristicsList[i]));

            CharacteristicsChanged?.Invoke(charact);
        }

        public static string GetServiceName(GaTTServices service)
        {
            if (IsSigDefinedUuid(service.Uuid))
            {
                GattNativeServiceUuid serviceName;
                if (Enum.TryParse(ConvertUuidToShortId(service.Uuid).ToString(), out serviceName))
                {
                    return serviceName.ToString();
                }
            }

            return "Custom Service: " + service.Uuid;
        }

        private static bool IsSigDefinedUuid(Guid uuid)
        {
            return true;

            var bluetoothBaseUuid = new Guid("00000000-0000-1000-8000-00805F9B34FB");

            var bytes = uuid.ToByteArray();
            // Zero out the first and second bytes
            // Note how each byte gets flipped in a section - 1234 becomes 34 12
            // Example Guid: 35918bc9-1234-40ea-9779-889d79b753f0
            //                   ^^^^
            // bytes output = C9 8B 91 35 34 12 EA 40 97 79 88 9D 79 B7 53 F0
            //                ^^ ^^
            bytes[0] = 0;
            bytes[1] = 0;
            var baseUuid = new Guid(bytes);
            return baseUuid == bluetoothBaseUuid;
        }

        private static ushort ConvertUuidToShortId(Guid uuid)
        {
            // Get the short Uuid
            var bytes = uuid.ToByteArray();
            var shortUuid = (ushort)(bytes[0] | (bytes[1] << 8));
            return shortUuid;
        }

        private enum GattNativeServiceUuid : ushort
        {
            None = 0,

            // Avi
            Nordic_UART_Service = 0x01,
            Avi = 0x69,
            
            AlertNotification = 0x1811,
            Battery = 0x180F,
            BloodPressure = 0x1810,
            CurrentTimeService = 0x1805,
            CyclingSpeedandCadence = 0x1816,
            DeviceInformation = 0x180A,
            GenericAccess = 0x1800,
            GenericAttribute = 0x1801,
            Glucose = 0x1808,
            HealthThermometer = 0x1809,
            HeartRate = 0x180D,
            HumanInterfaceDevice = 0x1812,
            ImmediateAlert = 0x1802,
            LinkLoss = 0x1803,
            NextDSTChange = 0x1807,
            PhoneAlertStatus = 0x180E,
            ReferenceTimeUpdateService = 0x1806,
            RunningSpeedandCadence = 0x1814,
            ScanParameters = 0x1813,
            TxPower = 0x1804,
            SimpleKeyService = 0xFFE0
        }

        ////////////////////////

        private async void SelectCharacteristic(GattCharacteristic characteristic)
        {
            _selectedCharacteristic = characteristic;
            if (_selectedCharacteristic == null)
            {
                EnableCharacteristicPanels(GattCharacteristicProperties.None);

                STSStatus?.Invoke(Status.ConnectionFailed);

                Debug.WriteLine("No characteristic selected");
                //userInfo.Text = "No characteristic selected";
                UserInfo?.Invoke("No characteristic selected");

                return;
            }

            // Get all the child descriptors of a characteristics. Use the cache mode to specify uncached descriptors only 
            // and the new Async functions to get the descriptors of unpaired devices as well. 
            try
            {
                var result = await characteristic.GetDescriptorsAsync().AsTask();
                if (result.Status != GattCommunicationStatus.Success)
                {
                    STSStatus?.Invoke(Status.ConnectionFailed);

                    Debug.WriteLine($"Descriptor read failure: {result.Status.ToString()}");
                    //userInfo.Text = $"Descriptor read failure: { result.Status.ToString()}";
                    UserInfo?.Invoke($"Descriptor read failure: { result.Status.ToString()}");
                }
            }
            catch (Exception ex)
            {
                STSStatus?.Invoke(Status.ConnectionFailed);

                Debug.WriteLine($"Error while connecting to characteristic: {ex.Message}");
            }

            // becuase of the await
            if (_selectedCharacteristic == null)
            {
                EnableCharacteristicPanels(GattCharacteristicProperties.None);

                STSStatus?.Invoke(Status.ConnectionFailed);

                Debug.WriteLine("No characteristic selected");
                //userInfo.Text = "No characteristic selected";
                UserInfo?.Invoke("No characteristic selected");

                return;
            }

            // BT_Code: There's no need to access presentation format unless there's at least one. 
            _presentationFormat = null;
            if (_selectedCharacteristic.PresentationFormats.Count > 0)
            {

                if (_selectedCharacteristic.PresentationFormats.Count.Equals(1))
                {
                    // Get the presentation format since there's only one way of presenting it
                    _presentationFormat = _selectedCharacteristic.PresentationFormats[0];
                }
                else
                {
                    // It's difficult to figure out how to split up a characteristic and encode its different parts properly.
                    // In this case, we'll just encode the whole thing to a string to make it easy to print out.
                }
            }

            // Enable/disable operations based on the GattCharacteristicProperties.
            Debug.WriteLine("successfully accessing characteristic");
            EnableCharacteristicPanels(_selectedCharacteristic.CharacteristicProperties);
        }

        private void EnableCharacteristicPanels(GattCharacteristicProperties properties)
        {
            // BT_Code: Hide the controls which do not apply to this characteristic.
            bool IsRead = properties.HasFlag(GattCharacteristicProperties.Read);
            bool IsWrite = properties.HasFlag(GattCharacteristicProperties.Write);
            bool IsNotify = properties.HasFlag(GattCharacteristicProperties.Notify) || properties.HasFlag(GattCharacteristicProperties.Indicate);

            _characteristicProperties = (IsRead, IsWrite, IsNotify);

            CharacteristicProperties?.Invoke(IsRead, IsWrite, IsNotify);
        }

        public static string GetCharacteristicName(GaTTCharacteristics characteristic)
        {
            if (IsSigDefinedUuid(characteristic.Uuid))
            {
                GattNativeCharacteristicUuid characteristicName;
                if (Enum.TryParse(ConvertUuidToShortId(characteristic.Uuid).ToString(),
                    out characteristicName))
                {
                    return characteristicName.ToString();
                }
            }

            if (!string.IsNullOrEmpty(characteristic.UserDescription))
            {
                return characteristic.UserDescription;
            }

            else
            {
                return "Custom Characteristic: " + characteristic.Uuid;
            }
        }

        private enum GattNativeCharacteristicUuid : ushort
        {
            None = 0,

            // Avi:
            RX_Characteristic = 0x02,
            TX_Characteristic = 0x03,
            TheKing = 0x70,
            
            AlertCategoryID = 0x2A43,
            AlertCategoryIDBitMask = 0x2A42,
            AlertLevel = 0x2A06,
            AlertNotificationControlPoint = 0x2A44,
            AlertStatus = 0x2A3F,
            Appearance = 0x2A01,
            BatteryLevel = 0x2A19,
            BloodPressureFeature = 0x2A49,
            BloodPressureMeasurement = 0x2A35,
            BodySensorLocation = 0x2A38,
            BootKeyboardInputReport = 0x2A22,
            BootKeyboardOutputReport = 0x2A32,
            BootMouseInputReport = 0x2A33,
            CSCFeature = 0x2A5C,
            CSCMeasurement = 0x2A5B,
            CurrentTime = 0x2A2B,
            DateTime = 0x2A08,
            DayDateTime = 0x2A0A,
            DayofWeek = 0x2A09,
            DeviceName = 0x2A00,
            DSTOffset = 0x2A0D,
            ExactTime256 = 0x2A0C,
            FirmwareRevisionString = 0x2A26,
            GlucoseFeature = 0x2A51,
            GlucoseMeasurement = 0x2A18,
            GlucoseMeasurementContext = 0x2A34,
            HardwareRevisionString = 0x2A27,
            HeartRateControlPoint = 0x2A39,
            HeartRateMeasurement = 0x2A37,
            HIDControlPoint = 0x2A4C,
            HIDInformation = 0x2A4A,
            IEEE11073_20601RegulatoryCertificationDataList = 0x2A2A,
            IntermediateCuffPressure = 0x2A36,
            IntermediateTemperature = 0x2A1E,
            LocalTimeInformation = 0x2A0F,
            ManufacturerNameString = 0x2A29,
            MeasurementInterval = 0x2A21,
            ModelNumberString = 0x2A24,
            NewAlert = 0x2A46,
            PeripheralPreferredConnectionParameters = 0x2A04,
            PeripheralPrivacyFlag = 0x2A02,
            PnPID = 0x2A50,
            ProtocolMode = 0x2A4E,
            ReconnectionAddress = 0x2A03,
            RecordAccessControlPoint = 0x2A52,
            ReferenceTimeInformation = 0x2A14,
            Report = 0x2A4D,
            ReportMap = 0x2A4B,
            RingerControlPoint = 0x2A40,
            RingerSetting = 0x2A41,
            RSCFeature = 0x2A54,
            RSCMeasurement = 0x2A53,
            SCControlPoint = 0x2A55,
            ScanIntervalWindow = 0x2A4F,
            ScanRefresh = 0x2A31,
            SensorLocation = 0x2A5D,
            SerialNumberString = 0x2A25,
            ServiceChanged = 0x2A05,
            SoftwareRevisionString = 0x2A28,
            SupportedNewAlertCategory = 0x2A47,
            SupportedUnreadAlertCategory = 0x2A48,
            SystemID = 0x2A23,
            TemperatureMeasurement = 0x2A1C,
            TemperatureType = 0x2A1D,
            TimeAccuracy = 0x2A12,
            TimeSource = 0x2A13,
            TimeUpdateControlPoint = 0x2A16,
            TimeUpdateState = 0x2A17,
            TimewithDST = 0x2A11,
            TimeZone = 0x2A0E,
            TxPowerLevel = 0x2A07,
            UnreadAlertStatus = 0x2A45,
            AggregateInput = 0x2A5A,
            AnalogInput = 0x2A58,
            AnalogOutput = 0x2A59,
            CyclingPowerControlPoint = 0x2A66,
            CyclingPowerFeature = 0x2A65,
            CyclingPowerMeasurement = 0x2A63,
            CyclingPowerVector = 0x2A64,
            DigitalInput = 0x2A56,
            DigitalOutput = 0x2A57,
            ExactTime100 = 0x2A0B,
            LNControlPoint = 0x2A6B,
            LNFeature = 0x2A6A,
            LocationandSpeed = 0x2A67,
            Navigation = 0x2A68,
            NetworkAvailability = 0x2A3E,
            PositionQuality = 0x2A69,
            ScientificTemperatureinCelsius = 0x2A3C,
            SecondaryTimeZone = 0x2A10,
            String = 0x2A3D,
            TemperatureinCelsius = 0x2A1F,
            TemperatureinFahrenheit = 0x2A20,
            TimeBroadcast = 0x2A15,
            BatteryLevelState = 0x2A1B,
            BatteryPowerState = 0x2A1A,
            PulseOximetryContinuousMeasurement = 0x2A5F,
            PulseOximetryControlPoint = 0x2A62,
            PulseOximetryFeatures = 0x2A61,
            PulseOximetryPulsatileEvent = 0x2A60,
            SimpleKeyState = 0xFFE1
        }

        /////////////////////

        readonly int E_BLUETOOTH_ATT_WRITE_NOT_PERMITTED = unchecked((int)0x80650003);
        readonly int E_BLUETOOTH_ATT_INVALID_PDU = unchecked((int)0x80650004);
        readonly int E_ACCESSDENIED = unchecked((int)0x80070005);

        private async void ReadValueFromCharacteristic()
        {
            // BT_Code: Read the actual value from the device by using Uncached.
            /*var result = await _selectedCharacteristic.ReadValueAsync().AsTask();
            if (result.Status == GattCommunicationStatus.Success)
            {
                string formattedResult = FormatValueByPresentation(result.Value, _presentationFormat);
                //userInfo.Text = $"Read result: {formattedResult}";
                CharacteristicValue?.Invoke(formattedResult);
            }
            else
            {
                //userInfo.Text = $"Read failed: {result.Status}";
                UserInfo?.Invoke($"Read failed: {result.Status}");
            }*/
        }

        private async void WriteCharacteristicValueAsASCII(string ValueText)
        {
            if (!String.IsNullOrEmpty(ValueText))
            {
                var isValidValue = Int32.TryParse(ValueText, out int readValue);
                if (isValidValue)
                {
                    var writer = new DataWriter();
                    writer.ByteOrder = ByteOrder.LittleEndian;
                    writer.WriteInt32(readValue);

                    try
                    {
                        var writeSuccessful = await WriteBufferToSelectedCharacteristicAsync(writer.DetachBuffer());
                        Debug.WriteLine($"writeSuccessful={writeSuccessful}");

                    }
                    catch (Exception ex)
                    {
                        STSStatus?.Invoke(Status.ConnectionFailed);

                        Debug.WriteLine($"Error while writing to characteristics: {ex.Message}");
                        UserInfo?.Invoke($"Error while writing to characteristics: {ex.Message}");
                    }
                }
                else
                {
                    STSStatus?.Invoke(Status.ConnectionFailed);

                    //userInfo.Text = "Data to write has to be an int32";
                    UserInfo?.Invoke("Data to write has to be an int32");
                }
            }
            else
            {
                STSStatus?.Invoke(Status.ConnectionFailed);

                //userInfo.Text = "No data to write to device";
                UserInfo?.Invoke("No data to write to device");
            }
        }

        private async void WriteCharacteristicValueAsUTF(string ValueText)
        {
            if (!String.IsNullOrEmpty(ValueText))
            {
                var writeBuffer = CryptographicBuffer.ConvertStringToBinary(ValueText, BinaryStringEncoding.Utf8);

                try
                {
                    var writeSuccessful = await WriteBufferToSelectedCharacteristicAsync(writeBuffer);
                    Debug.WriteLine($"writeSuccessful={writeSuccessful}");
                }
                catch (Exception ex)
                {
                    STSStatus?.Invoke(Status.ConnectionFailed);

                    Debug.WriteLine($"Error while writing to characteristics: {ex.Message}");
                    UserInfo?.Invoke($"Error while writing to characteristics: {ex.Message}");
                }
            }
            else
            {
                STSStatus?.Invoke(Status.ConnectionFailed);

                //userInfo.Text = "No data to write to device";
                UserInfo?.Invoke("No data to write to device");
            }
        }

        private async void ChangeNotify()
        {
            if (!_subscribedForNotifications)
            {
                // initialize status
                //GattCommunicationStatus status = GattCommunicationStatus.Unreachable;
                var cccdValue = GattClientCharacteristicConfigurationDescriptorValue.None;
                if (_selectedCharacteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Indicate))
                {
                    cccdValue = GattClientCharacteristicConfigurationDescriptorValue.Indicate;
                }

                else if (_selectedCharacteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Notify))
                {
                    cccdValue = GattClientCharacteristicConfigurationDescriptorValue.Notify;
                }

                try
                {
                    // BT_Code: Must write the CCCD in order for server to send indications.
                    // We receive them in the ValueChanged event handler.

                    var status = await _selectedCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(cccdValue);
                    //GattClientCharacteristicConfigurationDescriptorValue.Notify);
                    if (status == GattCommunicationStatus.Success)
                    {
                        AddValueChangedHandler();
                        //userInfo.Text = "Successfully subscribed for value changes";
                        Debug.WriteLine("Successfully subscribed for value changes");
                        UserInfo?.Invoke("Successfully subscribed for value changes");
                    }
                    else
                    {
                        STSStatus?.Invoke(Status.ConnectionFailed);

                        Debug.WriteLine($"Error registering for value changes: {status}");
                        //userInfo.Text = $"Error registering for value changes: {status}";
                        UserInfo?.Invoke($"Error registering for value changes: {status}");
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    // This usually happens when a device reports that it support indicate, but it actually doesn't.
                    //userInfo.Text = $"{ex.Message}";
                    UserInfo?.Invoke($"{ex.Message}");
                }
            }
            else
            {
                try
                {
                    // BT_Code: Must write the CCCD in order for server to send notifications.
                    // We receive them in the ValueChanged event handler.
                    // Note that this sample configures either Indicate or Notify, but not both.
                    var result = await _selectedCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.None);
                    if (result == GattCommunicationStatus.Success)
                    {
                        //subscribedForNotifications = false;
                        RemoveValueChangedHandler();
                        //userInfo.Text = "Successfully un-registered for notifications";
                        Debug.WriteLine("Successfully un-registered for value changes");
                        UserInfo?.Invoke("Successfully un-registered for notifications");
                    }
                    else
                    {
                        STSStatus?.Invoke(Status.ConnectionFailed);

                        //userInfo.Text = $"Error un-registering for notifications: {result}";
                        Debug.WriteLine($"Error un-registering for notifications: {result}");
                        UserInfo?.Invoke($"Error un-registering for notifications: {result}");
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    // This usually happens when a device reports that it support notify, but it actually doesn't.
                    //userInfo.Text = $"{ex.Message}";
                    UserInfo?.Invoke($"{ex.Message}");
                }
            }
        }

        private async Task<bool> WriteBufferToSelectedCharacteristicAsync(IBuffer buffer)
        {
            try
            {
                var result = await _selectedCharacteristic.WriteValueAsync(buffer);
                if (result == GattCommunicationStatus.Success)
                {
                    //userInfo.Text = "Successfully wrote value to device";
                    UserInfo?.Invoke("Successfully wrote value to device");
                    return true;
                }
                else
                {
                    STSStatus?.Invoke(Status.ConnectionFailed);

                    //userInfo.Text = $"Write failed: {result.Status}";
                    UserInfo?.Invoke($"Write failed: {result}");
                    return false;
                }
            }
            catch (Exception ex) when (ex.HResult == E_BLUETOOTH_ATT_INVALID_PDU)
            {
                //userInfo.Text = $"{ex.Message}";
                UserInfo?.Invoke($"{ex.Message}");
                return false;
            }
            catch (Exception ex) when (ex.HResult == E_BLUETOOTH_ATT_WRITE_NOT_PERMITTED || ex.HResult == E_ACCESSDENIED)
            {
                // This usually happens when a device reports that it support writing, but it actually doesn't.
                //userInfo.Text = $"{ex.Message}";
                UserInfo?.Invoke($"{ex.Message}");
                return false;
            }
        }

        private void AddValueChangedHandler()
        {
            if (!_subscribedForNotifications)
            {
                _registeredCharacteristic = _selectedCharacteristic;
                _registeredCharacteristic.ValueChanged += Characteristic_ValueChanged;
            }
        }

        private void RemoveValueChangedHandler()
        {
            if (_subscribedForNotifications)
            {
                if (_registeredCharacteristic != null)
                    _registeredCharacteristic.ValueChanged -= Characteristic_ValueChanged;
                _registeredCharacteristic = null;
            }
        }
    }

    public class BluetoothLEDeviceDisplay
    {
        public BluetoothLEDeviceDisplay()
        {
        }

        public BluetoothLEDeviceDisplay(DeviceInformation deviceInfoIn)
        {
            DeviceInformation = deviceInfoIn;
        }

        public DeviceInformation DeviceInformation { get; private set; }

        public string Id => DeviceInformation?.Id;
        public string Name
        {
            get
            {
                return DeviceInformation?.Name;
            }
        }
    }

    public class GaTTServices
    {
        public GaTTServices(GattDeviceService gatt)
        {
            Service = gatt;
        }

        public GattDeviceService Service { get; private set; }

        public string Id => Service.DeviceId;

        public Guid Uuid => Service.Uuid;
    }

    public class GaTTCharacteristics
    {
        public GaTTCharacteristics(GattCharacteristic gatt)
        {
            Characteristics = gatt;
        }

        public GattCharacteristic Characteristics { get; private set; }

        public string UserDescription => Characteristics.UserDescription;

        public Guid Uuid => Characteristics.Uuid;
    }

    public class Constants
    {
        // BT_Code: Initializes custom local parameters w/ properties, protection levels as well as common descriptors like User Description. 
        public static readonly GattLocalCharacteristicParameters gattOperandParameters = new GattLocalCharacteristicParameters
        {
            CharacteristicProperties = GattCharacteristicProperties.Write |
                                       GattCharacteristicProperties.WriteWithoutResponse,
            WriteProtectionLevel = GattProtectionLevel.Plain,
            UserDescription = "Operand Characteristic"
        };

        public static readonly GattLocalCharacteristicParameters gattOperatorParameters = new GattLocalCharacteristicParameters
        {
            CharacteristicProperties = GattCharacteristicProperties.Write |
                                       GattCharacteristicProperties.WriteWithoutResponse,
            WriteProtectionLevel = GattProtectionLevel.Plain,
            UserDescription = "Operator Characteristic"
        };

        public static readonly GattLocalCharacteristicParameters gattResultParameters = new GattLocalCharacteristicParameters
        {
            CharacteristicProperties = GattCharacteristicProperties.Read |
                                       GattCharacteristicProperties.Notify,
            WriteProtectionLevel = GattProtectionLevel.Plain,
            UserDescription = "Result Characteristic"
        };

        public static readonly Guid CalcServiceUuid = Guid.Parse("caecface-e1d9-11e6-bf01-fe55135034f0");

        public static readonly Guid Op1CharacteristicUuid = Guid.Parse("caec2ebc-e1d9-11e6-bf01-fe55135034f1");
        public static readonly Guid Op2CharacteristicUuid = Guid.Parse("caec2ebc-e1d9-11e6-bf01-fe55135034f2");
        public static readonly Guid OperatorCharacteristicUuid = Guid.Parse("caec2ebc-e1d9-11e6-bf01-fe55135034f3");
        public static readonly Guid ResultCharacteristicUuid = Guid.Parse("caec2ebc-e1d9-11e6-bf01-fe55135034f4");
    };

    public enum Status
    {
        ConnectionFailed,
        ConnectionSucceeded,
        Disconnected
    }
}
