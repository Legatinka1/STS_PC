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
    public partial class EditShortDoctorDetails : UserControl
    {
        #region Private Members

        DoctorCard currentDoctor = null;
        Enum_Doctor_Level doctorLevel = Enum_Doctor_Level.Techniction;

        private Bitmap cloneBitmap;

        private bool isInit = false;

        private bool ignoreChanges = true;
        
        private bool newDoctor = false;
        string oldUserName = "";

        MonthCalendarForm monthCalendarForm = null;

        #endregion

        #region Constructor / Control_Load

        public EditShortDoctorDetails()
        {
            InitializeComponent();
        }

        private void EditShortDoctorDetails_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            isInit = false;

            cloneBitmap = new Bitmap(this.Width, this.Height);

            InitColor();
            InitBitmapControls();
            InitComboBox();
            InitRadioButtons();


            isInit = true;
        }

        private void InitComboBox()
        {
            doctorsList_Value_ComboBoxClean.Items.Clear();

            List<DoctorCard> doctors = Manager.AllDoctorCard;
            if (doctors != null && doctors.Count > 0)
            {
                foreach (var item in doctors)
                {
                    doctorsList_Value_ComboBoxClean.Items.Add(item.UserName);
                }
                int index = 0;
                if(currentDoctor!=null)
                    index = doctors.FindIndex(card => card.UserName == currentDoctor.UserName && card.Password == currentDoctor.Password);
                index = Math.Max(index, 0);
                doctorsList_Value_ComboBoxClean.SelectedIndex = index;
            }
        }

        #endregion

        #region Events

        public event Action<DoctorCard> SaveDoctorDetails;
        public event Action<DoctorCard> DoctorDetailsChanged;
        public event Action CancelSaveDoctorDetails;

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

        public void SetDoctor(DoctorCard doctor)
        {
            currentDoctor = doctor;

            ignoreChanges = true;
            newDoctor = false;
            if (currentDoctor == null)
            {
                newDoctor = true;

                currentDoctor = new DoctorCard();
                doctorLevel = Enum_Doctor_Level.Admin;
            }
            else
                doctorLevel = currentDoctor.DoctorLevel;

            SetDoctorImpl();
            oldUserName = currentDoctor.UserName;

            if (newDoctor)
            {
                ethnicity_Value_Panel.Visible = false;
                doctorsList_Name_Label.Visible = false;
            }
            else
            {
                InitComboBox();
                if (currentDoctor.DoctorLevel == Enum_Doctor_Level.Admin)
                {
                    ethnicity_Value_Panel.Visible = true;
                    doctorsList_Name_Label.Visible = true;
                }
                else
                {
                    ethnicity_Value_Panel.Visible = false;
                    doctorsList_Name_Label.Visible = false;
                }
            }
            doctorDetails_Name_Label.Focus();
            Thread.Sleep(100);
            ignoreChanges = false;
        }

        #endregion


        #region Private Functions

        private void InitRadioButtons()
        {
            List<SmallRadioButton> partners = new List<SmallRadioButton>() { adminSmallRadioButton, technictionSmallRadioButton };
            foreach (var item in partners)
            {
                adminSmallRadioButton.AddPartner(item);
                technictionSmallRadioButton.AddPartner(item);
            }
        }

        private void InitColor()
        {

            this.BackColor = Color.FromArgb(247, 248, 252);

            Color itemBackgroundColotr = Color.FromArgb(138, 192, 252);
 //           itemBackgroundPictureBox.BackColor = itemBackgroundColotr;

            doctorName_Name_Label.BackColor = itemBackgroundColotr;
            creationDate_Name_Label.BackColor = itemBackgroundColotr;

            fullNamePanel.BackColor = itemBackgroundColotr;
            creationDate_Value_Panel.BackColor = itemBackgroundColotr;


            fullNameTextBox.BackColor = itemBackgroundColotr;
            creationDate_Value_TextBox.BackColor = itemBackgroundColotr;

            level_Name_Label.BackColor = itemBackgroundColotr;
            adminSmallRadioButton.BackColor = itemBackgroundColotr;
            technictionSmallRadioButton.BackColor = itemBackgroundColotr;
            level_Admin_Name_Label.BackColor = itemBackgroundColotr;
            level_Techniction_Name_Label.BackColor = itemBackgroundColotr;

            photo_Name_Label.BackColor = itemBackgroundColotr;

            userName_Name_Label.BackColor = itemBackgroundColotr;
            userName_Value_Panel.BackColor = itemBackgroundColotr;
            userName_Value_TextBox.BackColor = itemBackgroundColotr;

            password_Name_Label.BackColor = itemBackgroundColotr;
            password_Value_Panel.BackColor = itemBackgroundColotr;
            password_Value_TextBox.BackColor = itemBackgroundColotr;



            Color textcolor = Color.FromArgb(110, 157, 209);

            doctorDetails_Name_Label.ForeColor = textcolor;

            textcolor = Color.FromArgb(37, 55, 86);

            doctorName_Name_Label.ForeColor = textcolor;
            creationDate_Name_Label.ForeColor = textcolor;

            level_Name_Label.ForeColor = textcolor;
            adminSmallRadioButton.ForeColor = textcolor;
            technictionSmallRadioButton.ForeColor = textcolor;
            userName_Name_Label.ForeColor = textcolor;
            password_Name_Label.ForeColor = textcolor;
            photo_Name_Label.ForeColor = textcolor;
        }

        private void InitBitmapControls()
        {
            GuiUtils.SetNewLocation(doctorName_Name_Label, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(creationDate_Name_Label, itemBackgroundPictureBox);

            GuiUtils.SetNewLocation(fullNamePanel, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(creationDate_Value_Panel, itemBackgroundPictureBox);

            GuiUtils.SetNewLocation(level_Name_Label, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(adminSmallRadioButton, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(level_Admin_Name_Label, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(technictionSmallRadioButton, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(level_Techniction_Name_Label, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(photo_Name_Label, itemBackgroundPictureBox);
            GuiUtils.SetNewLocation(photoPictureBox, itemBackgroundPictureBox);

            this.Controls.Remove(doctorName_Name_Label);
            this.Controls.Remove(creationDate_Name_Label);
           
            this.Controls.Remove(fullNamePanel);
            this.Controls.Remove(creationDate_Value_Panel);

            this.Controls.Remove(level_Name_Label);
            this.Controls.Remove(adminSmallRadioButton);
            this.Controls.Remove(level_Admin_Name_Label);
            this.Controls.Remove(technictionSmallRadioButton);
            this.Controls.Remove(level_Techniction_Name_Label);
            this.Controls.Remove(photo_Name_Label);
            this.Controls.Remove(photoPictureBox);


            itemBackgroundPictureBox.Controls.Add(doctorName_Name_Label);
            itemBackgroundPictureBox.Controls.Add(creationDate_Name_Label);

            itemBackgroundPictureBox.Controls.Add(fullNamePanel);
            itemBackgroundPictureBox.Controls.Add(creationDate_Value_Panel);

            itemBackgroundPictureBox.Controls.Add(level_Name_Label);
            itemBackgroundPictureBox.Controls.Add(adminSmallRadioButton);
            itemBackgroundPictureBox.Controls.Add(level_Admin_Name_Label);
            itemBackgroundPictureBox.Controls.Add(technictionSmallRadioButton);
            itemBackgroundPictureBox.Controls.Add(level_Techniction_Name_Label);
            itemBackgroundPictureBox.Controls.Add(photo_Name_Label);
            itemBackgroundPictureBox.Controls.Add(photoPictureBox);
        }


        private void level_Admin_Name_Label_Click(object sender, EventArgs e)
        {
            adminSmallRadioButton.Checked = true;
            technictionSmallRadioButton.Checked = false;
        }

        private void level_Techniction_Name_Label_Click(object sender, EventArgs e)
        {
            adminSmallRadioButton.Checked = false;
            technictionSmallRadioButton.Checked = true;
        }


        private void cancelButtonPictureBox_Click(object sender, EventArgs e)
        {
            CancelSaveDoctorDetails?.Invoke();
        }

        private void saveButtonPictureBox_Click(object sender, EventArgs e)
        {
            if (!IsSaveButtonEnabled())
            {
                saveButtonPictureBox.Enabled = false;
                return;
            }

            if (UpdateCurrentPatient())
                SaveDoctorDetails?.Invoke(currentDoctor);
            else
                MessageBox.Show("Save Patient Details FALSE","Save Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void SetDoctorImpl()
        {
            if (currentDoctor == null)
            {
                fullNameTextBox.Text = "";

                creationDate_Value_TextBox.Text = "";
                creationDate_Value_TextBox.Tag = null;
                userName_Value_TextBox.Text = "";
                password_Value_TextBox.Text = "";

                photoPictureBox.Image = null;

                saveButtonPictureBox.Enabled = false;

            }
            else
            {
                fullNameTextBox.Text = $"{currentDoctor.FullName}";

                creationDate_Value_TextBox.Text = $"{currentDoctor.CreationDate.ToString("dd/MM/yyyy")}";
                creationDate_Value_TextBox.Tag = currentDoctor.CreationDate;

                if (currentDoctor.DoctorLevel == Enum_Doctor_Level.Admin)
                {
                    adminSmallRadioButton.Checked = true;
                    technictionSmallRadioButton.Checked = false;
                }
                else
                {
                    adminSmallRadioButton.Checked = false;
                    technictionSmallRadioButton.Checked = true;
                }

                bool isEnabled = doctorLevel == Enum_Doctor_Level.Admin;
                adminSmallRadioButton.Enabled = isEnabled;
                level_Admin_Name_Label.Enabled = isEnabled;

                technictionSmallRadioButton.Enabled = isEnabled;
                level_Techniction_Name_Label.Enabled = isEnabled;

                userName_Value_TextBox.Text = $"{currentDoctor.UserName}";

                photoPictureBox.Image = currentDoctor.DoctorPicture;

                password_Value_TextBox.Text = $"{currentDoctor.Password}";

                saveButtonPictureBox.Enabled = IsSaveButtonEnabled();
            }



        }
        private bool UpdateCurrentPatient()
        {
            UpdateCurrentDoctorImpl();

            return Manager.SaveDoctorCard(currentDoctor, oldUserName, newDoctor);

        }

        private bool UpdateCurrentDoctorImpl()
        {
            bool result = true;

            currentDoctor.FullName = fullNameTextBox.Text;

            try
            {
                DateTime currentCreationDate = Convert.ToDateTime(creationDate_Value_TextBox.Tag);
                if (currentCreationDate != null)
                    currentDoctor.CreationDate = currentCreationDate;
            }
            catch (Exception ee)
            {

            }

            if (adminSmallRadioButton.Checked)
                currentDoctor.DoctorLevel = Enum_Doctor_Level.Admin;
            else
                currentDoctor.DoctorLevel = Enum_Doctor_Level.Techniction;

            currentDoctor.UserName = userName_Value_TextBox.Text;

            currentDoctor.Password = password_Value_TextBox.Text;

            //DoctorDetailsChanged?.Invoke(currentDoctor);
            return result;

        }









        private void doctor_Value_ComboBoxClean_SelectedIndexChanged(object sender, EventArgs e)
        {
            doctorsList_Name_Label.Focus();
            if (!ignoreChanges)
            {
                List<DoctorCard> doctors = Manager.AllDoctorCard;
                if (doctors != null && doctors.Count > 0)
                {
                    currentDoctor = doctors[doctorsList_Value_ComboBoxClean.SelectedIndex];
                    SetDoctorImpl();
                    oldUserName = currentDoctor.UserName;

                }

            }

        }

        private void adminSmallRadioButton_CheckedChanged(object arg1, bool arg2)
        {
            //if (!ignoreChanges)
            //    UpdateCurrentDoctorImpl();
        }

        private void openCalendarButtonPictureBox_Click(object sender, EventArgs e)
        {
            Point p = PointToScreen(creationDate_Value_Panel.Location);

            if (monthCalendarForm == null)
            {
                monthCalendarForm = new MonthCalendarForm();
                //p.X = p.X + birthDate_Value_Panel.Width - monthCalendarForm.Width;
                p.X = p.X + itemBackgroundPictureBox.Location.X;
                p.Y = p.Y + creationDate_Value_Panel.Height + itemBackgroundPictureBox.Location.Y;
                MonthCalendarForm.NeedLocation = p;
                monthCalendarForm.VisibleChanged += MonthCalendarForm_VisibleChanged;
                try
                {
                    monthCalendarForm.SetInitDateTime(Convert.ToDateTime(creationDate_Value_TextBox.Tag));
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
                monthCalendarForm.SetInitDateTime(Convert.ToDateTime(creationDate_Value_TextBox.Tag));
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
                creationDate_Value_TextBox.Text = $"{time.ToString("dd/MM/yyyy")}";
                creationDate_Value_TextBox.Tag = time;
            }

        }

        private void fullNameTextBox_Validated(object sender, EventArgs e)
        {
            saveButtonPictureBox.Enabled = IsSaveButtonEnabled();
        }


        private bool IsSaveButtonEnabled()
        {
            bool res = !string.IsNullOrEmpty(fullNameTextBox.Text) &&
                       !string.IsNullOrEmpty(userName_Value_TextBox.Text) &&
                       !string.IsNullOrEmpty(password_Value_TextBox.Text);

            return res;

        }

        #endregion

        private void photoPictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (currentDoctor == null)
                return;

            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Imgae files|*.bmp;*.png;*.jpg",
                DefaultExt = "*.bmp",
                CheckFileExists = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    photoPictureBox.Image = currentDoctor.DoctorPicture = (Bitmap)Bitmap.FromFile(dialog.FileName);
                     
                }
                catch(Exception ee)
                {

                }
            }

        }

        private void userName_Value_TextBox_Validated(object sender, EventArgs e)
        {
            saveButtonPictureBox.Enabled = IsSaveButtonEnabled();
        }

        private void password_Value_TextBox_Validated(object sender, EventArgs e)
        {
            saveButtonPictureBox.Enabled = IsSaveButtonEnabled();
        }
    }
}
