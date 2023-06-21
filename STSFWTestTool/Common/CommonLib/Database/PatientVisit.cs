using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class PatientVisit
    {
        static Config config = ConfigurationFileManager<Config>.Instance.GetData;

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(VisitDateTime.ToLongDateString()+ " " + VisitDateTime.ToLongTimeString() + ",");
            stringBuilder.Append(Doctor.FullName+ ",");
            stringBuilder.Append(Patient.PatientId+ ",");

            return stringBuilder.ToString();
        }

        public PatientVisit()
        {
            Patient = new Patient();
            Doctor = new DoctorCard();

            Pulse = 0;
            Temperture = 36.5;
            BloodPresure = "";

            UnitSystem = config.UnitSystem;

            TestType = Enum_TestType.NotKnown;
            TestStatus = Enum_TestStatus.NotKnown;

            VisitDateTime = DateTime.Now;
            MoreDetails = "";
            Test = new PUATestResult();

            VisitHospital = new Hospital();
        }

        public PatientVisit(DoctorCard doctor) : this()
        {
            Doctor = doctor;
        }

        public PatientVisit(PatientVisit other)
        {
            CopyFromOther(other);
        }

        public PatientVisit(PatientVisitDB other, DoctorCardDB otherDoctor, PatientDB otherPatient, Enum_Unit_System unitSystem)
        {
            CopyFromOther(other, otherDoctor, otherPatient, unitSystem);
        }

        public void CopyFromOther(PatientVisit other)
        {
            if (other == null)
                return;
            if (Patient == null)
                Patient = new Patient();
            Patient.CopyFromOther(other.Patient);
            MoreDetails = other.MoreDetails;
            Doctor = other.Doctor;
            VisitDateTime = other.VisitDateTime;

            Pulse = other.Pulse;
            Temperture = other.Temperture;
            BloodPresure = other.BloodPresure;

            TestType = other.TestType;
            TestStatus = other.TestStatus;

            Test = other.Test;

            UnitSystem = other.UnitSystem;

            VisitHospital = other.VisitHospital;
        }

        public void CopyFromOther(PatientVisitDB other, DoctorCardDB otherDoctor, PatientDB otherPatient, Enum_Unit_System unitSystem)
        {
            if (other == null)
                return;

            Patient = new Patient(otherPatient, unitSystem);
            MoreDetails = other.MoreDetails;
            Doctor = new DoctorCard(otherDoctor);
            VisitDateTime = other.VisitDateTime;

            Pulse = other.Pulse;
            Temperture = other.Temperture;
            BloodPresure = other.BloodPresure;

            UnitSystem = unitSystem;

            TestType = other.TestType;
            TestStatus = other.TestStatus;

            Test = PUATestResult.LoadTestResult(other.Test);

            VisitHospital = new Hospital(other.HospitalName, other.ClassName);
        }

        public static event Action PatientVisitParameterChanged;

        public Patient Patient
        {
            get;
            set;
        }

        public DoctorCard Doctor
        {
            get;
            set;
        }

        public DateTime VisitDateTime
        {
            get;
            set;
        }

        public int Pulse
        {
            get;
            set;
        }

        public double Temperture
        {
            get;
            set;
        }

        public string BloodPresure
        {
            get;
            set;
        }

        public Enum_TestType TestType
        {
            get;
            set;
        }

        public Enum_TestStatus TestStatus
        {
            get;
            set;
        }

        public string MoreDetails
        {
            get;
            set;
        }

        //public List<double[]> Test
        //{
        //    get;
        //    set;
        //}

        public PUATestResult Test
        {
            get;
            set;
        }

        private Enum_Unit_System _unitSystem = Enum_Unit_System.Metric;
        public Enum_Unit_System UnitSystem
        {
            get
            {
                return _unitSystem;
            }
            set
            {
                if (_unitSystem != value)
                    Temperture = value == Enum_Unit_System.Metric ? (Temperture - 32) * 5 / 9 : (Temperture * 9 / 5) + 32;

                _unitSystem = value;
            }
        }

        public Hospital VisitHospital
        {
            get;
            set;
        }
    }
}
