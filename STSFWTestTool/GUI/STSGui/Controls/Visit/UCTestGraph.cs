using CommonLib;
using ImplementationLib;
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

namespace STSGui
{
    public partial class UCTestGraph : UserControl
    {
        private List<double[]> _allTests = new List<double[]>();
        private List<double[]> _allTimes = new List<double[]>();

        private List<double[]> _allExhFlow = new List<double[]>();
        private List<double[]> _allFVC = new List<double[]>();

        public UCTestGraph()
        {
            InitializeComponent();
        }

        private void UCTestGraph_Load(object sender, EventArgs e)
        {
            _allTests.Clear();
            _allTimes.Clear();
            _allExhFlow.Clear();
            _allFVC.Clear();

            ZGraphData.GraphPane.XAxis.Title.FontSpec.Size = 25;
            ZGraphData.GraphPane.YAxis.Title.FontSpec.Size = 25;
            ZGraphData.GraphPane.Title.FontSpec.Size = 30;
        }

        public string Title 
        { 
            get
            {
                return ZGraphData.GraphPane.Title.Text;
            }
            set
            {
                ZGraphData.GraphPane.Title.Text = value;
            }
        }

        public void LoadTestPressure(PUATestHelper test)
        {
            if (test == null)
                return;

            _allTests.Clear();
            _allTimes.Clear();
            _allExhFlow.Clear();
            _allFVC.Clear();

            _allTests.Add(test.RawData);
            _allTimes.Add(test.Time);

            DrawPressures();
        }

        public void LoadTestPressure(PUATestResult tests)
        {
            if (tests == null)
                return;

            _allTests.Clear();
            _allTimes.Clear();
            _allExhFlow.Clear();
            _allFVC.Clear();

            for (int i = 0; i < tests.AllTests.Count; i++)
            {
                _allTests.Add(tests.AllTests[i].RawData);
                _allTimes.Add(tests.AllTests[i].Time);
            }

            DrawPressures();
        }

        private void DrawPressures()
        {
            this.InvokeIfRequired(() =>
            {
                ZGraphData.GraphPane.CurveList.Clear();
                ZGraphData.Refresh();
            });

            for (int i = 0; i < _allTests.Count; i++)
            {
                double[] x_data, y_data;

                if (_allTimes[i] != null && _allTimes[i].Length != 0)
                    x_data = _allTimes[i];
                else
                {
                    x_data = new double[_allTests[i].Length];
                    for (int j = 0; j < _allTests[i].Length; j++)
                        x_data[j] = j;

                    for (int j = 0; j < x_data.Length; j++)
                        x_data[j] /= STSManager.GetManager.Frequency;
                }

                y_data = new double[_allTests[i].Length];
                for (int j = 0; j < _allTests[i].Length; j++)
                    y_data[j] = (double)_allTests[i][j];

                DrawGraph(x_data, y_data, "Time[Seconds]", "Pressure[kPa]", $"Test: {i}", GetColorByTestNum(i));
            }
        }

        public void LoadExhFlow(PUATestHelper test)
        {
            if (test == null)
                return;

            _allTests.Clear();
            _allTimes.Clear();
            _allExhFlow.Clear();
            _allFVC.Clear();

            _allExhFlow.Add(test.ExhFlow);
            //_allTimes.Add(test.Time);
            _allFVC.Add(test.ExhVC);

            DrawExh();
        }

        public void LoadExhFlow(PUATestResult tests)
        {
            if (tests == null)
                return;

            _allTests.Clear();
            _allTimes.Clear();
            _allExhFlow.Clear();
            _allFVC.Clear();

            for (int i = 0; i < tests.AllTests.Count; i++)
            {
                if (tests.AllTests[i] != null)
                {
                    _allExhFlow.Add(tests.AllTests[i].ExhFlow);
                    //_allTimes.Add(tests.AllTests[i].Time);
                    _allFVC.Add(tests.AllTests[i].ExhVC);
                }
            }

            DrawExh();
        }

        private void DrawExh()
        {
            this.InvokeIfRequired(() =>
            {
                ZGraphData.GraphPane.CurveList.Clear();
                ZGraphData.Refresh();

                for (int i = 0; i < _allExhFlow.Count; i++)
                {
                    if (_allExhFlow[i] != null)
                    {
                        double[] x_data, y_data;

                        /*if (_allTimes[i] != null && _allTimes[i].Length != 0)
                            x_data = _allTimes[i];
                        else
                        {
                            x_data = new double[_allExhFlow[i].Length];
                            for (int j = 0; j < _allExhFlow[i].Length; j++)
                                x_data[j] = j;
                        }*/

                        x_data = _allFVC[i];
                        y_data = _allExhFlow[i];

                        var curveData = ZGraphData.GraphPane.AddCurve($"Test: {i}", x_data, y_data, GetColorByTestNum(i));
                        curveData.Symbol.IsVisible = false;

                        ZGraphData.GraphPane.XAxis.Title.Text = "FVC[L]";
                        ZGraphData.GraphPane.YAxis.Title.Text = "Flow[L/S]";

                        ZGraphData.GraphPane.XAxis.ResetAutoScale(ZGraphData.GraphPane, CreateGraphics());
                        ZGraphData.GraphPane.YAxis.ResetAutoScale(ZGraphData.GraphPane, CreateGraphics());
                        ZGraphData.Refresh();
                    }
                }
            });
        }

        public void LoadFVC(PUATestHelper test)
        {
            if (test == null)
                return;

            _allFVC.Clear();
            _allTimes.Clear();

            _allFVC.Add(test.ExhVC);
            _allTimes.Add(test.Time);

            DrawFVC();
        }

        public void LoadFVC(PUATestResult tests)
        {
            if (tests == null)
                return;

            _allFVC.Clear();
            _allTimes.Clear();

            for (int i = 0; i < tests.AllTests.Count; i++)
            {
                if (tests.AllTests[i] != null)
                {
                    _allFVC.Add(tests.AllTests[i].ExhVC);
                    _allTimes.Add(tests.AllTests[i].Time);
                }
            }

            DrawFVC();
        }

        private void DrawFVC()
        {
            this.InvokeIfRequired(() =>
            {
                ZGraphData.GraphPane.CurveList.Clear();
                ZGraphData.Refresh();

                for (int i = 0; i < _allFVC.Count; i++)
                {
                    if (_allFVC[i] != null)
                    {
                        double[] x_data, y_data;

                        if (_allTimes[i] != null && _allTimes[i].Length != 0)
                            x_data = _allTimes[i];
                        else
                        {
                            x_data = new double[_allFVC[i].Length];
                            for (int j = 0; j < _allFVC[i].Length; j++)
                                x_data[j] = j;

                            for (int j = 0; j < x_data.Length; j++)
                                x_data[j] /= STSManager.GetManager.Frequency;
                        }

                        y_data = _allFVC[i];

                        var curveData = ZGraphData.GraphPane.AddCurve($"Test: {i}", x_data, y_data, GetColorByTestNum(i));
                        curveData.Symbol.IsVisible = false;

                        ZGraphData.GraphPane.XAxis.Title.Text = "Time[Seconds]";
                        ZGraphData.GraphPane.YAxis.Title.Text = "FVC[L]";

                        ZGraphData.GraphPane.XAxis.ResetAutoScale(ZGraphData.GraphPane, CreateGraphics());
                        ZGraphData.GraphPane.YAxis.ResetAutoScale(ZGraphData.GraphPane, CreateGraphics());
                        ZGraphData.Refresh();
                    }
                }
            });
        }

        private void DrawGraph(double[] x_data, double[] y_data, string x_title, string y_title, string curve_name, Color c)
        {
            this.InvokeIfRequired(() =>
            {
                var curveData = ZGraphData.GraphPane.AddCurve(curve_name, x_data, y_data, c);
                curveData.Symbol.IsVisible = false;

                ZGraphData.GraphPane.XAxis.Title.Text = x_title;
                ZGraphData.GraphPane.YAxis.Title.Text = y_title;

                ZGraphData.GraphPane.XAxis.ResetAutoScale(ZGraphData.GraphPane, CreateGraphics());
                ZGraphData.Refresh();
            });
        }

        private static Color GetColorByTestNum(int num)
        {
            switch (num)
            {
                case 0:
                    return Color.Red;
                case 1:
                    return Color.Brown;
                case 2:
                    return Color.Green;
                case 3:
                    return Color.Yellow;
                case 4:
                    return Color.Blue;
                case 5:
                    return Color.Pink;
                default:
                    return Color.Black;
            }
        }
    }
}
