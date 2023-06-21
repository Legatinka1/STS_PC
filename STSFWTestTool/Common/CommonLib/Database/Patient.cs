using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class Patient
    {
        static Config config = ConfigurationFileManager<Config>.Instance.GetData;

        public Patient()
        {
            PatientId = "";
            FullName = "";

            Height = 0;
            Weight = 0;

            BirthDate = DateTime.Now;
            Gender = Enum_Gender.Male;
            Ethnicity = ENUM_Ethnicity.Caucasian;
            PhoneNumber = "0599999999";

            PatientAdress = "";

            Medication = Enum_Medication.None;
            MedicationDescription = "";
            Smoking = Enum_Smoking.Not;
            SmokingDescription = "";

            PatientPicture = PictureHelper.GetDefaultPicture();

            UnitSystem = config.UnitSystem;

            LastDoctor = new DoctorCard();
            Visited = new List<PatientVisit>();
        }

        public Patient(Patient other)
        {
            CopyFromOther(other);
        }
        public Patient(PatientDB other, Enum_Unit_System unitSystem)
        {
            CopyFromOther(other, unitSystem);
        }

        public void CopyFromOther(Patient other)
        {
            if (other == null)
                return;

            PatientId = other.PatientId;
            FullName = other.FullName;
            FullName = other.FullName;

            UnitSystem = other.UnitSystem;

            Height = other.Height;
            Weight = other.Weight;

            BirthDate = other.BirthDate;
            Gender = other.Gender;
            Ethnicity = other.Ethnicity;
            PhoneNumber = other.PhoneNumber;
            PatientAdress = other.PatientAdress;

            Medication = other.Medication;
            MedicationDescription = other.MedicationDescription;
            Smoking = other.Smoking;
            SmokingDescription = other.SmokingDescription;

            PatientPicture = other.PatientPicture;

            LastDoctor = other.LastDoctor;
            Visited = other.Visited;
        }
        public void CopyFromOther(PatientDB other, Enum_Unit_System unitSystem)
        {
            if (other == null)
                return;

            PatientId = other.PatientId;
            FullName = other.FullName;

            Height = other.Height;
            Weight = other.Weight;

            UnitSystem = unitSystem;

            BirthDate = other.BirthDate;

            Gender = other.Gender.Equals("Male") ? Enum_Gender.Male : Enum_Gender.Female;

            try
            {
                Ethnicity = (ENUM_Ethnicity)Enum.Parse(typeof(ENUM_Ethnicity), other.Ethnicity);
            }
            catch(Exception e)
            {
                Ethnicity = ENUM_Ethnicity.Caucasian;
            }

            PhoneNumber = other.PhoneNumber;
            PatientAdress = other.PatientAdress;

            Medication = other.Medication;
            MedicationDescription = other.MedicationDescription;
            Smoking = other.Smoking;
            SmokingDescription = other.SmokingDescription;

            PatientPicture = PictureHelper.GetBitmapFromString(other.PatientPicture);

            LastDoctor = new DoctorCard();
            Visited = new List<PatientVisit>();
        }

        public string PatientId
        {
            get;
            set;
        }

        public string FullName
        {
            get;
            set;
        }

        public double Weight
        {
            get;
            set;
        }

        public double Height
        {
            get;
            set;
        }

        public DateTime BirthDate
        {
            get;
            set;
        }
        
        public Enum_Gender Gender
        {
            get;
            set;
        }

        public ENUM_Ethnicity Ethnicity
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public string PatientAdress
        {
            get;
            set;
        }

        public Enum_Medication Medication
        {
            get;
            set;
        }

        public string MedicationDescription
        {
            get;
            set;
        }

        public Enum_Smoking Smoking
        {
            get;
            set;
        }

        public string SmokingDescription
        {
            get;
            set;
        }

        public Bitmap PatientPicture
        {
            get;
            set;
        }

        public DoctorCard LastDoctor
        {
            get;
            set;
        }

        public List<PatientVisit> Visited
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
                {
                    Height = value == Enum_Unit_System.Metric ? Height / 0.393701 : Height * 0.393701;
                    Weight = value == Enum_Unit_System.Metric ? Weight / 2.2046226 : Weight * 2.2046226;
                }
                _unitSystem = value;

            }
        }

        public double HeightAsMetric
        {
            get { return UnitSystem == Enum_Unit_System.Metric ? Height : Height / 0.393701; }
        }
        public double WeightAsMetric
        {
            get { return UnitSystem == Enum_Unit_System.Metric ? Weight : Weight / 2.2046226; }
        }
    }
}
