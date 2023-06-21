using CommonLib;
using ImplementationLib;
using InterfacesLib;
using Patientlist;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace GUITest
{
    public partial class TestSession : Form
    {
        private PatientVisit visit;

        private PUATestHelper predict;
        private PUATestHelper best;

        public TestSession(PatientVisit pv)
        {
            InitializeComponent();

            visit = pv;
        }

        private void TestSession_Load(object sender, EventArgs e)
        {
            LPatientInfo.Text = $"{visit.Patient.FullName} {visit.Patient.PatientId}";

            InitPredicted();
            InitBest();

            InitPreviousTest();

            UCTestGraph uc = new UCTestGraph();
            uc.LoadTestResult(visit.Test);
            PTestGraph.Controls.Add(uc);
        }

        private void InitPredicted()
        {
            predict = visit.Test.Prediction;
            if (predict != null)
                AddTest(1, predict);
        }

        private void AddTest(int column, PUATestHelper pua)
        {
            LViewPreviousTest.Items[0].SubItems[column].Text = $"{pua.FVC:0.000}";
            LViewPreviousTest.Items[1].SubItems[column].Text = $"{pua.FEV1:0.000}";
            LViewPreviousTest.Items[2].SubItems[column].Text = $"{pua.FEV1_FVC:0.000}";
            LViewPreviousTest.Items[3].SubItems[column].Text = $"{pua.FEV6:0.000}";
            LViewPreviousTest.Items[4].SubItems[column].Text = $"{pua.FEV3:0.000}";
            LViewPreviousTest.Items[5].SubItems[column].Text = $"{pua.FEV3_FVC:0.000}";
            LViewPreviousTest.Items[6].SubItems[column].Text = $"{pua.PEF:0.000}";
            LViewPreviousTest.Items[7].SubItems[column].Text = $"{pua.FEF25_75:0.000}";
            LViewPreviousTest.Items[8].SubItems[column].Text = $"{pua.VC:0.000}";
                                                              
            LViewPreviousTest.Items[9].SubItems[column].Text = $"{pua.TLC:0.000}";
            LViewPreviousTest.Items[10].SubItems[column].Text = $"{pua.TGV:0.000}";
            LViewPreviousTest.Items[11].SubItems[column].Text = $"{pua.RV:0.000}";
            LViewPreviousTest.Items[12].SubItems[column].Text = $"{pua.TGV_TLC:0.000}";
            LViewPreviousTest.Items[13].SubItems[column].Text = $"{pua.RV_TLC:0.000}";
                                                                
            LViewPreviousTest.Items[14].SubItems[column].Text = $"{pua.RAW:0.000}";
            LViewPreviousTest.Items[15].SubItems[column].Text = $"{pua.CL:0.000}";
        }


        private void InitBest()
        {
            best = visit.Test.AllTests[visit.Test.BestIndex];
            if (best != null)
                AddTest(2, best);
        }

        private void InitPreviousTest()
        {

            Debug.WriteLine(visit.Patient.FullName + " " + visit.Test.AllTests[0].RAW);

            if (visit.Test == null || visit.Test.AllTests.Count == 0)
                return;

            // FVC
            string[] row = new string[visit.Test.AllTests.Count];

            double[] value;

            bool stam = true;
            // FVC
            for (int i = visit.Test.AllTests.Count - 1; i >= 0; i--)
            {
                //LViewPreviousTests.Columns.Add($"Test {i}", 95);
                LViewPreviousTest.Columns.Add($"  Test {i + 1}", 100);

                row[i] = $"{visit.Test.AllTests[i].FVC:0.000}     {STSManager.GetManager.GetPercentage(visit.Test.AllTests[i], predict, Enum_PUAParameters.FVC, out stam):0.000}";
                //LViewPreviousTests.Items.Add(new ListViewItem(row));
                LViewPreviousTest.Items[0].SubItems.Add(new ListViewSubItem());
                LViewPreviousTest.Items[0].SubItems[3 + visit.Test.AllTests.Count - i - 1].Text = row[i];
            }
            // FEV1
            for (int i = visit.Test.AllTests.Count - 1; i >= 0; i--)
            {
                //value = visit.Test[i];
                //pua.RawData = value;
                //pua.CalculateParameters(visit.Patient);

                row[i] = $"{visit.Test.AllTests[i].FEV1:0.000}     {STSManager.GetManager.GetPercentage(visit.Test.AllTests[i], predict, Enum_PUAParameters.FEV1, out stam):0.000}";
                //LViewPreviousTests.Items.Add(new ListViewItem(row));
                LViewPreviousTest.Items[1].SubItems.Add(new ListViewSubItem());
                LViewPreviousTest.Items[1].SubItems[3 + visit.Test.AllTests.Count - i - 1].Text = row[i];
            }
            // FEV1_FVC
            for (int i = visit.Test.AllTests.Count - 1; i >= 0; i--)
            {
                row[i] = $"{visit.Test.AllTests[i].FEV1_FVC:0.000}     {STSManager.GetManager.GetPercentage(visit.Test.AllTests[i], predict, Enum_PUAParameters.FEV1_FVC, out stam):0.000}";
                //LViewPreviousTests.Items.Add(new ListViewItem(row));
                LViewPreviousTest.Items[2].SubItems.Add(new ListViewSubItem());
                LViewPreviousTest.Items[2].SubItems[3 + visit.Test.AllTests.Count - i - 1].Text = row[i];
            }

            // FEV6
            for (int i = visit.Test.AllTests.Count - 1; i >= 0; i--)
            {
                row[i] = $"{visit.Test.AllTests[i].FEV6:0.000}     {STSManager.GetManager.GetPercentage(visit.Test.AllTests[i], predict, Enum_PUAParameters.FEV6, out stam):0.000}";
                //LViewPreviousTests.Items.Add(new ListViewItem(row));
                LViewPreviousTest.Items[3].SubItems.Add(new ListViewSubItem());
                LViewPreviousTest.Items[3].SubItems[3 + visit.Test.AllTests.Count - i - 1].Text = row[i];
            }
            // FEV3
            for (int i = visit.Test.AllTests.Count - 1; i >= 0; i--)
            {
                row[i] = $"{visit.Test.AllTests[i].FEV3:0.000}     {STSManager.GetManager.GetPercentage(visit.Test.AllTests[i], predict, Enum_PUAParameters.FEV3, out stam):0.000}";
                //LViewPreviousTests.Items.Add(new ListViewItem(row));
                LViewPreviousTest.Items[4].SubItems.Add(new ListViewSubItem());
                LViewPreviousTest.Items[4].SubItems[3 + visit.Test.AllTests.Count - i - 1].Text = row[i];
            }
            // FEV3_FVC
            for (int i = visit.Test.AllTests.Count - 1; i >= 0; i--)
            {
                row[i] = $"{visit.Test.AllTests[i].FEV3_FVC:0.000}     {STSManager.GetManager.GetPercentage(visit.Test.AllTests[i], predict, Enum_PUAParameters.FEV3_FVC, out stam):0.000}";
                //LViewPreviousTests.Items.Add(new ListViewItem(row));
                LViewPreviousTest.Items[5].SubItems.Add(new ListViewSubItem());
                LViewPreviousTest.Items[5].SubItems[3 + visit.Test.AllTests.Count - i - 1].Text = row[i];
            }
            // PEF
            for (int i = visit.Test.AllTests.Count - 1; i >= 0; i--)
            {
                row[i] = $"{visit.Test.AllTests[i].PEF:0.000}     {STSManager.GetManager.GetPercentage(visit.Test.AllTests[i], predict, Enum_PUAParameters.PEF, out stam):0.000}";
                //LViewPreviousTests.Items.Add(new ListViewItem(row));
                LViewPreviousTest.Items[6].SubItems.Add(new ListViewSubItem());
                LViewPreviousTest.Items[6].SubItems[3 + visit.Test.AllTests.Count - i - 1].Text = row[i];
            }
            // FEF25_75
            for (int i = visit.Test.AllTests.Count - 1; i >= 0; i--)
            {
                row[i] = $"{visit.Test.AllTests[i].FEF25_75:0.000}     {STSManager.GetManager.GetPercentage(visit.Test.AllTests[i], predict, Enum_PUAParameters.FEF25_75, out stam):0.000}";
                //LViewPreviousTests.Items.Add(new ListViewItem(row));
                LViewPreviousTest.Items[7].SubItems.Add(new ListViewSubItem());
                LViewPreviousTest.Items[7].SubItems[3 + visit.Test.AllTests.Count - i - 1].Text = row[i];
            }
            // VC
            for (int i = visit.Test.AllTests.Count - 1; i >= 0; i--)
            {
                row[i] = $"{visit.Test.AllTests[i].VC:0.000}     {STSManager.GetManager.GetPercentage(visit.Test.AllTests[i], predict, Enum_PUAParameters.VC, out stam):0.000}";
                //LViewPreviousTests.Items.Add(new ListViewItem(row));
                LViewPreviousTest.Items[8].SubItems.Add(new ListViewSubItem());
                LViewPreviousTest.Items[8].SubItems[3 + visit.Test.AllTests.Count - i - 1].Text = row[i];
            }

            // TLC
            for (int i = visit.Test.AllTests.Count - 1; i >= 0; i--)
            {
                row[i] = $"{visit.Test.AllTests[i].TLC:0.000}     {STSManager.GetManager.GetPercentage(visit.Test.AllTests[i], predict, Enum_PUAParameters.TLC, out stam):0.000}";
                //LViewPreviousTests.Items.Add(new ListViewItem(row));
                LViewPreviousTest.Items[9].SubItems.Add(new ListViewSubItem());
                LViewPreviousTest.Items[9].SubItems[3 + visit.Test.AllTests.Count - i - 1].Text = row[i];
            }
            // TGV
            for (int i = visit.Test.AllTests.Count - 1; i >= 0; i--)
            {
                row[i] = $"{visit.Test.AllTests[i].TGV:0.000}     {STSManager.GetManager.GetPercentage(visit.Test.AllTests[i], predict, Enum_PUAParameters.TGV, out stam):0.000}";
                //LViewPreviousTests.Items.Add(new ListViewItem(row));
                LViewPreviousTest.Items[10].SubItems.Add(new ListViewSubItem());
                LViewPreviousTest.Items[10].SubItems[3 + visit.Test.AllTests.Count - i - 1].Text = row[i];
            }
            // RV
            for (int i = visit.Test.AllTests.Count - 1; i >= 0; i--)
            {
                row[i] = $"{visit.Test.AllTests[i].RV:0.000}     {STSManager.GetManager.GetPercentage(visit.Test.AllTests[i], predict, Enum_PUAParameters.RV, out stam):0.000}";
                //LViewPreviousTests.Items.Add(new ListViewItem(row));
                LViewPreviousTest.Items[11].SubItems.Add(new ListViewSubItem());
                LViewPreviousTest.Items[11].SubItems[3 + visit.Test.AllTests.Count - i - 1].Text = row[i];
            }
            // TGV_TLC
            for (int i = visit.Test.AllTests.Count - 1; i >= 0; i--)
            {
                row[i] = $"{visit.Test.AllTests[i].TGV_TLC:0.000}     {STSManager.GetManager.GetPercentage(visit.Test.AllTests[i], predict, Enum_PUAParameters.TGV_TLC, out stam):0.000}";
                //LViewPreviousTests.Items.Add(new ListViewItem(row));
                LViewPreviousTest.Items[12].SubItems.Add(new ListViewSubItem());
                LViewPreviousTest.Items[12].SubItems[3 + visit.Test.AllTests.Count - i - 1].Text = row[i];
            }
            // RV_TLC
            for (int i = visit.Test.AllTests.Count - 1; i >= 0; i--)
            {
                row[i] = $"{visit.Test.AllTests[i].RV_TLC:0.000}     {STSManager.GetManager.GetPercentage(visit.Test.AllTests[i], predict, Enum_PUAParameters.RV_TLC, out stam):0.000}";
                //LViewPreviousTests.Items.Add(new ListViewItem(row));
                LViewPreviousTest.Items[13].SubItems.Add(new ListViewSubItem());
                LViewPreviousTest.Items[13].SubItems[3 + visit.Test.AllTests.Count - i - 1].Text = row[i];
            }
            // RAW
            for (int i = visit.Test.AllTests.Count - 1; i >= 0; i--)
            {
                row[i] = $"{visit.Test.AllTests[i].RAW:0.000}     {STSManager.GetManager.GetPercentage(visit.Test.AllTests[i], predict, Enum_PUAParameters.RAW, out stam):0.000}";
                //LViewPreviousTests.Items.Add(new ListViewItem(row));
                LViewPreviousTest.Items[14].SubItems.Add(new ListViewSubItem());
                LViewPreviousTest.Items[14].SubItems[3 + visit.Test.AllTests.Count - i - 1].Text = row[i];
            }
            // CL
            for (int i = visit.Test.AllTests.Count - 1; i >= 0; i--)
            {
                row[i] = $"{visit.Test.AllTests[i].CL:0.000}     {STSManager.GetManager.GetPercentage(visit.Test.AllTests[i], predict, Enum_PUAParameters.CL, out stam):0.000}";
                //LViewPreviousTests.Items.Add(new ListViewItem(row));
                LViewPreviousTest.Items[15].SubItems.Add(new ListViewSubItem());
                LViewPreviousTest.Items[15].SubItems[3 + visit.Test.AllTests.Count - i - 1].Text = row[i];
            }
        }

        private void LViewTestInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LPatientsData_Click(object sender, EventArgs e)
        {
            PatientData PD = new PatientData(visit.Patient);
            this.Hide();
            PD.SetDesktopLocation(this.DesktopLocation.X, this.DesktopLocation.Y);
            PD.ShowDialog();
            this.Close();
        }

        private void LPatientInfo_Click(object sender, EventArgs e)
        {

        }

        private void TestSession_FormClosed(object sender, FormClosedEventArgs e)
        {
            PTestGraph.Controls.Clear();
        }
    }
}
