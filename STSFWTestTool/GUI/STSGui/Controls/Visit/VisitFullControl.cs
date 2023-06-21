using CommonLib;
using ImplementationLib;
using InterfacesLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STSGui
{
    public partial class VisitFullControl : UserControl
    {
        PatientVisit _currentVisit = null;
        Patient _currentPatient = null;
        bool _isNewSession = true;
        public VisitFullControl()
        {
            InitializeComponent();
        }

        private void VisitFullControl_Load(object sender, EventArgs e)
        {
            SubscrubeForManagerEvents();
            SubscrubeForControlsEvents();
        }


        #region Events

        public event Action<Patient,PatientVisit> CommentsButtonClick;
        public event Action<Patient, PatientVisit> PrintButtonClick;
        public event Action<Patient, PatientVisit> PressureButtonClick;

        #endregion

        #region Get Manager

        private ISTSManager Manager
        {
            get => STSManager.GetManager;
        }

        #endregion

        public void SetPatientVisit(Patient patient, PatientVisit currentVisit, bool isNewSession)
        {
            _currentVisit = currentVisit;
            _currentPatient = patient;
            _isNewSession = isNewSession;
            vistTestsControl1.SetCurrentTestResult(currentVisit.Test, _isNewSession);
            //ucTestGraph1.LoadTestPressure(currentVisit.Test);

            ucTestGraphExhFlow.LoadExhFlow(_currentVisit.Test);
            ucTestGraphFVC.LoadFVC(_currentVisit.Test);
        }
        public PatientVisit GetCurrenttVisit()
        {
            return _currentVisit;
        }
        public Patient GetCurrenttPatien()
        {
            return _currentPatient;
        }

        public void ResetControls()
        {
            vistTestsControl1.ResetControls();
        }
        private void SubscrubeForManagerEvents()
        {
            Manager.TestDone += Manager_TestDone;
        }
        private void SubscrubeForControlsEvents()
        {
            vistTestsControl1.RemoveTest += VistTestsControl1_RemoveTest;
        }

        private void VistTestsControl1_RemoveTest(int index)
        {
            if (MessageBox.Show($"Remove Test index {index}?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Manager.RemoveTest(_currentVisit.Test, index))
                {
                    vistTestsControl1.SetCurrentTestResult(_currentVisit.Test, _isNewSession);
                   
                    ucTestGraphExhFlow.LoadExhFlow(_currentVisit.Test);
                    ucTestGraphFVC.LoadFVC(_currentVisit.Test);
                }
                else
                    MessageBox.Show($"Remove Test index {index} False", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Manager_TestDone(bool res, PUATestResult result)
        {
            if (res)
            {
                ucTestGraphExhFlow.LoadExhFlow(_currentVisit.Test);
                ucTestGraphFVC.LoadFVC(_currentVisit.Test);
            }
        }

        private void commentsButtonPictureBox_Click(object sender, EventArgs e)
        {
            CommentsButtonClick?.Invoke(_currentPatient, _currentVisit);
        }

        private void printButtonPictureBox_Click(object sender, EventArgs e)
        {
            PrintButtonClick?.Invoke(_currentPatient, _currentVisit);
        }

        private void pressureButtonPictureBox_Click(object sender, EventArgs e)
        {
            PressureButtonClick?.Invoke(_currentPatient, _currentVisit);
        }

        private void ucTestGraph1_Load(object sender, EventArgs e)
        {

        }

        private void printVectorButtonPictureBox_Click(object sender, EventArgs e)
        {
            string dateTime = DateTime.Now.ToString("dd;MM-HH;mm;ss");
            if (!Directory.Exists($"C:\\STS\\Vectors\\{dateTime}"))
                Directory.CreateDirectory($"C:\\STS\\Vectors\\{dateTime}");

            for(int i = 0; i < _currentVisit.Test.AllTests.Count; i++)
            {
                string[] arr = new string[_currentVisit.Test.AllTests[i].RawData.Length];
                for (int j = 0; j < arr.Length; j++)
                    arr[j] = $"{_currentVisit.Test.AllTests[i].RawData[j]}";

                File.WriteAllLines($"C:\\STS\\Vectors\\{dateTime}\\{i}.csv", arr);
            }
        }
    }
}
