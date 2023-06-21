using CommonLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLib
{
    public interface ISTSManager
    {
        #region Events

        event Action<bool> DatabaseLoadDone;

        event Action<bool, PUATestResult> TestDone;
        event Action StartTestTimer;

        event Action PrintStart;
        event Action<bool> PrintDone;

        event Action<Bitmap> NewVideoFrame;
        event Action<bool> VideoStart;
        event Action<bool> VideoEnd;

        event Action<Enum_ConnectionLog> ConnectionLog;

        #endregion

        #region Properties

        #region DB Properties

        bool IsDatabaseLoaded
        {
            get;
        }

        Hospital HospitalData
        {
            get;
            set;
        }

        Enum_Unit_System UnitSystem
        {
            get;
            set;
        }

        PatientVisit CurrentPatientVisit
        {
            get;
        }

        DoctorCard CurrentDoctorCard
        {
            get;
        }

        List<DoctorCard> AllDoctorCard
        {
            get;
        }

        List<Patient> AllPatients
        {
            get;
        }

        List<PatientVisit> AllVisits
        {
            get;
        }

        MonthlyTest MonthlyTests
        {
            get;
        }

        int ComPort
        {
            get;
            set;
        }

        string BlueToothDevice
        {
            get;
            set;
        }

        int Frequency
        {
            get;
            set;
        }

        Enum_TestCommunication TestCommunication
        {
            get;
            set;
        }

        int RawThreshold
        {
            get;
            set;
        }

        int MinThreshold
        {
            get;
            set;
        }

        #endregion

        #endregion

        #region Functions

        #region DB Functions

        string GetHospitalName();

        string GetClassName();

        bool Login(string userName, string password);

        bool Logout();

        bool Disconnect();

        Patient GetPatient(string patientId);

        DoctorCard GetDoctor(string patientId);

        double GetBMI(Patient p);

        bool SaveDoctorCard(DoctorCard doctor, string oldUserName, bool isNew);

        bool DeleteDoctor(DoctorCard card);

        bool SavePatientVisitCard(PatientVisit patient, bool isNew);

        string SavePatient(Patient patient, string oldPatientID, bool isNew);

        double GetPercentage(PUATestHelper value, PUATestHelper prediction, Enum_PUAParameters parameter, out bool isOk);

        void SetStringPathHelp(string help);

        #endregion

        void Init();

        bool StartTest(Patient currentPatient);

        bool StopTest();

        bool Reconnect();
        PUATestHelper GetExamples(Enum_ExamplePresure pressureExample);

        PatientVisit AddNewVisit(Patient currentPatient);

        Patient CreateNewPatient();
      
        PUATestResult GeturrentTestResult();

        PUATestHelper GetPrediction(Patient patient);

        bool RemoveTest(PUATestResult testResult, int index);


        #region Print Functions

        List<string> GetAllPrinters(out int defaultIndex);

        bool StartPrint(PrintData data);

        PUATestHelper DoCalc(PatientVisit visit, int testIndex, string deviceName);

        bool StartVideo();
        bool EndVideo();

        string[] GetAllSTSBluetoothDevices();
        void DeletePatient(Patient patient);
        void DeleteVisit(Patient currentPatient, PatientVisit visit);
        void SetCalibarationFileName(string fileName);
        string getDeviceName();

        string getDoCalcString();

        #endregion

        #endregion
    }
}
