using CommonLib;
using GUITest;
using ImplementationLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Patientlist
{
    public partial class PatientData : Form
    {
        private Patient p;
        public PatientData(Patient p)
        {
            InitializeComponent();
            this.p = STSManager.GetManager.GetPatient(p.PatientId);
        }

        private void LPatientlist_Click(object sender, EventArgs e)
        {
            PatientsList PL = new PatientsList();
            this.Hide();
            PL.SetDesktopLocation(this.DesktopLocation.X, this.DesktopLocation.Y);
            PL.ShowDialog();
            this.Close();
        }

        private void LMainPage_Click(object sender, EventArgs e)
        {
            MainPage MP = new MainPage();
            this.Hide();
            MP.SetDesktopLocation(this.DesktopLocation.X, this.DesktopLocation.Y);
            MP.ShowDialog();
            this.Close();
        }

        public void InitValues()
        {
            LPatientData.Text = p.FullName + " " + p.PatientId;
            LPrivateName.Text = p.FullName;
            LPrivateAge.Text = $"{CalculateAge(p.BirthDate)}";
            LPrivateID.Text = p.PatientId;
            LPrivatePhone.Text = PhoneFormate(p.PhoneNumber);

            LPrivateHeight.Text = $"{p.Height:0.00}";
            LPrivateWeight.Text = $"{p.Weight:0.00}";
            LPrivateBMI.Text = $"{STSManager.GetManager.GetBMI(p)}";

            LPrivateBirthDate.Text = p.BirthDate.ToString("dd/MM/yyyy");
            LPrivateGender.Text = p.Gender.ToString();
            LPrivateEtnicity.Text = $"{p.Ethnicity}";
            LPrivateAdress.Text = p.PatientAdress;
        }

        public int CalculateAge(DateTime BirthDate)
        {
            DateTime Now = DateTime.Now;
            return new DateTime(DateTime.Now.Subtract(BirthDate).Ticks).Year - 1;
        }

        public string PhoneFormate(string Phone)
        {
            if (Phone[0].Equals('+'))
                return string.Format("({0}){1}-{2}-{3}", Phone.Substring(0, 4), Phone.Substring(4, 3), Phone.Substring(7, 3), Phone.Substring(10, 3));
            else if (!Phone[1].Equals('5'))
                return string.Format("{0}-{1}-{2}", Phone.Substring(0, 2), Phone.Substring(2, 3), Phone.Substring(5, 4));

            return string.Format("({0}){1}-{2}", Phone.Substring(0, 3), Phone.Substring(3, 3), Phone.Substring(6, 4));
        }

        public void InitPreviousTests()
        {
            if (p.Visited == null)
                return;

            string[] properties;
            foreach (PatientVisit pv in p.Visited)
            {
                properties = new string[] { pv.VisitDateTime.ToString("dd/MMM/yyyy"), pv.Doctor.UserName, "N/A", "N/A"};

                LViewPreviousTests.Items.Add(new ListViewItem(properties));
            }
        }

        private void InitPicture()
        {
             PicBoxAvatar.Image = new Bitmap(p.PatientPicture, PicBoxAvatar.Width, PicBoxAvatar.Height);
        }

        private void BtnNewTest_Click(object sender, EventArgs e)
        {
            /*TestSession TS = new TestSession();
            this.Hide();
            TS.SetDesktopLocation(this.DesktopLocation.X, this.DesktopLocation.Y);
            TS.ShowDialog();
            this.Close();*/
        }

        private void PatientData_Load(object sender, EventArgs e)
        {
            InitValues();
            InitPreviousTests();

            InitPicture();
        }

        private void LViewPreviousTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            TestSession TS = new TestSession(p.Visited[LViewPreviousTests.SelectedItems[0].Index]);
            this.Hide();
            TS.SetDesktopLocation(this.DesktopLocation.X, this.DesktopLocation.Y);
            TS.ShowDialog();
            this.Close();
        }

        private void BtnPreProSession_Click(object sender, EventArgs e)
        {
            /*string[] lines = File.ReadAllLines(@"C:\EfCom\Technoplumsts\SVN\trunk\PatientDataConverted\Patient-3.csv");

            List<double> time = new List<double>(), pressure = new List<double>();
            for(int i = 2; i < lines.Length; i++)
            {
                var sl = lines[i].Split(',');
                time.Add(Double.Parse(sl[0]));
                pressure.Add(Double.Parse(sl[1]));
            }

            string help = "";
            for (int i = 0; i < time.Count; i++)
                help += time[i] + ",";

            File.WriteAllText(@"C:\STS\Time-3.txt", help);

            help = "";
            for (int i = 0; i < pressure.Count; i++)
                help += pressure[i] + ",";

            File.WriteAllText(@"C:\STS\Pressure-3.txt", help);*/
        }
    }
}
