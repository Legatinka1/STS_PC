using CommonLib;
using ImplementationLib;
using InterfacesLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STSGui
{
    public partial class ShortPatientDetails : UserControl
    {
        #region Private Members

        Patient currentPatient = null;

        private Bitmap cloneBitmap;

        private bool isInit = false;

        #endregion

        #region Constructor / Control_Load

        public ShortPatientDetails()
        {
            InitializeComponent();
        }

        private void ShortPatientDetails_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            isInit = false;

            cloneBitmap = new Bitmap(this.Width, this.Height);

            InitColor();
            InitUnits();

            isInit = true;
        }

        #endregion

        #region Events

        public event Action<Patient> EditPatientDetails;

        #endregion

        #region Get Manager

        private ISTSManager Manager
        {
            get => STSManager.GetManager;
        }

        #endregion

        #region Public Functions

        public void ResetControls()
        {

        }

        public void SetPatient(Patient patient)
        {
            currentPatient = patient;

            SetPatientImpl();
            patientDetails_Name_Label.Focus();
            Thread.Sleep(100);
        }

        #endregion

        #region Private Functions

        private void SetPatientImpl()
        {
            if(currentPatient == null)
            {
                patientName_Value_Label.Text = "";
                patientAge_Value_Label.Text = "";
                patientID_Value_Label.Text = "";
                patientPhone_Value_Label.Text = "";

                photoPictureBox.Image = null;

                birthDate_Value_Label.Text = "";
                gender_Value_Label.Text = "";
                ethnicity_Value_Label.Text = "";
                height_Value_Label.Text = "";
                weight_Value_Label.Text = "";
                bmi_Value_Label.Text = "";
                medications_Value_Label.Text = "";
                smoking_Value_Label.Text = "";
                smokingStatusPictureBox.Image = null;
                address_Value_Label.Text = "";

            }
            else
            {
                patientName_Value_Label.Text = $"{currentPatient.FullName}";
                patientAge_Value_Label.Text = $"{Math.Round((DateTime.Now-currentPatient.BirthDate).TotalDays/365,0)}";
                patientID_Value_Label.Text = $"{currentPatient.PatientId}";
                patientPhone_Value_Label.Text = $"{currentPatient.PhoneNumber}";

                photoPictureBox.Image = currentPatient.PatientPicture;

                birthDate_Value_Label.Text = $"{currentPatient.BirthDate.ToString("dd/MM/yyyy")}";
                gender_Value_Label.Text = $"{currentPatient.Gender}";
                ethnicity_Value_Label.Text = $"{currentPatient.Ethnicity}";
                height_Value_Label.Text = $"{Math.Round(currentPatient.Height, 0)}";
                weight_Value_Label.Text = $"{Math.Round(currentPatient.Weight,0)}";
                bmi_Value_Label.Text = $"{Math.Round(Manager.GetBMI(currentPatient),1)}";
                medications_Value_Label.Text = $"{currentPatient.MedicationDescription}"; // Avi
                if (currentPatient.Medication == Enum_Medication.Yes) //Avi
                    medicationsStatusPictureBox.Image = Properties.Resources.patients_details_green_res_ellipse;
                else
                    medicationsStatusPictureBox.Image = Properties.Resources.patients_details_red_res_ellipse;
                smoking_Value_Label.Text = $"{currentPatient.SmokingDescription}";
                if(currentPatient.Smoking == Enum_Smoking.Yes)
                    smokingStatusPictureBox.Image = Properties.Resources.patients_details_green_res_ellipse;
                else
                    smokingStatusPictureBox.Image = Properties.Resources.patients_details_red_res_ellipse;
                address_Value_Label.Text = $"{currentPatient.PatientAdress}";

            }



        }
        private void InitColor()
        {

            this.BackColor = Color.FromArgb(247, 248, 252);
//            itemBackgroundPictureBox.BackColor = Color.FromArgb(138, 192, 252);



            Color textcolor = Color.FromArgb(110, 157, 209);

            patientDetails_Name_Label.ForeColor = textcolor;

            textcolor = Color.FromArgb(255, 255, 255);

            patientName_Value_Label.ForeColor = textcolor;
            patientAge_Value_Label.ForeColor = textcolor;
            patientID_Value_Label.ForeColor = textcolor;
            patientPhone_Value_Label.ForeColor = textcolor;

            textcolor = Color.FromArgb(37, 55, 86);

            patientName_Name_Label.ForeColor = textcolor;
            patientAge_Name_Label.ForeColor = textcolor;
            patientID_Name_Label.ForeColor = textcolor;
            patientPhone_Name_Label.ForeColor = textcolor;


            textcolor = Color.FromArgb(149, 158, 172);

            birthDate_Name_Label.ForeColor = textcolor;
            gender_Name_Label.ForeColor = textcolor;
            ethnicity_Name_Label.ForeColor = textcolor;
            height_Name_Label.ForeColor = textcolor;
            weight_Name_Label.ForeColor = textcolor;
            bmi_Name_Label.ForeColor = textcolor;
            medications_Name_Label.ForeColor = textcolor;
            smoking_Name_Label.ForeColor = textcolor;
            address_Name_Label.ForeColor = textcolor;

            textcolor = Color.FromArgb(92, 105, 128);

            birthDate_Value_Label.ForeColor = textcolor;
            gender_Value_Label.ForeColor = textcolor;
            ethnicity_Value_Label.ForeColor = textcolor;
            height_Value_Label.ForeColor = textcolor;
            weight_Value_Label.ForeColor = textcolor;
            bmi_Value_Label.ForeColor = textcolor;
            medications_Value_Label.ForeColor = textcolor;
            smoking_Value_Label.ForeColor = textcolor;
            address_Value_Label.ForeColor = textcolor;

        }
        private void InitUnits()
        {
            if (Manager.UnitSystem == Enum_Unit_System.Metric)
            {
                height_Name_Label.Text = "Height (cm)";
                weight_Name_Label.Text = "Weight (kg)";
            }
            else if (Manager.UnitSystem == Enum_Unit_System.USA)
            {
                height_Name_Label.Text = "Height (inch)";
                weight_Name_Label.Text = "Weight (pound)";
            }
            else if (Manager.UnitSystem == Enum_Unit_System.Imperial)
            {
                height_Name_Label.Text = "Height (inch)";
                weight_Name_Label.Text = "Weight (pound)";
            }
            else
            {
                height_Name_Label.Text = "Height ";
                weight_Name_Label.Text = "Weight ";
            }
        }

        private void editButtonPictureBox_Click(object sender, EventArgs e)
        {
            EditPatientDetails?.Invoke(currentPatient);
        }


        #endregion
    }
}
