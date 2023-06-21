using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoCalc
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //double[] my_data = readFile(@"C:\EfCom\Technoplumsts\SVN\trunk\pySolution\rec 1kHz_150-2000_PS-test2.csv");
            //double[] my_data = readFile(@"C:\EfCom\Technoplumsts\SVN\trunk\pySolution\rec.csv");

            //dc.Calculate(68, 174, 80, "Male", my_data, 483);

            string file = @"C:\EfCom\Technoplum\Measurements\Sampling Test\rec_3Khz_Igor*.csv";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"File,Frequency,IsAvg,FVC,FEV1,PEF,TLCMeasuredAvg123");

            for (int i = 1; i <= 5; i++)
            {
                string f = file.Replace("*", $"{i}");
                double[] my_data = readFile(f);

                DoCalc dc = new DoCalc();
                dc.Frequency = 3000;
                dc.Calculate(68, 174, 80, "Male", my_data, -1);
                sb.AppendLine($"{Path.GetFileName(f)},{dc.Frequency},{false},{dc.FVC},{dc.FEV1}, {dc.PEF}, {dc.TLCMeasuredAvg123}");

                // undersampling 3:
                dc = new DoCalc();
                double[] d = UndeSample(my_data, 3); // 1Khz
                dc.Frequency = 1000;
                dc.Calculate(68, 174, 80, "Male", d, -1);
                sb.AppendLine($"{Path.GetFileName(f)},{dc.Frequency},{false},{dc.FVC},{dc.FEV1}, {dc.PEF}, {dc.TLCMeasuredAvg123}");

                dc = new DoCalc();
                d = UndeSample(my_data, 3 * 2); // 500hz
                dc.Frequency = 500;
                dc.Calculate(68, 174, 80, "Male", d, -1);
                sb.AppendLine($"{Path.GetFileName(f)},{dc.Frequency},{false},{dc.FVC},{dc.FEV1}, {dc.PEF}, {dc.TLCMeasuredAvg123}");

                dc = new DoCalc();
                d = UndeSample(my_data, 3 * 2 * 2); // 250hz
                dc.Frequency = 250;
                dc.Calculate(68, 174, 80, "Male", d, -1);
                sb.AppendLine($"{Path.GetFileName(f)},{dc.Frequency},{false},{dc.FVC},{dc.FEV1}, {dc.PEF}, {dc.TLCMeasuredAvg123}");


                //////////////
                // undersampling 3:
                dc = new DoCalc();
                d = UndeSample(my_data, 3, true); // 1Khz
                dc.Frequency = 1000;
                dc.Calculate(68, 174, 80, "Male", d, -1);
                sb.AppendLine($"{Path.GetFileName(f)},{dc.Frequency},{true},{dc.FVC},{dc.FEV1}, {dc.PEF}, {dc.TLCMeasuredAvg123}");

                dc = new DoCalc();
                d = UndeSample(my_data, 3 * 2, true); // 500hz
                dc.Frequency = 500;
                dc.Calculate(68, 174, 80, "Male", d, -1);
                sb.AppendLine($"{Path.GetFileName(f)},{dc.Frequency},{true},{dc.FVC},{dc.FEV1}, {dc.PEF}, {dc.TLCMeasuredAvg123}");

                dc = new DoCalc();
                d = UndeSample(my_data, 3 * 2 * 2, true); // 250hz
                dc.Frequency = 250;
                dc.Calculate(68, 174, 80, "Male", d, -1);
                sb.AppendLine($"{Path.GetFileName(f)},{dc.Frequency},{true},{dc.FVC},{dc.FEV1}, {dc.PEF}, {dc.TLCMeasuredAvg123}");
            }

            Console.Write(sb);
            File.WriteAllText(@"C:\EfCom\Technoplum\Measurements\Sampling Test\sum.csv", sb.ToString());
            Console.ReadLine();
            //dc.Calculate("Avi", 40, 173, 70, "male", my_data, 2840);
            //dc.Calculate("Avi", 40, 173, 70, "male", my_data, 3419);
        }


        private static double[] UndeSample(double[] myData, int n, bool needAvg = false)
        {
            double[] d = new double[myData.Length / n];
            for (int i = 0; i < d.Length * n; i += n)
            {
                if (needAvg)
                {
                    double s = 0;
                    for (int j = 0; j < n; j++)
                    {
                        s += myData[i + j];
                    }
                    d[i / n] = s / n;
                }
                else
                {
                    d[i / n] = myData[i];
                }
            }

            return d;
        }

        public static double[] readFile(string path)
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
