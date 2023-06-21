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
    public partial class TestsLeftParameterItem : UserControl
    {
        #region Private Members

        private PUATestResult testResult = null;

        Color textColor;
        Color redTextColor;

        Color greenBackColor;
        Color blueBackColor;

        #endregion

        #region Constructor / Control_Load

        public TestsLeftParameterItem()
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

        #region Property


        #region TypeUnit

        [Bindable(true)]
        [Localizable(true)]
        [IODescriptionAttribute("TypeUnit")]
        public Enum_PUAParameters TypeUnit
        { 
            get
            {
                return typeUnit;
            }
            set
            {
                typeUnit = value;
                typeUnitLabel.Text = Utils.GetParameterGuiName(typeUnit);
            }
        }
        private Enum_PUAParameters typeUnit = Enum_PUAParameters.FVC;


        #endregion

        #region Get Manager

        private ISTSManager Manager
        {
            get => STSManager.GetManager;
        }

        #endregion


        #endregion

        #region Public Functions

        public void Reset()
        {
            predictedLabel.Text = "";
            actual_Best_ValueLabel.Text = "";
            actual_Best_A_P_ValueLabel.Text = "";
        }

        public void SetCurrentTestResult(PUATestResult result)
        {
            testResult = result;
            InitTestResult();
        }

        #endregion

        #region Private Functions

        private void SubscrubeForManagerEvents()
        {
            Manager.TestDone += Manager_TestDone;
        }

        private void Manager_TestDone(bool res, PUATestResult result)
        {
            if (res)
            {
                testResult = result;
                InitTestResult();
            }
        }

        #region Service Functions

        private void PostLanguageChangedInit()
        {
            InitColor();
            InitTestResult();

        }

        private void InitColor()
        {
            textColor = Color.FromArgb(37, 55, 86);
            redTextColor = Color.FromArgb(216, 86, 100);
            greenBackColor = Color.FromArgb(220,240,210);
            blueBackColor = Color.FromArgb(224, 236, 254);

            LabelsInitColor(textColor);

        }

        private void LabelsInitColor(Color textColor)
        {
            typeUnitLabel.ForeColor = textColor;
            predictedLabel.ForeColor = textColor;
            actual_Best_ValueLabel.ForeColor = textColor;
            actual_Best_A_P_ValueLabel.ForeColor = textColor;

            predictedLabel.BackColor = greenBackColor;
            actual_Best_ValueLabel.BackColor = blueBackColor;
            actual_Best_A_P_ValueLabel.BackColor = blueBackColor;
        }

        private void InitTestResult()
        {
            this.InvokeIfRequired(() =>
            {
                if (testResult == null)
                {
                    predictedLabel.Text = "";
                    actual_Best_ValueLabel.Text = "";
                    actual_Best_A_P_ValueLabel.Text = "";
                }
                else
                {
                    if(testResult.Prediction!=null)
                    {
                        predictedLabel.Text = $"{Math.Round(Utils.GetPrediction(TypeUnit, testResult),2)}";
                    }

                    if(testResult.AllTests!=null)
                    {
                        if (testResult.BestIndex < testResult.AllTests.Count && testResult.BestIndex >= 0)
                        {
                            bool isOk = true;
                            actual_Best_ValueLabel.Text = $"{Math.Round(Utils.GetActual(TypeUnit, testResult.AllTests[testResult.BestIndex]), 2)}";
                            actual_Best_A_P_ValueLabel.Text = $"{Math.Round(Manager.GetPercentage(testResult.AllTests[testResult.BestIndex], testResult.Prediction, TypeUnit, out isOk), 0)}";
                            if (isOk)
                                actual_Best_A_P_ValueLabel.ForeColor = textColor;
                            else
                                actual_Best_A_P_ValueLabel.ForeColor = redTextColor;
                        }
                        else if(testResult.AllTests.Count == 0)
                        {
                            actual_Best_ValueLabel.Text = "";
                            actual_Best_A_P_ValueLabel.Text = "";
                        }

                    }

                }
            });
        }

        #endregion



        #endregion
    }
}
