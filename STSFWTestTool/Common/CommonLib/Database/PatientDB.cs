using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class PatientDB
    {
        public PatientDB()
        {
            PatientId = "";
            FullName = "";

            Height = 0;
            Weight = 0;

            BirthDate = DateTime.Now;
            Gender = "N/A";
            Ethnicity = "N/A";
            PhoneNumber = "0599999999";

            MoreDetails = "";
            PatientAdress = "";

            Medication = Enum_Medication.None;
            MedicationDescription = "";
            Smoking = Enum_Smoking.Not;
            SmokingDescription = "";

            PatientPicture = PictureHelper.GetDefaultPictureAsString();
        }

        public PatientDB(PatientDB other)
        {
            CopyFromOther(other);
        }
        public PatientDB(Patient other)
        {
            CopyFromOther(other);
        }

        public void CopyFromOther(PatientDB other)
        {
            if (other == null)
                return;

            PatientId = other.PatientId;
            FullName = other.FullName;
            MoreDetails = other.MoreDetails;

            Height = other.Height;
            Weight = other.Weight;

            BirthDate = other.BirthDate;
            Gender = other.Gender;
            Ethnicity = other.Ethnicity;
            PhoneNumber = other.PhoneNumber;

            Medication = other.Medication;
            MedicationDescription = other.MedicationDescription;
            Smoking = other.Smoking;
            SmokingDescription = other.SmokingDescription;

            PatientAdress = other.PatientAdress;

            PatientPicture = other.PatientPicture;
        }
        public void CopyFromOther(Patient other)
        {
            if (other == null)
                return;

            PatientId = other.PatientId;
            FullName = other.FullName;

            Height = other.UnitSystem == Enum_Unit_System.Metric ? other.Height : other.Height / 0.393701;
            Weight = other.UnitSystem == Enum_Unit_System.Metric ? other.Weight : other.Weight / 2.2046226;

            BirthDate = other.BirthDate;

            Gender = other.Gender.Equals(Enum_Gender.Male) ? "Male" : "Female";

            Ethnicity = $"{other.Ethnicity}";
            PhoneNumber = other.PhoneNumber;
            PatientAdress = other.PatientAdress;

            Medication = other.Medication;
            MedicationDescription = other.MedicationDescription;
            Smoking = other.Smoking;
            SmokingDescription = other.SmokingDescription;

            PatientPicture = PictureHelper.GetStringFromBitmap(other.PatientPicture);
        }

        [Key]
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

        public string Gender
        {
            get;
            set;
        }

        public string Ethnicity
        {
            get;
            set;
        }

        public string PhoneNumber
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

        public string MoreDetails
        {
            get;
            set;
        }

        public string PatientAdress
        {
            get;
            set;
        }

        public string PatientPicture
        {
            get;
            set;
        }
    }
}