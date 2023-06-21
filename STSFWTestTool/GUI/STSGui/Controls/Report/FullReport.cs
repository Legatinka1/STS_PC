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

namespace STSGui.Controls.Report
{
    public partial class FullReport : UserControl
    {
        #region Private Members

        private Bitmap cloneBitmap;

        private bool isInit = false;

        #endregion

        #region Constructor / Control_Load
        public FullReport()
        {
            InitializeComponent();
        }

        private void FullReport_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            isInit = false;

            cloneBitmap = new Bitmap(this.Width, this.Height);

            InitColor();
            SubscrubeForManagerEvents();
            SubscrubeForControlsEvents();

            isInit = true;

        }


        #endregion

        #region Events

        public event Action<PrintData> StartPrint;
        public event Action CancelPrint;

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
            //vistTestsControl1.ResetControls();
        }
        //public void SetPatientVisit(Patient patient, PatientVisit currentVisit)
        //{
        //    reportResultTest1.SetCurrentTestResult(patient,currentVisit.Test,"Test 1","Test 2");
        //}
        public void SetPatientVisit(PatientVisit currentVisit)
        {
            reportResultTest1.SetCurrentTestResult(currentVisit);
        }

        #endregion

        #region Private Functions

        private void InitColor()
        {
            this.BackColor = Color.FromArgb(247, 248, 252);
        }
        private void SubscrubeForManagerEvents()
        {
            Manager.PrintStart += Manager_PrintStart;
            Manager.PrintDone += Manager_PrintDone;
        }

        private void Manager_PrintDone(bool res)
        {

        }

        private void Manager_PrintStart()
        {

        }

        private void SubscrubeForControlsEvents()
        {
            printer1.StartPrint += Printer1_StartPrint;
            printer1.CancelPrint += Printer1_CancelPrint;
       }

        private void Printer1_CancelPrint()
        {
            CancelPrint?.Invoke();
        }

        private void Printer1_StartPrint(PrintData printData)
        {
            Bitmap reportBitmap = new Bitmap(reportResultTest1.Width, reportResultTest1.Height);
            reportResultTest1.DrawToBitmap(reportBitmap, new Rectangle(0, 0, reportResultTest1.Width, reportResultTest1.Height));
            printData.ReportBitmap = reportBitmap;
            StartPrint?.Invoke(printData);
        }

        #endregion

        private void reportResultTest1_Load(object sender, EventArgs e)
        {

        }
    }
}
