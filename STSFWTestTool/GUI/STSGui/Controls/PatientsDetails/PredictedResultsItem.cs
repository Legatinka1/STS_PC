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
    public partial class PredictedResultsItem : UserControl
    {
        #region Private Members

        PUATestHelper currentPUATestHelper = null;

        Color textColor;
        Color redTextColor;

        Color greenBackColor;

        #endregion

        #region Constructor / Control_Load

        public PredictedResultsItem()
        {
            InitializeComponent();
        }

        private void TestsLeftParameterItem_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            PostLanguageChangedInit();
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
        }

        public void SetPUATestHelper(PUATestHelper puaTestHelper)
        {
            currentPUATestHelper = puaTestHelper;
            InitTestResult();
        }

        #endregion

        #region Private Functions



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

            LabelsInitColor(textColor);

        }

        private void LabelsInitColor(Color textColor)
        {
            typeUnitLabel.ForeColor = textColor;
            predictedLabel.ForeColor = textColor;

            typeUnitLabel.BackColor = greenBackColor;
            predictedLabel.BackColor = greenBackColor;
        }

        private void InitTestResult()
        {
            if (currentPUATestHelper == null)
                predictedLabel.Text = "";
            else
                predictedLabel.Text = $"{Math.Round(Utils.GetPrediction(TypeUnit, currentPUATestHelper), 2)}";
        }

        #endregion



        #endregion
    }
}
