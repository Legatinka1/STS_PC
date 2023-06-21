using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathUtils
{
    public partial class frmMain : Form
    {
        PatientPP pp = new PatientPP();
        public frmMain()
        {
            InitializeComponent();
        }

        private void nudWeight_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbEthnicity.SelectedIndex = 0;
            UdpatePP();
        }


        void UdpatePP()
        {
            pp.Age = (double)nudAge.Value;
            pp.Heigth = (double)nudHeight.Value;
            pp.Weight = (double)nudWeight.Value;
            pp.Ethnic = (Ethnicity)cmbEthnicity.SelectedIndex;
            pp.IsMale = radioButton1.Checked;

            lblFVC.Text = $"{PredictionCalc.CalcFVC(pp):0.000}";
            lblFEV1.Text = $"{PredictionCalc.CalcFEV1(pp):0.000}";
            lblFEV1_FVC.Text = $"{PredictionCalc.CalcFEV1_FVC(pp):0.000}";
            lblPEF.Text = $"{PredictionCalc.CalcPEF(pp):0.000}";
            lblTLC.Text = $"{PredictionCalc.CalcTLC(pp):0.000}";
            lblRV.Text = $"{PredictionCalc.CalcRV(pp):0.000}";
            lblTGV.Text = $"{PredictionCalc.CalcTGV(pp):0.000}";

            lblRV_TLC.Text = $"{PredictionCalc.CalcRV_TLC(PredictionCalc.CalcRV(pp), PredictionCalc.CalcTLC(pp)):0.000}";
            lblTGV_TLC.Text = $"{PredictionCalc.CalcTGV_TLC(PredictionCalc.CalcTGV(pp), PredictionCalc.CalcTLC(pp)):0.000}";

            lblRAW.Text = $"{PredictionCalc.CalcRAW(pp):0.000}";
            lblCL.Text = $"{PredictionCalc.CalcCL(pp):0.000}";
        }

        private void nudAge_ValueChanged(object sender, EventArgs e)
        {
            UdpatePP();
        }

        private void nudHeight_ValueChanged(object sender, EventArgs e)
        {
            UdpatePP();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UdpatePP();
        }

        private void cmbEthnicity_SelectedIndexChanged(object sender, EventArgs e)
        {
            UdpatePP();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
