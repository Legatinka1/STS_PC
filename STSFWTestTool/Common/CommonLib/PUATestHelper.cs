using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLib;
using DoCalc;

namespace CommonLib
{
    public class PUATestHelper
    {
        public PUATestHelper()
        {
            IndexT = new Index();
            IndexV = new Index();
            IndexP = new Index();
            IndexO = new Index();
        }

        public PUATestHelper(double[] testValue)
        {
            if (testValue.Length != 22)
            {
                Debug.WriteLine("[PUAtHelper] test result must have 22 paramtrs");

                return;
            }

            RawData = new double[0];
            Time = new double[0];
            ExhFlow = new double[0];
            ExhVC = new double[0];

            this.FVC = testValue[0];
            this.FEV1 = testValue[1];
            this.FEV1_FVC = testValue[2];
            this.FEV6 = testValue[3];
            this.FEV3 = testValue[4];
            this.FEV3_FVC = testValue[5];
            this.PEF = testValue[6];
            this.FEF25_75 = testValue[7];
            this.VC = testValue[8];

            this.TLC = testValue[9];
            this.TGV = testValue[10];
            this.RV = testValue[11];
            this.TGV_TLC = testValue[12];
            this.RV_TLC = testValue[13];

            this.RAW = testValue[14];
            this.CL = testValue[15];

            this.IVC = testValue[16];
            this.PIF = testValue[17];

            this.IndexT = new Index() { Value = testValue[18] };
            this.IndexV = new Index() { Value = testValue[19] };
            this.IndexP = new Index() { Value = testValue[20] };
            this.IndexO = new Index() { Value = testValue[21] };
        }

        public double[] GetAsArray()
        {
            double[] values = new double[22];

            values[0] = this.FVC;
            values[1] = this.FEV1;
            values[2] = this.FEV1_FVC;
            values[3] = this.FEV6;
            values[4] = this.FEV3;
            values[5] = this.FEV3_FVC;
            values[6] = this.PEF;
            values[7] = this.FEF25_75;
            values[8] = this.VC;

            values[9] = this.TLC;
            values[10] = this.TGV;
            values[11] = this.RV;
            values[12] = this.TGV_TLC;
            values[13] = this.RV_TLC;

            values[14] = this.RAW;
            values[15] = this.CL;

            values[16] = this.IVC;
            values[17] = this.PIF;

            values[18] = this.IndexT.Value;
            values[19] = this.IndexV.Value;
            values[20] = this.IndexP.Value;
            values[21] = this.IndexO.Value;

            return values;
        }

        public void SetValesFromArray(double[] values)
        {
            this.FVC = values[0];
            this.FEV1 = values[1];
            this.FEV1_FVC = values[2];
            this.FEV6 = values[3];
            this.FEV3 = values[4];
            this.FEV3_FVC = values[5];
            this.PEF = values[6];
            this.FEF25_75 = values[7];
            this.VC = values[8];

            this.TLC = values[9];
            this.TGV = values[10];
            this.RV = values[11];
            this.TGV_TLC = values[12];
            this.RV_TLC = values[13];

            this.RAW = values[14];
            this.CL = values[15];

            this.IVC = values[16];
            this.PIF = values[17];

            this.IndexT = new Index() { Value = values[18] };
            this.IndexV = new Index() { Value = values[19] };
            this.IndexP = new Index() { Value = values[20] };
            this.IndexO = new Index() { Value = values[21] };
        }

        public void Stam()
        {
            Random rnd = new Random();
            double rndNum = rnd.NextDouble() / 3.0 + 0.7;

            FVC = 5.6 * rndNum;
            FEV1 = 3.6 * rndNum;
            FEV1_FVC = 5.2 * rndNum;
            FEV6 = 5.1 * rndNum;
            FEV3 = 7.0 * rndNum;
            FEV3_FVC = 1.3 * rndNum;
            PEF = 8.9 * rndNum;
            FEF25_75 = 6.3 * rndNum;
            VC = 7.7 * rndNum;
            TLC = 9.8 * rndNum;
            TGV = 3.5 * rndNum;
            RV = 3.5 * rndNum;
            TGV_TLC = 3.5 * rndNum;
            RV_TLC = 9.7 * rndNum;
            RAW = 8.9 * rndNum;
            CL = 1.3 * rndNum;

            IndexT = new Index() { Value = 0.66 * rndNum };
            IndexV = new Index() { Value = 0.77 * rndNum };
            IndexP = new Index() { Value = 0.32 * rndNum };
            IndexO = new Index() { Value = 1.07 * rndNum };
        }

        public void StamByLadingData(string path, int id)
        {
            try
            {
                string patientsData = File.ReadAllText($"{path}/PatientsData.csv");
                var sl = patientsData.Split(',');

                FVC = Double.Parse(sl[(id * 19) + 7]);
                FEV1 = Double.Parse(sl[(id * 19) + 8]);
                PEF = Double.Parse(sl[(id * 19) + 9]);
                TLC = Double.Parse(sl[(id * 19) + 10]);
                TGV = Double.Parse(sl[(id * 19) + 11]);
                RV = Double.Parse(sl[(id * 19) + 12]);
                RAW = GetFixedNumber(sl[(id * 19) + 13]);
                CL = GetFixedNumber(sl[(id * 19) + 14]);

                IndexT = new Index() { Value = Double.Parse(sl[(id * 19) + 15])};
                IndexV = new Index() { Value = Double.Parse(sl[(id * 19) + 16])};
                IndexP = new Index() { Value = Double.Parse(sl[(id * 19) + 17])};
                IndexO = new Index() { Value = Double.Parse(sl[(id * 19) + 18])};

                TGV_TLC = TGV / TLC * 100;
                RV_TLC = RV / TLC * 100;
                FEV1_FVC = FEV1 / FVC * 100;

                AddTime($"{path}/Patient-{id}.csv");
            }
            catch (Exception ee)
            {
                Debug.WriteLine($"Exception while loading db from file ({path}): {ee.Message}");
            }
        }

        private void AddTime(string path)
        {
            /*List<short> raw = new List<short>();
            List<double> time = new List<double>();

            List<double> exhVC = new List<double>();
            List<double> exh = new List<double>();

            Random rnd = new Random();
            double rndNum = rnd.NextDouble() / 5.0 + 0.9;

            using (var reader = new StreamReader(path))
            {
                int lineCounter = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (lineCounter >= 2)
                    {
                        var sl = line.Split(',');
                        if (sl[0].Equals(""))
                            time.Add(0);
                        else
                            time.Add(Double.Parse(sl[0]));

                        if (sl[1].Equals(""))
                            raw.Add(0);
                        else
                            raw.Add((short)(Double.Parse(sl[1]) * rndNum));

                        if (sl[5].Equals(""))
                            exh.Add(0);
                        else
                            exh.Add(Double.Parse(sl[5]) * rndNum);

                        if (sl[6].Equals(""))
                            exhVC.Add(0);
                        else
                            exhVC.Add(Double.Parse(sl[6]));
                    }

                    lineCounter++;
                }
            }

            this.RawData = raw.ToArray();
            this.Time = time.ToArray();
            //this.ExhFlow = exh.ToArray();
            //this.ExhVC = exhVC.ToArray();*/
        }

        private double GetFixedNumber(string number)
        {
            double firstNumber = 0, secondNumber = 0;
            for(int i = 0; i < number.Length; i++)
            {
                if (number[i].Equals('*'))
                    firstNumber = Double.Parse(number.Substring(0, i));
                if (number[i].Equals('E'))
                {
                    secondNumber = Double.Parse(number.Substring(i + 1, number.Length - i - 1));

                    break;
                }
            }

            return firstNumber * Math.Pow(10, secondNumber);
        }

        public double[] RawData
        {
            get;
            set;
        }

        public double[] Time // optional
        {
            get;
            set;
        }

        public double[] ExhFlow
        {
            get;
            set;
        }
        public double[] ExhVC
        {
            get;
            set;
        }


        public double FVC
        {
            get;
            set;
        }

        public double FEV1
        {
            get;
            set;
        }

        public double FEV1_FVC
        {
            get;
            set;
        }

        public double FEV6
        {
            get;
            set;
        }

        public double FEV3
        {
            get;
            set;
        }

        public double FEV3_FVC
        {
            get;
            set;
        }

        public double PEF
        {
            get;
            set;
        }

        public double FEF25_75
        {
            get;
            set;
        }

        public double VC
        {
            get;
            set;
        }

        public double TLC
        {
            get;
            set;
        }

        public double TGV
        {
            get;
            set;
        }

        public double RV
        {
            get;
            set;
        }

        public double TGV_TLC
        {
            get;
            set;
        }

        public double RV_TLC
        {
            get;
            set;
        }

        public double RAW
        {
            get;
            set;
        }

        public double CL
        {
            get;
            set;
        }

        public double IVC
        {
            get;
            set;
        }

        public double PIF
        {
            get;
            set;
        }

        public Index IndexT
        {
            get;
            set;
        }

        public Index IndexV
        {
            get;
            set;
        }

        public Index IndexP
        {
            get;
            set;
        }

        public Index IndexO
        {
            get;
            set;
        }

        private static readonly int _maxGraphSize = 500;
        public static string SaveTest(PUATestHelper test)
        {
            //rawdata[...,...];Time[...,...];exh[...,...];flowVC[...,...];values[...,...]

            string testAsString = "";
            double space;
            // raw data
            if (test.RawData != null)
            {
                space = (double)test.RawData.Length / (double)_maxGraphSize;
                space = space < 1 ? 1 : space;
                for (double i = 0; i < test.RawData.Length; i += space)
                    testAsString += i == 0 ? $"{test.RawData[(int)i]}" : $",{test.RawData[(int)i]}";
            }
            testAsString += ";";

            //time
            if (test.Time != null)
            {
                space = (double)test.Time.Length / (double)_maxGraphSize;
                space = space < 1 ? 1 : space;
                for (double i = 0; i < test.Time.Length; i += space)
                    testAsString += i == 0 ? $"{test.Time[(int)i]}" : $",{test.Time[(int)i]}";
            }
            testAsString += ";";

            //exh
            if (test.ExhFlow != null)
            {
                space = (double)test.ExhFlow.Length / (double)_maxGraphSize;
                space = space < 1 ? 1 : space;
                for (double i = 0; i < test.ExhFlow.Length; i += space)
                    testAsString += i == 0 ? $"{test.ExhFlow[(int)i]}" : $",{test.ExhFlow[(int)i]}";
            }
            testAsString += ";";
            
            //flowVC
            if (test.ExhVC != null)
            {
                space = (double)test.ExhVC.Length / (double)_maxGraphSize;
                space = space < 1 ? 1 : space;
                for (double i = 0; i < test.ExhVC.Length; i += space)
                    testAsString += i == 0 ? $"{test.ExhVC[(int)i]}" : $",{test.ExhVC[(int)i]}";
            }
            testAsString += ";";

            //values
            double[] arr = test.GetAsArray();
            for (int i = 0; i < arr.Length; i++)
                testAsString += i == 0 ? $"{arr[i]}" : $",{arr[i]}";
            testAsString += ";";

            return testAsString;
        }

        public static PUATestHelper LoadTest(string test)
        {
            PUATestHelper testAsObj = new PUATestHelper();
            var sl = test.Split(';');
            for (int i = 0; i < sl.Length; i++)
            {
                List<double> helpList = new List<double>();
                var sp = sl[i].Split(',');
                for (int j = 0; j < sp.Length; j++)
                {
                    if (sp[j].Length != 0)
                        helpList.Add(Double.Parse(sp[j]));
                    else
                        break;
                }

                switch (i)
                {
                    case 0: // rawData
                        testAsObj.RawData = helpList.ToArray();
                        break;
                    case 1: // time
                        testAsObj.Time = helpList.ToArray();
                        break;
                    case 2: // Exh_Flow
                        testAsObj.ExhFlow = helpList.ToArray();
                        break;
                    case 3: // FlowVC
                        testAsObj.ExhVC = helpList.ToArray();
                        break;
                    case 4: // values
                        testAsObj.SetValesFromArray(helpList.ToArray());
                        break;
                }
            }

            if(testAsObj.RawData.Length > 18)
            {

            }

            // fixing time:


            return testAsObj;
        }

        private static double[] FromShortToDouble(short[] s)
        {
            double[] d = new double[s.Length];
            for (int i = 0; i < s.Length; i++)
                d[i] = (double)s[i];

            return d;
        }

        public static double[] GetHealthyPressureExample()
        {
            return null;
        }
        
        public static short[] readFile(string path)
        {
            List<short> arr = new List<short>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    arr.Add(short.Parse(reader.ReadLine()));
                }
            }

            return arr.ToArray();
        }

        public static PUATestHelper Healthy
        {
            get
            {
                PUATestHelper t = new PUATestHelper();


                //string[] lines = File.ReadAllLines();

                return t;
            }
        }
    }

    public class Index
    {
        public Index()
        {
            Value = 0;
            IndexClassification = DoCalc.DoCalc.HealtCondition.Healty;
        }

        public Index(Index other)
        {
            Value = other.Value;
            IndexClassification = other.IndexClassification;
        }

        public Index(double value, DoCalc.DoCalc.HealtCondition indexClassification)
        {
            Value = value;
            IndexClassification = indexClassification;
        }

        public double Value
        {
            get;
            set;
        }

        public DoCalc.DoCalc.HealtCondition IndexClassification
        {
            get;
            set;
        }
    }
}
