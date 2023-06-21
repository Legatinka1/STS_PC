using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    [Serializable]
    public class PUATestResult
    {
        private List<PUATestHelper> allTests = new List<PUATestHelper>();
        private PUATestHelper prediction = new PUATestHelper();
        private int bestIndex = -1;

        public PUATestResult()
        {

        }

        public PUATestResult(List<double[]> allTestList)
        {
            for(int i = 0; i < allTestList.Count; i++)
                allTests.Add(new PUATestHelper(allTestList[i]));
        }

        public List<double[]> GetAllTestAsList()
        {
            List<double[]> list = new List<double[]>();

            for (int i = 0; i < allTests.Count; i++)
                list.Add(allTests[i].GetAsArray());

            return list;
        }

        public List<double[]> GetAllRawAsList()
        {
            List<double[]> allRaw = new List<double[]>();
            for(int i = 0; i < allTests.Count; i++) {
                allRaw.Add(allTests[i].RawData);
            }

            return allRaw;
        }

        public void CalcBest() 
        {
            /*for(int i = 0; i< allTests.Count; i++) // for now
            {
                if(i != bestIndex)
                {
                    if (bestIndex < 0 || bestIndex >= allTests.Count || allTests[i].FVC > allTests[bestIndex].FVC)
                        bestIndex = i;
                }
            }*/

            for (int i = 0; i < allTests.Count; i++)
                for (int j = 0; j < allTests.Count; j++)
                    for (int f = 0; f < allTests.Count; f++)
                        if (i != j && i != f && j != f && Math.Abs(allTests[i].FVC - allTests[j].FVC) < 0.15 && Math.Abs(allTests[j].FVC - allTests[f].FVC) < 0.15)
                        {
                            bestIndex = j;

                            return;
                        }

            bestIndex = -1;
        }

        public static string SaveTestResult(PUATestResult result)
        {
            // AllTests[PUATest=PUATest]*prediction[...,...]*best

            string testsAsString = "";
            for (int i = 0; i < result.AllTests.Count; i++)
                testsAsString += i == 0 ? $"{PUATestHelper.SaveTest(result.AllTests[i])}" : $"={PUATestHelper.SaveTest(result.AllTests[i])}";
            testsAsString += "*";
            testsAsString += $"{PUATestHelper.SaveTest(result.Prediction)}";
            testsAsString += "*";
            testsAsString += $"{result.BestIndex}";

            return testsAsString;
        }

        public static PUATestResult LoadTestResult(string result)
        {
            PUATestResult testsAsObj = new PUATestResult();

            try
            {
                var sl = result.Split('*');

                // all tests
                var sp = sl[0].Split('=');
                for (int i = 0; i < sp.Length; i++)
                    testsAsObj.AllTests.Add(PUATestHelper.LoadTest(sp[i]));

                // prediction:
                testsAsObj.Prediction = PUATestHelper.LoadTest(sl[1]);

                // best
                testsAsObj.bestIndex = int.Parse(sl[2]);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("a problem occurred while trying to load test result");
            }

            return testsAsObj;
        }

        public PUATestHelper Prediction
        {
            get
            {
                return prediction;
            }
            set
            {
                prediction = value;
            }
        }

        public int BestIndex
        {
            get { return bestIndex; }
            set { bestIndex = value; }
        }

        public List<PUATestHelper> AllTests
        {
            get
            {
                CalcBest();
                return allTests;
            }
            set
            {
                allTests = value;
            }
        }
    }
}
