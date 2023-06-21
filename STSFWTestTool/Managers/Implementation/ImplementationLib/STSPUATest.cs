using CommonLib;
using InterfacesLib;
using STSFWTestTool;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using MathUtils;
using static CommonLib.PlumpDeviceStatusStruct;

namespace ImplementationLib
{
    public class STSPUATest : ISTSPUATest
    {
        public event Action<bool> PUALoadDone;
        public event Action<bool, PUATestHelper> OneTestDone;
        public event Action<bool, PUATestHelper> FinishCalculatePrediction;
        public event Action<bool, PUATestResult> FinishAllTest;
        public event Action StartTimer;
        public event Action<Enum_ConnectionLog> ConnectionLog;

        private static ISTSPUATest PUATest;
        private static ISTSPlumpDevice _testDevice;

        private bool _isWorking;
            
        private PatientVisit _currentPatientVisit;

        public static ISTSPUATest GetPUATest
        {
            get
            {
                if (PUATest == null)
                    PUATest = new STSPUATest();

                return PUATest;
            }
        }


        private static ISTSPlumpDevice GetPlumpDevice
        {
            get
            {
                if (_testDevice == null || STSManager.GetManager.TestCommunication != _testDevice.GetCommunicationType())
                {
                    if (STSManager.GetManager.TestCommunication == Enum_TestCommunication.Simulated)
                    {
                        Debug.WriteLine("Using Plump Device Simulator");
                        _testDevice = new PlumpDeviceSimulator();
                    }
                    else if(STSManager.GetManager.TestCommunication == Enum_TestCommunication.Serial)
                    {
                        Debug.WriteLine("Using Plump Device Serial");
                        _testDevice = new PlumpDeviceSerial(); 
                    }
                    else if (STSManager.GetManager.TestCommunication == Enum_TestCommunication.BlueTooth)
                    {
                        Debug.WriteLine("Using Plump Device Bluetooth");
                        _testDevice = new PlumpDeviceBlueTooth();
                    }
                }

                return _testDevice;
            }
        }

        public bool Reconnect()
        {
            try
            {
                if (STSManager.GetManager.TestCommunication == Enum_TestCommunication.Serial)
                    GetPlumpDevice.Init($"Com{STSManager.GetManager.ComPort}"); // the com port 
                else if (STSManager.GetManager.TestCommunication == Enum_TestCommunication.BlueTooth)
                    GetPlumpDevice.Init(STSManager.GetManager.BlueToothDevice);
                else
                    GetPlumpDevice.Init("");

                _isWorking = true;

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        private bool _isConnected = false;
        public bool IsConnected => _isConnected;

        public bool Init(PatientVisit currentPatientVisit)
        {
            _currentPatientVisit = currentPatientVisit;
            _currentPatientVisit.Test.Prediction = CalcPrediction(_currentPatientVisit.Patient);

            if (_isConnected && STSManager.GetManager.TestCommunication != Enum_TestCommunication.Simulated)
                return true;

            GetPlumpDevice.ConnectedSuccessfully -= GetPlumpDevice_ConnectedSuccessfully;
            GetPlumpDevice.ConnectionFailed -= GetPlumpDevice_ConnectionFailed;
            GetPlumpDevice.Disconnected -= GetPlumpDevice_Disconnected;
            GetPlumpDevice.OnNewData -= GetPlumpDevice_OnNewData;
            GetPlumpDevice.ConnectionLog -= GetPlumpDevice_ConnectionLog;

            if (currentPatientVisit == null)
            {
                Debug.WriteLine("[STSPUATest] Exception: Init failed- currentPatientVisit cannot be null");
                return false;
            }
            try
            {
                GetPlumpDevice.ConnectedSuccessfully += GetPlumpDevice_ConnectedSuccessfully;
                GetPlumpDevice.ConnectionFailed += GetPlumpDevice_ConnectionFailed;
                GetPlumpDevice.Disconnected += GetPlumpDevice_Disconnected;
                GetPlumpDevice.OnNewData += GetPlumpDevice_OnNewData;
                GetPlumpDevice.ConnectionLog += GetPlumpDevice_ConnectionLog;

                // Init
                Reconnect();

                if (GetPlumpDevice.GetType().IsInstanceOfType(new PlumpDeviceSimulator()))
                {
                    PlumpDeviceSimulator pd = (PlumpDeviceSimulator)GetPlumpDevice;
                    pd.AddPaientForTesting(currentPatientVisit.Patient);
                }
            }
            catch (Exception ee)
            {
                Debug.WriteLine($"[STSPUATest] Exception: Init failed- {ee.Message}");

                _isWorking = false;
            }

            PUALoadDone?.Invoke(_isWorking);

            return _isWorking;
        }

        //private Thread _deviceThread;
        public void StartTest()
        {
            GetPlumpDevice.ClearSessionSamplesList();
            _sampleData.Clear();

            if (!_isConnected)
                return;

            GetPlumpDevice.SendAcquireCommandMessage(STSManager.GetManager.Frequency, 4, STSManager.GetManager.Frequency, 6 - 4, STSManager.GetManager.RawThreshold, STSManager.GetManager.MinThreshold);

            //DeviceThread dt = new DeviceThread();
            //Thread _deviceThread = new Thread(new ThreadStart(dt.Start));
            //_deviceThread.Start();
        }

        public void StopTest()
        {
            _sampleData.Clear();

            OneTestDone?.Invoke(false, null);

            if (!_isConnected)
                return;

            //GetPlumpDevice.OnNewData -= GetPlumpDevice_OnNewData;
            GetPlumpDevice.SendStopCommandMessage();

            //if(_deviceThread != null)
            //    _deviceThread.Abort();
        }

        private void GetPlumpDevice_Disconnected()
        {
            _isConnected = false;
            OneTestDone?.Invoke(false, null);

            Debug.WriteLine("Disconnected");
        }

        private void GetPlumpDevice_ConnectionFailed()
        {
            _isConnected = false;
            OneTestDone?.Invoke(false, null);

            Debug.WriteLine("Connection Failed-t");
        }

        private void GetPlumpDevice_ConnectedSuccessfully()
        {
            _isConnected = true;
            Debug.WriteLine("Connected Successfully");
        }

        private void GetPlumpDevice_ConnectionLog(Enum_ConnectionLog obj)
        {
            ConnectionLog?.Invoke(obj);
        }

        private List<short> _sampleData = new List<short>();
        private ESampleType _lastSample = ESampleType.PreRecording;

        private void GetPlumpDevice_OnNewData(PlumpDeviceStatusStruct obj, double avg)
        {
            for (int i = 0; i < obj.Samples.Length; i++)
                _sampleData.Add(obj.Samples[i]);

            if (_lastSample != obj.SampleType && (_lastSample == ESampleType.PreRecording && obj.SampleType != ESampleType.PreRecordingStart))
                StartTimer?.Invoke();

            _lastSample = obj.SampleType;

            if (obj.SampleType == ESampleType.EndRecording || STSManager.GetManager.TestCommunication == Enum_TestCommunication.Simulated)
            {
                PUATestHelper newTest = new PUATestHelper();
                newTest.RawData = FromShortToDouble(_sampleData.ToArray());

                double[] new_list = new double[newTest.RawData.Length];
                for (int i = 0; i < new_list.Length; i++)
                    new_list[i] = (double)i / STSManager.GetManager.Frequency;

                newTest.Time = new_list;

                _currentPatientVisit.Test.AllTests.Add(newTest);

                //if (config.IsLoadingDBFile)
                //    newTest.StamByLadingData(config.DBFilePath, int.Parse(_currentPatientVisit.Patient.PatientId));

                Debug.WriteLine($"{_currentPatientVisit}");
                Debug.WriteLine($"{_currentPatientVisit.Test.AllTests.Count - 1}");
                Debug.WriteLine($"{GetPlumpDevice.GetName()}");

                STSManager.GetManager.DoCalc(_currentPatientVisit, _currentPatientVisit.Test.AllTests.Count - 1, GetPlumpDevice.GetName());

                OneTestDone?.Invoke(true, newTest);

                _lastSample = ESampleType.PreRecording;
            }
        }

        public PUATestResult GetAllTestResult()
        {
            return _currentPatientVisit.Test;
        }

        public PUATestHelper GetPrediction()
        {
            return _currentPatientVisit.Test.Prediction;
        }

        public static PUATestHelper CalcPrediction(Patient patient)
        {
            PUATestHelper prediction = new PUATestHelper();

            PatientPP pp = new PatientPP();
            try
            {
                pp.Age = new DateTime(DateTime.Now.Subtract(patient.BirthDate).Ticks).Year - 1;
            }
            catch (Exception ex)
            {
                pp.Age = 0;
            }
            if (patient.Weight == 0 || patient.Height == 0)
                return prediction;

            pp.Heigth = patient.HeightAsMetric;
            pp.Weight = patient.WeightAsMetric;
            pp.IsMale = patient.Gender == Enum_Gender.Male;
            pp.Ethnic = patient.Ethnicity ==
                ENUM_Ethnicity.Caucasian ? MathUtils.Ethnicity.Caucasian :
                patient.Ethnicity == ENUM_Ethnicity.African_American ? MathUtils.Ethnicity.African_American :
                patient.Ethnicity == ENUM_Ethnicity.Asian ? MathUtils.Ethnicity.Asian :
                MathUtils.Ethnicity.Caucasian; // default

            
            prediction.FVC = PredictionCalc.CalcFVC(pp);
            prediction.FEV1 = PredictionCalc.CalcFEV1(pp);

            prediction.FEV1_FVC = PredictionCalc.CalcFEV1_FVC(pp);
            prediction.PEF = PredictionCalc.CalcPEF(pp);
            prediction.TLC = PredictionCalc.CalcTLC(pp);
            prediction.RV = PredictionCalc.CalcRV(pp);
            prediction.TGV = PredictionCalc.CalcTGV(pp);
            prediction.RV_TLC = PredictionCalc.CalcRV_TLC(prediction.RV, prediction.TLC);
            prediction.TGV_TLC = PredictionCalc.CalcTGV_TLC(prediction.TGV, prediction.TLC);
            prediction.RAW = PredictionCalc.CalcRAW(pp);
            prediction.CL = PredictionCalc.CalcCL(pp);

            prediction.FEV6 = PredictionCalc.CalcFEV6(pp);
            prediction.VC = prediction.FVC; // what igor told me
            prediction.FEV3 = PredictionCalc.CalcFEV3(pp, prediction.FVC);
            prediction.FEV3_FVC = PredictionCalc.CalcFEV3_FVC(prediction.FEV3, prediction.FVC);
            prediction.FEF25_75 = PredictionCalc.CalcFEF25_75(pp);

            prediction.IVC = PredictionCalc.CalcIVC(pp);
            prediction.PIF = PredictionCalc.CalcPIF(pp);

            return prediction;
        }

        private static double[] FromShortToDouble(short[] s)
        {
            double[] d = new double[s.Length];
            for (int i = 0; i < s.Length; i++)
                d[i] = (double)s[i];

            return d;
        }
    }
}
