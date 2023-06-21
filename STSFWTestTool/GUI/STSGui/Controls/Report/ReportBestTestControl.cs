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

namespace STSGui.Controls.Visit
{
    public partial class ReportBestTestControl : UserControl
    {
        #region Private Members

        private Color textColor;
        private PUATestResult testResult = null;
        List<TestsLeftParameterItem> allTestsLeftParameterItems = new List<TestsLeftParameterItem>();

        #endregion

        #region Constructor / Control_Load
        public ReportBestTestControl()
        {
            InitializeComponent();
        }

        private void ReportBestTestControl_Load(object sender, EventArgs e)
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

        public void ResetControls()
        {
            testsLeftParameterHeader1.Reset();

            foreach (var item in allTestsLeftParameterItems)
            {
                item.Reset();
            }
        }
        public void SetCurrentTestResult(PUATestResult result)
        {
            testResult = result;
            InitTestResult();
        }
        public PUATestResult GetCurrentTestResult()
        {
            return testResult ;
        }

        #endregion

        #region Private Functions

        private void Manager_TestDone(bool res, PUATestResult result)
        {
            if (res)
                testResult = result;
        }

        #region Service Functions

        private void PostLanguageChangedInit()
        {
            InitColor();
            InitResultControls();
            InitTestResult();

        }

        private void InitResultControls()
        {

            testsLeftParameterItem_FVC.TypeUnit = Enum_PUAParameters.FVC;
            testsLeftParameterItem_FEV1.TypeUnit = Enum_PUAParameters.FEV1;
            testsLeftParameterItem_FEV1_FVC.TypeUnit = Enum_PUAParameters.FEV1_FVC;
            testsLeftParameterItem_FEV6.TypeUnit = Enum_PUAParameters.FEV6;
            testsLeftParameterItem_FEV3.TypeUnit = Enum_PUAParameters.FEV3;
            testsLeftParameterItem_FEV3_FVC.TypeUnit = Enum_PUAParameters.FEV3_FVC;
            testsLeftParameterItem_PEF.TypeUnit = Enum_PUAParameters.PEF;
            testsLeftParameterItem_FEF25_75.TypeUnit = Enum_PUAParameters.FEF25_75;
            testsLeftParameterItem_VC.TypeUnit = Enum_PUAParameters.VC;
            testsLeftParameterItem_TLC.TypeUnit = Enum_PUAParameters.TLC;
            testsLeftParameterItem_TGV.TypeUnit = Enum_PUAParameters.TGV;
            testsLeftParameterItem_RV.TypeUnit = Enum_PUAParameters.RV;
            testsLeftParameterItem_TGV_TLC.TypeUnit = Enum_PUAParameters.TGV_TLC;
            testsLeftParameterItem_RV_TLC.TypeUnit = Enum_PUAParameters.RV_TLC;
            testsLeftParameterItem_RAW.TypeUnit = Enum_PUAParameters.RAW;
            testsLeftParameterItem_CL.TypeUnit = Enum_PUAParameters.CL;
            testsLeftParameterItem_IVC.TypeUnit = Enum_PUAParameters.IVC;
            testsLeftParameterItem_PIF.TypeUnit = Enum_PUAParameters.PIF;

            allTestsLeftParameterItems.Add(testsLeftParameterItem_FVC);
            allTestsLeftParameterItems.Add(testsLeftParameterItem_FEV1);
            allTestsLeftParameterItems.Add(testsLeftParameterItem_FEV1_FVC);
            allTestsLeftParameterItems.Add(testsLeftParameterItem_FEV6);
            allTestsLeftParameterItems.Add(testsLeftParameterItem_FEV3);
            allTestsLeftParameterItems.Add(testsLeftParameterItem_FEV3_FVC);
            allTestsLeftParameterItems.Add(testsLeftParameterItem_PEF);
            allTestsLeftParameterItems.Add(testsLeftParameterItem_FEF25_75);
            allTestsLeftParameterItems.Add(testsLeftParameterItem_VC);
            allTestsLeftParameterItems.Add(testsLeftParameterItem_TLC);
            allTestsLeftParameterItems.Add(testsLeftParameterItem_TGV);
            allTestsLeftParameterItems.Add(testsLeftParameterItem_RV);
            allTestsLeftParameterItems.Add(testsLeftParameterItem_TGV_TLC);
            allTestsLeftParameterItems.Add(testsLeftParameterItem_RV_TLC);
            allTestsLeftParameterItems.Add(testsLeftParameterItem_RAW);
            allTestsLeftParameterItems.Add(testsLeftParameterItem_CL);
            allTestsLeftParameterItems.Add(testsLeftParameterItem_IVC);
            allTestsLeftParameterItems.Add(testsLeftParameterItem_PIF);
        }

        private void InitColor()
        {
            textColor = Color.FromArgb(37, 55, 86);
            LabelsInitColor(textColor);

        }


        private void LabelsInitColor(Color textColor)
        {
            flowVolumeParametersLabel.ForeColor = textColor;
            volumeParametersLabel.ForeColor = textColor;
            resistanceComplianceParametersLabel.ForeColor = textColor;
        }

        private void InitTestResult()
        {
            testsLeftParameterHeader1.SetCurrentTestResult(testResult);

            foreach (var item in allTestsLeftParameterItems)
            {
                item.SetCurrentTestResult(testResult);
            }

        }
        private void SubscrubeForManagerEvents()
        {
            Manager.TestDone += Manager_TestDone;
        }

        #endregion

        #endregion

    }
}
