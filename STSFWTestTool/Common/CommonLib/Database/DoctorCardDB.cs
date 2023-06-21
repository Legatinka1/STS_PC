using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class DoctorCardDB
    {
        public DoctorCardDB()
        {
            FullName = "";
            MoreDetails = "";

            UserName = "UserName";
            Password = "";
            SettingsPassword = "";

            PhotoFile = "";

            SignatureFile = "";

            Site = "";

            CreationDate = DateTime.Now;

            DoctorPicture = PictureHelper.GetDefaultDoctorPictureAsString();

            DoctorLevel = Enum_Doctor_Level.Admin;
        }

        public DoctorCardDB(DoctorCardDB other)
        {
            CopyFromOther(other);
        }
        public DoctorCardDB(DoctorCard other)
        {
            CopyFromOther(other);
        }

        public void CopyFromOther(DoctorCardDB other)
        {
            if (other == null)
                return;

            FullName = other.FullName;
            MoreDetails = other.MoreDetails;

            UserName = other.UserName;
            Password = other.Password;
            SettingsPassword = other.SettingsPassword;

            PhotoFile = other.PhotoFile;
            SignatureFile = other.SignatureFile;

            //Level = other.Level;
            Site = other.Site;

            CreationDate = other.CreationDate;

            DoctorPicture = other.DoctorPicture;

            DoctorLevel = other.DoctorLevel;
        }
        public void CopyFromOther(DoctorCard other)
        {
            if (other == null)
                return;

            FullName = other.FullName;
            MoreDetails = other.MoreDetails;

            UserName = other.UserName;
            Password = other.Password;
            SettingsPassword = other.SettingsPassword;

            PhotoFile = other.PhotoFile;
            SignatureFile = other.SignatureFile;

            //Level = other.Level;
            Site = other.Site;

            CreationDate = other.CreationDate;

            DoctorPicture = PictureHelper.GetStringFromBitmap(other.DoctorPicture);

            DoctorLevel = other.DoctorLevel;
        }
        
        [Key]
        public string UserName
        {
            get;
            set;
        }

        public string FullName
        {
            get;
            set;
        }

        public DateTime CreationDate
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

        //public DoctorLevel Level
        //{
        //    get;
        //    set;
        //}

        public string Site
        {
            get;
            set;
        }

        public string DoctorPicture
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
