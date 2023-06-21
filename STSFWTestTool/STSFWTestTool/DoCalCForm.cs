using CommonLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace STSFWTestTool
{
    public partial class DoCalCForm : Form
    {
        public DoCalCForm()
        {
            InitializeComponent();
        }
        private void DoCalCForm_Load(object sender, EventArgs e)
        {
            radioBtnMale.Checked = true;
         
        }

        private double[] pressureData = null;
        double freq = 1000;

        private DoCalc.DoCalc _dc;

        private void btnLoad_Click(object sender, EventArgs e)
        {
            pressureData = LoadFile(txtBoxPath.Text);
            if (pressureData == null)
                return;

            freq = 1000;
            chkUseSolenoidTime.Enabled = false;
            chkUseSolenoidTime.Checked = false;
            lblSolTime.Text = $"N/A";
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                int age = (int)numBoxAge.Value;
                int height = (int)numBoxHeight.Value;
                int weight = (int)numBoxWeight.Value;
                string gender = !radioBtnFemale.Checked ? "Male" : "Female";

                _dc = new DoCalc.DoCalc(CommonLib.Utils.GetDeviceConfigFileName(null));
                rtbCalib.Text = _dc.CalibrationInfo.ToString();
                _dc.Frequency = freq;
                _dc.Calculate(age, height, weight, gender, pressureData, chkUseSolenoidTime.Checked?solenoidIndex:-1);

                DrawPressureGraph();
                DrawExhFlowGraph();
                DrawFVCGraph();

                WriteValues(_dc);

                Save();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnBrawse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv files (*.csv) | *.csv; *.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
                txtBoxPath.Text = ofd.FileName;
        }

        private void WriteValues(DoCalc.DoCalc dc)
        {
            string valueText =
                $"TLC predicted: {dc.TLCPredicted} \n" +
                $"TLC measured: {dc.TLCMeasuredAvg123}\n" +
                $"FEV1: {dc.FEV1}\n" +
                $"PEF: {dc.PEF}\n" +
                $"FVC: {dc.FVC}\n" +
                $"AR: {dc.AR}\n" +
                $"TGV > avg(1,2,3): {dc.TGVAvg123}\n" +
                $"TLC measured > avg(1,3): {dc.TLCMeasuredAvg13}\n" +
                $"TGV > avg(1,3): {dc.TGVAvg13}\n" +
                $"RV: {dc.RV}\n" +
                $"T-index: {dc.TIndex}, {dc.GetHealtConditionTIndex()}\n" +
                $"V-index: {dc.VIndex}, {dc.GetHealtConditionVIndex()}\n" +
                $"P-index: {dc.PIndex}, {dc.GetHealtConditionPIndex()}\n" +
                $"O-index: {dc.OIndex}, {dc.GetHealtConditionOIndex()}\n" +
                $"Compliance: {dc.Compliance}\n" +

                $"FEV6: {dc.FEV6}\n"+
                $"FEV3: {dc.FEV3}\n" +
                $"FEF25-75: {dc.FEF25_75}\n";

            rbResults.Text = valueText;
        }

        private double[] LoadFile(string path)
        {
            if (!File.Exists(path))
                return null;

            List<double> data = new List<double>();
            string[] lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++)
            {
                var d = lines[i].Split(',');
                if (d.Length > 1)
                    data.Add(double.Parse(d[1]));
                else
                    data.Add(double.Parse(d[0]));
            }

            return data.ToArray();
        }

        private void DrawPressureGraph()
        {
            if (_dc == null)
                return;

            this.InvokeIfRequired(() =>
            {
                zedGraphPressure.GraphPane.CurveList.Clear();
                double[] index = new double[_dc.Pressure.Length];
                for (int i = 0; i < index.Length; i++)
                    index[i] = i;

                var curveData = zedGraphPressure.GraphPane.AddCurve("Pressure", index, _dc.Pressure, Color.Red);
                curveData.Symbol.IsVisible = false;

                zedGraphPressure.GraphPane.XAxis.ResetAutoScale(zedGraphPressure.GraphPane, CreateGraphics());
                zedGraphPressure.Refresh();
            });
        }

        private void DrawExhFlowGraph()
        {
            if (_dc == null)
                return;

            this.InvokeIfRequired(() =>
            {
                zedGraphExhFlow.GraphPane.CurveList.Clear();
                double[] index = new double[_dc.Pressure.Length];
                for (int i = 0; i < index.Length; i++)
                    index[i] = i;

                var curveData = zedGraphExhFlow.GraphPane.AddCurve("Exh_Flow", index, _dc.Exh_Flow, Color.Red);
                curveData.Symbol.IsVisible = false;

                zedGraphExhFlow.GraphPane.XAxis.ResetAutoScale(zedGraphExhFlow.GraphPane, CreateGraphics());
                zedGraphExhFlow.Refresh();
            });
        }

        private void DrawFVCGraph()
        {
            if (_dc == null)
                return;

            this.InvokeIfRequired(() =>
            {
                zedGraphFVC.GraphPane.CurveList.Clear();
                double[] index = new double[_dc.Pressure.Length];
                for (int i = 0; i < index.Length; i++)
                    index[i] = i;

                var curveData = zedGraphFVC.GraphPane.AddCurve("FVC", index, _dc.FlowVC, Color.Red);
                curveData.Symbol.IsVisible = false;

                zedGraphFVC.GraphPane.XAxis.ResetAutoScale(zedGraphFVC.GraphPane, CreateGraphics());
                zedGraphFVC.Refresh();
            });
        }

        private void Save()
        {
            var sl = txtBoxPath.Text.Split('.');
            string savePath = sl[0];
            for (int i = 1; i < sl.Length - 1; i++)
                savePath += $"\\{sl[i]}";

            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            string[] exhData = new string[_dc.Exh_Flow.Length];
            for (int i = 0; i < _dc.Exh_Flow.Length; i++)
                exhData[i] = $"{_dc.Exh_Flow[i]}";
            File.WriteAllLines($"{savePath}\\Exh_Flow.csv", exhData);

            string[] fvcData = new string[_dc.FlowVC.Length];
            for (int i = 0; i < _dc.FlowVC.Length; i++)
                fvcData[i] = $"{_dc.FlowVC[i]}";
            File.WriteAllLines($"{savePath}\\FVC.csv", fvcData);

            string[] commendsData = _dc.Commends;
            File.WriteAllLines($"{savePath}\\Commends.csv", commendsData);
        }

        public void LoadPressure(double[] pressure)
        {
            pressureData = pressure;
        }

        private int solenoidIndex = -1;

        public void SetVctor(List<SamplesObj> lastVec, int pdSolenoidTime)
        {
            if (lastVec == null)
                return;

            pressureData = new double[lastVec.Count];
            for (int i = 0; i < lastVec.Count; i++)
                pressureData[i] = lastVec[i].Raw;

            chkUseSolenoidTime.Enabled = pdSolenoidTime > -1;
            lblSolTime.Text = $"Index: {pdSolenoidTime}";

            solenoidIndex = pdSolenoidTime;
        }

        internal void SetFreq(int f)
        {
            freq = f;
        }
    }
}
