using CommonLib;
using ImplementationLib;
using InterfacesLib;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace STSGui
{
    public partial class TestsLeftParameterHeader : UserControl
    {
        #region Private Members

        private PUATestResult testResult = null;

        Color textColor;

        Color greenBackColor;
        Color blueBackColor;

        #endregion

        #region Constructor / Control_Load

        public TestsLeftParameterHeader()
        {
            InitializeComponent();
        }

        private void TestsLeftParameterItem_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            PostLanguageChangedInit();
            SubscrubeForManagerEvents();
        }

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
            bestNameLabel.Text = "BEST";
        }

        public void SetCurrentTestResult(PUATestResult result)
        {
            testResult = result;
            InitTestResult();
        }

        #endregion

        #region Private Functions


        private void Manager_TestDone(bool res, PUATestResult result)
        {
            if(res)
                testResult = result;
        }

        #region Service Functions

        private void SubscrubeForManagerEvents()
        {
            Manager.TestDone += Manager_TestDone;
        }
        private void PostLanguageChangedInit()
        {
            InitColor();
            InitTestResult();

        }

        private void InitColor()
        {
            textColor = Color.FromArgb(37, 55, 86);
            greenBackColor = Color.FromArgb(220,240,210);
            blueBackColor = Color.FromArgb(88, 116, 169);

            LabelsInitColor(textColor);

        }

        private void LabelsInitColor(Color textColor)
        {
            typeUnitLabel.ForeColor = textColor;
            predictedLabel.ForeColor = textColor;

            predictedLabel.BackColor = greenBackColor;
            bestNameLabel.BackColor = blueBackColor;
            actualNameLabel.BackColor = blueBackColor;
            apNameLabel.BackColor = blueBackColor;
        }

        private void InitTestResult()
        {
            if (testResult == null)
                bestNameLabel.Text = "BEST";
            else
            {
                if(testResult.AllTests!=null && testResult.BestIndex< testResult.AllTests.Count)
                    bestNameLabel.Text = $"BEST (Test {testResult.BestIndex+1})";
                else
                    bestNameLabel.Text = "BEST";

            }
        }


        #endregion

        #endregion

        private void typeUnitLabel_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show($"{Manager.getDoCalcString()}", "DoCalc String");
        }
    }
}
