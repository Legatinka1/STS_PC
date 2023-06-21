using CommonLib;
using ImplementationLib;
using InterfacesLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STSGui.Controls.Pressure
{
    public partial class PressureControl : UserControl
    {
        #region Private Members

        private Patient currentPatient = null;
        private PUATestResult testResult = null;

        #endregion

        #region Constructor / Control_Load

        public PressureControl()
        {
            InitializeComponent();
        }

        private void PressureControl_Load(object sender, EventArgs e)
        {

            if (this.DesignMode)
                return;

            PostLanguageChangedInit();
        }

        #endregion

        #region Public Functions

        public void SetCurrentTestResult(PatientVisit visit)
        {
            currentPatient = visit.Patient;
            testResult = visit.Test;

            InitTestResult();
        }

        #endregion

        #region Get Manager

        private ISTSManager Manager
        {
            get => STSManager.GetManager;
        }

        #endregion

        #region Events

        public event Action ClosePressureControl;

        #endregion

        #region Private Functions

        private void PostLanguageChangedInit()
        {
            InitColor();
        }
        private void InitColor()
        {
            Color textcolor = Color.FromArgb(62, 124, 195);

            pressureMeasuremetsLabel.ForeColor = textcolor;
            examplesLabel.ForeColor = textcolor;

            Color backcolor = Color.FromArgb(250, 251, 221);
            restrictiveLabel.BackColor = backcolor;
            restrictive_T_Label.BackColor = backcolor;
            restrictive_V_Label.BackColor = backcolor;
            restrictive_P_Label.BackColor = backcolor;
            restrictive_O_Label.BackColor = backcolor;

            obstructiveLabel.BackColor = backcolor;
            obstructive_T_Label.BackColor = backcolor;
            obstructive_V_Label.BackColor = backcolor;
            obstructive_P_Label.BackColor = backcolor;
            obstructive_O_Label.BackColor = backcolor;

            backcolor = Color.FromArgb(228, 240, 210);
            healthyLabel.BackColor = backcolor;
            healthy_T_Label.BackColor = backcolor;
            healthy_V_Label.BackColor = backcolor;
            healthy_P_Label.BackColor = backcolor;
            healthy_O_Label.BackColor = backcolor;
        }
        private void InitTestResult()
        {
            InitGraphControls();
            InitTableControl();
        }

        private void InitTableControl()
        {
            if (testResult.BestIndex < 0 || testResult.BestIndex >= testResult.AllTests.Count)
                return;

            PUATestHelper helper = testResult.AllTests[testResult.BestIndex];

            value_T_Label.Text = $"{Math.Round(helper.IndexT.Value, 2)}";
            value_V_Label.Text = $"{Math.Round(helper.IndexV.Value, 2)}";
            value_P_Label.Text = $"{Math.Round(helper.IndexP.Value, 2)}";
            value_O_Label.Text = $"{Math.Round(helper.IndexO.Value, 2)}";

            restrictive_T_Label.Text = "";
            healthy_T_Label.Text = "";
            obstructive_T_Label.Text = "";
            switch (helper.IndexT.IndexClassification)
            {
                case DoCalc.DoCalc.HealtCondition.Healty:
                    healthy_T_Label.Text = "X";
                    break;
                case DoCalc.DoCalc.HealtCondition.Obstructuve:
                    obstructive_T_Label.Text = "X";
                    break;
                case DoCalc.DoCalc.HealtCondition.Restrictive:
                    restrictive_T_Label.Text = "X";
                    break;
                default:
                    break;
            }

            restrictive_V_Label.Text = "";
            healthy_V_Label.Text = "";
            obstructive_V_Label.Text = "";
            switch (helper.IndexV.IndexClassification)
            {
                case DoCalc.DoCalc.HealtCondition.Healty:
                    healthy_V_Label.Text = "X";
                    break;
                case DoCalc.DoCalc.HealtCondition.Obstructuve:
                    obstructive_V_Label.Text = "X";
                    break;
                case DoCalc.DoCalc.HealtCondition.Restrictive:
                    restrictive_V_Label.Text = "X";
                    break;
                default:
                    break;
            }

            restrictive_P_Label.Text = "";
            healthy_P_Label.Text = "";
            obstructive_P_Label.Text = "";
            switch (helper.IndexP.IndexClassification)
            {
                case DoCalc.DoCalc.HealtCondition.Healty:
                    healthy_P_Label.Text = "X";
                    break;
                case DoCalc.DoCalc.HealtCondition.Obstructuve:
                    obstructive_P_Label.Text = "X";
                    break;
                case DoCalc.DoCalc.HealtCondition.Restrictive:
                    restrictive_P_Label.Text = "X";
                    break;
                default:
                    break;
            }

            restrictive_O_Label.Text = "";
            healthy_O_Label.Text = "";
            obstructive_O_Label.Text = "";
            switch (helper.IndexO.IndexClassification)
            {
                case DoCalc.DoCalc.HealtCondition.Healty:
                    healthy_O_Label.Text = "X";
                    break;
                case DoCalc.DoCalc.HealtCondition.Obstructuve:
                    obstructive_O_Label.Text = "X";
                    break;
                case DoCalc.DoCalc.HealtCondition.Restrictive:
                    restrictive_O_Label.Text = "X";
                    break;
                default:
                    break;
            }
        }

        private void InitGraphControls()
        {
            if (testResult.BestIndex < 0 || testResult.BestIndex >= testResult.AllTests.Count)
                return;

            pressureCountsGraph.LoadTestPressure(testResult.AllTests[testResult.BestIndex]);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            ClosePressureControl?.Invoke();
        }

        #endregion

    }
}
