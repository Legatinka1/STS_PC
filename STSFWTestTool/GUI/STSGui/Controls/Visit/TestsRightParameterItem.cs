using CommonLib;
using ImplementationLib;
using InterfacesLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace STSGui
{
    public partial class TestsRightParameterItem : UserControl
    {
        #region Private Members

        private PUATestResult testResult = null;

        Color textColor;
        Color redTextColor;

        Dictionary<int, Label> actualLabels = new Dictionary<int, Label>();
        Dictionary<int, Label> actual_A_P_Labels = new Dictionary<int, Label>();

        public bool isDesignMode = true;
        #endregion

        #region Constructor / Control_Load

        public TestsRightParameterItem()
        {
            InitializeComponent();
        }

        private void TestsRightParameterItem_Load(object sender, EventArgs e)
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
            }
        }
        private Enum_PUAParameters typeUnit = Enum_PUAParameters.FVC;


        #endregion

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
            //typeUnitLabel.BackColor = Color.Transparent;
            //predictedLabel.BackColor = Color.Transparent;
            //actual_Best_ValueLabel.BackColor = Color.Transparent;
            //actual_Best_A_P_ValueLabel.BackColor = Color.Transparent;
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

        #region Service Functions

        private void PostLanguageChangedInit()
        {
            InitDictionarys();
            InitColor();
            InitTestResult();

        }

        private void InitDictionarys()
        {
            int index = 0;
            actualLabels[index] = actual_0_ValueLabel;
            actual_A_P_Labels[index] = actual_0_A_P_ValueLabel;
            index++;

            actualLabels[index] = actual_1_ValueLabel;
            actual_A_P_Labels[index] = actual_1_A_P_ValueLabel;
            index++;

            actualLabels[index] = actual_2_ValueLabel;
            actual_A_P_Labels[index] = actual_2_A_P_ValueLabel;
            index++;

            actualLabels[index] = actual_3_ValueLabel;
            actual_A_P_Labels[index] = actual_3_A_P_ValueLabel;
            index++;

            actualLabels[index] = actual_4_ValueLabel;
            actual_A_P_Labels[index] = actual_4_A_P_ValueLabel;
            index++;

            actualLabels[index] = actual_5_ValueLabel;
            actual_A_P_Labels[index] = actual_5_A_P_ValueLabel;
            index++;

            actualLabels[index] = actual_6_ValueLabel;
            actual_A_P_Labels[index] = actual_6_A_P_ValueLabel;
            index++;

            actualLabels[index] = actual_7_ValueLabel;
            actual_A_P_Labels[index] = actual_7_A_P_ValueLabel;
            index++;

            actualLabels[index] = actual_8_ValueLabel;
            actual_A_P_Labels[index] = actual_8_A_P_ValueLabel;
            index++;

            actualLabels[index] = actual_9_ValueLabel;
            actual_A_P_Labels[index] = actual_9_A_P_ValueLabel;
            index++;

            actualLabels[index] = actual_10_ValueLabel;
            actual_A_P_Labels[index] = actual_10_A_P_ValueLabel;
            index++;

        }

        private void InitColor()
        {
            textColor = Color.FromArgb(37, 55, 86);
            redTextColor = Color.FromArgb(216, 86, 100);
            LabelsInitColor(textColor);

        }

        private void LabelsInitColor(Color textColor)
        {
            foreach (var item in actualLabels.Values)
            {
                item.ForeColor = textColor;
            }
            foreach (var item in actual_A_P_Labels.Values)
            {
                item.ForeColor = textColor;
            }
        }

        #endregion



        private void InitTestResult()
        {
            this.InvokeIfRequired(() =>
            {
                if (this.DesignMode)
                    return;
                if (isDesignMode)
                    return;

                if (testResult == null)
                    this.Size = new Size(0, this.Size.Height);
                else
                {
                    if (testResult.AllTests == null || testResult.AllTests.Count == 0)
                    {
                        this.Size = new Size(0, this.Size.Height);
                        return;
                    }

                    int maxCount = Math.Min(testResult.AllTests.Count, actualLabels.Count);
                    bool isOk = true;
                    for (int ii = maxCount - 1, jj = 0; ii >= 0; ii--, jj++)
                    {
                        actualLabels[jj].Text = $"{Math.Round(Utils.GetActual(TypeUnit, testResult.AllTests[ii]), 2)}";
                        actual_A_P_Labels[jj].Text = $"{Math.Round(Manager.GetPercentage(testResult.AllTests[ii], testResult.Prediction, TypeUnit, out isOk), 0)}";
                        if (isOk)
                            actual_A_P_Labels[jj].ForeColor = textColor;
                        else
                            actual_A_P_Labels[jj].ForeColor = redTextColor;

                    }
                    this.Size = new Size(actual_A_P_Labels[maxCount - 1].Location.X + actual_A_P_Labels[maxCount - 1].Width + 2, this.Size.Height);

                }
            });




        }
        private void Manager_TestDone(bool res, PUATestResult result)
        {
            if (res)
            {
                testResult = result;
                InitTestResult();
                    
            }
        }

        #endregion
    }
}
