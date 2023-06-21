using CommonLib;
using InterfacesLib;
using ImplementationLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patientlist
{
    public partial class MainPage : Form
    {
        private ISTSManager dataBase;
        private List<PatientVisit> visits;

        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnToList_Click(object sender, EventArgs e)
        {
            PatientsList PL = new PatientsList();
            this.Hide();
            PL.SetDesktopLocation(this.DesktopLocation.X, this.DesktopLocation.Y);
            PL.ShowDialog();
            this.Close();
        }
    
        public void InitRecentVisited()
        {
            visits = visits.OrderBy(o => o.VisitDateTime).ToList();
            visits.Reverse();

            string[] properties;
            foreach (PatientVisit v in visits)
            {
                properties = new string[] { v.Patient.FullName, v.Patient.PatientId, v.VisitDateTime.ToString("dd MMMM yyyy"), v.Doctor.UserName};
                LViewRecentVisited.Items.Add(new ListViewItem(properties));
            }
        }

        private void LViewRecentVisited_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatientData PD = new PatientData(visits[LViewRecentVisited.SelectedItems[0].Index].Patient);
            this.Hide();
            PD.SetDesktopLocation(this.DesktopLocation.X, this.DesktopLocation.Y);
            PD.ShowDialog();
            this.Close();
        }

        private void Search_Changed(object sender, EventArgs e)
        {
            if (TxtSearch.Text.Equals("") || TxtSearch.Text.Equals(" "))
            {
                InitRecentVisited();
                TxtSearch.Text = "";
            }

            LViewRecentVisited.Items.Clear();
            try
            {
                string[] properties;
                int IdSearch = int.Parse(TxtSearch.Text);
                foreach (PatientVisit v in visits)
                {
                    if (TxtSearch.Text.Length <= v.Patient.PatientId.Length && v.Patient.PatientId.Substring(0, TxtSearch.Text.Length).Equals(TxtSearch.Text))
                    {
                        properties = new string[] { v.Patient.FullName, v.Patient.PatientId, v.VisitDateTime.ToString("dd MMMM yyyy"), v.Doctor.UserName };
                        LViewRecentVisited.Items.Add(new ListViewItem(properties));
                    }
                }
            }
            catch (Exception ee)
            {
                string[] properties;
                foreach (PatientVisit v in visits)
                {
                    if (TxtSearch.Text.Length <= v.Patient.FullName.Length && v.Patient.FullName.ToLower().Substring(0, TxtSearch.Text.Length).Equals(TxtSearch.Text.ToLower()))
                    {
                        properties = new string[] { v.Patient.FullName, v.Patient.PatientId, v.VisitDateTime.ToString("dd MMMM yyyy"), v.Doctor.UserName };
                        LViewRecentVisited.Items.Add(new ListViewItem(properties));
                    }
                }
            }
        }

        private void BtnAddPatient_Click(object sender, EventArgs e)
        {

        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            //dataBase = DBWrapper.STSDBWrapper.GetDBWrapper;

            dataBase = STSManager.GetManager;
            visits = dataBase.AllVisits;

            InitRecentVisited();
        }
    }
}
