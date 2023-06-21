using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoCalc;
using Globals;

namespace STSFWTestTool
{
    public partial class ucCalibPanel : UserControl
    {

        class VecData
        {
            public string fileName;
            public double[] P;
            public double A;
            public double B;
            public double As;
            public double V;

            public override string ToString()
            {
                return $"{V / 0.001},{A},{B},{As}";
            }
        }

        DoCalc.DoCalc calc = new DoCalc.DoCalc(CommonLib.Utils.GetDeviceConfigFileName(null));
        private DoCalc.DoCalc.CalibInfo newCalibInfo = null;
        public ucCalibPanel()
        {
            InitializeComponent();
        }

        double[] rawPressure;
        private void btnClearList_Click(object sender, EventArgs e)
        {
            lstCalibVectors.Items.Clear();
        }

        private void btnProcessVector_Click(object sender, EventArgs e)
        {
            // take the vector and calculate it calbration factors (A1, A2), add to table
            //LoadAndProcessVec("STS_08D0_C1.csv");
            //LoadAndProcessVec("STS_08D0_C2.csv");
            //LoadAndProcessVec("STS_08D0_C3_OS1.csv");
            //LoadAndProcessVec("STS_08D0_C4_OS2.csv");
            //btnProcess_Click(null, null);



            double A = 0, B = 0, v = 0;
            double ds = calc.CalibrationInfo.DS1L, cs = calc.CalibrationInfo.CS1L;

            if (chkUse2.Checked)
            {
                ds = calc.CalibrationInfo.DS2L;
                cs = calc.CalibrationInfo.CS2L;
            }

            double As = 0;
            calc.ProcessCalibVector(rawPressure, ds, cs, ref v, ref A, ref B, ref As);

            VecData vec = new VecData() { A = A, B = B, As = As, V = v, P = rawPressure };

            //string calibStr = $"{v / 0.001},{A},{B},{As}";
            //lstCalibVectors.Items.Add(calibStr);
            lstCalibVectors.Items.Add(vec);
        }


        private void LoadAndProcessVec(string path)
        {
            double A = 0, B = 0, v = 0, As = 0;
            rawPressure = LoadFromFile(path);
            double ds = calc.CalibrationInfo.DS1L, cs = calc.CalibrationInfo.CS1L;

            if (chkUse2.Checked)
            {
                ds = calc.CalibrationInfo.DS2L;
                cs = calc.CalibrationInfo.CS2L;
            }

            calc.ProcessCalibVector(rawPressure, ds, cs, ref v, ref A, ref B, ref As);


            VecData vec = new VecData() { A = A, B = B, As = As, V = v, P = rawPressure };

            //string calibStr = $"{v/ 0.001},{A},{B},{As}";
            //lstCalibVectors.Items.Add(calibStr);
            lstCalibVectors.Items.Add(vec);
        }

        private double[] LoadFromFile(string path)
        {
            if (!File.Exists(path))
                return null;

            string[] arr = File.ReadAllLines(path);
            double[] d = new double[arr.Length-1];
            for (int i = 1; i < arr.Length; i++)
                d[i-1] = Convert.ToDouble(arr[i].Split(',')[1]);

            return d;
        }

        private void ucCalibPanel_Load(object sender, EventArgs e)
        {
            rtbCalib.Text = calc.CalibrationInfo.ToString();
            //rawPressure = LoadFromFile("STS_08D0_C4_OS2.csv");
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (lstCalibVectors.Items.Count < 2)
                return;

            double avgc = 0;
            double avgd = 0;
            textBox1.Text = string.Empty;

            //double[] rawPressure = LoadFromFile("STS_08D0_C1.csv");
           
            double v = 0, A = 0, B = 0;
            List<double> lstA = new List<double>();
            List<double> lstB = new List<double>();
            double V = 3 * 0.001;
            double temp = 0;

            for (int i = 0; i < lstCalibVectors.Items.Count-1; i++)
            {
                //string[] l1 = lstCalibVectors.Items[i].ToString().Split(',');
                //string[] l2 = lstCalibVectors.Items[i+1].ToString().Split(',');
                VecData vec1 = (VecData)lstCalibVectors.Items[i];
                VecData vec2 = (VecData)lstCalibVectors.Items[i+1];

                //double a1 = Convert.ToDouble(l1[1]);
                //double b1 = Convert.ToDouble(l1[2]);
                double a1 = vec1.A;
                double b1 = vec1.B;
               
                lstA.Add(a1);
                lstB.Add(b1);

                //double a2 = Convert.ToDouble(l2[1]);
                //double b2 = Convert.ToDouble(l2[2]);
                double a2 = vec2.A;
                double b2 = vec2.B;

                if (i == lstCalibVectors.Items.Count - 2)
                {
                    lstA.Add(a2);
                    lstB.Add(b2);
                }

               
                double C = V * (a1 - a2) / (a1 * b2 - a2 * b1);
                double D = V * (b2 - b1) / (a1 * b2 - a2 * b1);
                avgc += C;
                avgd += D;

                /// recalc using this variables:               
                textBox1.Text += $"C = {C}" + Environment.NewLine;
                textBox1.Text += $"D = {D}" + Environment.NewLine;
               
                double ds = D, cs = C;

                var calc1 = new DoCalc.DoCalc(CommonLib.Utils.GetDeviceConfigFileName(null));
                calc1.ProcessCalibVector(vec1.P, ds, cs, ref v, ref A, ref B, ref temp);
                textBox1.Text += $"V(C,D) = {v / 0.001}" + Environment.NewLine;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var itm in lstCalibVectors.Items)
            {
                sb.AppendLine(itm.ToString());
            }
            File.WriteAllText("calibsummry.txt", sb.ToString());

            avgc /= (lstCalibVectors.Items.Count - 1);
            avgd /= (lstCalibVectors.Items.Count - 1);
         
            calc.ProcessCalibVector(rawPressure, avgd, avgc, ref v, ref A, ref B, ref temp);
            textBox1.Text += $"Final V(C,D) = {v / 0.001}" + Environment.NewLine;
            textBox1.Text += $"Final C = {avgc}" + Environment.NewLine;
            textBox1.Text += $"Final D = {avgd}" + Environment.NewLine;

            if (newCalibInfo == null)
                newCalibInfo = new DoCalc.DoCalc.CalibInfo(calc.CalibrationInfo);

            if (!chkUse2.Checked)
            {
                newCalibInfo.CS1L = avgc;
                newCalibInfo.DS1L = avgd;
            }
            else
            {
                newCalibInfo.CS2L = avgc;
                newCalibInfo.DS2L = avgd;
            }

            // try linear regression:
            double[] xdata = lstB.ToArray();
            double[] ydata = lstA.ToArray();

            var p = Fit.Line(xdata, ydata);
            var ta = p.Item1; // == 10; intercept
            var tb = p.Item2; // == 0.5; slope
                              // 
            double rsq = GoodnessOfFit.RSquared(xdata.Select(x => ta + tb * x), ydata);

            avgd = V / ta;
            avgc = -tb * avgd;

            calc.ProcessCalibVector(rawPressure, avgd, avgc, ref v, ref A, ref B, ref temp);
            textBox1.Text += $"Regresion V(C,D) = {v / 0.001}" + Environment.NewLine;
            textBox1.Text += $"Regresion C = {avgc}" + Environment.NewLine;
            textBox1.Text += $"Regresion D = {avgd}" + Environment.NewLine;
            textBox1.Text += $"Regresion RR = {rsq}" + Environment.NewLine;

            if (newCalibInfo == null)
                newCalibInfo = new DoCalc.DoCalc.CalibInfo(calc.CalibrationInfo);

            if (!chkUse2.Checked)
            {
                newCalibInfo.CS1L = avgc;
                newCalibInfo.DS1L = avgd;
            }
            else
            {
                newCalibInfo.CS2L = avgc;
                newCalibInfo.DS2L = avgd;
            }


        }

        internal void SetVector(List<SamplesObj> sessionSamplesList)
        {
            int cnt = sessionSamplesList.Count;

            rawPressure = new double[cnt];

            for (int i = 0; i < cnt; i++)            
                rawPressure[i] = sessionSamplesList[i].RunAvg;            
        }

        private void btnSaveCalibFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialogConfig.ShowDialog() == DialogResult.OK)
            {
                Serializer.Save(newCalibInfo, saveFileDialogConfig.FileName);
            }
        }

        private void btnLoadCalib_Click(object sender, EventArgs e)
        {

            if (openFileDialogConfig.ShowDialog() == DialogResult.OK)
            {
                newCalibInfo = Serializer.Load<DoCalc.DoCalc.CalibInfo>(openFileDialogConfig.FileName);

                calc.CalibrationInfo.LoadFrom(newCalibInfo);
                rtbCalib.Text = calc.CalibrationInfo.ToString();
            }
        }

        private void btnLoadVector_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv files (*.csv) | *.csv; *.txt";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var s in ofd.FileNames)
                    LoadAndProcessVec(s);
            }
        }

        private double[] LoadFile(string path)
        {
            if (!File.Exists(path))
                return null;

            List<double> data = new List<double>();
            string[] lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++)
                data.Add(double.Parse(lines[i].Split(',')[1]));

            return data.ToArray();
        }

        private void btnProcessC_Click(object sender, EventArgs e)
        {
            if (lstCalibVectors.Items.Count < 2)
                return;

            double avgc = 0;
            double avgd = 0;
            textBox1.Text = string.Empty;

            //double[] rawPressure = LoadFromFile("STS_08D0_C1.csv");

            double v = 0, A = 0, B = 0;        
            double V = 3 * 0.001;
            double temp = 0;

            for (int i = 0; i < lstCalibVectors.Items.Count; i++)
            {
                //string[] l1 = lstCalibVectors.Items[i].ToString().Split(',');
                VecData vec1 = (VecData)lstCalibVectors.Items[i];

                double a1 = vec1.As;  
                avgc += a1;               
            }

            StringBuilder sb = new StringBuilder();
            foreach (var itm in lstCalibVectors.Items)
            {
                sb.AppendLine(itm.ToString());
            }
            File.WriteAllText("calibsummry.txt", sb.ToString());

            avgc /= (lstCalibVectors.Items.Count);
            textBox1.Text += $"Final C = {avgc}" + Environment.NewLine;

            for (int i = 0; i < lstCalibVectors.Items.Count; i++)
            {
                //string[] l1 = lstCalibVectors.Items[i].ToString().Split(',');
                VecData vec1 = (VecData)lstCalibVectors.Items[i];

                calc.ProcessCalibVector(vec1.P, avgd, avgc, ref v, ref A, ref B, ref temp);
                textBox1.Text += $"Final V(C) = {v / 0.001}" + Environment.NewLine;                        
            }

            if (newCalibInfo == null)
                newCalibInfo = new DoCalc.DoCalc.CalibInfo(calc.CalibrationInfo);

            newCalibInfo.DS1L = 0;
            newCalibInfo.DS2L = 0;

            if (!chkUse2.Checked)
                newCalibInfo.CS1L = avgc;
            else         
                newCalibInfo.CS2L = avgc;
        }

        private void chkUse2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
