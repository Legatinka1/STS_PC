using CommonLib;
using ImplementationLib;
using InterfacesLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patientlist
{
    public partial class PatientsList : Form
    {
        private ISTSManager dataBase;
        private List<DoctorCard> docs;
        private List<Patient> patients;
        private List<PatientVisit> visits;

        public PatientsList()
        {
            InitializeComponent();
        }

        public void InitPatientsList()
        {
            if (patients == null || patients.Count == 0)
            {
                Debug.WriteLine("could not find any patient visit");
                return;
            }

            string[] properties;
            foreach (Patient p in patients)
            {
                DoctorCard lastDoctor = null;
                for (int i = 0; i < dataBase.AllDoctorCard.Count; i++)
                    if (p.LastDoctor.Equals(dataBase.AllDoctorCard[i].UserName))
                        lastDoctor = dataBase.AllDoctorCard[i]; //dataBase.GetDoctor(p.PatientId);

                if (lastDoctor != null)
                    properties = new string[] { p.FullName, p.PatientId, "N/A", lastDoctor.UserName, p.Gender.ToString(), $"{p.Ethnicity}" };
                else
                    properties = new string[] { p.FullName, p.PatientId, "N/A", "N/A", p.Gender.ToString(), $"{p.Ethnicity}" };

                LViewPatientList.Items.Add(new ListViewItem(properties));
            }
        }

        private void NewPatient_Click(object sender, EventArgs e)
        {
            
        }

        private void Search_Changed(object sender, EventArgs e)
        {
            if (TxtSearch.Text.Equals("") || TxtSearch.Text.Equals(" "))
            {
                InitPatientsList();
                TxtSearch.Text = "";
            }

            LViewPatientList.Items.Clear();
            try
            {
                string[] properties;
                int IdSearch = int.Parse(TxtSearch.Text);

                foreach (Patient p in patients)
                {
                    if (TxtSearch.Text.Length <= p.PatientId.Length && p.PatientId.Substring(0, TxtSearch.Text.Length).Equals(TxtSearch.Text))
                    {
                        DoctorCard lastDoctor = null;
                        for (int i = 0; i < dataBase.AllDoctorCard.Count; i++)
                            if (p.LastDoctor.Equals(dataBase.AllDoctorCard[i].UserName))
                                lastDoctor = dataBase.AllDoctorCard[i]; //dataBase.GetDoctor(p.PatientId);

                        if (lastDoctor != null)
                            properties = new string[] { p.FullName, p.PatientId, "N/A", lastDoctor.UserName, p.Gender.ToString(), $"{p.Ethnicity}" };
                        else
                            properties = new string[] { p.FullName, p.PatientId, "N/A", "N/A", p.Gender.ToString(), $"{p.Ethnicity}" };
                    }
                }
            }
            catch (Exception ee)
            {
                Debug.WriteLine("sdasd");
                string[] properties;
                foreach (Patient p in patients)
                {
                    if (TxtSearch.Text.Length <= p.FullName.Length && p.FullName.ToLower().Substring(0, TxtSearch.Text.Length).Equals(TxtSearch.Text.ToLower()))
                    {
                        DoctorCard lastDoctor = null;
                        for (int i = 0; i < dataBase.AllDoctorCard.Count; i++)
                            if (p.LastDoctor.Equals(dataBase.AllDoctorCard[i].UserName))
                                lastDoctor = dataBase.AllDoctorCard[i]; //dataBase.GetDoctor(p.PatientId);

                        if (lastDoctor != null)
                            properties = new string[] { p.FullName, p.PatientId, "N/A", lastDoctor.UserName, p.Gender.ToString(), $"{p.Ethnicity}" };
                        else
                            properties = new string[] { p.FullName, p.PatientId, "N/A", "N/A", p.Gender.ToString(), $"{p.Ethnicity}" };
                    }
                }
            }
        }

        private void LViewPatientList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatientData PD = new PatientData(patients[LViewPatientList.SelectedItems[0].Index]);
            this.Hide();
            PD.SetDesktopLocation(this.DesktopLocation.X, this.DesktopLocation.Y);
            PD.ShowDialog();
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

        private void PatientsList_Load(object sender, EventArgs e)
        {
            control = PPatientsList;

            STSManager.GetManager.SetStringPathHelp("../../../");

            dataBase = STSManager.GetManager;
            dataBase.Init();

            dataBase.DatabaseLoadDone += Manager_DataBaseLoadDone;

            if (dataBase.IsDatabaseLoaded)
            {
                docs = dataBase.AllDoctorCard;
                patients = dataBase.AllPatients;
                visits = dataBase.AllVisits;

                InitPatientsList();
            }
        }

        Control control;

        private void Manager_DataBaseLoadDone(bool res)
        {
            control.BeginInvoke((MethodInvoker)delegate ()
            {
                docs = dataBase.AllDoctorCard;
                patients = dataBase.AllPatients;
                visits = dataBase.AllVisits;

                InitPatientsList();
            });
        }
    }
}
