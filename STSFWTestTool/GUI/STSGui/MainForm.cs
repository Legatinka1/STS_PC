using BelkinEagleGui.Forms;
using CommonLib;
using ImplementationLib;
using InterfacesLib;
using STSGui.Controls.Doctors;
using STSGui.Controls.MainPanel;
using STSGui.Forms;
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
using static BelkinEagleGui.Forms.FormBackGround;

namespace STSGui
{
    public partial class MainForm : Form
    {
        #region Private Members

        bool isMoveble = true;
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        DoctorCard currentDoctorCard = null;

        private UserControl currentOpenedControl = null;
        private PatientDetails patientDetailsPanel1;
        private LogInControl logInControlPanel1;
        private EditShortDoctorDetails editShortDoctorDetails;
        private MainPanel mainPanel;
        SettingsControl settingsPanel;

        MainMenuForm mainMenuForm = null;

        private bool first = true;

        const int currentDoctorDistance = 15;
        #endregion

        #region Constructor / Control_Load
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //InitMenu();
            lblVer.Text = Application.ProductVersion;
            allPatientsPanel1.Visible = false;
            PostLanguageChangedInit();
            InitColor();
            SubscrubeForControlsEvents();
            SubscrubeForManagerEvents();
 
            STSManager.GetManager.Init();
        }

        #endregion

        #region Get Manager

        private ISTSManager Manager
        {
            get => STSManager.GetManager;
        }

        #endregion


        #region Private Functions

        private void InitColor()
        {
            Color textColor = Color.FromArgb(113, 125, 145);

            healthClinicLabelExtended.DisableTextColor = textColor;
            healthClinicLabelExtended.MouseDownTextColor = textColor;
            healthClinicLabelExtended.MouseOverTextColor = textColor;
            healthClinicLabelExtended.NormalTextColor = textColor;

            currentDoctorLabelExtended.DisableTextColor = textColor;
            currentDoctorLabelExtended.MouseDownTextColor = textColor;
            currentDoctorLabelExtended.MouseOverTextColor = textColor;
            currentDoctorLabelExtended.NormalTextColor = textColor;



        }

        private void SubscrubeForManagerEvents()
        {
            Manager.DatabaseLoadDone += Manager_DatabaseLoadDone;
        }
        private void SubscrubeForControlsEvents()
        {
            allPatientsPanel1.OpenPatientDetails += AllPatientsPanel1_OpenPatientDetails;
            allPatientsPanel1.AddNewPatient += AllPatientsPanel1_AddNewPatient;
        }

        private void AllPatientsPanel1_AddNewPatient()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                this.InvokeIfRequired(() =>
                {
                    LoadPatientDetailsPanel(null);
                });
            });

        }

        private void AllPatientsPanel1_OpenPatientDetails(Patient patient)
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                this.InvokeIfRequired(() =>
                {
                    LoadPatientDetailsPanel(patient);
                });
            });
        }

        private void Manager_DatabaseLoadDone(bool res)
        {
            LoadLogInPanel();
        }

        #region Move Main Form Mouse Functions

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isMoveble)
                return;
            dragging = true;
            startPoint = new Point(e.X, e.Y);

        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMoveble)
                return;
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
//                Console.WriteLine($"{Location.X},{Location.Y}");
            }

        }

        private void topPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isMoveble)
                return;
            dragging = false;

        }

        #endregion

        //#region Doctor Menu Functions

        //private void upDounCurrentDoctorMenuPictureBox_Click(object sender, EventArgs e)
        //{
        //    ButtonPictureBox.SoundPlay();
        //    (currentDoctorMenuOpenClosePictureBox.Tag as ButtonTagParameters).Pressed = !(currentDoctorMenuOpenClosePictureBox.Tag as ButtonTagParameters).Pressed;
        //    UpdateOpenMenuPicture();

        //}
        //private void UpdateOpenMenuPicture()
        //{
        //    bool isPressed = (currentDoctorMenuOpenClosePictureBox.Tag as ButtonTagParameters).Pressed;

        //    if (isPressed)
        //        currentDoctorMenuOpenClosePictureBox.Image = Properties.Resources.top_panel_arrow_up;
        //    else
        //        currentDoctorMenuOpenClosePictureBox.Image = Properties.Resources.top_panel_arrow_down;
        //}

        //private void InitMenu()
        //{
        //    currentDoctorMenuOpenClosePictureBox.Tag = new ButtonTagParameters() { Pressed = false, Enabled = true };
        //    UpdateOpenMenuPicture();
        //}

        //#endregion

        #region Main Menu Functions

        private void mainMenuOpenClosePictureBox_Click(object sender, EventArgs e)
        {
            Point p = PointToScreen(mainMenuOpenClosePictureBox.Location);

            if (mainMenuForm == null)
            {
                mainMenuForm = new MainMenuForm();
                p.X = p.X + mainMenuOpenClosePictureBox.Width- mainMenuForm.Width-6;
                p.Y = p.Y + mainMenuOpenClosePictureBox.Height-10 ;
                MainMenuForm.NeedLocation = p;
                mainMenuForm.VisibleChanged += MainMenuForm_VisibleChanged; 
                mainMenuForm.Show();
            }
            if(isMoveble)
            {
                p.X = p.X + mainMenuOpenClosePictureBox.Width - mainMenuForm.Width-6;
                p.Y = p.Y + mainMenuOpenClosePictureBox.Height - 10;
                MainMenuForm.NeedLocation = p;
            }
            if (mainMenuForm.Visible)
                return;

            mainMenuForm.Visible = true;
        }

        private void MainMenuForm_VisibleChanged(object sender, EventArgs e)
        {
            if (mainMenuForm.Visible)
                return;

            MainMenuSelectedItem selectedItem = mainMenuForm.SelectedItem;
            switch (selectedItem)
            {
                case MainMenuSelectedItem.Unselected:
                    return;
                case MainMenuSelectedItem.Close:
                    Application.Exit();
                    break;
                case MainMenuSelectedItem.Minimize:
                    this.WindowState = FormWindowState.Minimized;
                    break;
                case MainMenuSelectedItem.CalibrationTest:
                    break;
                case MainMenuSelectedItem.LogOut:
                    LoadLogInPanel();
                    break;
                case MainMenuSelectedItem.EditDoctor:
                    LoadEditDoctorPanel();
                    break;
                case MainMenuSelectedItem.AddDoctor:
                    LoadAddDoctorPanel();
                    break;
                case MainMenuSelectedItem.Settings:
                    LoadSettingsPanel();
                    break;
                default:
                    break;
            }
        }

        private void LoadSettingsPanel()
        {
            this.InvokeIfRequired(() =>
            {
                if (currentOpenedControl == settingsPanel)
                    return;
                SuspendLayout();
                topLeftButtonPictureBox.Visible = false;
                settingsPanel.Visible = true;
                currentOpenedControl.Visible = false;
                initializingLabelExtended.Visible = false;
                currentOpenedControl = settingsPanel;
                if (settingsPanel != null)
                    settingsPanel.ResetControls();

                mainMenuOpenClosePictureBox.Visible = true;

                this.ResumeLayout(false);
                this.PerformLayout();
            });
        }

        private void LoadLogInPanel()
        {
            this.InvokeIfRequired(() =>
            {
                if (currentOpenedControl == logInControlPanel1)
                    return;
                SuspendLayout();
                currentDoctorLabelExtended.Visible = false;
                topLeftButtonPictureBox.Visible = true;
                logInControlPanel1.Visible = true;
                currentOpenedControl.Visible = false;
                initializingLabelExtended.Visible = false;
                currentOpenedControl = logInControlPanel1;
                if (logInControlPanel1 != null)
                    logInControlPanel1.ResetControls();

                mainMenuOpenClosePictureBox.Visible = true;

                this.ResumeLayout(false);
                this.PerformLayout();
            });

        }
        private void LoadMainPanel()
        {
            this.InvokeIfRequired(() =>
            {
                if (currentOpenedControl == mainPanel)
                    return;
                SuspendLayout();
                topLeftButtonPictureBox.Visible = true;
                mainPanel.Visible = true;
                currentOpenedControl.Visible = false;
                initializingLabelExtended.Visible = false;
                currentOpenedControl = mainPanel;
                if (mainPanel != null)
                    mainPanel.ResetControls();

                mainMenuOpenClosePictureBox.Visible = true;

                this.ResumeLayout(false);
                this.PerformLayout();
            });

        }
        private void LoadAddDoctorPanel()
        {
            //if (currentDoctorCard == null || currentDoctorCard.DoctorLevel == Enum_Doctor_Level.Techniction)
            //    return;
            this.InvokeIfRequired(() =>
            {
                if (currentOpenedControl == editShortDoctorDetails)
                    return;
                SuspendLayout();
                topLeftButtonPictureBox.Visible = false;
                editShortDoctorDetails.Visible = true;
                currentOpenedControl.Visible = false;
                currentOpenedControl = editShortDoctorDetails;
                if (editShortDoctorDetails != null)
                {
                    editShortDoctorDetails.ResetControls();
                    editShortDoctorDetails.SetDoctor(null);
                }

//                mainMenuOpenClosePictureBox.Visible = true;

                this.ResumeLayout(false);
                this.PerformLayout();
            });
        }

        private void LoadEditDoctorPanel()
        {
            this.InvokeIfRequired(() =>
            {
                if (currentOpenedControl == editShortDoctorDetails)
                    return;
                SuspendLayout();
                topLeftButtonPictureBox.Visible = false;
                editShortDoctorDetails.Visible = true;
                currentOpenedControl.Visible = false;
                currentOpenedControl = editShortDoctorDetails;
                if (editShortDoctorDetails != null)
                {
                    editShortDoctorDetails.ResetControls();
                    editShortDoctorDetails.SetDoctor(currentDoctorCard);
                }

                //               mainMenuOpenClosePictureBox.Visible = true;

                this.ResumeLayout(false);
                this.PerformLayout();
            });
        }

        #endregion

        #endregion

        private void LoadPatientDetailsPanel(Patient patient)
        {
            if (currentOpenedControl == patientDetailsPanel1)
                return;
            SuspendLayout();
            topLeftButtonPictureBox.Visible = false;
            patientDetailsPanel1.Visible = true;
            currentOpenedControl.Visible = false;
            currentOpenedControl = patientDetailsPanel1;
            if (patientDetailsPanel1 != null)
            {
                patientDetailsPanel1.ResetControls();
                if(patient == null)
                    patientDetailsPanel1.AddPatient();
                else
                    patientDetailsPanel1.SetPatient(patient);

            }

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void LoadAllPatientsPanelImpl()
        {
            if (first)
            {
                first = false;
                LoadAllPatientsPanelAfterFirstLogIn();
            }
            else
            {
                currentDoctorCard = Manager.CurrentDoctorCard;
                LoadAllPatientsPanel();
            }

        }
        private void LoadAllPatientsPanel()
        {
            if (currentOpenedControl == allPatientsPanel1)
                return;

            SuspendLayout();
            topLeftButtonPictureBox.Visible = false;
            allPatientsPanel1.Visible = true;
            currentOpenedControl.Visible = false;
            currentOpenedControl = allPatientsPanel1;
            //currentDoctorLabel.Visible = true;
            //currentDoctorMenuOpenClosePictureBox.Visible = true;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void LoadAllPatientsPanelAfterFirstLogIn()
        {
            if (currentOpenedControl == allPatientsPanel1)
                return;
            this.InvokeIfRequired(() =>
            {
                allPatientsPanel1.PostLoad();
                topLeftButtonPictureBox.Visible = false;
                allPatientsPanel1.Visible = true;
                currentOpenedControl.Visible = false;
                initializingLabelExtended.Visible = false;

                currentDoctorCard = Manager.CurrentDoctorCard;
                //if (currentDoctorCard != null)
                //    currentDoctorLabel.Text = $"Technician : Dr.  {currentDoctorCard.FullName}";

                //currentDoctorLabel.Visible = true;
                //currentDoctorMenuOpenClosePictureBox.Visible = true;
                mainMenuOpenClosePictureBox.Visible = true;
                currentOpenedControl = allPatientsPanel1;
            });

        }

        private void PostLanguageChangedInit()
        {
            //saveBtnPanel.Tag = new ButtonTagParameters() { Pressed = false, Enabled = true };

            currentOpenedControl = allPatientsPanel1;

            if (patientDetailsPanel1 == null)
            {
                patientDetailsPanel1 = new PatientDetails();
                patientDetailsPanel1.ClosePatientDetails += PatientDetailsPanel1_ClosePatientDetails;
                patientDetailsPanel1.SavePatientDetails += PatientDetailsPanel1_SavePatientDetails;
                patientDetailsPanel1.NewTestSession += PatientDetailsPanel1_NewTestSession;
                patientDetailsPanel1.ShowHistoryTest += PatientDetailsPanel1_ShowHistoryTest;
                patientDetailsPanel1.EditPatientDetails += PatientDetailsPanel1_EditPatientDetails;
            }
            PrepareControl(patientDetailsPanel1, "usersSettingsPanel1");

            if (editShortDoctorDetails == null)
            {
                editShortDoctorDetails = new EditShortDoctorDetails();
                editShortDoctorDetails.SaveDoctorDetails += EditShortDoctorDetails1_SaveDoctorDetails;
                editShortDoctorDetails.DoctorDetailsChanged += EditShortDoctorDetails1_DoctorDetailsChanged;
                editShortDoctorDetails.CancelSaveDoctorDetails += EditShortDoctorDetails1_CancelSaveDoctorDetails;
            }
            PrepareControl(editShortDoctorDetails, "editShortDoctorDetails12");

            if (logInControlPanel1 == null)
            {
                logInControlPanel1 = new LogInControl();
                logInControlPanel1.LoginSuccess += LogInControlPanel1_LoginSuccess;
            }
            PrepareControl(logInControlPanel1, "logInControlPanel1");

            if (mainPanel == null)
            {
                mainPanel = new MainPanel();
                mainPanel.OpenPatientDetails += AllPatientsPanel1_OpenPatientDetails;
                mainPanel.AddNewPatient += AllPatientsPanel1_AddNewPatient;
                mainPanel.ToPatientList += PatientDetailsPanel1_ClosePatientDetails;
            }
            PrepareControl(mainPanel, "mainPanel1");

            if (settingsPanel == null)
            {
                settingsPanel = new SettingsControl();
                settingsPanel.Save += SettingsPanel_Save;
                settingsPanel.Cancel += SettingsPanel_Cancel;
            }
            PrepareControl(settingsPanel, "settingsPanel1");
            

        }

        private void SettingsPanel_Cancel()
        {
            LoadAllPatientsPanelImpl();
        }

        private void SettingsPanel_Save()
        {
            LoadAllPatientsPanelImpl();
        }

        private void EditShortDoctorDetails1_CancelSaveDoctorDetails()
        {
            LoadAllPatientsPanelImpl();
        }

        private void EditShortDoctorDetails1_DoctorDetailsChanged(DoctorCard obj)
        {
            LoadAllPatientsPanelImpl();
        }

        private void EditShortDoctorDetails1_SaveDoctorDetails(DoctorCard doctor)
        {
            SetDoctorNameToTopPanel();
            LoadAllPatientsPanelImpl();
        }

        private void LogInControlPanel1_LoginSuccess()
        {
            currentDoctorCard = Manager.CurrentDoctorCard;
            SetDoctorNameToTopPanel();
            LoadMainPanel();
        }

        private void SetDoctorNameToTopPanel()
        {
            if (currentDoctorCard == null)
                return;

            this.InvokeIfRequired(() =>
            {
                currentDoctorLabelExtended.Visible = true;

                using (Graphics g = currentDoctorLabelExtended.CreateGraphics())
                {
                    #region Text

                    string text = $"{currentDoctorCard.FullName}";
                    SizeF stringSize = g.MeasureString(text, currentDoctorLabelExtended.Font);
                    float newWidth = stringSize.Width + 2 * currentDoctorLabelExtended.Image.Width;
                    currentDoctorLabelExtended.Text = text;
                    currentDoctorLabelExtended.Size = new Size((int)newWidth, currentDoctorLabelExtended.Size.Height);
                    currentDoctorLabelExtended.Location = new Point(mainMenuOpenClosePictureBox.Location.X - (int)newWidth - currentDoctorDistance, currentDoctorLabelExtended.Location.Y);

                    #endregion

                }
                currentDoctorLabelExtended.Visible = true;

            });
        }

        private void PrepareControl(UserControl control, string name, bool resize = true)
        {
            control.BackColor = allPatientsPanel1.BackColor;
            control.Location = allPatientsPanel1.Location;
            control.Name = name;
            if (resize)
                control.Size = allPatientsPanel1.Size;
            control.TabIndex = allPatientsPanel1.TabIndex;

            this.bottomPanel.Controls.Add(control);
            control.Visible = false;
        }

        private void PatientDetailsPanel1_ShowHistoryTest(Patient patient, PatientVisit visit)
        {
        }

        private void PatientDetailsPanel1_NewTestSession(Patient patient)
        {
        }
        private void PatientDetailsPanel1_EditPatientDetails(Patient patient)
        {
        }

        private void PatientDetailsPanel1_ClosePatientDetails()
        {
            LoadAllPatientsPanelImpl();
        }
        private void PatientDetailsPanel1_SavePatientDetails()
        {
            allPatientsPanel1.InitAllPatients(true);
        }

        private void technoPalmLabelExtended_Click(object sender, EventArgs e)
        {
            LoadMainPanel();
        }
        //private void InitBitmapControls()
        //{
        //    GuiUtils.SetNewLocation(topLeftLogoPictureBox, topLeftButtonPictureBox);

        //    this.Controls.Remove(topLeftLogoPictureBox);

        //    topLeftButtonPictureBox.Controls.Add(topLeftLogoPictureBox);
        //}

    }
}
