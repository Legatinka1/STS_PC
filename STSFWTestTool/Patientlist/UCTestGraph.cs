using CommonLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUITest
{
    public partial class UCTestGraph : UserControl
    {
        private List<double[]> _allTests;

        public UCTestGraph()
        {
            InitializeComponent();
        }

        public void LoadTestResult(PUATestResult testsRawData)
        {
            _allTests = new List<double[]>();
            for (int i = 0; i < testsRawData.AllTests.Count; i++)
                _allTests.Add(testsRawData.AllTests[i].RawData);
        }

        private void UCTestGraph_Load(object sender, EventArgs e)
        {
            DrawRawDataGrahs();
        }

        private void DrawRawDataGrahs()
        {
            ZGraphData.GraphPane.CurveList.Clear();
            for (int i = 0; i < _allTests.Count; i++)
            {
                double[] my_data = new double[_allTests[i].Length];
                for(int j = 0; j < _allTests[i].Length; j++)
                    my_data[j] = (double)_allTests[i][j];

                double[] my_time = new double[my_data.Length];
                for (int j = 0; j < my_time.Length; j++)
                    my_time[j] = j;

                var curveData = ZGraphData.GraphPane.AddCurve($"Test: {i + 1}", my_time, my_data, GetColorByTestNum(i));
                curveData.Symbol.IsVisible = false;

                curveData.Line.Width = 1;

                ZGraphData.GraphPane.Title.Text = $"Test";
                ZGraphData.GraphPane.XAxis.Title.Text = "Time(second)";
                ZGraphData.GraphPane.YAxis.Title.Text = "Volume(L)";

                ZGraphData.GraphPane.XAxis.ResetAutoScale(ZGraphData.GraphPane, CreateGraphics());
                ZGraphData.Refresh();
            }
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

        private static double[] readFile(string path)
        {
            List<double> arr = new List<double>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    arr.Add(double.Parse(reader.ReadLine()));
                }
            }

            return arr.ToArray();
        }
    }
}
