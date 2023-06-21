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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STSGui
{
    public partial class PredictedResults : UserControl
    {
        #region Private Members

        PUATestHelper currentPUATestHelper = null;

        List<PredictedResultsItem> allTestsLeftParameterItems = new List<PredictedResultsItem>();

        private Bitmap cloneBitmap;
        private bool isFirst = true;

        private bool isInit = false;

        #endregion

        #region Constructor / Control_Load

        public PredictedResults()
        {
            InitializeComponent();
        }

        private void PreviousTests_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            isInit = false;

            cloneBitmap = new Bitmap(this.Width, this.Height);

            PostLanguageChangedInit();
            SubscrubeForManagerEvents();

            isInit = true;
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
        }

        public void SetPUATestHelper(PUATestHelper puaTestHelper)
        {
            currentPUATestHelper = puaTestHelper;

            SetPredictedImpl();
        }

        #endregion

        #region Private Functions
        private void SubscrubeForManagerEvents()
        {
            //Manager.TestDone += Manager_TestDone;
        }

        private void PostLanguageChangedInit()
        {
            InitColor();
            InitResultControls();
            InitTestResult();
        }
        private void InitResultControls()
        {

            predictedResultsItem_FVC.TypeUnit = Enum_PUAParameters.FVC;
            predictedResultsItem_FEV1.TypeUnit = Enum_PUAParameters.FEV1;
            predictedResultsItem_FEV1_FVC.TypeUnit = Enum_PUAParameters.FEV1_FVC;
            predictedResultsItem_FEV6.TypeUnit = Enum_PUAParameters.FEV6;
            predictedResultsItem_FEV3.TypeUnit = Enum_PUAParameters.FEV3;
            predictedResultsItem_FEV3_FVC.TypeUnit = Enum_PUAParameters.FEV3_FVC;
            predictedResultsItem_PEF.TypeUnit = Enum_PUAParameters.PEF;
            predictedResultsItem_FEF25_75.TypeUnit = Enum_PUAParameters.FEF25_75;
            predictedResultsItem_VC.TypeUnit = Enum_PUAParameters.VC;
            predictedResultsItem_TLC.TypeUnit = Enum_PUAParameters.TLC;
            predictedResultsItem_TGV.TypeUnit = Enum_PUAParameters.TGV;
            predictedResultsItem_RV.TypeUnit = Enum_PUAParameters.RV;
            predictedResultsItem_TGV_TLC.TypeUnit = Enum_PUAParameters.TGV_TLC;
            predictedResultsItem_RV_TLC.TypeUnit = Enum_PUAParameters.RV_TLC;
            predictedResultsItem_RAW.TypeUnit = Enum_PUAParameters.RAW;
            predictedResultsItem_CL.TypeUnit = Enum_PUAParameters.CL;
            predictedResultsItem_IVC.TypeUnit = Enum_PUAParameters.IVC;
            predictedResultsItem_PIF.TypeUnit = Enum_PUAParameters.PIF;


            allTestsLeftParameterItems.Add(predictedResultsItem_FVC);
            allTestsLeftParameterItems.Add(predictedResultsItem_FEV1);
            allTestsLeftParameterItems.Add(predictedResultsItem_FEV1_FVC);
            allTestsLeftParameterItems.Add(predictedResultsItem_FEV6);
            allTestsLeftParameterItems.Add(predictedResultsItem_FEV3);
            allTestsLeftParameterItems.Add(predictedResultsItem_FEV3_FVC);
            allTestsLeftParameterItems.Add(predictedResultsItem_PEF);
            allTestsLeftParameterItems.Add(predictedResultsItem_FEF25_75);
            allTestsLeftParameterItems.Add(predictedResultsItem_VC);
            allTestsLeftParameterItems.Add(predictedResultsItem_TLC);
            allTestsLeftParameterItems.Add(predictedResultsItem_TGV);
            allTestsLeftParameterItems.Add(predictedResultsItem_RV);
            allTestsLeftParameterItems.Add(predictedResultsItem_TGV_TLC);
            allTestsLeftParameterItems.Add(predictedResultsItem_RV_TLC);
            allTestsLeftParameterItems.Add(predictedResultsItem_RAW);
            allTestsLeftParameterItems.Add(predictedResultsItem_CL);
            allTestsLeftParameterItems.Add(predictedResultsItem_IVC);
            allTestsLeftParameterItems.Add(predictedResultsItem_PIF);

        }
        private void InitTestResult()
        {
            //testsLeftParameterHeader1.SetCurrentTestResult(testResult);
            //testsRightParameterHeader1.SetCurrentTestResult(testResult);

            //foreach (var item in allTestsLeftParameterItems)
            //{
            //    item.SetCurrentTestResult(testResult);
            //}
            //foreach (var item in allTestsRightParameterItems)
            //{
            //    item.SetCurrentTestResult(testResult);
            //}

        }

        private void SetPredictedImpl()
        {
            if (currentPUATestHelper == null)
                return;

            foreach (PredictedResultsItem item in allTestsLeftParameterItems)
            {
                item.SetPUATestHelper(currentPUATestHelper);
            }
            
        }
        private void InitColor()
        {

            this.BackColor = Color.FromArgb(247, 248, 252);


            Color textcolor = Color.FromArgb(110, 157, 209);

            predictedResults_Name_Label.ForeColor = textcolor;
            flowVolumeParametersLabel.ForeColor = textcolor;
            predictedLabel.ForeColor = textcolor;
            volumeParametersLabel.ForeColor = textcolor;
            resistanceComplianceParametersLabel.ForeColor = textcolor;

        }


        #endregion
    }
}
