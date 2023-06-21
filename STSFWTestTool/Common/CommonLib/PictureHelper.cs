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
    public class PictureHelper
    {
        private const string DefaultPicture = "iVBORw0KGgoAAAANSUhEUgAAAIAAAACACAIAAABMXPacAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAKbSURBVHhe7dnbduIwEERR / v + n55I5WR57AcEgdbXg7Eew1aWu8JTLL0VZQJgFhFlAmAWEWUCYBYStVMDlLh5aTevcrPY83l9Bx6xscQRObKxXRNY2Gqe31CUcq5qJSc20iMWG5mNeJ / lM7KYQg3tIpmEfCSRoIBaFTeSQIy2Tgx2kkSYqEILb90CmnOoE3LsTkoVYwCcVwI37IV + CBYCI5eoGc9GuSFmuaDC37I2stSxgQ9ZaFrAha62KqdxvBSQuZAE7JC5kATskLmQBR4SuMn0e11oHuatYwBG5q1jAEbmrWMARuatYwBG5q1jAEbmrWMARuatYwBG5q1TM42aLIHQVC9ghcSEL2CFxIQvYIXGhopHcrzey1rKADVlrWcCGrLXqpnLLrkhZzgJAynKlg7lrP + RLqJ7NjTshWYgFfFgBf3DvHsiUk0nA7dNIExULwQ5yyJGWzMEmEkjQQD4KKynE4B5apGEx8zGvky6Z2NBMTGqm2e9xDk5vqeWvchxObKz3X8ezeH8Fy2Rltbfx3GpWzf02LCDMAsIsIMwCwiwgzALCLCDMAsIsIMwCwiwgzALCLCDMAsIsIKx1Afyr5TzeX0GLrKxtPuZ1ksnEPtJIE1UXgkt3Rcpy0wdzv3WQu8qsedxmZdxkssFjyP5euNscY04n6bvjtkO9eijRPgk3H + T544jzqdjCy545iAgaUcO5IxirPbbzlEdfZpRuY1MnPfQaE / QT9nXGD + 9wsM5gd4+59zTn6Tw2+IDrj3KMXsM277ryEG9rBHZ62/EJ3tM4bPaG3de8odHY7zXbdzyraVj03t9P+V7z/Vv6//hCZVj8Nz5VJXb/hY9Uid1/4SMVY/0WEGQBeRYgSZIkSZIkSZIkSZKkGS6X301TPBjGwXeXAAAAAElFTkSuQmCC";
        private const string FemalePicture = "iVBORw0KGgoAAAANSUhEUgAAAIAAAACACAIAAABMXPacAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAALhSURBVHhe7dHRcqswDIThvP9Ln07bv+NDhiSApZWA/S4TbK+0j39WygUUcwHFXEAxF1DMBRRzAcXOVMDjLT46m9a5We1+nD+DjlnZYgRubKxXRNYWjdtb6hKOVWXipWZaxGJD+Xivk/pM7EaIh3uoTMM+KpCggbIobKIOOarV5GAH1UhTqiAE0/dApjrqBMzdCcmKuIA7FcDE/ZCvggv4Rr4KureZtStSyrkAkFJO9DBTNkZQORcwkFXLBQxk1VK8ynztEVfLBQzE1XIBA3G1XMBAXC0XMBBXywUMxNVyAQNxtVzAQFwtFzAQV8sFDMTVcgEDcbVcwEBcLRcwEFfLBQzE1XIBA3G1XMBAXC0XMBBXywUskFgo/UkmOwlCC7mABUILuYAFQgu5gAVCC7mABUILuYBn5FbJfY+ZToXoKi7gGdFVXMAzoqu4gBWkl3ABK0gvkfgY05wQA0i4gHXMkC/rJeY4LcbI5wJeYpJkKc8wwckxTDIX8A7zZIp/g+yXwEiZgt8g+IUwWJrIB4h8OYyXI+x2wl4UQyaIuZqYl8ao0QLuJeANMHCo2UuJdhuMHWfqRkLdDMMHOXgdWe6KLUQ4chcpbo91zGlaAC9txjE5np/QogDujcO9+XhvwsEreH8nDlcgQTRun3D8CiJ8wtf9kG8CF83puyAxlroZx6a1LoBZ9+P8GbTIytry8V4nNZnYRzXSlNKFYOiuSCmX/jDznQe5VbLeY5ozY5Jkwc+Q/VqYLUfM7SS9OqYNNXsp0e6EyYMcv444d8UWph25iAgWUcO+K3jWltjOIVsP85S9xqZ22nSMF+wT9rXHhzNcbHuwu23efc19th8b3GD9U66xOWzzrZWPOG0R2Olrz19wzuKw2RcWf3PCorHfNeM/vrU0LHrp+1f+t3y/S/8ff5gMi//Dr6bE7n/wkymx+x/8ZGKs3wUUcgH1XICZmZmZmZmZmZmZmZmZmZmZZXg8vgALJQdsVtZPywAAAABJRU5ErkJggg==";
        private const string doctorPicture = "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";

        public static string GetDefaultDoctorPictureAsString()
        {
            return GetStringFromBitmap(GetDefaultDoctorPicture());
        }

        public static Bitmap GetDefaultDoctorPicture()
        {
            return GetBitmapFromString(doctorPicture);
        }

        public static Bitmap getFemalePicture()
        {
            return GetBitmapFromString(FemalePicture);
        }

        public static bool FixDefaultFemale(Patient p)
        {
            if (p.PatientPicture == null || (p.Gender.Equals("Female") && GetStringFromBitmap(p.PatientPicture).Equals(DefaultPicture)))
            {
                p.PatientPicture = GetBitmapFromString(FemalePicture);
                return true;
            }

            return false;
        }

        public static string GetDefaultPictureAsString()
        {
            return GetStringFromBitmap(GetDefaultPicture());
        }

        public static Bitmap GetDefaultPicture()
        {
            return GetBitmapFromString(DefaultPicture);
        }

        public static Bitmap GetBitmapFromString(string imgData)
        {
            Bitmap Img;

            using (var ms = new MemoryStream(Convert.FromBase64String(imgData)))
            {
                Img = new Bitmap(ms);
            }

            return Img;
        }

        public static string GetStringFromBitmap(Bitmap img)
        {
            string ImgData;

            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                ImgData = Convert.ToBase64String(stream.ToArray());
            }

            return ImgData;
        }

        /////////////////////////////////////////////////////////////
        /*public static bool LoadDefaultPicture(Patient p)
        {
            if (p.PatientPicture != null && !p.PatientPicture.Equals(DefaultPicture))
                return false;

            if (p.Gender.Equals("Female"))
                p.PatientPicture = FemalePicture;
            else
                p.PatientPicture = DefaultPicture;

            return true;
        }*/

        /*public static bool LoadDefaultPicture(PatientDB pdb)
        {
            if (pdb.PatientPicture != null && !pdb.PatientPicture.Equals(DefaultPicture))
                return false;

            if (pdb.Gender.Equals("Female"))
                pdb.PatientPicture = FemalePicture;
            else
                pdb.PatientPicture = DefaultPicture;

            return true;
        }*/

        /*public static void AddPictureToPatient(Patient p, Bitmap img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                p.PatientPicture = Convert.ToBase64String(stream.ToArray());
            }
        }*/

        /*public static Bitmap getImageFromPatient(Patient p)
        {
            Bitmap PatientImg;

            using (var ms = new MemoryStream(Convert.FromBase64String(p.PatientPicture)))
            {
                PatientImg = new Bitmap(ms);
            }

            return PatientImg;
        }*/
    }
}
