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
    public partial class ReportTestControl : UserControl
    {
        #region Private Members

        private Patient currentPatient = null;
        private PUATestResult testResult = null;
        private PatientVisit _visit = null;
        string medicalCenterName = "";
        string medicalCenterUnitName = "";

        #endregion

        #region Constructor / Control_Load

        public ReportTestControl()
        {
            InitializeComponent();
        }

        private void ReportTestControl_Load(object sender, EventArgs e)
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
            _visit = visit;
            medicalCenterName = visit.VisitHospital.HospitalName;
            medicalCenterUnitName = visit.VisitHospital.ClassName;

            InitTestResult();
        }

        //public void SetCurrentTestResult(Patient patient,PUATestResult result,string medicalCenter, string medicalCenterUnit)
        //{
        //    currentPatient = patient;
        //    testResult = result;
        //    medicalCenterName = medicalCenter;
        //    medicalCenterUnitName = medicalCenterUnit;

        //    InitTestResult();
        //}

        #endregion

        #region Get Manager

        private ISTSManager Manager
        {
            get => STSManager.GetManager;
        }

        #endregion

        #region Private Functions

        private void InitTestResult()
        {
            SetPatientImpl();
            SetMedicalCenterImpl();
            InitReportBestTestControl();
            InitGraphControls();
            InitTable();
            InitUnits();
        }

        private void InitGraphControls()
        {
            ucTestGraph1.Title = "Exh Flow";
            ucTestGraph2.Title = "FVC";
            ucTestGraph3.Title = "Pressure";

            ucTestGraph1.LoadExhFlow(testResult);
            ucTestGraph2.LoadFVC(testResult);
            ucTestGraph3.LoadTestPressure(testResult);
        }

        private void InitTable()
        {
            if (testResult.BestIndex == -1 || testResult.AllTests[testResult.BestIndex] == null)
                return;

            tValue.Text = $"T ({Math.Round(testResult.AllTests[testResult.BestIndex].IndexT.Value, 2)})";
            vValue.Text = $"V ({Math.Round(testResult.AllTests[testResult.BestIndex].IndexV.Value, 2)})";
            pValue.Text = $"P ({Math.Round(testResult.AllTests[testResult.BestIndex].IndexP.Value, 2)})";
            oValue.Text = $"O ({Math.Round(testResult.AllTests[testResult.BestIndex].IndexO.Value, 2)})";

            tRestrictive.Text = "";
            tHealth.Text = "";
            tObstructive.Text = "";
            switch (testResult.AllTests[testResult.BestIndex].IndexT.IndexClassification)
            {
                case DoCalc.DoCalc.HealtCondition.Healty:
                    tHealth.Text = "x";
                    break;
                case DoCalc.DoCalc.HealtCondition.Obstructuve:
                    tObstructive.Text = "x";
                    break;
                case DoCalc.DoCalc.HealtCondition.Restrictive:
                    tRestrictive.Text = "x";
                    break;
            }

            vRestrictive.Text = "";
            vHealth.Text = "";
            vObstructive.Text = "";
            switch (testResult.AllTests[testResult.BestIndex].IndexV.IndexClassification)
            {
                case DoCalc.DoCalc.HealtCondition.Healty:
                    vHealth.Text = "x";
                    break;
                case DoCalc.DoCalc.HealtCondition.Obstructuve:
                    vObstructive.Text = "x";
                    break;
                case DoCalc.DoCalc.HealtCondition.Restrictive:
                    vRestrictive.Text = "x";
                    break;
            }

            pRestrictive.Text = "";
            pHealth.Text = "";
            pObstructive.Text = "";
            switch (testResult.AllTests[testResult.BestIndex].IndexP.IndexClassification)
            {
                case DoCalc.DoCalc.HealtCondition.Healty:
                    pHealth.Text = "x";
                    break;
                case DoCalc.DoCalc.HealtCondition.Obstructuve:
                    pObstructive.Text = "x";
                    break;
                case DoCalc.DoCalc.HealtCondition.Restrictive:
                    pRestrictive.Text = "x";
                    break;
            }

            oRestrictive.Text = "";
            oHealth.Text = "";
            oObstructive.Text = "";
            switch (testResult.AllTests[testResult.BestIndex].IndexO.IndexClassification)
            {
                case DoCalc.DoCalc.HealtCondition.Healty:
                    oHealth.Text = "x";
                    break;
                case DoCalc.DoCalc.HealtCondition.Obstructuve:
                    oObstructive.Text = "x";
                    break;
                case DoCalc.DoCalc.HealtCondition.Restrictive:
                    oRestrictive.Text = "x";
                    break;
            }
        }

        private void InitReportBestTestControl()
        {
            reportBestTestControl1.SetCurrentTestResult(testResult);
        }

        private void SetMedicalCenterImpl()
        {
            medicalCenterNameLabel.Text = medicalCenterName;
            medicalCenterUnitNameLabel.Text = medicalCenterUnitName;
        }

        private void SetPatientImpl()
        {
            if (currentPatient == null)
            {
                patientName_Value_Label.Text = "";
                patientAge_Value_Label.Text = "";
                patientID_Value_Label.Text = "";


                birthDate_Value_Label.Text = "";
                gender_Value_Label.Text = "";
                height_Value_Label.Text = "";
                weight_Value_Label.Text = "";
                bmi_Value_Label.Text = "";

                lblDate.Text = "";

            }
            else
            {
                patientName_Value_Label.Text = $"{currentPatient.FullName}";
                patientAge_Value_Label.Text = $"{Math.Round((DateTime.Now - currentPatient.BirthDate).TotalDays / 365, 0)}";
                patientID_Value_Label.Text = $"{currentPatient.PatientId}";

                birthDate_Value_Label.Text = $"{currentPatient.BirthDate.ToString("dd/MM/yyyy")}";
                gender_Value_Label.Text = $"{currentPatient.Gender}";
                height_Value_Label.Text = $"{currentPatient.Height}";
                weight_Value_Label.Text = $"{currentPatient.Weight}";
                bmi_Value_Label.Text = $"{Math.Round(Manager.GetBMI(currentPatient), 1)}";

                lblDate.Text = $"{_visit.VisitDateTime.ToString("dd/MM/yyyy")}";
            }



        }

        private void PostLanguageChangedInit()
        {
            InitColor();
        }
        private void InitColor()
        {
            Color textColor = Color.FromArgb(37, 55, 86);

            medicalCenterNameLabel.ForeColor = textColor;
            medicalCenterUnitNameLabel.ForeColor = textColor;

            patientName_Name_Label.ForeColor = textColor;
            patientName_Value_Label.ForeColor = textColor;

            patientID_Name_Label.ForeColor = textColor;
            patientID_Value_Label.ForeColor = textColor;

            height_Name_Label.ForeColor = textColor;
            height_Value_Label.ForeColor = textColor;

            weight_Name_Label.ForeColor = textColor;
            weight_Value_Label.ForeColor = textColor;

            patientAge_Name_Label.ForeColor = textColor;
            patientAge_Value_Label.ForeColor = textColor;

            gender_Name_Label.ForeColor = textColor;
            gender_Value_Label.ForeColor = textColor;

            birthDate_Name_Label.ForeColor = textColor;
            birthDate_Value_Label.ForeColor = textColor;

            bmi_Name_Label.ForeColor = textColor;
            bmi_Value_Label.ForeColor = textColor;

            textColor = Color.FromArgb(113, 125, 145);
            healthClinicLabelExtended.NormalTextColor = textColor;

            textColor = Color.FromArgb(220, 107, 118);
            postNameLabel.ForeColor = textColor;

            textColor = Color.FromArgb(53, 95, 168);
            picNameLabel.ForeColor = textColor;

            textColor = Color.FromArgb(151, 151, 151);
            refNameLabel.ForeColor = textColor;

        }
        private void InitUnits()
        {
            if (_visit == null)
                return;

            if (_visit.UnitSystem == Enum_Unit_System.Metric)
            {
                height_Name_Label.Text = "Height (cm)";
                weight_Name_Label.Text = "Weight (kg)";
            }
            else if (_visit.UnitSystem == Enum_Unit_System.USA)
            {
                height_Name_Label.Text = "Height (inch)";
                weight_Name_Label.Text = "Weight (pound)";
            }
            else if (_visit.UnitSystem == Enum_Unit_System.Imperial)
            {
                height_Name_Label.Text = "Height (inch)";
                weight_Name_Label.Text = "Weight (pound)";
            }
            else
            {
                height_Name_Label.Text = "Height ";
                weight_Name_Label.Text = "Weight ";
            }
        }

        #endregion

    }
}
