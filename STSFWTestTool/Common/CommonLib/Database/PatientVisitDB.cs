using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace CommonLib
{
    public class PatientVisitDB
    {
        static Config config = ConfigurationFileManager<Config>.Instance.GetData;

        public PatientVisitDB()
        {
            MoreDetails = "";

            VisitDateTime = DateTime.Now;

            Pulse = 0;
            Temperture = 36.7;
            BloodPresure = "";

            TestType = Enum_TestType.NotKnown;
            TestStatus = Enum_TestStatus.NotKnown;

            VisitDateTime = DateTime.Now;
            MoreDetails = "";

            HospitalName = config.HospitalName;
            ClassName = config.ClassName;

            Test = null;
        }

        public PatientVisitDB(PatientVisitDB other)
        {
            CopyFromOther(other);
        }
        public PatientVisitDB(PatientVisit other)
        {
            CopyFromOther(other);
        }

        public void CopyFromOther(PatientVisitDB other)
        {
            if (other == null)
                return;
            MoreDetails = other.MoreDetails;

            VisitDateTime = other.VisitDateTime;

            UserName = other.UserName;
            PatientId = other.PatientId;

            Pulse = other.Pulse;
            Temperture = other.Temperture;
            BloodPresure = other.BloodPresure;

            TestType = other.TestType;
            TestStatus = other.TestStatus;

            Test = other.Test;

            HospitalName = other.HospitalName;
            ClassName = other.ClassName;
        }
        public void CopyFromOther(PatientVisit other)
        {
            if (other == null)
                return;

            MoreDetails = other.MoreDetails;

            VisitDateTime = other.VisitDateTime;

            UserName = other.Doctor.UserName;
            PatientId = other.Patient.PatientId;

            Pulse = other.Pulse;
            Temperture = other.UnitSystem == Enum_Unit_System.Metric ? other.Temperture : (other.Temperture - 32) * 5 / 9;
            BloodPresure = other.BloodPresure;

            TestType = other.TestType;
            TestStatus = other.TestStatus;

            Test = PUATestResult.SaveTestResult(other.Test);

            HospitalName = other.VisitHospital.HospitalName;
            ClassName = other.VisitHospital.ClassName;
        }

        public string UserName { get; set; }
 //       [ForeignKey("DoctorCardDBUserName")]
        public virtual DoctorCardDB DoctorCardDB { get; set; }

        public string PatientId { get; set; }
 //       [ForeignKey("PatientDBPatientId")]
        public virtual PatientDB PatientDB { get; set; }

        [Key]
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

        public string Test
        {
            get;
            set;
        }

        public string HospitalName
        {
            get;
            set;
        }
        public string ClassName
        {
            get;
            set;
        }
    }
}