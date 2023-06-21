using CommonLib;
using ImplementationLib;
using InterfacesLib;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace STSGui
{
    public partial class AllVisitsItem : UserControl
    {
        #region Private Members

        private PatientVisit currentVisit = null;

        Color blackTextColor;
        Color itemBackColor;

        #endregion

        #region Constructor / Control_Load

        public AllVisitsItem()
        {
            InitializeComponent();
        }

        private void AllVisitsItem_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            PostLanguageChangedInit();
            SubscrubeForManagerEvents();
        }

        #endregion

        #region Property

        #region CurrentPatientCard

        public PatientVisit CurrentVisit
        {
            get
            {
                return currentVisit;
            }
            set
            {
                {
                    if (this.DesignMode)
                        return;

                    currentVisit = value;
                    InitPatient();
                }
            }
        }

        #endregion


        #endregion

        #region Events


        public static event Action<PatientVisit> RightButtonClick;
        public static event Action<PatientVisit> DeleteButtonClick;

        #endregion

        #region Get Manager

        private ISTSManager Manager
        {
            get => STSManager.GetManager;
        }

        #endregion

        #region Public Functions

        public void Reset()
        {
            itemBackgroundPictureBox.BackColor = Color.Transparent;
            statusPictureBox.BackColor = Color.Transparent;
            pulseLabel.BackColor = Color.Transparent;
            tempertureLabel.BackColor = Color.Transparent;
            dateVisitLabel.BackColor = Color.Transparent;
            doctorFirstLastNameLabel.BackColor = Color.Transparent;
            bloodPresureLabel.BackColor = Color.Transparent;
            testTypeLabel.BackColor = Color.Transparent;
        }
        #endregion

        #region Private Functions

        private void SubscrubeForManagerEvents()
        {

        }

        #region Service Functions

        private void PostLanguageChangedInit()
        {
            openExtentionPictureBox.Visible = true;

            InitBitmapControls();
            InitColor();
            InitPatient();
            InitBitmaps();

        }
        private void InitBitmaps()
        {
        }

        private void InitColor()
        {
            blackTextColor = System.Drawing.ColorTranslator.FromHtml("#353840");
            itemBackColor = Color.FromArgb(199,225,252);
            LabelsSetForeColor(blackTextColor);

        }

        private void InitBitmapControls()
        {
            //statusPictureBox.BorderStyle = BorderStyle.None;
            //pulseLabel.BorderStyle = BorderStyle.None;
            //tempertureLabel.BorderStyle = BorderStyle.None;
            //dateVisitLabel.BorderStyle = BorderStyle.None;
            //doctorFirstLastNameLabel.BorderStyle = BorderStyle.None;
            //bloodPresureLabel.BorderStyle = BorderStyle.None;
            //testTypeLabel.BorderStyle = BorderStyle.None;


            GuiUtils.SetNewLocation(statusPictureBox, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(pulseLabel, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(tempertureLabel, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(dateVisitLabel, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(doctorFirstLastNameLabel, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(bloodPresureLabel, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(testTypeLabel, itemBackgroundPictureBox);

            GuiUtils.SetNewLocation(openExtentionPictureBox, itemBackgroundPictureBox);

            this.Controls.Remove(statusPictureBox);
            this.Controls.Remove(pulseLabel);
            this.Controls.Remove(tempertureLabel);
            this.Controls.Remove(dateVisitLabel);
            this.Controls.Remove(doctorFirstLastNameLabel);
            this.Controls.Remove(bloodPresureLabel);
            this.Controls.Remove(testTypeLabel);

            this.Controls.Remove(openExtentionPictureBox);

            itemBackgroundPictureBox.Controls.Add(statusPictureBox);
            itemBackgroundPictureBox.Controls.Add(pulseLabel);
            itemBackgroundPictureBox.Controls.Add(tempertureLabel);
            itemBackgroundPictureBox.Controls.Add(dateVisitLabel);
            itemBackgroundPictureBox.Controls.Add(doctorFirstLastNameLabel);
            itemBackgroundPictureBox.Controls.Add(bloodPresureLabel);
            itemBackgroundPictureBox.Controls.Add(testTypeLabel);

            itemBackgroundPictureBox.Controls.Add(openExtentionPictureBox);
        }

        private void LabelsSetForeColor(Color textColor)
        {
            pulseLabel.ForeColor = textColor;
            tempertureLabel.ForeColor = textColor;
            dateVisitLabel.ForeColor = textColor;
            doctorFirstLastNameLabel.ForeColor = textColor;
            bloodPresureLabel.ForeColor = textColor;
            testTypeLabel.ForeColor = textColor;
        }

        private void InitPatient()
        {
            openExtentionPictureBox.Visible = true;
            if (currentVisit == null)
            {
                pulseLabel.Text = "";
                tempertureLabel.Text = "";
                dateVisitLabel.Text = "";
                doctorFirstLastNameLabel.Text = "";
                bloodPresureLabel.Text = "";
                testTypeLabel.Text = "";

                statusPictureBox.Image = null;
                statusPictureBox.Tag = false;


            }
            else
            {
                pulseLabel.Text = $"{currentVisit.Pulse}";
                tempertureLabel.Text = $"{currentVisit.Temperture}";
                dateVisitLabel.Text = currentVisit.VisitDateTime.ToString("dd/MM/yy");
                doctorFirstLastNameLabel.Text = currentVisit.Doctor.FullName;
                bloodPresureLabel.Text = currentVisit.BloodPresure;
                testTypeLabel.Text = currentVisit.TestType == Enum_TestType.Spiro_TLC? $"Spiro and TLC" : $"{currentVisit.TestType}";

                statusPictureBox.Visible = currentVisit.TestStatus == Enum_TestStatus.Finished;


                LabelsSetForeColor(blackTextColor);
            }
        }

        #endregion

        #region Buttons Click Functions

        private void openExtentionPictureBox_Click(object sender, EventArgs e)
        {
            if (currentVisit == null)
                return;
            RightButtonClick?.Invoke(currentVisit);

        }




        #endregion


        private void idLabel_Click(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            //ToolTip1.SetToolTip(parameter_2_Label, currentVisit.PatientId);
            //Clipboard.SetText(currentVisit.PatientId);
        }

        private void firstNameLabel_Click(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            //ToolTip1.SetToolTip(nameLabel, currentPatient.Patient.FirstName);//Need Impl
            //Clipboard.SetText(currentPatient.Patient.FirstName);

        }

        private void lastNameLabel_Click(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            //ToolTip1.SetToolTip(lastNameLabel, currentPatient.Patient.LastName);//Need Impl
            //Clipboard.SetText(currentPatient.Patient.LastName);
        }

        private void doctorFirstLastNameLabel_Click(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            //ToolTip1.SetToolTip(doctorFirstLastNameLabel, currentPatient.Doctor.FullName);//Need Impl
            //Clipboard.SetText(currentPatient.Doctor.FullName);
        }

        private void settingsPictureBox_MouseEnter(object sender, EventArgs e)
        {
            itemBackgroundPictureBox.BackColor = itemBackColor;
        }

        private void settingsPictureBox_MouseLeave(object sender, EventArgs e)
        {
            itemBackgroundPictureBox.BackColor = Color.Transparent;
        }

        private void parameterLabel_MouseEnter(object sender, EventArgs e)
        {
            itemBackgroundPictureBox.BackColor = itemBackColor;
        }

        #endregion

        private void deleteExtentionPictureBox_Click(object sender, EventArgs e)
        {
            if (currentVisit == null)
                return;
            DeleteButtonClick?.Invoke(currentVisit);
        }
    }
}
