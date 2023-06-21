using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonLib
{
    public static class Utils
    {
        public static string GetConfigDirectory()
        {
            return @"C:\STS\Config\";
        }
        public static string GetReportDirectory()
        {
            return @"C:\STS\Report\";
        }
        public static string GetDeviceConfigFileName(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId))
                return @"C:\STS\Config\" + $"calib.xml";

            return @"C:\STS\Config\" + $"calib_{deviceId}.xml";
        }

        #region MethodInvoker

        public static void InvokeIfRequired(this Control control, MethodInvoker action, bool bWait = false)
        {
            if (control.InvokeRequired)
            {
                try
                {
                    if (bWait)
                        control.Invoke(action, new object[] { control });
                    else
                        control.BeginInvoke(action, new object[] { control });
                }
                catch (ThreadInterruptedException) { }
                catch (ObjectDisposedException) { }
            }
            else
            {
                action();
            }
        }
        #endregion

        public static string GetParameterGuiName(Enum_PUAParameters type)
        {
            string guiName = "";
            switch (type)
            {
                case Enum_PUAParameters.FVC:
                    guiName = "FVC (l)";
                    break;
                case Enum_PUAParameters.FEV1:
                    guiName = "FEV1 (l)";
                    break;
                case Enum_PUAParameters.FEV1_FVC:
                    guiName = "FEV1/FVC (%)";
                    break;
                case Enum_PUAParameters.FEV6:
                    guiName = "FEV6 (l)";
                    break;
                case Enum_PUAParameters.FEV3:
                    guiName = "FEV3 (l)";
                    break;
                case Enum_PUAParameters.FEV3_FVC:
                    guiName = "FEV3/FVC (%)";
                    break;
                case Enum_PUAParameters.PEF:
                    guiName = "PEF (l/s)";
                    break;
                case Enum_PUAParameters.FEF25_75:
                    guiName = "FEF 25-75 (l/s)";
                    break;
                case Enum_PUAParameters.VC:
                    guiName = "VC (l)";
                    break;
                case Enum_PUAParameters.TLC:
                    guiName = "TLC (l)";
                    break;
                case Enum_PUAParameters.TGV:
                    guiName = "TGV (l)";
                    break;
                case Enum_PUAParameters.RV:
                    guiName = "RV (l)";
                    break;
                case Enum_PUAParameters.TGV_TLC:
                    guiName = "TGV/TLC (%)";
                    break;
                case Enum_PUAParameters.RV_TLC:
                    guiName = "RV/TLC (%)";
                    break;
                case Enum_PUAParameters.RAW:
                    guiName = "RAW (kPa*s/l)";
                    break;
                case Enum_PUAParameters.CL:
                    guiName = "CL (l/lkPa)";
                    break;
                case Enum_PUAParameters.IVC:
                    guiName = "IVC (l)";
                    break;
                case Enum_PUAParameters.PIF:
                    guiName = "PIF (l/s)";
                    break;
                default:
                    break;
            }

            return guiName;
        }

        public static double GetPrediction(Enum_PUAParameters type, PUATestResult testResult)
        {
            double prediction = -1;
            switch (type)
            {
                case Enum_PUAParameters.FVC:
                    prediction = testResult.Prediction.FVC;
                    break;
                case Enum_PUAParameters.FEV1:
                    prediction = testResult.Prediction.FEV1;
                    break;
                case Enum_PUAParameters.FEV1_FVC:
                    prediction = testResult.Prediction.FEV1_FVC;
                    break;
                case Enum_PUAParameters.FEV6:
                    prediction = testResult.Prediction.FEV6;
                    break;
                case Enum_PUAParameters.FEV3:
                    prediction = testResult.Prediction.FEV3;
                    break;
                case Enum_PUAParameters.FEV3_FVC:
                    prediction = testResult.Prediction.FEV3_FVC;
                    break;
                case Enum_PUAParameters.PEF:
                    prediction = testResult.Prediction.PEF;
                    break;
                case Enum_PUAParameters.FEF25_75:
                    prediction = testResult.Prediction.FEF25_75;
                    break;
                case Enum_PUAParameters.VC:
                    prediction = testResult.Prediction.VC;
                    break;
                case Enum_PUAParameters.TLC:
                    prediction = testResult.Prediction.TLC;
                    break;
                case Enum_PUAParameters.TGV:
                    prediction = testResult.Prediction.TGV;
                    break;
                case Enum_PUAParameters.RV:
                    prediction = testResult.Prediction.RV;
                    break;
                case Enum_PUAParameters.TGV_TLC:
                    prediction = testResult.Prediction.TGV_TLC;
                    break;
                case Enum_PUAParameters.RV_TLC:
                    prediction = testResult.Prediction.RV_TLC;
                    break;
                case Enum_PUAParameters.RAW:
                    prediction = testResult.Prediction.RAW;
                    break;
                case Enum_PUAParameters.CL:
                    prediction = testResult.Prediction.CL;
                    break;
                case Enum_PUAParameters.IVC:
                    prediction = testResult.Prediction.IVC;
                    break;
                case Enum_PUAParameters.PIF:
                    prediction = testResult.Prediction.PIF;
                    break;
                default:
                    break;
            }

            return prediction;
        }

        public static double GetPrediction(Enum_PUAParameters type, PUATestHelper testHelper)
        {
            double prediction = -1;
            switch (type)
            {
                case Enum_PUAParameters.FVC:
                    prediction = testHelper.FVC;
                    break;
                case Enum_PUAParameters.FEV1:
                    prediction = testHelper.FEV1;
                    break;
                case Enum_PUAParameters.FEV1_FVC:
                    prediction = testHelper.FEV1_FVC;
                    break;
                case Enum_PUAParameters.FEV6:
                    prediction = testHelper.FEV6;
                    break;
                case Enum_PUAParameters.FEV3:
                    prediction = testHelper.FEV3;
                    break;
                case Enum_PUAParameters.FEV3_FVC:
                    prediction = testHelper.FEV3_FVC;
                    break;
                case Enum_PUAParameters.PEF:
                    prediction = testHelper.PEF;
                    break;
                case Enum_PUAParameters.FEF25_75:
                    prediction = testHelper.FEF25_75;
                    break;
                case Enum_PUAParameters.VC:
                    prediction = testHelper.VC;
                    break;
                case Enum_PUAParameters.TLC:
                    prediction = testHelper.TLC;
                    break;
                case Enum_PUAParameters.TGV:
                    prediction = testHelper.TGV;
                    break;
                case Enum_PUAParameters.RV:
                    prediction = testHelper.RV;
                    break;
                case Enum_PUAParameters.TGV_TLC:
                    prediction = testHelper.TGV_TLC;
                    break;
                case Enum_PUAParameters.RV_TLC:
                    prediction = testHelper.RV_TLC;
                    break;
                case Enum_PUAParameters.RAW:
                    prediction = testHelper.RAW;
                    break;
                case Enum_PUAParameters.CL:
                    prediction = testHelper.CL;
                    break;
                case Enum_PUAParameters.IVC:
                    prediction = testHelper.IVC;
                    break;
                case Enum_PUAParameters.PIF:
                    prediction = testHelper.PIF;
                    break;
                default:
                    break;
            }

            return prediction;
        }

        public static double GetActual(Enum_PUAParameters type, PUATestHelper testHelper)
        {
            if (testHelper == null)
                return -1;

            double actual = -1;
            switch (type)
            {
                case Enum_PUAParameters.FVC:
                    actual = testHelper.FVC;
                    break;
                case Enum_PUAParameters.FEV1:
                    actual = testHelper.FEV1;
                    break;
                case Enum_PUAParameters.FEV1_FVC:
                    actual = testHelper.FEV1_FVC;
                    break;
                case Enum_PUAParameters.FEV6:
                    actual = testHelper.FEV6;
                    break;
                case Enum_PUAParameters.FEV3:
                    actual = testHelper.FEV3;
                    break;
                case Enum_PUAParameters.FEV3_FVC:
                    actual = testHelper.FEV3_FVC;
                    break;
                case Enum_PUAParameters.PEF:
                    actual = testHelper.PEF;
                    break;
                case Enum_PUAParameters.FEF25_75:
                    actual = testHelper.FEF25_75;
                    break;
                case Enum_PUAParameters.VC:
                    actual = testHelper.VC;
                    break;
                case Enum_PUAParameters.TLC:
                    actual = testHelper.TLC;
                    break;
                case Enum_PUAParameters.TGV:
                    actual = testHelper.TGV;
                    break;
                case Enum_PUAParameters.RV:
                    actual = testHelper.RV;
                    break;
                case Enum_PUAParameters.TGV_TLC:
                    actual = testHelper.TGV_TLC;
                    break;
                case Enum_PUAParameters.RV_TLC:
                    actual = testHelper.RV_TLC;
                    break;
                case Enum_PUAParameters.RAW:
                    actual = testHelper.RAW;
                    break;
                case Enum_PUAParameters.CL:
                    actual = testHelper.CL;
                    break;
                case Enum_PUAParameters.IVC:
                    actual = testHelper.IVC;
                    break;
                case Enum_PUAParameters.PIF:
                    actual = testHelper.PIF;
                    break;
                default:
                    break;
            }

            return actual;
        }

        public static string GetCelsiusUnitString()
        {
            return "°C";
        }
        public static string GetFahrenheitUnitString()
        {
            return "°F";
        }


    }
}
