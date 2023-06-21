using CommonLib;
using ImplementationLib;
using InterfacesLib;
using STSGui.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STSGui
{
    public partial class EditShortPatientDetails : UserControl
    {
        #region Private Members

        Patient currentPatient = null;

        private Bitmap cloneBitmap;

        private bool isInit = false;

        private bool ignoreChanges = true;
        
        private bool newPatient = false;

        MonthCalendarForm monthCalendarForm = null;

        #endregion

        #region Constructor / Control_Load

        public EditShortPatientDetails()
        {
            InitializeComponent();
        }

        private void EditShortPatientDetails_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            isInit = false;

            cloneBitmap = new Bitmap(this.Width, this.Height);

            InitColor();
            InitBitmapControls();
            InitComboBox();
            InitRadioButtons();
            InitUnits();


            isInit = true;
        }

        private void InitComboBox()
        {
            ethnicity_Value_ComboBoxClean.Items.Clear();

            foreach (var item in Enum.GetNames(typeof(ENUM_Ethnicity)))
            {
                ethnicity_Value_ComboBoxClean.Items.Add(item);
            }
        }

        #endregion

        #region Events

        public event Action<Patient> SavePatientDetails;
        public event Action<Patient> PatientDetailsChanged;
        public event Action CancelSavePatientDetails;

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

            ignoreChanges = true;
            newPatient = false;
            SetPatientImpl();
            if (currentPatient == null)
            {
                newPatient = true;
                currentPatient = Manager.CreateNewPatient();
                SetPatientImpl();
                PatientDetailsChanged?.Invoke(currentPatient);
            }
            patientDetails_Name_Label.Focus();
            Thread.Sleep(100);
            ignoreChanges = false;
        }

        #endregion


        #region Private Functions

        private void InitRadioButtons()
        {
            List<SmallRadioButton> partners = new List<SmallRadioButton>() { femaleSmallRadioButton, maleSmallRadioButton };
            foreach (var item in partners)
            {
                femaleSmallRadioButton.AddPartner(item);
                maleSmallRadioButton.AddPartner(item);
            }
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

        private void InitColor()
        {

            this.BackColor = Color.FromArgb(247, 248, 252);

            Color itemBackgroundColotr = Color.FromArgb(138, 192, 252);
 //           itemBackgroundPictureBox.BackColor = itemBackgroundColotr;

            patientName_Name_Label.BackColor = itemBackgroundColotr;
            patientID_Name_Label.BackColor = itemBackgroundColotr;
            address_Name_Label.BackColor = itemBackgroundColotr;
            patientPhone_Name_Label.BackColor = itemBackgroundColotr;
            birthDate_Name_Label.BackColor = itemBackgroundColotr;

            fullNamePanel.BackColor = itemBackgroundColotr;
            patientID_Value_Panel.BackColor = itemBackgroundColotr;
            address_Value_Panel.BackColor = itemBackgroundColotr;
            patientPhone_Value_Panel.BackColor = itemBackgroundColotr;
            birthDate_Value_Panel.BackColor = itemBackgroundColotr;


            fullNameTextBox.BackColor = itemBackgroundColotr;
            patientID_Value_TextBox.BackColor = itemBackgroundColotr;
            address_Value_TextBox.BackColor = itemBackgroundColotr;
            patientPhone_Value_TextBox.BackColor = itemBackgroundColotr;
            birthDate_Value_TextBox.BackColor = itemBackgroundColotr;

            Color textcolor = Color.FromArgb(110, 157, 209);

            patientDetails_Name_Label.ForeColor = textcolor;

            textcolor = Color.FromArgb(255, 255, 255);

            fullNameTextBox.ForeColor = textcolor;
            birthDate_Value_TextBox.ForeColor = textcolor;
            patientID_Value_TextBox.ForeColor = textcolor;
            patientPhone_Value_TextBox.ForeColor = textcolor;

            textcolor = Color.FromArgb(37, 55, 86);

            patientName_Name_Label.ForeColor = textcolor;
            birthDate_Name_Label.ForeColor = textcolor;
            patientID_Name_Label.ForeColor = textcolor;
            patientPhone_Name_Label.ForeColor = textcolor;


            textcolor = Color.FromArgb(149, 158, 172);

            gender_Name_Label.ForeColor = textcolor;
            ethnicity_Name_Label.ForeColor = textcolor;
            height_Name_Label.ForeColor = textcolor;
            weight_Name_Label.ForeColor = textcolor;
            bmi_Name_Label.ForeColor = textcolor;
            medications_Name_Label.ForeColor = textcolor;
            smoking_Name_Label.ForeColor = textcolor;

            textcolor = Color.FromArgb(92, 105, 128);

            gender_Female_Name_Label.ForeColor = textcolor;
            gender_Male_Name_Label.ForeColor = textcolor;

            ethnicity_Value_ComboBoxClean.ForeColor = textcolor;
            height_Value_TextBox.ForeColor = textcolor;
            weight_Value_TextBox.ForeColor = textcolor;
            bmi_Value_TextBox.ForeColor = textcolor;
            medications_Value_TextBox.ForeColor = textcolor;
            smoking_Value_TextBox.ForeColor = textcolor;
            address_Value_TextBox.ForeColor = textcolor;

        }

        private void InitBitmapControls()
        {
            GuiUtils.SetNewLocation(patientName_Name_Label, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(patientID_Name_Label, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(address_Name_Label, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(patientPhone_Name_Label, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(birthDate_Name_Label, itemBackgroundPictureBox);

            GuiUtils.SetNewLocation(fullNamePanel, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(patientID_Value_Panel, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(address_Value_Panel, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(patientPhone_Value_Panel, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(birthDate_Value_Panel, itemBackgroundPictureBox);


            this.Controls.Remove(patientName_Name_Label);
            this.Controls.Remove(patientID_Name_Label);
            this.Controls.Remove(address_Name_Label);
            this.Controls.Remove(patientPhone_Name_Label);
            this.Controls.Remove(birthDate_Name_Label);
           
            this.Controls.Remove(fullNamePanel);
            this.Controls.Remove(patientID_Value_Panel);
            this.Controls.Remove(address_Value_Panel);
            this.Controls.Remove(patientPhone_Value_Panel);
            this.Controls.Remove(birthDate_Value_Panel);

            itemBackgroundPictureBox.Controls.Add(patientName_Name_Label);
            itemBackgroundPictureBox.Controls.Add(patientID_Name_Label);
            itemBackgroundPictureBox.Controls.Add(address_Name_Label);
            itemBackgroundPictureBox.Controls.Add(patientPhone_Name_Label);
            itemBackgroundPictureBox.Controls.Add(birthDate_Name_Label);

            itemBackgroundPictureBox.Controls.Add(fullNamePanel);
            itemBackgroundPictureBox.Controls.Add(patientID_Value_Panel);
            itemBackgroundPictureBox.Controls.Add(address_Value_Panel);
            itemBackgroundPictureBox.Controls.Add(patientPhone_Value_Panel);
            itemBackgroundPictureBox.Controls.Add(birthDate_Value_Panel);
        }


        private void gender_Female_Name_Label_Click(object sender, EventArgs e)
        {
            femaleSmallRadioButton.Checked = true;
            maleSmallRadioButton.Checked = false;
        }

        private void gender_Male_Name_Label_Click(object sender, EventArgs e)
        {
            femaleSmallRadioButton.Checked = false;
            maleSmallRadioButton.Checked = true;
        }


        private void cancelButtonPictureBox_Click(object sender, EventArgs e)
        {
            CancelSavePatientDetails?.Invoke();
        }

        private void saveButtonPictureBox_Click(object sender, EventArgs e)
        {
            if (!IsSaveButtonEnabled())
            {
                saveButtonPictureBox.Enabled = false;
                return;
            }

            string error = UpdateCurrentPatient();
            if (error == null)
                SavePatientDetails?.Invoke(currentPatient);
            else
            {
                MessageBox.Show(error, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Save Patient Details FALSE", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetPatientImpl()
        {
            if (currentPatient == null)
            {
                fullNameTextBox.Text = "";
                patientID_Value_TextBox.Text = "";
                patientPhone_Value_TextBox.Text = "";

                birthDate_Value_TextBox.Text = "";
                birthDate_Value_TextBox.Tag = null;
                height_Value_TextBox.Text = "";
                weight_Value_TextBox.Text = "";
                bmi_Value_TextBox.Text = "";
                medications_Value_TextBox.Text = "";
                smoking_Value_TextBox.Text = "";
                address_Value_TextBox.Text = "";

                saveButtonPictureBox.Enabled = false;

            }
            else
            {
                fullNameTextBox.Text = $"{currentPatient.FullName}";
                patientID_Value_TextBox.Text = $"{currentPatient.PatientId}";
                patientPhone_Value_TextBox.Text = $"{currentPatient.PhoneNumber}";

                birthDate_Value_TextBox.Text = $"{currentPatient.BirthDate.ToString("dd/MM/yyyy")}";
                birthDate_Value_TextBox.Tag = currentPatient.BirthDate;

                if (currentPatient.Gender == Enum_Gender.Female)
                {
                    femaleSmallRadioButton.Checked = true;
                    maleSmallRadioButton.Checked = false;
                }
                else
                {
                    femaleSmallRadioButton.Checked = false;
                    maleSmallRadioButton.Checked = true;
                }
                ethnicity_Value_ComboBoxClean.SelectedIndex = (int)currentPatient.Ethnicity;
                height_Value_TextBox.Text = $"{currentPatient.Height}";
                weight_Value_TextBox.Text = $"{currentPatient.Weight}";
                double bmi = Manager.GetBMI(currentPatient);
                if (double.IsNaN(bmi))
                    bmi_Value_TextBox.Text = "";
                else
                    bmi_Value_TextBox.Text = $"{Math.Round(bmi, 1)}";

                medications_Value_TextBox.Text = $"{currentPatient.MedicationDescription}";
                if (currentPatient.Medication == Enum_Medication.Yes)
                    medicationsStatusSmallCheckBox.Checked = true;
                else
                    medicationsStatusSmallCheckBox.Checked = false;


                smoking_Value_TextBox.Text = $"{currentPatient.SmokingDescription}";
                if (currentPatient.Smoking == Enum_Smoking.Yes)
                    smokingStatusSmallCheckBox.Checked = true;
                else
                    smokingStatusSmallCheckBox.Checked = false;

                address_Value_TextBox.Text = $"{currentPatient.PatientAdress}";

                saveButtonPictureBox.Enabled = !string.IsNullOrEmpty(fullNameTextBox.Text) && !string.IsNullOrEmpty(patientID_Value_TextBox.Text);
            }
        }

        private string UpdateCurrentPatient()
        {
            string oldPatientId = currentPatient.PatientId;

            UpdateCurrentPatientImpl();

            return Manager.SavePatient(currentPatient, oldPatientId, newPatient);
        }

        private bool UpdateCurrentPatientImpl()
        {
            bool result = true;

            string[] names = fullNameTextBox.Text.Split(new char[] { ' ' });
            if (names != null)
            {
                // Avi:
                currentPatient.FullName = $"{names[0]}";
                if (names.Length == 2)
                    currentPatient.FullName += $" {names[1]}";

                /*if (names.Count() >= 1)
                    currentPatient.FullName = names[0];
                else
                    currentPatient.FullName = "";

                if (names.Count() >= 2)
                    currentPatient.FullName = names[1];
                else
                    currentPatient.FullName = "";*/
            }
            currentPatient.PatientId = patientID_Value_TextBox.Text; //Avi: (can't change ID)
            currentPatient.PhoneNumber = patientPhone_Value_TextBox.Text; // Avi: patientPhone_Value_TextBox.Text = $"{currentPatient.PhoneNumber}";

            try
            {
                DateTime currentBirthDate = Convert.ToDateTime(birthDate_Value_TextBox.Tag);
                if (currentBirthDate != null)
                    currentPatient.BirthDate = currentBirthDate;
            }
            catch (Exception ee)
            {

            }

            if (femaleSmallRadioButton.Checked)
                currentPatient.Gender = Enum_Gender.Female;
            else
                currentPatient.Gender = Enum_Gender.Male;

            currentPatient.Ethnicity = (ENUM_Ethnicity)Enum.Parse(typeof(ENUM_Ethnicity), ethnicity_Value_ComboBoxClean.SelectedItem.ToString(), true); // Avi: currentPatient.Ethnicity = (ENUMEthnicity)ethnicity_Value_ComboBoxClean.SelectedItem;
            double tempDouble = 0;
            if (double.TryParse(height_Value_TextBox.Text, out tempDouble))
                currentPatient.Height = tempDouble;

            if (double.TryParse(weight_Value_TextBox.Text, out tempDouble))
                currentPatient.Weight = tempDouble;

            if (medicationsStatusSmallCheckBox.Checked)
                currentPatient.Medication = Enum_Medication.Yes;
            else
                currentPatient.Medication = Enum_Medication.None;

            currentPatient.MedicationDescription = medications_Value_TextBox.Text;
            //bmi_Value_TextBox.Text = $"{Math.Round(Manager.GetBMI(currentPatient), 1)}";

            currentPatient.SmokingDescription = smoking_Value_TextBox.Text;
            if (smokingStatusSmallCheckBox.Checked)
                currentPatient.Smoking = Enum_Smoking.Yes;
            else
                currentPatient.Smoking = Enum_Smoking.Not;

            currentPatient.PatientAdress = address_Value_TextBox.Text;

            PatientDetailsChanged?.Invoke(currentPatient);
            return result;

        }


        private void patientPhone_Value_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void itemBackgroundPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void patientPhone_Value_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void maleSmallRadioButton_Load(object sender, EventArgs e)
        {

        }

        private void femaleSmallRadioButton_Load(object sender, EventArgs e)
        {

        }

        private void height_Value_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!(char.IsDigit(c) || c == '.'))
                e.Handled = true;

        }

        private void weight_Value_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!(char.IsDigit(c) || c == '.'))
                e.Handled = true;

        }

        private void height_Value_TextBox_Validated(object sender, EventArgs e)
        {
            UpdateCurrentPatientImpl();
            double bmi = Manager.GetBMI(currentPatient);
            if (double.IsNaN(bmi))
                bmi_Value_TextBox.Text = "";
            else
                bmi_Value_TextBox.Text = $"{Math.Round(bmi, 1)}";

            saveButtonPictureBox.Enabled = IsSaveButtonEnabled();

        }

        private void weight_Value_TextBox_Validated(object sender, EventArgs e)
        {
            UpdateCurrentPatientImpl();
            double bmi = Manager.GetBMI(currentPatient);
            if (double.IsNaN(bmi))
                bmi_Value_TextBox.Text = "";
            else
                bmi_Value_TextBox.Text = $"{Math.Round(bmi, 1)}";

            saveButtonPictureBox.Enabled = IsSaveButtonEnabled();
        }

        private void ethnicity_Value_ComboBoxClean_SelectedIndexChanged(object sender, EventArgs e)
        {
            ethnicity_Name_Label.Focus();
            if (!ignoreChanges)
                UpdateCurrentPatientImpl();

        }

        private void femaleSmallRadioButton_CheckedChanged(object arg1, bool arg2)
        {
            if (!ignoreChanges)
                UpdateCurrentPatientImpl();
        }

        private void openCalendarButtonPictureBox_Click(object sender, EventArgs e)
        {
            Point p = PointToScreen(birthDate_Value_Panel.Location);

            if (monthCalendarForm == null)
            {
                monthCalendarForm = new MonthCalendarForm();
                //p.X = p.X + birthDate_Value_Panel.Width - monthCalendarForm.Width;
                p.X = p.X + itemBackgroundPictureBox.Location.X;
                p.Y = p.Y + birthDate_Value_Panel.Height + itemBackgroundPictureBox.Location.Y;
                MonthCalendarForm.NeedLocation = p;
                monthCalendarForm.VisibleChanged += MonthCalendarForm_VisibleChanged;
                try
                {
                    monthCalendarForm.SetInitDateTime(Convert.ToDateTime(birthDate_Value_TextBox.Tag));
                }
                catch (Exception ee)
                {

                }
                monthCalendarForm.Show();
            }
            if (monthCalendarForm.Visible)
                return;
            try
            {
                monthCalendarForm.SetInitDateTime(Convert.ToDateTime(birthDate_Value_TextBox.Tag));
            }
            catch(Exception ee)
            {

            }
            monthCalendarForm.Visible = true;
            //monthCalendarForm.ShowDialog();
            //DateTime time = monthCalendarForm.SelectedTime;
            //if (time != DateTime.MinValue)
            //{
            //    birthDate_Value_TextBox.Text = $"{time.ToString("dd/MM/yyyy")}";
            //    birthDate_Value_TextBox.Tag = time;
            //}
        }

        private void MonthCalendarForm_VisibleChanged(object sender, EventArgs e)
        {
            if (monthCalendarForm.Visible)
                return;

            DateTime time = monthCalendarForm.SelectedTime;
            if (time != DateTime.MinValue)
            {
                birthDate_Value_TextBox.Text = $"{time.ToString("dd/MM/yyyy")}";
                birthDate_Value_TextBox.Tag = time;
            }

        }

        private void fullNameTextBox_Validated(object sender, EventArgs e)
        {
            saveButtonPictureBox.Enabled = IsSaveButtonEnabled();
        }

        private void patientID_Value_TextBox_Validated(object sender, EventArgs e)
        {
            saveButtonPictureBox.Enabled = IsSaveButtonEnabled();
        }

        private bool IsSaveButtonEnabled()
        {
            bool res = !string.IsNullOrEmpty(fullNameTextBox.Text) &&
                        !string.IsNullOrEmpty(patientID_Value_TextBox.Text) &&
                        !string.IsNullOrEmpty(height_Value_TextBox.Text) &&
                        !string.IsNullOrEmpty(weight_Value_TextBox.Text);

            if (!res)
                return res;

            double tempHeight = 0, tempWeight = 0;
            if (!double.TryParse(height_Value_TextBox.Text, out tempHeight) || tempHeight<=0)
                return false;
  
            if (!double.TryParse(weight_Value_TextBox.Text, out tempWeight) || tempHeight <= 0)
                return false;

            return true;
        }

        #endregion
    }
}
