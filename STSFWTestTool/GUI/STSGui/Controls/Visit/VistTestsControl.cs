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
    public partial class VistTestsControl : UserControl
    {
        #region Private Members

        private Color textColor;
        private PUATestResult testResult = null;
        List<TestsLeftParameterItem> allTestsLeftParameterItems = new List<TestsLeftParameterItem>();
        List<TestsRightParameterItem> allTestsRightParameterItems = new List<TestsRightParameterItem>();

        bool isMoveble = true;
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);
        //        Rectangle startRectangle = Rectangle.Empty;

        private bool _isNewSession = true;
        #endregion

        #region Constructor / Control_Load
        public VistTestsControl()
        {
            InitializeComponent();
        }

        private void VistTestsControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            PostLanguageChangedInit();
            SubscrubeForManagerEvents();
            SubscrubeForControlsEvents();
            //ControlExtension.Draggable(allGridItemsPanel, true);

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
            testsRightParameterHeader1.Reset();

            foreach (var item in allTestsLeftParameterItems)
            {
                item.Reset();
            }
            foreach (var item in allTestsRightParameterItems)
            {
                item.Reset();
            }
            allGridItemsPanel.Width = Math.Max(allTestsRightParameterItems[0].Width, scrollPanel.Width);
            allGridItemsPanel.Location = new Point(0, 0);
            if (allGridItemsPanel.Width > scrollPanel.Width)
                ControlExtension.Draggable(allGridItemsPanel, true);
            else
                ControlExtension.Draggable(allGridItemsPanel, false);

        }
        public void SetCurrentTestResult(PUATestResult result, bool isNewSession)
        {
            testResult = result;
            _isNewSession = isNewSession;
            InitTestResult();
        }
        public PUATestResult GetCurrentTestResult()
        {
            return testResult ;
        }

        #endregion

        #region Events

        public event Action<int> RemoveTest;

        #endregion

        #region Private Functions

        private void Manager_TestDone(bool res, PUATestResult result)
        {
            if (res)
                testResult = result;
        }
        private void TestsRightParameterHeader1_RemoveTest(int index)
        {
            RemoveTest?.Invoke(index);
            //if (MessageBox.Show($"Remove Test index {index}?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    if (Manager.RemoveTest(testResult, index))
            //        InitTestResult();
            //    else
            //        MessageBox.Show($"Remove Test index {index} False", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}

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

            testsRightParameterItem_FVC.TypeUnit = Enum_PUAParameters.FVC;
            testsRightParameterItem_FEV1.TypeUnit = Enum_PUAParameters.FEV1;
            testsRightParameterItem_FEV1_FVC.TypeUnit = Enum_PUAParameters.FEV1_FVC;
            testsRightParameterItem_FEV6.TypeUnit = Enum_PUAParameters.FEV6;
            testsRightParameterItem_FEV3.TypeUnit = Enum_PUAParameters.FEV3;
            testsRightParameterItem_FEV3_FVC.TypeUnit = Enum_PUAParameters.FEV3_FVC;
            testsRightParameterItem_PEF.TypeUnit = Enum_PUAParameters.PEF;
            testsRightParameterItem_FEF25_75.TypeUnit = Enum_PUAParameters.FEF25_75;
            testsRightParameterItem_VC.TypeUnit = Enum_PUAParameters.VC;
            testsRightParameterItem_TLC.TypeUnit = Enum_PUAParameters.TLC;
            testsRightParameterItem_TGV.TypeUnit = Enum_PUAParameters.TGV;
            testsRightParameterItem_RV.TypeUnit = Enum_PUAParameters.RV;
            testsRightParameterItem_TGV_TLC.TypeUnit = Enum_PUAParameters.TGV_TLC;
            testsRightParameterItem_RV_TLC.TypeUnit = Enum_PUAParameters.RV_TLC;
            testsRightParameterItem_RAW.TypeUnit = Enum_PUAParameters.RAW;
            testsRightParameterItem_CL.TypeUnit = Enum_PUAParameters.CL;
            testsRightParameterItem_IVC.TypeUnit = Enum_PUAParameters.IVC;
            testsRightParameterItem_PIF.TypeUnit = Enum_PUAParameters.PIF;


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


            allTestsRightParameterItems.Add(testsRightParameterItem_FVC);
            allTestsRightParameterItems.Add(testsRightParameterItem_FEV1);
            allTestsRightParameterItems.Add(testsRightParameterItem_FEV1_FVC);
            allTestsRightParameterItems.Add(testsRightParameterItem_FEV6);
            allTestsRightParameterItems.Add(testsRightParameterItem_FEV3);
            allTestsRightParameterItems.Add(testsRightParameterItem_FEV3_FVC);
            allTestsRightParameterItems.Add(testsRightParameterItem_PEF);
            allTestsRightParameterItems.Add(testsRightParameterItem_FEF25_75);
            allTestsRightParameterItems.Add(testsRightParameterItem_VC);
            allTestsRightParameterItems.Add(testsRightParameterItem_TLC);
            allTestsRightParameterItems.Add(testsRightParameterItem_TGV);
            allTestsRightParameterItems.Add(testsRightParameterItem_RV);
            allTestsRightParameterItems.Add(testsRightParameterItem_TGV_TLC);
            allTestsRightParameterItems.Add(testsRightParameterItem_RV_TLC);
            allTestsRightParameterItems.Add(testsRightParameterItem_RAW);
            allTestsRightParameterItems.Add(testsRightParameterItem_CL);
            allTestsRightParameterItems.Add(testsRightParameterItem_IVC);
            allTestsRightParameterItems.Add(testsRightParameterItem_PIF);


            foreach (var item in allTestsRightParameterItems)
            {
                item.isDesignMode = false;
            }
            allTestsRightParameterItems[0].SizeChanged += VistTestsControl_SizeChanged;
            testsRightParameterHeader1.isDesignMode = false;

        }

        private void VistTestsControl_SizeChanged(object sender, EventArgs e)
        {
            allGridItemsPanel.Width = Math.Max(allTestsRightParameterItems[0].Width, scrollPanel.Width);
            if (allGridItemsPanel.Width > scrollPanel.Width)
                ControlExtension.Draggable(allGridItemsPanel, true);
            else
                ControlExtension.Draggable(allGridItemsPanel, false);

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
            testsRightParameterHeader1.SetCurrentTestResult(testResult, _isNewSession);

            foreach (var item in allTestsLeftParameterItems)
            {
                item.SetCurrentTestResult(testResult);
            }
            foreach (var item in allTestsRightParameterItems)
            {
                item.SetCurrentTestResult(testResult);
            }

            allGridItemsPanel.Width = Math.Max(allTestsRightParameterItems[0].Width, scrollPanel.Width);
            allGridItemsPanel.Location = new Point(0,0);
            if(allGridItemsPanel.Width>scrollPanel.Width)
                ControlExtension.Draggable(allGridItemsPanel, true);
            else
                ControlExtension.Draggable(allGridItemsPanel, false);


        }
        private void SubscrubeForManagerEvents()
        {
            Manager.TestDone += Manager_TestDone;
        }
        private void SubscrubeForControlsEvents()
        {
            testsRightParameterHeader1.RemoveTest += TestsRightParameterHeader1_RemoveTest;
        }


        #endregion

        #endregion

        #region Move Main Form Mouse Functions
        private void allGridItemsPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isMoveble)
                return;
            dragging = true;
            startPoint = Cursor.Position;
 //           startRectangle = Cursor.Clip;

            int RightWidth = Math.Max(0, -allGridItemsPanel.Location.X);
            int LeftWidth = allGridItemsPanel.Width - scrollPanel.Width - Math.Abs(allGridItemsPanel.Location.X);
            LeftWidth = Math.Max(LeftWidth, 0);
            int width = Math.Max((RightWidth + LeftWidth), 1);
            Point leftPoint = new Point(startPoint.X - LeftWidth, startPoint.Y);
            Rectangle clipRect = new Rectangle(leftPoint, new Size(width, 1));
            if (clipRect.Width == 1)
                return;
            Cursor.Clip = clipRect;

        }


        private void allGridItemsPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isMoveble)
                return;
            dragging = false;

            Cursor.Clip = new Rectangle();
        }
        #endregion

        private void testsLeftParameterHeader1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void testsLeftParameterHeader1_Click(object sender, EventArgs e)
        {

        }
    }
}
