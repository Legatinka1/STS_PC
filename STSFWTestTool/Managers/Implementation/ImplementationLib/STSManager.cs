using BLEConsole;
using CommonLib;
using DBWrapper;
using DBWrapper.DataModel;
using Globals;
using InterfacesLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImplementationLib
{
    public class STSManager : ISTSManager
    {
        #region Private Members
        static Config config = ConfigurationFileManager<Config>.Instance.GetData;

        private static ISTSDBWrapper DBWrapper = null;
        private static ISTSManager stsManager = null;
        private static ISTSPUATest PUATest = null;
        private static MonthlyTest monthly = null;

        private bool isDatabaseLoaded = false;
        private bool isPUATestLoaded = false;

        private static ISTSDBWrapper GetDatabaseWrapper
        {
            get
            {
                return STSDBWrapper.GetDBWrapper;
            }
        }

        private static ISTSPUATest GetPUATest
        {
            get
            {
                return STSPUATest.GetPUATest;
            }
        }

        #endregion

        #region Constructor

        private STSManager()
        {


        }

        public static ISTSManager GetManager
        {
            get
            {
                if (stsManager == null)
                    stsManager = new STSManager();

                return stsManager;
            }
        }

        #endregion

        # region ISTSManager Impl. 

        #region Events

        public event Action<bool> DatabaseLoadDone;
        public event Action<PatientVisit> SavePatientVisitCardStart;
        public event Action<PatientVisit, bool> SavePatientVisitCardFinish;

        public event Action<bool, PUATestResult> TestDone;
        public event Action StartTestTimer;

        public event Action PrintStart;
        public event Action<bool> PrintDone;

        public event Action<Bitmap> NewVideoFrame;
        public event Action<bool> VideoStart;
        public event Action<bool> VideoEnd;
        public event Action<Enum_ConnectionLog> ConnectionLog;

        #endregion

        #region Properties

        #region DB Properties

        private PatientVisit currentVisit;
        public PatientVisit CurrentPatientVisit
        {
            get
            {
                if (currentVisit == null && AllVisits.Count != 0)
                    currentVisit = AllVisits[0];

                return currentVisit;
            }
        }

        private DoctorCard currentDoctor;
        public DoctorCard CurrentDoctorCard
        {
            get
            {
                //if (currentDoctor == null)
                //    currentDoctor = AllDoctorCard[0];

                return currentDoctor;
            }
        }

        public bool IsDatabaseLoaded
        {
            get { return isDatabaseLoaded; }
        }

        public List<DoctorCard> AllDoctorCard
        {
            get
            {
                if (!IsDatabaseLoaded)
                    return null;

                List<DoctorCard> dl = new List<DoctorCard>();
                for (int i = 0; i < DBWrapper.AllDoctorCard.Count; i++)
                    dl.Add(new DoctorCard(DBWrapper.AllDoctorCard[i]));

                return dl;
            }
        }

        public List<PatientVisit> AllVisits
        {
            get
            {
                if (!IsDatabaseLoaded)
                    return null;

                List<PatientVisit> vl = new List<PatientVisit>();
                for (int i = 0; i < DBWrapper.AllVisits.Count; i++)
                    vl.Add(new PatientVisit(DBWrapper.AllVisits[i]));

                return vl;
            }
        }

        public List<Patient> AllPatients
        {
            get
            {
                if (!IsDatabaseLoaded)
                    return null; 

                List<Patient> pl = new List<Patient>();
                for (int i = 0; i < DBWrapper.AllPatients.Count; i++)
                    pl.Add(new Patient(DBWrapper.AllPatients[i])); 

                return pl;

                /*for (int i = 0; i < pl.Count; i++)
                    pl[i].Visited.Clear();

                foreach(PatientVisit pv in AllVisits)
                {
                    for (int i = 0; i < pl.Count; i++)
                        if (pv.Patient.PatientId.Equals(pl[i].PatientId))
                            pl[i].Visited.Add(pv);
                }

                for (int i = 0; i < pl.Count; i++)
                    pl[i].Visited.OrderBy(o => o.VisitDateTime).Reverse().ToList();*/
            }
        }

        public List<PUATestHelper> AllTests => throw new NotImplementedException();

        public MonthlyTest MonthlyTests
        {
            get
            {
                if (monthly == null)
                    monthly = new MonthlyTest(40, 50, 30); // for now

                return monthly;
            }
        }

        public int Frequency 
        {
            get
            {
                return config.Frequency;
            }
            set
            {
                config.Frequency = value;
            }
        }

        public Enum_TestCommunication TestCommunication
        {
            get
            {
                return config.TestCommunication;
            }
            set
            {
                if(config.TestCommunication != value)
                {
                    if(value == Enum_TestCommunication.BlueTooth)
                        Ble.GetBLE.StartBleScan();
                    else if(config.TestCommunication == Enum_TestCommunication.BlueTooth)
                        Ble.GetBLE.StopBleScan();
                }

                config.TestCommunication = value;
            }
        }

        public int RawThreshold 
        { 
            get
            {
                return config.RawThreshold;
            }
            set
            {
                config.RawThreshold = value;
            }
        }

        public int MinThreshold 
        { 
            get
            {
                return config.MinThreshold;
            }
            set
            {
                config.MinThreshold = value;
            }
        }

        #endregion

        #endregion

        #region Functions

        #region DB Functions

        public double GetBMI(Patient p)
        {
            if (p.Weight == 0 || p.Height == 0)
                return 0;

            double baseBMI = p.Weight / Math.Pow(p.Height / 100, 2);
            return p.UnitSystem == Enum_Unit_System.Metric ? baseBMI : baseBMI * (703.0 / 10000.0);
        }

        public bool AddDoctorcard(DoctorCard doctor)
        {
            return DBWrapper.AddDoctorCard(doctor);
        }

        public string AddPatient(Patient patient)
        {
            return DBWrapper.AddPatient(patient);
        }

        public bool AddVisit(PatientVisit visit)
        {
            return DBWrapper.AddVisit(visit);
        }

        public Patient GetPatient(string patientId)
        {
            return DBWrapper.GetPatient(patientId);
        }

        /*private PatientVisit GetLastVisit(string patientId)
        {
            List<PatientVisit> allVisits = DBWrapper.AllVisits;
            allVisits = allVisits.OrderBy(o => o.VisitDateTime).ToList();
            allVisits.Reverse();

            foreach (PatientVisit pv in allVisits)
            {
                if (pv.Patient.PatientId.Equals(patientId))
                    return pv;
            }

            return null;
        }*/

        public DoctorCard GetDoctor(string PatientId)
        {
            List<PatientVisit> allVisits = AllVisits;
            allVisits = allVisits.OrderBy(o => o.VisitDateTime).ToList();
            allVisits.Reverse();

            foreach (PatientVisit pv in allVisits)
            {
                if (pv.Patient.PatientId.Equals(PatientId))
                    return pv.Doctor;
            }

            return null;
        }

        public bool SaveDoctorCard(DoctorCard doctor, string oldUserName, bool isNew)
        {
            if (isNew)
                return DBWrapper.AddDoctorCard(doctor);

            return DBWrapper.UpdateDoctorCard(doctor, oldUserName);
        }

        public bool SavePatientVisitCard(PatientVisit visit, bool isNew)
        {
            if (isNew)
                return DBWrapper.AddVisit(visit);

            return DBWrapper.UpdateVisit(visit);
        }

        public string SavePatient(Patient patient, string oldPatientID, bool isNew)
        {
            if (isNew)
            {
                for (int i = 0; i < DBWrapper.AllPatients.Count; i++)
                    if (DBWrapper.AllPatients[i].PatientId.Equals(oldPatientID))
                        return "ID number already in use";
                return DBWrapper.AddPatient(patient);
            }

            for (int i = 0; i < DBWrapper.AllPatients.Count; i++)
                if (oldPatientID.Equals(DBWrapper.AllPatients[i].PatientId) && DBWrapper.AllPatients[i].Gender != patient.Gender) // change Gender
                {
                    if (patient.Gender == Enum_Gender.Male)
                        patient.PatientPicture = PictureHelper.GetDefaultPicture();
                    else
                        patient.PatientPicture = PictureHelper.getFemalePicture();
                }

            if (oldPatientID != patient.PatientId)
                for (int i = 0; i < DBWrapper.AllPatients.Count; i++)
                    if (DBWrapper.AllPatients[i].PatientId.Equals(patient.PatientId))
                    {
                        Debug.WriteLine("Can't change Id to an already axisting Id");
                        return "ID number already in use";
                    }

            return DBWrapper.UpdatePatient(patient, oldPatientID)? null : "Error";
        }

        public bool DeleteDoctor(DoctorCard doctor)
        {
            return DBWrapper.DeleteDoctor(doctor);
        }

        #endregion

        public void Init()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Thread.Sleep(1000);

                ComPort.GetType();

                if (TestCommunication == Enum_TestCommunication.BlueTooth)
                    Ble.GetBLE.StartBleScan();

                if (DBWrapper == null)
                {
                    DBWrapper = GetDatabaseWrapper;
                    DBWrapper.DatabaseLoadDone += DBWrapper_DatabaseLoadDone;
                }
                isDatabaseLoaded = DBWrapper.Load();
                if (!isDatabaseLoaded)
                    Debug.WriteLine("An ERROR occurred while trying to load the data base");
            });
            // load the data base to DBWrapper

            if (PUATest == null)
                PUATest = GetPUATest;

            PUATest.PUALoadDone += PUATest_PUALoadDone;

            PUATest.OneTestDone += PUATest_OneTestDone;
            PUATest.StartTimer += PUATest_StartTimer;

            PUATest.ConnectionLog += PUATest_ConnectionLog;
        }

        private void PUATest_ConnectionLog(Enum_ConnectionLog obj)
        {
            ConnectionLog?.Invoke(obj);
        }

        private void PUATest_PUALoadDone(bool obj)
        {
        }

        private void DBWrapper_DatabaseLoadDone(bool res)
        {
            DatabaseLoadDone?.Invoke(res);
        }

        public void SetStringPathHelp(string help)
        {
            STSManager.GetDatabaseWrapper.SetStringPathHelp(help);
        }

        public double GetPercentage(PUATestHelper value, PUATestHelper prediction, Enum_PUAParameters parameter, out bool isOk)
        {
            double per = 100;
            switch (parameter)
            {
                case Enum_PUAParameters.FVC:
                    per = 100 * (value.FVC / prediction.FVC);
                    break;
                case Enum_PUAParameters.FEV1:
                    per = 100 * (value.FEV1 / prediction.FEV1);
                    break;
                case Enum_PUAParameters.FEV1_FVC:
                    per = 100 * (value.FEV1_FVC / prediction.FEV1_FVC);
                    break;
                case Enum_PUAParameters.FEV6:
                    per = 100 * (value.FEV6 / prediction.FEV6);
                    break;
                case Enum_PUAParameters.FEV3:
                    per = 100 * (value.FEV3 / prediction.FEV3);
                    break;
                case Enum_PUAParameters.FEV3_FVC:
                    per = 100 * (value.FEV3_FVC / prediction.FEV3_FVC);
                    break;
                case Enum_PUAParameters.PEF:
                    per = 100 * (value.PEF / prediction.PEF);
                    break;
                case Enum_PUAParameters.FEF25_75:
                    per = 100 * (value.FEF25_75 / prediction.FEF25_75);
                    break;
                case Enum_PUAParameters.VC:
                    per = 100 * (value.VC / prediction.VC);
                    break;
                case Enum_PUAParameters.IVC:
                    per = 100 * (value.IVC / prediction.IVC);
                    break;
                case Enum_PUAParameters.PIF:
                    per = 100 * (value.PIF / prediction.PIF);
                    break;

                case Enum_PUAParameters.TLC:
                    per = 100 * (value.TLC / prediction.TLC);
                    break;
                case Enum_PUAParameters.TGV:
                    per = 100 * (value.TGV / prediction.TGV);
                    break;
                case Enum_PUAParameters.RV:
                    per = 100 * (value.RV / prediction.RV);
                    break;
                case Enum_PUAParameters.TGV_TLC:
                    per = 100 * (value.TGV_TLC / prediction.TGV_TLC);
                    break;
                case Enum_PUAParameters.RV_TLC:
                    per = 100 * (value.RV_TLC / prediction.RV_TLC);
                    break;

                case Enum_PUAParameters.RAW:
                    per = 100 * (value.RAW / prediction.RAW);
                    break;
                case Enum_PUAParameters.CL:
                    per = 100 * (value.CL / prediction.CL);
                    break;
            }

            if (Double.IsInfinity(per) || Double.IsNaN(per))
                per = 0;

            isOk = (per <= 150 && per >= 50);
            return per;
        }

        private Patient _currentPatient;
        private bool _isTestRunning = false;
        private bool disposedValue;

        public bool StartTest(Patient currentPatient)
        {
            string[] ports = SerialPort.GetPortNames();

            bool portIsOk = false;
            for (int i = 0; i < ports.Length; i++)
                if (ports[i].Equals(ComPort))
                {
                    portIsOk = true;
                    break;
                }

            if (!portIsOk)
            {
                ComPort = 0;
                ComPort.GetType();
            }

            _isTestRunning = true;
            _currentPatient = currentPatient;
            //if (_currentPatient.RunningTestVisit == null)
            //  _currentPatient.RunningTestVisit = AddNewVisit(_currentPatient);

            PUATest.StartTest();

            //DateTime(DateTime.Now.Subtract(BirthDate).Ticks).Year - 1;
            return isPUATestLoaded && PUATest.IsConnected;
        }

        private void PUATest_OneTestDone(bool arg1, PUATestHelper arg2)
        {
            if (!_isTestRunning || _currentPatient.Visited.Count == 0)
                return;

            Debug.WriteLine("TestDone");
            TestDone?.Invoke(arg1, _currentPatient.Visited[_currentPatient.Visited.Count - 1].Test);
        }

        private void PUATest_StartTimer()
        {
            StartTestTimer?.Invoke();
        }

        public bool StopTest()
        {
            PUATest.StopTest();

            _isTestRunning = false;
            //AddVisit(_currentPatient.RunningTestVisit);
            //_currentPatient.RunningTestVisit = null;

            PUATest.PUALoadDone -= PUATest_PUALoadDone;

            return true;
        }

        public PatientVisit AddNewVisit(Patient currentPatient)
        {
            if (currentPatient == null)
                return null;

            PatientVisit newVisit = new PatientVisit();
            newVisit = new PatientVisit();

            newVisit.UnitSystem = config.UnitSystem;

            newVisit.VisitDateTime = DateTime.Now;
            newVisit.Doctor = currentDoctor;
            newVisit.Patient = currentPatient;
            newVisit.TestType = Enum_TestType.Spiro_TLC;

            isPUATestLoaded = PUATest.Init(newVisit);
            if (!isPUATestLoaded)
                Debug.WriteLine("An ERROR occurred while trying to start a new test");

            if (currentPatient.Visited == null)
                currentPatient.Visited = new List<PatientVisit>();

            //Check on today
            currentPatient.Visited.Add(newVisit);
            return newVisit;
        }

        public Patient CreateNewPatient()
        {
            Patient newPatient = new Patient();
            newPatient.UnitSystem = config.UnitSystem;

            newPatient.Visited = new List<PatientVisit>();//Avi need Impl;

            //Avi need Impl;
            return newPatient;
        }

        public PUATestResult GeturrentTestResult()
        {
            return null;
        }
        public PUATestHelper GetPrediction(Patient patient)
        {
            return STSPUATest.CalcPrediction(patient);
        }

        public bool RemoveTest(PUATestResult testResult, int index)
        {
            if (testResult == null || index < 0 || index >= testResult.AllTests.Count)
                return false;

            try
            {
                testResult.AllTests.RemoveAt(index);
                testResult.CalcBest();
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }

        
        #region Print Functions

        public List<string> GetAllPrinters(out int defaultIndex)
        {
            defaultIndex = 0;
            List<string> printers = new List<string>();

            var printerQuery = new ManagementObjectSearcher("SELECT * from Win32_Printer");

            _printPicture = null;

            int index = 0;
            foreach (var printer in printerQuery.Get())
            {
                var name = printer.GetPropertyValue("Name");
                var status = printer.GetPropertyValue("Status");
                var isDefault = printer.GetPropertyValue("Default");
                if (Convert.ToBoolean(isDefault))
                    defaultIndex = index;
                var isNetworkPrinter = printer.GetPropertyValue("Network");

                //Debug.WriteLine("{0} (Status: {1}, Default: {2}, Network: {3}",name, status, isDefault, isNetworkPrinter);
                printers.Add(printer.GetPropertyValue("Name").ToString());
                index++;
            }

            return printers;
        }

        public bool StartPrint(PrintData data)
        {
            if (data == null)
                return false;

            PrintStart?.Invoke();

            _printPicture = null;

            if (data.ReportBitmap != null)
            {
                if (!Directory.Exists(Utils.GetReportDirectory()))
                    Directory.CreateDirectory(Utils.GetReportDirectory());

                string date_time = DateTime.Now.ToShortDateString().Replace('/', '_') + "_" + DateTime.Now.ToLongTimeString().Replace(':', '_');
                date_time = date_time.Replace(" ", "_");
                string reportFile = Utils.GetReportDirectory() + date_time + "_Report.bmp";

                data.ReportBitmap.Save(reportFile);
            }

            try
            {
                _printPicture = data.ReportBitmap;

                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = data.PrinterName;
                pd.PrinterSettings.Copies = (short)data.Copies;
                pd.PrintPage += Pd_PrintPage;
                pd.Print();
            }
            catch (Exception ex)
            {
                PrintDone?.Invoke(false);
                return false;
            }

            PrintDone?.Invoke(true);
            return true;
        }

        private Bitmap _printPicture = null;
        private void Pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            if (_printPicture == null)
                return;

            Bitmap newPrint = new Bitmap(_printPicture, (int)(ev.PageSettings.PaperSize.Width * 0.9), (int)((double)_printPicture.Height * (double)ev.PageSettings.PaperSize.Width * 0.9 / (double)_printPicture.Width));

            Graphics g = ev.Graphics;
            g.DrawImage((Image)newPrint, new PointF(0, 0));
        }

        public string GetHospitalName()
        {
            return config.HospitalName;
        }

        public string GetClassName()
        {
            return config.ClassName;
        }

        public bool Login(string userName, string password)
        {
            for(int i = 0; i < AllDoctorCard.Count; i++)
            {
                if(AllDoctorCard[i].UserName.Equals(userName) && AllDoctorCard[i].Password.Equals(password))
                {
                    currentDoctor = AllDoctorCard[i];
                    return true;
                }
            }

            return false;
        }

        public bool Logout()
        {
            currentDoctor = null;
            return true;
        }

        public bool Disconnect()
        {
            currentDoctor = null;
            return true;
        }

        // need to impl
        public PUATestHelper GetExamples(Enum_ExamplePresure pressureExample) 
        {
            PUATestHelper t = PUATestHelper.Healthy;

            switch (pressureExample)
            {
                case Enum_ExamplePresure.Healthy:
                    break;
                case Enum_ExamplePresure.Obstructive:
                    break;
                case Enum_ExamplePresure.Restrictive:
                    break;
            }

            return null;
        }

        private DoCalc.DoCalc _dc = null;
        public PUATestHelper DoCalc(PatientVisit visit, int testIndex, string deviceName)
        {
            if (visit.Test.AllTests.Count == 0 || visit.Test.AllTests[testIndex] == null)
                return null;

            PUATestHelper test = visit.Test.AllTests[testIndex];

            _dc = new DoCalc.DoCalc(CommonLib.Utils.GetDeviceConfigFileName(deviceName));
            
            _dc.Frequency = Frequency;

            double age = new DateTime(DateTime.Now.Subtract(visit.Patient.BirthDate).Ticks).Year - 1;
            try
            {
                _dc.Calculate(age, visit.Patient.HeightAsMetric, visit.Patient.WeightAsMetric, visit.Patient.Gender.ToString(), test.RawData, -1);

                test.ExhFlow = _dc.Exh_Flow;
                test.ExhVC = _dc.FlowVC;

                test.TLC = _dc.TLCMeasuredAvg123;
                test.FEV1 = _dc.FEV1;
                test.PEF = _dc.PEF;
                test.FVC = _dc.FVC;
                test.RAW = _dc.AR;
                test.TGV = _dc.TGVAvg123;
                test.RV = _dc.RV;
                test.CL = _dc.Compliance;

                test.FEV1_FVC = 100 * test.FEV1 / test.FVC;
                test.TGV_TLC = 100 * test.TGV / test.TLC;
                test.RV_TLC = 100 * test.RV / test.TLC;

                test.IndexT.Value = _dc.TIndex;
                test.IndexV.Value = _dc.VIndex;
                test.IndexP.Value = _dc.PIndex;
                test.IndexO.Value = _dc.OIndex;

                test.IndexT.IndexClassification = _dc.GetHealtConditionTIndex();
                test.IndexV.IndexClassification = _dc.GetHealtConditionVIndex();
                test.IndexP.IndexClassification = _dc.GetHealtConditionPIndex();
                test.IndexO.IndexClassification = _dc.GetHealtConditionOIndex();

                // might be wrong
                test.FEV6 = _dc.FEV6;
                test.FEV3 = _dc.FEV3;
                test.FEV3_FVC = 100 * test.FEV3 / test.FVC;
                test.FEF25_75 = _dc.FEF25_75;

                test.VC = test.FVC; // igor told me

                test.IVC = _dc.IVC;
                test.PIF = _dc.PIF;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Do calc Failed" + ex.Message);
            }

            return null;
        }

        public Hospital HospitalData
        {
            get { return new Hospital(config.HospitalName, config.ClassName); }
            set { config.HospitalName = value.HospitalName; config.ClassName = value.ClassName; }
        }

        public Enum_Unit_System UnitSystem
        {
            get
            {
                return config.UnitSystem;
            }
            set
            {
                config.UnitSystem = value;

                for (int i = 0; i < AllPatients.Count; i++)
                    AllPatients[i].UnitSystem = value;

                for (int i = 0; i < AllVisits.Count; i++)
                    AllVisits[i].UnitSystem = value;
            }
        }

        public int ComPort
        {
            get
            {
                try
                {
                    //if (config.PlumpDeviceComPortNumber == 0)
                    //    config.PlumpDeviceComPortNumber = int.Parse(SerialPort.GetPortNames()[0]);

                    if (config.PlumpDeviceComPortNumber == 0)
                    {
                        List<ComPort> allPorts = new List<ComPort>();
                        using (var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_SerialPort"))
                        {
                            var ports = searcher.Get().Cast<ManagementBaseObject>().ToList();

                            foreach (var p in ports)
                            {
                                ComPort c = new ComPort();
                                c.Name = p.GetPropertyValue("DeviceID").ToString();
                                //Debug.WriteLine(p.GetPropertyValue("PNPDeviceID").ToString());
                                c.Description = p.GetPropertyValue("Caption").ToString().Split('(')[0];

                                allPorts.Add(c);

                                //allPortDescription.Add(c.Description.Split('(')[0]);
                            }
                        }

                        for (int i = 0; i < allPorts.Count; i++)
                            if (allPorts[i].Description.Equals("USB Serial Device "))
                                config.PlumpDeviceComPortNumber = int.Parse(allPorts[i].Name.Split('M')[1]);

                        if (config.PlumpDeviceComPortNumber == 0)
                            config.PlumpDeviceComPortNumber = int.Parse(SerialPort.GetPortNames()[0]);
                    }
                }
                catch (Exception ex)
                {
                    config.PlumpDeviceComPortNumber = 0;
                }


                return config.PlumpDeviceComPortNumber;
            }

            set
            {
                config.PlumpDeviceComPortNumber = value;
            }
        }

        private string _bluetoothDeviceName = null;
        public string BlueToothDevice 
        {
            get
            {
                if(_bluetoothDeviceName == null && GetAllSTSBluetoothDevices().Length > 0)
                    _bluetoothDeviceName = GetAllSTSBluetoothDevices()[0];

                return _bluetoothDeviceName;
            }
            set
            {
                _bluetoothDeviceName = value;
            }
        }

        public bool StartVideo()
        {
            return false;
        }

        public bool EndVideo()
        {
            return true;
        }

        public string[] GetAllSTSBluetoothDevices()
        {
            List<string> allDevicesNames = new List<string>();

            var devices = Ble.GetBLE.KnownDevices;
            for (int i = 0; i < devices.Count; i++)
                if (devices[i].Name.Length >= 3 && devices[i].Name.Substring(0, 3).Equals("STS"))
                    allDevicesNames.Add(devices[i].Name);

            return allDevicesNames.ToArray();
        }

        public void DeletePatient(Patient patient)
        {
            GetDatabaseWrapper.DeletePatient(patient);
        }

        public void DeleteVisit(Patient currentPatient, PatientVisit visit)
        {
            GetDatabaseWrapper.DeleteVisit(visit);

            for (int i = 0; i < currentPatient.Visited.Count; i++)
            {
                var visitT = currentPatient.Visited.First(x => x.VisitDateTime == visit.VisitDateTime);
                currentPatient.Visited.Remove(visitT);
            }
        }

        public void SetCalibarationFileName(string fileName)
        {
        }

        public string getDeviceName()
        {
            throw new NotImplementedException();
        }

        public string getDoCalcString()
        {
            if (_dc == null)
                _dc = new DoCalc.DoCalc(CommonLib.Utils.GetDeviceConfigFileName(null));

            return _dc.CalibrationInfo.ToString();
        }

        public bool Reconnect()
        {
            return PUATest.Reconnect();
        }

        #endregion

        #endregion

        #endregion
    }
}
