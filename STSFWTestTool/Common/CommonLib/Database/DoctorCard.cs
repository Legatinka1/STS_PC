using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CommonLib
{
    [Serializable]
    public class DoctorCard
    {
        public DoctorCard()
        {
            FullName = "";
            //LastName = "";
            MoreDetails = "";

            UserName = "";
            Password = "";
            SettingsPassword = "";


            PhotoFile = "";

            SignatureFile = "";
            //Signature = null;

            //Level = DoctorLevel.Administrator;
            Site = "";

            CreationDate = DateTime.Now;

            DoctorPicture = PictureHelper.GetDefaultDoctorPicture();

            DoctorLevel = Enum_Doctor_Level.Admin;
        }

        public DoctorCard(DoctorCard other)
        {
            CopyFromOther(other);
        }

        public DoctorCard(DoctorCardDB other)
        {
            CopyFromOther(other);
        }

        public void CopyFromOther(DoctorCard other)
        {
            if (other == null)
                return;

            FullName = other.FullName;
            //LastName = other.LastName;
            MoreDetails = other.MoreDetails;

            UserName = other.UserName;
            Password = other.Password;
            SettingsPassword = other.SettingsPassword;

            PhotoFile = other.PhotoFile;

            SignatureFile = other.SignatureFile;
            // Signature = other.Signature;


            //Level = other.Level;
            Site = other.Site;

            CreationDate = other.CreationDate;

            DoctorPicture = other.DoctorPicture;

            DoctorLevel = other.DoctorLevel;
        }

        public void CopyFromOther(DoctorCardDB other)
        {
            if (other == null)
                return;

            FullName = other.FullName;
            //LastName = other.LastName;
            MoreDetails = other.MoreDetails;

            UserName = other.UserName;
            Password = other.Password;
            SettingsPassword = other.SettingsPassword;

            PhotoFile = other.PhotoFile;

            SignatureFile = other.SignatureFile;
            Site = other.Site;

            CreationDate = other.CreationDate;

            DoctorPicture = PictureHelper.GetBitmapFromString(other.DoctorPicture);

            DoctorLevel = other.DoctorLevel;
        }

        public string FullName
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string SettingsPassword
        {
            get;
            set;
        }

        public string MoreDetails
        {
            get;
            set;
        }

        public string PhotoFile
        {
            get;
            set;
        }

        public string SignatureFile
        {
            get;
            set;
        }

        public string Site
        {
            get;
            set;
        }

        public DateTime CreationDate
        {
            get;
            set;
        }

        public Bitmap DoctorPicture
        {
            get;
            set;
        }

        public Enum_Doctor_Level DoctorLevel
        {
            get;
            set;
        }
    }
}
