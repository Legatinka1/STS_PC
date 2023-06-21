using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonLib;
using InterfacesLib;

namespace ImplementationLib
{
    public class PlumpDeviceSimulator : ISTSPlumpDevice
    {
        public event Action<PlumpDeviceStatusStruct, double> OnNewData;
        public event Action OnErrorPacket;
        public event Action ConnectedSuccessfully;
        public event Action ConnectionFailed;
        public event Action Disconnected;
        public event Action<Enum_ConnectionLog> ConnectionLog;

        private bool isConnectedToDevice = false;
        private bool shutterIsOpened = false;

        private List<short> lstData = null;

        private PDSimulatorThread _pDThread;
        private Thread _thr;

        public PlumpDeviceSimulator()
        {

        }

        private void SendCommandMessage(byte opcode, byte[] payload)
        {
            if (!isConnectedToDevice)
                return;

            // write to serial(device)
            Debug.WriteLine($"CommandMessage:: opcode:{opcode}, payload:{payload}");
        }

        public void SendStartCommandMessage(int frequency)
        {
            Debug.WriteLine("StartCommandMessage");
            byte opcode = 0;
            byte[] payload = new byte[2];

            payload[0] = (byte)(frequency & 0xFF);
            payload[1] = (byte)((frequency >> 8) & 0xFF);

            SendCommandMessage(opcode, payload);
        }

        private void _pDThread_NewDataSimulated(short[] sample)
        {
            PlumpDeviceStatusStruct p = new PlumpDeviceStatusStruct();
            p.SetSampleFortesting(sample);
            //p.sampleType = PlumpDeviceStatusStruct.ESampleType.EndRecording;
            //p.Sa
            //p.ReceivedTime

            OnNewData?.Invoke(p, 1);
        }

        public void SendStopCommandMessage()
        {
            _thr.Abort();

            return;
            Debug.WriteLine("StopCommandMessage");
            byte opcode = 0;
            byte[] payload = new byte[2];

            payload[0] = 0;
            payload[1] = 0;

            SendCommandMessage(opcode, payload);
        }

        public void ClearSessionSamplesList()
        {
            //Disconnected?.Invoke();
            lstData?.Clear();
        }

        public void SendShutterOpenMessage()
        {
            Debug.WriteLine("Open Shutter");
            shutterIsOpened = true;
        }

        public void SendShutterCloseMessage()
        {
            Debug.WriteLine("Close Shutter");
            shutterIsOpened = false;
        }

        public bool IsShutterOpened()
        {
            return shutterIsOpened;
        }

        public void SendAcquireCommandMessage(int frequency_fast, int duration_fast, int frequency_slow, int duration_slow, int threshold_raw, int threshol_min)
        {
            _thr = new Thread(new ThreadStart(_pDThread.Start));
            _thr.Start();

            return;

            byte opcode = 10;
            byte[] payload = new byte[12];

            payload[0] = (byte)(frequency_fast & 0xFF);
            payload[1] = (byte)((frequency_fast >> 8) & 0xFF);
            payload[2] = (byte)(duration_fast & 0xFF);
            payload[3] = (byte)((duration_fast >> 8) & 0xFF);
            payload[4] = (byte)(frequency_slow & 0xFF);
            payload[5] = (byte)((frequency_slow >> 8) & 0xFF);
            payload[6] = (byte)(duration_slow & 0xFF);
            payload[7] = (byte)((duration_slow >> 8) & 0xFF);
            payload[8] = (byte)(threshold_raw & 0xFF);
            payload[9] = (byte)((threshold_raw >> 8) & 0xFF);
            payload[10] = (byte)(threshol_min & 0xFF);
            payload[11] = (byte)((threshol_min >> 8) & 0xFF);


            lstData = new List<short>();

            SendCommandMessage(opcode, payload);
        }

        public void AddPaientForTesting(Patient p)
        {
            _pDThread.SetPatient(p);
        }

        public bool Init(string comPort)
        {
            _pDThread = new PDSimulatorThread();
            _pDThread.NewDataSimulated += _pDThread_NewDataSimulated;

            ConnectedSuccessfully?.Invoke();

            return true;
        }

        public string GetName()
        {
            return "Sim";
        }

        public Enum_TestCommunication GetCommunicationType()
        {
            return Enum_TestCommunication.Simulated;
        }
    }

    public class PDSimulatorThread
    {
        static Config config = ConfigurationFileManager<Config>.Instance.GetData;

        public event Action<short[]> NewDataSimulated;

        private Patient _currentPatient;

        public void Start()
        {
            // For testing the thread
            DateTime startTime = DateTime.Now, currentTime = DateTime.Now;
            while (((TimeSpan)(currentTime - startTime)).TotalMilliseconds < 01) { currentTime = DateTime.Now; }

            NewDataSimulated?.Invoke(DataTesting());
        }

        private short[] DataTesting()
        {
            string path = "";
            string lastPath = @"trunk\STSFWTestTool";
            //double[] rawData;
            for (int i = 0; i < Environment.CurrentDirectory.Length; i++)
            {
                bool isIt = true;
                if (path.Length >= lastPath.Length)
                {
                    for (int j = lastPath.Length - 1; j >= 0; j--)
                    {
                        if (!lastPath[j].Equals(path[path.Length - (lastPath.Length - j)]))
                            isIt = false;
                    }
                    if (isIt)
                        break;
                }
                path += Environment.CurrentDirectory[i];
            }

            double[] arr = null, time = null;
            List<short> sample = new List<short>();
            try
            {
                if (config.IsLoadingDBFile && _currentPatient != null)
                {
                    var help = ReadFile(config.DBFilePath + @"\Patient-" + _currentPatient.PatientId + ".csv"); //_currentPatient.FullName.Substring(2, _currentPatient.FullName.Length - 2) + ".csv");
                    arr = help.Item1;
                    time = help.Item2;
                }
                else if (path.Length != Environment.CurrentDirectory.Length)
                {
                    var help = ReadFile(path + @"\Common\CommonLib\PressureTest\DefaultPressure.csv");
                    arr = help.Item1;
                    time = help.Item2;
                }

                for (int i = 0; i < arr.Length; i++)
                    sample.Add((short)arr[i]);
            }
            catch (Exception e)
            {
                sample = GetDefault();
            }

            return sample.ToArray();
        }

        private List<short> GetDefault()
        {
            List<short> sample = new List<short>();
            sample.Add(0);sample.Add(1);sample.Add(2);sample.Add(3);sample.Add(4);
            sample.Add(5);sample.Add(6);sample.Add(7);sample.Add(8);sample.Add(9);
            sample.Add(9);sample.Add(10);sample.Add(10);sample.Add(11);sample.Add(10);
            sample.Add(10);sample.Add(9);sample.Add(9);sample.Add(8);sample.Add(7);
            sample.Add(6);sample.Add(5);sample.Add(4);sample.Add(4);sample.Add(3);
            sample.Add(3);sample.Add(4);sample.Add(4);sample.Add(5);sample.Add(6);
            sample.Add(7);sample.Add(7);sample.Add(8);sample.Add(8);sample.Add(7);
            sample.Add(6);sample.Add(5);sample.Add(4);sample.Add(3);sample.Add(2);
            sample.Add(2);sample.Add(2);sample.Add(1);sample.Add(1);sample.Add(1);
            sample.Add(1);sample.Add(0);sample.Add(0);sample.Add(0);sample.Add(0);

            return sample;
        }

        public void SetPatient(Patient patient)
        {
            _currentPatient = patient;
        }

        private static (double[], double[]) ReadFile(string path)
        {
            List<double> arr = new List<double>();
            List<double> time = new List<double>();

            Random rnd = new Random(DateTime.Now.Millisecond);
            double rndNum = rnd.NextDouble() / 5.0 + 0.9;

            using (var reader = new StreamReader(path))
            {
                int lineCounter = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (lineCounter >= 2)
                    {
                        var sl = line.Split(',');
                        if (sl.Length == 1)
                            arr.Add(Double.Parse(sl[0]) * rndNum);
                        else
                        {
                            //arr.Add(1);
                            arr.Add(Double.Parse(sl[5]) * rndNum);
                        }
                    }

                    lineCounter++;
                }
            }

            return (arr.ToArray(), time.ToArray());
        }
    }
}
