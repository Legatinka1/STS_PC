using BelkinEagleGui.Forms;
using CommonLib;
using ImplementationLib;
using InterfacesLib;
using STSGui.Controls.Report;
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
using static BelkinEagleGui.Forms.FormBackGround;

namespace STSGui
{
    public partial class PatientDetails : UserControl
    {
        #region Private Members

        Patient currentPatient = null;

        private Bitmap cloneBitmap;

        private bool isFirst = true;
        private bool patientTopNameLabel_ClickIsEnabled = false;

        private bool isInit = false;

        EditShortPatientDetails editPatientDetailsControl = null;
        VisitFullControl visitFullControl = null;
        PredictedResults predictedResultsControl = null;
        FullReport fullReportControl = null;

        private bool isAddNewPatientMode = false;

        #endregion

        #region Constructor / Control_Load

        public PatientDetails()
        {
            InitializeComponent();
        }

        private void PatientDetails_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            isInit = false;

            cloneBitmap = new Bitmap(this.Width, this.Height);

            InitButtons();
            InitColor();
            InitPreviousTestsControl();
            PostLanguageChangedInit();
            SubscrubeForManagerEvents();

            isInit = true;

            co2FenoButtonPictureBox.Enabled = false;
            dlcoButtonPictureBox.Enabled = false;
        }

        private void PatientDetails_ControlRemoved(object sender, ControlEventArgs e)
        {
            _isBlinking = false;
            _timer = false;
        }

        private void SubscrubeForManagerEvents()
        {
            Manager.TestDone += Manager_TestDone;
            Manager.ConnectionLog += Manager_ConnectionLog;
            Manager.StartTestTimer += Manager_StartTestTimer;
        }

        private void Manager_StartTestTimer()
        {
            _isBlinking = false;
            this.InvokeIfRequired(() => { timerLabel.Visible = true; });

            _timer = true;

            Thread thr = new Thread(Timer);
            thr.Start();
        }

        private bool _timer = false;
        private void Timer()
        {
            _start = DateTime.Now;
            DateTime help = DateTime.Now;
            while (_timer)
            {
                if (DateTime.Now.Subtract(help).TotalMilliseconds > 100)
                {
                    double millis = Math.Round(6000 - DateTime.Now.Subtract(_start).TotalMilliseconds, 2);
                    if (millis < 0) { millis = 0; }

                    string time = $"{(millis / 1000).ToString("#.##")} seconds";
                    if (time[1].Equals('-'))
                        time = "(0:00)";

                    this.InvokeIfRequired(() => { timerLabel.Text = time; testProgressPictureBox.Visible = true; });
                    help = DateTime.Now;
                }
            }

            this.InvokeIfRequired(() => { timerLabel.Visible = false; testProgressPictureBox.Visible = false; });
        }

        private void Manager_TestDone(bool res, PUATestResult result)
        {
            this.InvokeIfRequired(() =>
            {
                if (isStartTestState)
                    startStopTestButtonPictureBox.Text = "Stop Test";
                else
                    startStopTestButtonPictureBox.Text = "Start Test";

                if (!res)
                {
                    startStopTestButtonPictureBox.Text = "Start Test";
                    isStartTestState = false;
                }

                isStartTestState = !isStartTestState;
                startStopTestButtonPictureBox.Invalidate();
                testProgressPictureBox.Visible = false;
                cancelButtonPictureBox.Enabled = true;
                saveSessionButtonPictureBox.Enabled = true;
                timerLabel.Visible = false;

                _isBlinking = false;
                _timer = false;
            });
        }

        private Enum_ConnectionLog _lastLog = Enum_ConnectionLog.Disconnected;
        private void Manager_ConnectionLog(Enum_ConnectionLog log)
        {
            this.InvokeIfRequired(() =>
            {
                switch (log)
                {
                    case Enum_ConnectionLog.Connected:
                        isStartTestState = true;
                        startStopTestButtonPictureBox.Enabled = true;
                        startStopTestButtonPictureBox.Text = "Start Test";
                        reconnectButtonPictureBox.Visible = false;
                        reconnectButtonPictureBox.Enabled = true;
                        break;
                    case Enum_ConnectionLog.Connecting:
                        isStartTestState = true;
                        startStopTestButtonPictureBox.Enabled = false;
                        startStopTestButtonPictureBox.Text = "Connecting...";
                        reconnectButtonPictureBox.Visible = false;
                        reconnectButtonPictureBox.Enabled = true;
                        break;
                    case Enum_ConnectionLog.Failed:
                        isStartTestState = true;
                        startStopTestButtonPictureBox.Enabled = false;
                        startStopTestButtonPictureBox.Text = "Connection Failed";
                        reconnectButtonPictureBox.Visible = true;
                        break;
                    case Enum_ConnectionLog.Disconnected:
                        isStartTestState = true;
                        startStopTestButtonPictureBox.Enabled = false;
                        startStopTestButtonPictureBox.Text = "Disconnected";
                        reconnectButtonPictureBox.Visible = true;
                        break;
                }
            });

            _lastLog = log;
        }

        private void InitPreviousTestsControl()
        {
            previousTestsControl.ShowHistoryTest += PreviousTestsControl_ShowHistoryTest;
        }

        private void PreviousTestsControl_ShowHistoryTest(Patient patient, PatientVisit visit)
        {
            LoadVisitFullControl(currentPatient, visit,false);
            patientTopNameLabel_ClickIsEnabled = true;
        }

        private void InitButtons()
        {
            cancelButtonPictureBox.Location = dlcoButtonPictureBox.Location;
            saveSessionButtonPictureBox.Location = co2FenoButtonPictureBox.Location;
            startStopTestButtonPictureBox.Location = spiro_TlcButtonPictureBox.Location;
            reconnectButtonPictureBox.Location = new Point(cancelButtonPictureBox.Location.X - Math.Abs(cancelButtonPictureBox.Location.X - saveSessionButtonPictureBox.Location.X), cancelButtonPictureBox.Location.Y);
            
            cancelButtonPictureBox.Visible = false;
            saveSessionButtonPictureBox.Visible = false;
            startStopTestButtonPictureBox.Visible = false;

            reconnectButtonPictureBox.Visible = false;
            reconnectButtonPictureBox.Enabled = true;

        }

        #endregion

        #region Events

        public event Action ClosePatientDetails;
        public event Action SavePatientDetails;
        public event Action<Patient> NewTestSession;
        public event Action<Patient, PatientVisit> ShowHistoryTest;
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
            UnloadVisitFullControl();
            visitFullControl.Visible = false;
            LoadShortPatientDetailsPanel(currentPatient);
        }

        public void SetPatient(Patient patient)
        {
            isAddNewPatientMode = false;
            currentPatient = patient;
            previousTestsControl.SetPatient(currentPatient);
            InitAllVisits(true);
            SetPatientImpl();
            patientTopNameAndIDLabel.Focus();
        }
        public void AddPatient()
        {
            isAddNewPatientMode = true;
            currentPatient = Manager.CreateNewPatient();
            currentPatient = null;
            SetPatientImpl();
            patientTopNameAndIDLabel.Focus();
        }

        public void InitAllVisits(bool fromParent)
        {
            InitAllVisitsImpl(true, fromParent);
        }
        #endregion

        #region Private Functions

        private void PostLanguageChangedInit()
        {
            //saveBtnPanel.Tag = new ButtonTagParameters() { Pressed = false, Enabled = true };


            if (editPatientDetailsControl == null)
            {
                editPatientDetailsControl = new EditShortPatientDetails();
                editPatientDetailsControl.SavePatientDetails += EditPatientDetailsControl_SavePatientDetails;
                editPatientDetailsControl.PatientDetailsChanged += EditPatientDetailsControl_PatientDetailsChanged;
                editPatientDetailsControl.CancelSavePatientDetails += EditPatientDetailsControl_CancelSavePatientDetails;
            }
            PrepareControl(editPatientDetailsControl, "editPatientDetailsControl1");
            
            if (visitFullControl == null)
            {
                visitFullControl = new VisitFullControl();

                visitFullControl.Location = new Point(0, rightBigPanel.Location.Y);
                visitFullControl.Name = "visitFullControl1";
                this.Controls.Add(visitFullControl);
                visitFullControl.Visible = false;

                visitFullControl.CommentsButtonClick += VisitFullControl_CommentsButtonClick;
                visitFullControl.PrintButtonClick += VisitFullControl_PrintButtonClick;
                visitFullControl.PressureButtonClick += VisitFullControl_PressureButtonClick;
            }


            if (fullReportControl == null)
            {
                fullReportControl = new FullReport();

                fullReportControl.Location = new Point(0, rightBigPanel.Location.Y);
                fullReportControl.Name = "fullReport1";
                this.Controls.Add(fullReportControl);
                fullReportControl.Visible = false;

                fullReportControl.StartPrint += FullReportControl_StartPrint;
                fullReportControl.CancelPrint += FullReportControl_CancelPrint;
            }
            

            if (predictedResultsControl == null)
            {
                predictedResultsControl = new PredictedResults();

                predictedResultsControl.Location = previousTestsControl.Location;
                predictedResultsControl.Size = previousTestsControl.Size;
                predictedResultsControl.Name = "predictedResultsControl";
                this.rightBigPanel.Controls.Add(predictedResultsControl);
                predictedResultsControl.Visible = false;
            }
            

            if (shortPatientDetailsControl!=null)
                shortPatientDetailsControl.EditPatientDetails += ShortPatientDetailsControl_EditPatientDetails;


        }

        #region fullReportControl Events Functions

        private void FullReportControl_CancelPrint()
        {
            UnloadReportFullControl();
        }

        private void FullReportControl_StartPrint(PrintData printData)
        {
            Manager.StartPrint(printData);
        }

        #endregion

        #region visitFullControl Events Functions

        private void VisitFullControl_PressureButtonClick(Patient patient, PatientVisit visit)
        {
            FormBackGround formBackGround = new FormBackGround(FormType.Pressure, visit);
            formBackGround.ShowDialog();
        }

        private void VisitFullControl_PrintButtonClick(Patient arg1, PatientVisit arg2)
        {
            //LoadReportFullControl(visitFullControl.GetCurrenttPatien(), visitFullControl.GetCurrenttVisit());
            LoadReportFullControl(visitFullControl.GetCurrenttVisit());
        }

        private void VisitFullControl_CommentsButtonClick(Patient arg1, PatientVisit arg2)
        {

        }

        #endregion

        private void ShortPatientDetailsControl_EditPatientDetails(Patient patient)
        {
            LoadEditShortPatientDetailsPanel(patient);
        }

        private void PrepareControl(UserControl control, string name, bool resize = true)
        {

//            control.BackColor = shortPatientDetailsControl.BackColor;
            control.Location = shortPatientDetailsControl.Location;
            control.Name = name;
            if (resize)
                control.Size = shortPatientDetailsControl.Size;
            control.TabIndex = shortPatientDetailsControl.TabIndex;

            this.leftBigPanel.Controls.Add(control);
            control.Visible = false;
        }

        private void EditPatientDetailsControl_CancelSavePatientDetails()
        {
            if (isAddNewPatientMode)
            {
                isAddNewPatientMode = false;
                ClosePatientDetails?.Invoke();
            }
            else
                LoadShortPatientDetailsPanel(null);
        }

        private void EditPatientDetailsControl_SavePatientDetails(Patient patient)
        {
            LoadShortPatientDetailsPanel(patient);
            if (isAddNewPatientMode)
            {
                isAddNewPatientMode = false;
                currentPatient = patient;
                LoadPreviousTests();
                SavePatientDetails?.Invoke();
            }
        }
        private void EditPatientDetailsControl_PatientDetailsChanged(Patient patient)
        {
            predictedResultsControl.SetPUATestHelper(Manager.GetPrediction(patient));
        }

        private void LoadEditShortPatientDetailsPanel(Patient patient)
        {
            SuspendLayout();

            //this.Controls.SetChildIndex(leftBigPanel, 0);
            //this.Controls.SetChildIndex(rightBigPanel, 1);
            //this.Controls.SetChildIndex(visitFullControl, 2);

            //leftBigPanel.Controls.SetChildIndex(editPatientDetailsControl, 0);
            //leftBigPanel.Controls.SetChildIndex(shortPatientDetailsControl, 1);



            if (editPatientDetailsControl != null)
            {
                editPatientDetailsControl.ResetControls();
                editPatientDetailsControl.SetPatient(patient);
            }

            dlcoButtonPictureBox.Visible = true;//Alex change to false. need true
            co2FenoButtonPictureBox.Visible = true;//Alex change to false. need true
            spiro_TlcButtonPictureBox.Visible = true;

            visitFullControl.Visible = false;

            editPatientDetailsControl.Visible = true;
            shortPatientDetailsControl.Visible = false;
            leftBigPanel.Visible = true;
            rightBigPanel.Visible = true;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void LoadShortPatientDetailsPanel(Patient patient)
        {
            SuspendLayout();

            //this.Controls.SetChildIndex(leftBigPanel, 0);
            //this.Controls.SetChildIndex(rightBigPanel, 1);
            //this.Controls.SetChildIndex(visitFullControl, 2);

            //leftBigPanel.Controls.SetChildIndex(shortPatientDetailsControl, 0);
            //leftBigPanel.Controls.SetChildIndex(editPatientDetailsControl, 1);

            if (shortPatientDetailsControl != null)
            {
                shortPatientDetailsControl.ResetControls();
                if(patient!=null)
                    shortPatientDetailsControl.SetPatient(patient);
            }
            dlcoButtonPictureBox.Visible = true;//Alex change to false. need true
            co2FenoButtonPictureBox.Visible = true;//Alex change to false. need true
            spiro_TlcButtonPictureBox.Visible = true;

            visitFullControl.Visible = false;

            shortPatientDetailsControl.Visible = true;
            editPatientDetailsControl.Visible = false;
            leftBigPanel.Visible = true;
            rightBigPanel.Visible = true;


            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void LoadPredictedResults()
        {
            if (!isAddNewPatientMode || predictedResultsControl.Visible)
                return;

            SuspendLayout();

            if (predictedResultsControl != null)
            {
                predictedResultsControl.ResetControls();
                if (currentPatient != null)
                    predictedResultsControl.SetPUATestHelper(Manager.GetPrediction(currentPatient));
            }
            previousTestsControl.Visible = false;
            predictedResultsControl.Visible = true;
            rightBigPanel.Visible = true;


            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void LoadPreviousTests()
        {
            if (isAddNewPatientMode || previousTestsControl.Visible)
                return;

            SuspendLayout();

            if (previousTestsControl != null)
            {
                previousTestsControl.ResetControls();
                if (currentPatient != null)
                    previousTestsControl.SetPatient(currentPatient);
            }
            predictedResultsControl.Visible = false;
            previousTestsControl.Visible = true;


            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private void LoadVisitFullControl(Patient patient, PatientVisit currentVisit,bool isNewSession)
        {
            SuspendLayout();

            //this.Controls.SetChildIndex(visitFullControl, 0);
            //this.Controls.SetChildIndex(leftBigPanel, 1);
            //this.Controls.SetChildIndex(rightBigPanel, 2);
            dlcoButtonPictureBox.Visible = false;
            co2FenoButtonPictureBox.Visible = false;
            spiro_TlcButtonPictureBox.Visible = false;

            cancelButtonPictureBox.Visible = isNewSession;
            saveSessionButtonPictureBox.Visible = isNewSession;
            startStopTestButtonPictureBox.Visible = isNewSession;
            if (!isNewSession)
            {
                reconnectButtonPictureBox.Visible = false;
                reconnectButtonPictureBox.Enabled = true;
            }

            if (visitFullControl != null)
            {
                visitFullControl.ResetControls();
                if (patient != null)
                    visitFullControl.SetPatientVisit(patient, currentVisit, isNewSession);
            }
            visitFullControl.Visible = true;
            leftBigPanel.Visible = false;
            rightBigPanel.Visible = false;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void UnloadVisitFullControl()
        {
            SuspendLayout();

            //this.Controls.SetChildIndex(leftBigPanel, 0);
            //this.Controls.SetChildIndex(rightBigPanel, 1);
            //this.Controls.SetChildIndex(visitFullControl, 2);

            leftBigPanel.Visible = true;
            rightBigPanel.Visible = true;
            visitFullControl.Visible = false;

            dlcoButtonPictureBox.Visible = true;//Alex change to false. need true
            co2FenoButtonPictureBox.Visible = true;//Alex change to false. need true
            spiro_TlcButtonPictureBox.Visible = true;

            cancelButtonPictureBox.Visible = false;
            saveSessionButtonPictureBox.Visible = false;
            startStopTestButtonPictureBox.Visible = false;
            reconnectButtonPictureBox.Visible = false;
            reconnectButtonPictureBox.Enabled = true;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        //==========================================================

        private void LoadReportFullControl(/*Patient patient, */PatientVisit currentVisit)
        {
            SuspendLayout();

            cancelButtonPictureBox.Visible = false;
            saveSessionButtonPictureBox.Visible = false;
            startStopTestButtonPictureBox.Visible = false;
            reconnectButtonPictureBox.Visible = false;
            reconnectButtonPictureBox.Enabled = true;

            //this.Controls.SetChildIndex(visitFullControl, 0);
            //this.Controls.SetChildIndex(leftBigPanel, 1);
            //this.Controls.SetChildIndex(rightBigPanel, 2);

            //dlcoButtonPictureBox.Visible = false;
            //co2FenoButtonPictureBox.Visible = false;
            //spiro_TlcButtonPictureBox.Visible = false;

            //cancelButtonPictureBox.Visible = true;
            //saveSessionButtonPictureBox.Visible = true;
            //startStopTestButtonPictureBox.Visible = true;

            if (fullReportControl != null)
            {
                fullReportControl.ResetControls();
                if (currentVisit != null)
                    fullReportControl.SetPatientVisit(currentVisit);
            }
            fullReportControl.Visible = true;
            visitFullControl.Visible = false;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void UnloadReportFullControl()
        {
            SuspendLayout();

            //this.Controls.SetChildIndex(leftBigPanel, 0);
            //this.Controls.SetChildIndex(rightBigPanel, 1);
            //this.Controls.SetChildIndex(visitFullControl, 2);
            cancelButtonPictureBox.Visible = true;
            saveSessionButtonPictureBox.Visible = true;
            startStopTestButtonPictureBox.Visible = true;


            visitFullControl.Visible = true;
            fullReportControl.Visible = false;

            dlcoButtonPictureBox.Visible = true;//Alex change to false. need true
            co2FenoButtonPictureBox.Visible = true;//Alex change to false. need true
            spiro_TlcButtonPictureBox.Visible = true;

            cancelButtonPictureBox.Visible = false;
            saveSessionButtonPictureBox.Visible = false;
            startStopTestButtonPictureBox.Visible = false;
            reconnectButtonPictureBox.Visible = false;
            reconnectButtonPictureBox.Enabled = true;

            this.ResumeLayout(false);
            this.PerformLayout();
        }


        //=====================================================================
        private void patientTopCloseLabel_Click(object sender, EventArgs e)
        {
            ClosePatientDetails?.Invoke();
        }

        private void SetPatientImpl()
        {
            if (isAddNewPatientMode)
            {
                LoadEditShortPatientDetailsPanel(currentPatient);
                LoadPredictedResults();
            }
            else
            {
                LoadShortPatientDetailsPanel(currentPatient);
                LoadPreviousTests();
            }

            if (currentPatient == null)
            {
                patientTopNameLabel.Text = "";
                patientTopNameAndIDLabel.Text = "";
            }
            else
            {
                patientTopNameLabel.Text = $"| {currentPatient.FullName}";
                patientTopNameAndIDLabel.Text = $"{currentPatient.FullName} {currentPatient.PatientId}"; ;

            }

        }


        private void InitColor()
        {

            this.BackColor = Color.FromArgb(247, 248, 252);


            Color textcolor = Color.FromArgb(62, 124, 195);
            patientTopNameAndIDLabel.ForeColor = textcolor;

            textcolor = Color.FromArgb(88, 116, 169);

            patientTopCloseLabel.ForeColor = textcolor;
            patientTopNameLabel.ForeColor = textcolor;

        }


        private void InitAllVisitsImpl(bool reload, bool fromParent)
        {
            previousTestsControl.InitAllVisits(fromParent);
        }


        #region Top Right Buttons_Click Functions

        private void newSessionButtonPictureBox_Click(object sender, EventArgs e)
        {
            NewTestSession?.Invoke(currentPatient);
            PatientVisit newVisit = Manager.AddNewVisit(currentPatient);
            if (newVisit == null)
                return;

            LoadVisitFullControl(currentPatient, newVisit,true);
            patientTopNameLabel_ClickIsEnabled = true;
        }

        private bool _isBlinking = false;
        private DateTime _start = DateTime.Now;
        private void BlinkProgressBar()
        {
            int counter = 0;
            while (_isBlinking) // && counter < 30)
            {
                DateTime current = DateTime.Now;
                if (current.Subtract(_start).TotalMilliseconds > 300)
                {
                    this.InvokeIfRequired(() => { testProgressPictureBox.Visible = !testProgressPictureBox.Visible; });
                    _start = current;
                    counter++;
                }
            }

            this.InvokeIfRequired(() => { testProgressPictureBox.Visible = false; });
        }

        private void dlcoButtonPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void co2FenoButtonPictureBox_Click(object sender, EventArgs e)
        {

        }
        private void cancelButtonPictureBox_Click(object sender, EventArgs e)
        {
            currentPatient.Visited.Remove(visitFullControl.GetCurrenttVisit());
            if (visitFullControl.Visible == true)
                UnloadVisitFullControl();

            patientTopNameLabel_ClickIsEnabled = false;
        }

        private void saveSessionButtonPictureBox_Click(object sender, EventArgs e)
        {
            if (Manager.SavePatientVisitCard(visitFullControl.GetCurrenttVisit(), true))
            {
                previousTestsControl.InitAllVisits(true);
                if (visitFullControl.Visible == true)
                    UnloadVisitFullControl();

                patientTopNameLabel_ClickIsEnabled = false;

            }

        }

        bool isStartTestState = true; 
        private void startStopTestButtonPictureBox_Click(object sender, EventArgs e)
        {
            startStopTestButtonPictureBox_ClickImpl();
        }
        private void startStopTestButtonPictureBox_ClickImpl()
        {
            if (isStartTestState)
            {
                if (!Manager.StartTest(currentPatient))
                    return;

                startStopTestButtonPictureBox.Text = "Stop Test";
                testProgressPictureBox.Visible = true;
                cancelButtonPictureBox.Enabled = false;
                saveSessionButtonPictureBox.Enabled = false;
                isStartTestState = !isStartTestState;

                _isBlinking = true;
                _timer = false;
                Thread thr = new Thread(BlinkProgressBar);
                thr.Start();
            }
            else
            {
                if (!Manager.StopTest())
                    return;
                //startStopTestButtonPictureBox.Text = "Start Test";
            }
        }

        #endregion

        private void editButtonPictureBox_Click(object sender, EventArgs e)
        {
            EditPatientDetails?.Invoke(currentPatient);
        }


        private void patientTopNameLabel_Click(object sender, EventArgs e)
        {
            if (!patientTopNameLabel_ClickIsEnabled)
                return;

            if (visitFullControl.Visible == true)
                UnloadVisitFullControl();

            patientTopNameLabel_ClickIsEnabled = false;
        }

        private void PatientDetails_Leave(object sender, EventArgs e)
        {
        }

        #endregion

        private void reconnectButtonPictureBox_Click(object sender, EventArgs e)
        {
            reconnectButtonPictureBox.Enabled = false;

            if (!Manager.Reconnect())
                return;

            this.InvokeIfRequired(() =>
            {
                startStopTestButtonPictureBox.Text = "Connecting...";
            });
        }
    }
}
