using CommonLib;
using ImplementationLib;
using InterfacesLib;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace STSGui
{
    public partial class RecentlyVisitedItem : UserControl
    {
        #region Private Members

        private Patient currentPatient = null;

        Color blackTextColor;
        Color itemBackColor;

        #endregion

        #region Constructor / Control_Load

        public RecentlyVisitedItem()
        {
            InitializeComponent();
        }

        private void RecentlyVisitedItem_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            PostLanguageChangedInit();
            SubscrubeForManagerEvents();
        }

        #endregion

        #region Property

        #region CurrentPatientCard

        public Patient CurrentPatient
        {
            get
            {
                return currentPatient;
            }
            set
            {
                {
                    if (this.DesignMode)
                        return;

                    currentPatient = value;
                    InitPatient();
                }
            }
        }

        #endregion


        #endregion

        #region Events


        public static event Action<Patient> RightButtonClick;

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
            photoPictureBox.BackColor = Color.Transparent;
            nameLabel.BackColor = Color.Transparent;
            idLabel.BackColor = Color.Transparent;
            dateLabel.BackColor = Color.Transparent;
            doctorFirstLastNameLabel.BackColor = Color.Transparent;
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
            TopLabelsSetForeColor(blackTextColor);

        }

        private void InitBitmapControls()
        {
            //photoPictureBox.BorderStyle = BorderStyle.None;
            //nameLabel.BorderStyle = BorderStyle.None;
            //idLabel.BorderStyle = BorderStyle.None;
            //dateLabel.BorderStyle = BorderStyle.None;
            //doctorFirstLastNameLabel.BorderStyle = BorderStyle.None;
            //genderLabel.BorderStyle = BorderStyle.None;
            //ethnicityLabel.BorderStyle = BorderStyle.None;


            GuiUtils.SetNewLocation(photoPictureBox, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(nameLabel, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(idLabel, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(dateLabel, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(doctorFirstLastNameLabel, itemBackgroundPictureBox);

            GuiUtils.SetNewLocation(openExtentionPictureBox, itemBackgroundPictureBox);

            this.Controls.Remove(photoPictureBox);
            this.Controls.Remove(nameLabel);
            this.Controls.Remove(idLabel);
            this.Controls.Remove(dateLabel);
            this.Controls.Remove(doctorFirstLastNameLabel);

            this.Controls.Remove(openExtentionPictureBox);

            itemBackgroundPictureBox.Controls.Add(photoPictureBox);
            itemBackgroundPictureBox.Controls.Add(nameLabel);
            itemBackgroundPictureBox.Controls.Add(idLabel);
            itemBackgroundPictureBox.Controls.Add(dateLabel);
            itemBackgroundPictureBox.Controls.Add(doctorFirstLastNameLabel);

            itemBackgroundPictureBox.Controls.Add(openExtentionPictureBox);
        }

        private void TopLabelsSetForeColor(Color textColor)
        {
            nameLabel.ForeColor = textColor;
            idLabel.ForeColor = textColor;
            dateLabel.ForeColor = textColor;
            doctorFirstLastNameLabel.ForeColor = textColor;
        }

        private void InitPatient()
        {
            openExtentionPictureBox.Visible = true;
            if (currentPatient == null)
            {
                nameLabel.Text = "";
                idLabel.Text = "";
                dateLabel.Text = "";
                doctorFirstLastNameLabel.Text = "";

                photoPictureBox.Image = null;
                photoPictureBox.Tag = false;


            }
            else
            {
                nameLabel.Text = $"{currentPatient.FullName}";
                idLabel.Text = currentPatient.PatientId;

                //Avi
                try
                {
                    if (currentPatient.Visited.Count > 0)
                    {
                        dateLabel.Text =
                            currentPatient.Visited[0].VisitDateTime
                                .ToString("dd/MM/yy"); // currentPatient.BirthDate.ToString("dd/MM/yy"); Avi
                        doctorFirstLastNameLabel.Text =
                            currentPatient.Visited[0].Doctor.FullName; //currentPatient.FullName; Avi
                    }
                }
                catch(Exception e)
                {
                    dateLabel.Text = currentPatient.BirthDate.ToString("dd/MM/yy");
                    doctorFirstLastNameLabel.Text = currentPatient.FullName; 
                }

                photoPictureBox.Image = currentPatient.PatientPicture;


                TopLabelsSetForeColor(blackTextColor);
            }
        }

        #endregion

        #region Buttons Click Functions

        private void openExtentionPictureBox_Click(object sender, EventArgs e)
        {
            if (currentPatient == null)
                return;
            RightButtonClick?.Invoke(currentPatient);

        }




        #endregion


        private void idLabel_Click(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(idLabel, currentPatient.PatientId);
            Clipboard.SetText(currentPatient.PatientId);
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

    }
}
