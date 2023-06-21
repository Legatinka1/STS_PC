using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Globals;

namespace DoCalc
{
    public class DoCalc
    {
        public class CalibInfo
        {
            // raw to pressure calibration
            public double Pcom { set; get; } = 99221.0;
            public double Kp { set; get; } = 0.2143;

            // Cross section area factors
            public double base_FVC { set; get; } = 383.0;
            public double DS1L { set; get; } = 2.84439821e-9;
            public double CS1L { set; get; } = -2.10912768e-4;
            public double DS2L { set; get; } = 2.38829285e-9;
            public double CS2L { set; get; } = -2.07625689e-04;

            public override string ToString()
            {
                string s = $"base_FVC = {base_FVC}, Pcom = {Pcom}, Kp = {Kp}, " + Environment.NewLine;
                s += $"DS1L = { DS1L}, " + Environment.NewLine;
                s += $"CS1L = { CS1L}, " + Environment.NewLine;
                s += $"DS2L = { DS2L}, " + Environment.NewLine;
                s += $"CS2L = { CS2L}, " + Environment.NewLine;

                return s;
            }

            public CalibInfo()
            {

            }

            public CalibInfo(CalibInfo newCalibInfo)
            {
                LoadFrom(newCalibInfo);
            }

            public void LoadFrom(CalibInfo newCalibInfo)
            {
                //Pcom = newCalibInfo.Pcom;
                //Kp = newCalibInfo.Kp;
                //base_FVC = newCalibInfo.base_FVC;
                //DS1L = newCalibInfo.DS1L;
                //CS1L = newCalibInfo.CS1L;
                //DS2L = newCalibInfo.DS2L;
                //CS2L = newCalibInfo.CS2L;
            }
        }

        internal DoCalc()
        {

        }

        public DoCalc(string filePath)
        {
            if (File.Exists(filePath)) 
                ci = Serializer.Load<CalibInfo>(filePath);
        }


        /// <summary>
        /// sampling frequency in Hz
        /// </summary>
        public double Frequency
        {
            get
            {
                return sf;
            }
            set
            {
                sf = value;
            }
        }

        private double[] rawPressure, pressure_abs, t, exh_flow, fvc;
        private double start;
        private int tmi, t3i, t2i, t4i, t5i, t6i;  

        private List<string> commends = new List<string>();

        const double Rho = 1.144; // air density for exhalation condition in kg/m^3
        const double TT = 310.0; //temperature of the exhalation air in degre K
        const double fi = 0.259;
        const double nn = 1.4;
        //double Pam = 101325.0; // 99221.0; // 101325;
        CalibInfo ci = new CalibInfo();
        public CalibInfo CalibrationInfo => ci;

        private double sf = 1e3;

        public bool Calculate(double age, double height, double weight, string gender, double[] rawPressure, int minXPos)
        {
            // Calculation estimated value of TLC
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////             
            double TLCpr = CalcPredictedTLC(age, height, weight, gender);

            this.rawPressure = rawPressure;
            double[] pressure = Gaussian_filter(rawPressure, 5);

            double dt = 1.0 / sf; // time interval between measurements (sample time) in Seconds
                                  // TODO - add dt2 for non uniform sampling
                                  //double dt2 = 1 / sf; // time interval between measurements (sample time) in Seconds
                                  // double ec = 0; // Number of samples to deduct from edges starting determined positions for error correction
            t = linspace(0, (1e3 * pressure.Length * dt), pressure.Length); // time stamps in mSec; +1 due to start counting from zero

            double t1i = 0;
            start = 0;
            double CPA = ci.base_FVC;

            if (minXPos != -1)
            {
                // assume shutter opening time is known
                t2i = minXPos;

                tmi = (int)getMax(getPartArray(pressure, 0, minXPos));
                t3i = (int)getMax(getPartArray(pressure, minXPos, pressure.Length)) + minXPos;
            }
            else
            {
                var minMaxTab = peakdet(pressure, 500);
                List<(double, double)> maxTab = minMaxTab.max, minTab = minMaxTab.min;

                if (maxTab.Count < 2)
                    return false;

                tmi = (int)maxTab[0].Item1;
                t3i = (int)maxTab[1].Item1;

                minMaxTab = peakdet(getPartArray(pressure, tmi, t3i), 500);
                maxTab = minMaxTab.max;
                minTab = minMaxTab.min;

                t2i = (int)(minTab[0].Item1 + tmi);
            }

            //tmi = 100; t3i = 545; t2i = 483;

            double t4set = pressure[t2i];

            List<double> t4il = new List<double>();
            for (int i = t3i; i < pressure.Length; i++)
                if (pressure[i] < 1 + t4set)
                    t4il.Add(i - t3i);
            t4i = (int)t4il[0] + t3i;

            if (t4i > t.Length)
                t4i = t.Length - 1;

            //Debug.WriteLine(t4i);

            //////////////////////////
            // Constants //
            //////////////////////////
            // Kp = 2.2776 //3.504
            // Kv = 9.2717
            //double Pa = 101235.0; // 99221.0; // 101325;
       

            double Pm1 = ci.Kp * CPA + ci.Pcom; // Start pressure (ambient pressure) in Pa
          
            double RR = Pm1 / (TT * Rho);
            double Ks = Math.Sqrt((2 * nn * RR * TT) / (nn - 1));
            double Ns = Math.Sqrt(2 * nn / (RR * TT * (nn - 1)));

            ////////////////////////////////////////
            // Measurement Data //
            ////////////////////////////////////////
            double t1 = t[(int)start] / 1e3;
            // double tm = t[tmi]/1e3;         // in Sec
            double t2 = t[t2i] / 1e3;         // in Sec
            double t3 = t[t3i] / 1e3;         // in Sec
            double t4 = t[t4i] / 1e3;         // in Sec
                                              // double CP1 = pressure[start];
            double CPm = pressure[tmi];
            double CP2 = pressure[t2i];
            double CP3 = pressure[t3i];
            double CP4 = pressure[t4i];

            //Debug.WriteLine(tmi + " " + t2i + " " + t3i + " " + t4i);
            //Debug.WriteLine(CPm+" "+CP2+" "+CP3+" "+CP4);

            ////////////////////////////////////
            // Presure levels //
            ////////////////////////////////////

            // New
            // Pm1 = Pa+Kp*(CP1-CPA)
            double Pmm = ci.Kp * CPm + ci.Pcom; //Pa + Kp * (CPm - CPA);
            double Pm2 = ci.Kp * CP2 + ci.Pcom; //Pa + Kp * (CP2 - CPA);
            double Pm3 = ci.Kp * CP3 + ci.Pcom; //Pa + Kp * (CP3 - CPA);
            double Pm4 = ci.Kp * CP4 + ci.Pcom; //Pa + Kp * (CP4 - CPA);

            // Shutter large effective area and flow rates
            double AS1m = ci.DS1L * Pmm + ci.CS1L;
            double QS1m = (2 * fi * Ks * AS1m * Math.Sqrt(Pm1 * (Pmm - Pm1))) / Pm1;
            //AS12 = DS1L*Pm2+CS1L
            //QS12 = (2*fi*Ks*AS12*sqrt(Pa*(Pm2-Pa)))/Pm2

            // Shutter small effective area and flow rates
            double AS22 = ci.DS2L * Pm2 + ci.CS2L;
            double AS23 = ci.DS2L * Pm3 + ci.CS2L;
            //AS24 = DS2L*Pm4+CS2L
            //QS22 = (2*fi*Ks*AS22*sqrt(Pa*(Pm2-Pa)))/Pm2
            double QS23 = (2 * fi * Ks * AS23 * Math.Sqrt(Pm1 * (Pm3 - Pm1))) / Pm3;
            //QS24 = (2*fi*Ks*AS24*sqrt(Pa*(Pm4-Pa)))/Pm4

            //////////////////////////////////////
            // FVC calculation //
            //////////////////////////////////////
            pressure_abs = new double[pressure.Length];
            for (int i = 0; i < pressure_abs.Length; i++)
                pressure_abs[i] = Pm1 + ci.Kp * (pressure[i] - ci.base_FVC);

            // New
            double[] shutter_eff = new double[pressure_abs.Length];

            for (int i = 0; i < t2i; i++)
                shutter_eff[i] = (Pm1 + Math.Abs(pressure_abs[i] - Pm1)) * ci.DS1L + ci.CS1L;
            for (int i = t2i; i < pressure_abs.Length; i++)
                shutter_eff[i] = (Pm1 + Math.Abs(pressure_abs[i] - Pm1)) * ci.DS2L + ci.CS2L;

            /** double shutter_eff = asarray(shutter_eff); **/
            exh_flow = new double[pressure_abs.Length];
            for (int i = 0; i < exh_flow.Length; i++)
                exh_flow[i] = 2 * fi * Ns * shutter_eff[i] * Pm1 * Math.Sqrt(Pm1 * Math.Abs(pressure_abs[i] - Pm1)) / (Rho * pressure_abs[i]);

            fvc = new double[pressure_abs.Length];
            for (int i = (int)start + 1; i < pressure_abs.Length; i++)
                fvc[i] = fvc[i - 1] + dt * exh_flow[i];

            /**fvc = asarray(fvc); // List to array -> much faster calculations*/
            double FEV1 = fvc[(int)(t1i + 1 / dt)]; // Exhaled volume during first second

            commends.Add($"FEV1: {FEV1}");
            commends.Add($"FEV1 time: {(int)(t1i + 1 / dt)}");

            //////////////////////////////////////////////////////////////
            // Lung flow rates at point //3 //
            //////////////////////////////////////////////////////////////
            // QL3 = (2*fi*Ks*AS23*sqrt(Pa*(Pm3-Pa)))/Pm3
            // BM3 = 2*fi*Ks*AS23*sqrt(Pa*(Pm3-Pa))

            //////////////////////////////////////////////////////////////////////
            // Pressure Approximation Exponent //
            //////////////////////////////////////////////////////////////////////
            double BP = -Math.Log((Pm4 - Pm1) / (Pm3 - Pm1)) / (t4 - t3);

            //////////////////////////////////////////////////////////
            // Calculation for point //4c //
            //////////////////////////////////////////////////////////

            //double DPm23 = (Pm2 - Pm3) / (t3 - t2);
            double DPM5 = -150; // pa / s
            //double DPM4c = 0.002 * DPm23 * Pm3 * (Pm3 - Pa) / (Pm2 * (Pm2 - Pa));
            double DPM4c = DPM5 / 2 * Pm3 * (Pm3 - Pm1) / (Pm2 * (Pm2 - Pm1));

            double DPM4 = DPM4c;
            double t4c = t3 - (Math.Log(-DPM4c / (BP * (Pm3 - Pm1))) / BP);

            t4 = t4c;
            /** double t4ci = where(t > t4c * 1e3)[0][0]; // *1e3 because t4c is in seconds but time indexes are in milliseconds **/
            List<double> t4cil = new List<double>();
            for (int i = 0; i < t.Length; i++)
                if (t[i] > (t4c * 1e3) + 10)
                    t4cil.Add(i);

            double t4ci = t4cil[0];

            t4i = (int)t4ci;

            double VC4c = fvc[(int)t4ci];
            commends.Add($"VC4c: {VC4c}");
            commends.Add($"VC4c time: {(int)(t4ci / dt)}");
            double VC4 = VC4c;

            double Pm4c = Pm1 + (Pm3 - Pm1) * Math.Exp(-BP * (t4c - t3));
            Pm4 = Pm4c;
            //double CP4c = base_FVC+((Pm4c-Pa)/Kp)
            //double CP4 = CP4c
            double AS24c = ci.CS2L + ci.DS2L * Pm4c;
            double AS24 = AS24c;
            double BM4c = 2 * fi * Ks * AS24c * Math.Sqrt(Pm1 * (Pm4c - Pm1));
            double BM4 = BM4c;
            double QS24c = 2 * fi * Ks * AS24c * Math.Sqrt(Pm1 * (Pm4c - Pm1)) / Pm4c;
            double QS24 = QS24c;

            ////////////////////////////////////////////////////////////
            // Calculation for point //41c //
            ////////////////////////////////////////////////////////////
            double t41c = t4c - 0.1;
            double t41 = t41c;
            double VC41c = fvc[(int)(t4ci - 0.1 / dt)];
            commends.Add($"VC41c: {VC41c}");
            commends.Add($"VC41c time: {(int)(t4ci - 0.1 / dt)}");

            double VC41 = VC41c;
            double Pm41c = Pm1 + (Pm3 - Pm1) * Math.Exp(-BP * (t41c - t3));
            double Pm41 = Pm41c;
            double DPM41c = BP * (Pm3 - Pm1) * Math.Exp(-BP * (t41c - t3));
            double DPM41 = DPM41c;
            double AS241c = ci.DS2L * Pm41c + ci.CS2L;
            //double AS241 = AS241c;
            double BM41c = 2 * fi * Ks * AS241c * Math.Sqrt(Pm1 * (Pm41c - Pm1));
            double BM41 = BM41c;
            double QS241c = (2 * fi * Ks * AS241c * Math.Sqrt(Pm1 * (Pm41c - Pm1))) / Pm41c;
            double QS241 = QS241c;

            ////////////////////////////////////////////////////////////
            // Calculation for point //42c //
            ////////////////////////////////////////////////////////////
            double t42c = t4c + 0.1;
            double t42 = t42c;
            double VC42c = fvc[(int)(t4ci + 0.1 / dt)];
            commends.Add($"VC42c: {VC42c}");
            commends.Add($"VC42c time: {(int)(t4ci + 0.1 / dt)}");

            double VC42 = VC42c;
            double Pm42c = Pm1 + (Pm3 - Pm1) * Math.Exp(-BP * (t42c - t3));
            double Pm42 = Pm42c;
            double DPM42c = BP * (Pm3 - Pm1) * Math.Exp(-BP * (t42c - t3));
            double DPM42 = DPM42c;
            double AS242c = ci.DS2L * Pm42c + ci.CS2L;
            //double AS242 = AS242c;
            double BM42c = 2 * fi * Ks * AS242c * Math.Sqrt(Pm1 * (Pm42c - Pm1));
            double BM42 = BM42c;
            double QS242c = (2 * fi * Ks * AS242c * Math.Sqrt(Pm1 * (Pm42c - Pm1))) / Pm42c;
            double QS242 = QS242c;

            ////////////////////////////////////////////////////////
            // Calculation for point //5 //
            ////////////////////////////////////////////////////////
            // double DPM5 = -150 // Pa/s;
            //double DPM5 = 0.005 * DPm23;
            double t5 = t3 - Math.Log(-DPM5 / (BP * (Pm3 - Pm1))) / BP;
            if (Double.IsNaN(t5))
                t5 = 0;
            // double Pm5 = Pa+(Pm3-Pa)*exp(-BP*(t5-t3));
            double VC5 = fvc[(int)(t5 / dt)];

            commends.Add($"VC5: {VC5}");
            commends.Add($"VC5 time: {(int)(t5 / dt)}");

            //List<double> t5il = new List<double>();
            //for (int i = 0; i < t.Length; i++)
            //    if (t[i] > t5 * 1e3)
            //        t5il.Add(i);
            //double t5i = t5il[0];

            //////////////////////////////////////////////////////////////////////////////////////////
            // Calculation for point //6 - end of process //
            //////////////////////////////////////////////////////////////////////////////////////////
            //double t6 = t1 + 6; // 6 Seconds after start
            double t6 = (fvc.Length-1)*dt;

            double VC6 = fvc[(int)(t6 / dt)];
            commends.Add($"VC6: {VC6}");
            commends.Add($"VC6 time: {(int)(t6 / dt)}");

            double VC3 = fvc[(int)(t3 / dt)];
            commends.Add($"VC3: {VC3}");
            commends.Add($"VC3 time: {(int)(t3 / dt)}");

            //List<double> t6il = new List<double>();
            //for (int i = 0; i < t.Length; i++)
            //    if (t[i] > t6 * 1e3)
            //        t6il.Add(i);
            //double t6i = t6il[0];

                ////////////////////////////////////////////
                // Diagnostic Indexes //
                ////////////////////////////////////////////
            double TI14 = (t4 - t3) / (t4 - t1);
            double TI15 = (t5 - t3) / (t5 - t1);
            double TI25 = (t3 - t2) / (t5 - t2);
            double TI35 = (t2 - t1) / (t5 - t2);

            double VI = FEV1 / (TLCpr * 1e-3);
            double VC2 = fvc[(int)(t2 / dt)];
            commends.Add($"VC2: {VC2}");
            commends.Add($"VC2 time: {(int)(t2 / dt)}");

            double VI24 = (VC4 - VC2) / VC4;
            double VI35 = FEV1 / VC5;
            double VVI1 = VI24 / VI;

            double PI = (Pm3 - Pm1) / (Pmm - Pm1);

            //////////////////////////////////
            // TLC option //1 //
            //////////////////////////////////
            double AT = (DPM4 * VC4 - BM4) / DPM4;
            double BT1 = (Pm4 * (DPM41 * VC41 - BM41)) / (Pm41 * (DPM4 * VC4 - BM4));
            double BT2 = (Pm4 * (DPM42 * VC42 - BM42)) / (Pm42 * (DPM4 * VC4 - BM4));
            double BT = BT1 + BT2;
            double CT1 = Pm4 * DPM41 / (Pm41 * DPM4);
            double CT2 = Pm4 * DPM42 / (Pm42 * DPM4);
            double CT = CT1 + CT2;
            double KTex = (TLCpr * 1e-3 + (nn + 1) * VC4) / (2 * AT);
            double QCLex = (BT - KTex * CT) / (1 - KTex);
            double QCS = (QS241 + QS242) / QS24;
            double DelQCS1 = QCLex - QCS;
            double QCSav1 = 0.5 * (QCS + QCLex + 0.5 * DelQCS1);
            double TGV1 = (AT * (QCSav1 - BT) / (QCSav1 - CT)) - VC4;
            //double TLC1 = TGV1+VC4;
            // Correction
            double K11 = TI14 + VI24 - TI25;
            double K12 = 2 * TI35 + VI;
            double KOb = 0.5 * (TI14 + TI15 + VVI1);
            double KC1 = K11 * K12 * KOb;
            double TGV1c = TGV1 * KC1;
            double TLC1c = TGV1c + VC4;

            //////////////////////////////////
            // TLC option //2 //
            //////////////////////////////////
            double BP2 = Math.Log((Pm3 - Pm1) / (Pm4 - Pm1));
            double BPP34 = Math.Sqrt((Pm4 - Pm1) / (Pm3 - Pm1));
            //double BBPP = BPP34*BP2;
            double TGV2 = fi * Ks * AS24 * (t4 - t3) * BP2 * BPP34;
            // Correction
            double K2c = VI35 - 2 * TI25;
            double TGV2c = TGV2 * K2c;
            double TLC2c = TGV2c + VC4;

            //////////////////////////////////
            // TLC option //3 //
            //////////////////////////////////
            double TLCex = (nn - 1) * (TLCpr * 1e-3 + (nn + 1) * VC4);
            double C11 = TLCex - VC41;
            double C12 = TLCex - VC42;
            double A11 = Math.Pow((t41 - t3), 3) / (3 * Math.Log(Pm41 / Pm3));
            double A12 = Math.Pow((t42 - t3), 3) / (3 * Math.Log(Pm42 / Pm3));
            double B11 = Math.Pow((t41 - t3), 2) / (2 * Math.Log(Pm41 / Pm3));
            double B12 = Math.Pow((t42 - t3), 2) / (2 * Math.Log(Pm42 / Pm3));
            double Btt = ((C11 / A11) - (C12 / A12)) / ((B11 / A11) - (B12 / A12));
            //double Att = (C11 / A11) - (B11 / A11) * Btt; // bug
            double Att = (C11 - B11 * Btt) / A11; // bug
            double TGV3 = ((Att * Math.Pow((t4 - t3), 3)) / (3 * Math.Log(Pm4 / Pm3))) + ((Btt * Math.Pow((t4 - t3), 2)) / (2 * Math.Log(Pm4 / Pm3)));
            // Correction
            double TGV3c = TGV3 * KC1;
            double TLC3c = TGV3c + VC4;

            ////////////////////////////////////////////////////////////////////////////////
            // Airway resistance calculation option //
            ////////////////////////////////////////////////////////////////////////////////
            double Bp1 = ((AS23 * Pm2) / (AS22 * Pm3)) * Math.Sqrt(((Pm2 - Pm1) * Pm3) / ((Pm3 - Pm1) * Pm2));
            double PL3 = Pm3 + (((Pm3 - Pm2) * (1 - nn * Bp1)) / (1 - Bp1));
            //double Aaw1 = (AS23 * PL3 * Math.Sqrt(Pm1 * (Pm3 - Pm1))) / (Pm3 * Math.Sqrt(Pm3 * (PL3 - Pm3)));
            double Raw2a = (PL3 - Pm3) / QS23;

            //////////////////////////////////////////////////////////////
            // Lung compliance calculation //
            //////////////////////////////////////////////////////////////    
            double CLT = (t5 - t1) / (3 * Raw2a);

            //////////////////////////////////////////////////
            // Averaging TLC results //
            //////////////////////////////////////////////////
            double TLC1a = 0.5 * (TLC1c + TLC3c);
            double TLC2a;
            if (KOb > 1.5)
                TLC2a = TLC1c;
            else
                TLC2a = (TLC1c + TLC2c + TLC3c) / 3;

            // Fields in GUI to be filled by measurement results
            //f = new float[14];
            //f[0] = (float)Math.Round(TLCpr, 2); // TLC predicted
            //f[1] = (float)Math.Round(TLC2a * 1e3, 2); // TLC measured > avg(1,2,3)
            //f[2] = (float)Math.Round(FEV1 * 1e3, 2); // FEV1
            //f[3] = (float)Math.Round(QS1m * 1e3, 2); // PEF
            //f[4] = (float)Math.Round(VC6 * 1e3, 2); // FVC
            //f[5] = (float)Math.Round(Raw2a / 1e5, 2); // AR
            //f[6] = (float)Math.Round((TLC2a - VC4) * 1e3, 2); // TGV > avg(1,2,3)
            //f[7] = (float)Math.Round(TLC1a * 1e3, 2); // TLC measured > avg(1,3)
            //f[8] = (float)Math.Round((TLC1a - VC4) * 1e3, 2); // TGV > avg(1,3)
            //f[9] = (float)Math.Round(TI14, 2); // T-index
            //f[10] = (float)Math.Round(VVI1, 2); // V-index
            //f[11] = (float)Math.Round(PI, 2); // P-index
            //f[12] = (float)Math.Round(KOb, 2); // O-index
            //f[13] = (float)Math.Round(CLT * 1e6, 2); // Compliance

            //Console.WriteLine($"TLC predicted: {TLCpr}");
            //Console.WriteLine($"TLC measured: {TLC2a * 1e3}");
            //Console.WriteLine($"FEV1: {FEV1 * 1e3}");
            //Console.WriteLine($"PEF: {QS1m * 1e3}");
            //Console.WriteLine($"FVC: {VC6 * 1e3}");
            //Console.WriteLine($"AR: {Raw2a / 1e5}");
            //Console.WriteLine($"TGV > avg(1,2,3): {(TLC2a - VC4) * 1e3}");
            //Console.WriteLine($"TLC measured > avg(1,3): {TLC1a * 1e3}");
            //Console.WriteLine($"TGV > avg(1,3): {(TLC1a - VC4) * 1e3}");
            //Console.WriteLine($"T-index: {TI14}");
            //Console.WriteLine($"V-index: {VVI1}");
            //Console.WriteLine($"P-index: {PI}");
            //Console.WriteLine($"O-index: {KOb}");
            //Console.WriteLine($"Compliance: {CLT * 1e6}");

            commends.Add($"TLC predicted: {TLCpr}");
            commends.Add($"TLC measured: {TLC2a * 1e3}");
            commends.Add($"FEV1: {FEV1 * 1e3}");
            commends.Add($"PEF: {QS1m * 1e3}");
            commends.Add($"FVC: {VC6 * 1e3}");
            commends.Add($"AR: {Raw2a / 1e5}");
            commends.Add($"TGV > avg(1,2,3): {(TLC2a - VC4) * 1e3}");
            commends.Add($"TLC measured > avg(1,3): {TLC1a * 1e3}");
            commends.Add($"TGV > avg(1,3): {(TLC1a - VC4) * 1e3}");
            commends.Add($"T-index: {TI14}");
            commends.Add($"V-index: {VVI1}");
            commends.Add($"P-index: {PI}");
            commends.Add($"O-index: {KOb}");
            commends.Add($"Compliance: {CLT * 1e6}");

            foreach (var s in commends)
                Console.WriteLine(s);

            TLCPredicted = TLCpr;
            TLCMeasuredAvg123 = TLC2a * 1e3; //(TLC1c + TLC2c + TLC3c) / 3; //TLC2a * 1e3;
            this.FEV1 = FEV1 * 1e3;
            PEF = QS1m * 1e3;
            FVC = VC6 * 1e3;
            AR = Raw2a / 1e6;
            TGVAvg123 = (TLC2a - VC4) * 1e3;
            TLCMeasuredAvg13 = TLC1a * 1e3;
            TGVAvg13 = (TLC1a - VC4) * 1e3;

            TIndex = TI14;
            VIndex = VVI1;
            PIndex = PI;
            OIndex = KOb;

            Compliance = CLT * 1e6;
            RV = TLCMeasuredAvg123 - FVC;

            // Avi:
            FEV6 = VC6 * 1e3;
            FEV3 = fvc[(int)(3 / dt)] * 1e3;

            double t25 = 0, t75 = 0;
            double n25 = 0, n75 = 0;
            for (int i = 0; i < fvc.Length; i++)
            {
                if (Math.Abs(fvc[i] - 0.25 * VC6) <= 0.0001)
                {
                    n25 = i;
                    t25 = n25 * dt;
                }
                if (Math.Abs(fvc[i] - 0.75 * VC6) <= 0.0001)
                {
                    n75 = i;
                    t75 = n75 * dt;
                }
            }

            double fef = 0;
            for (int i = (int)n25; i < n75; i++)
                fef += dt * fvc[i] / (t75 - t25);

            FEF25_75 = fef * 1e3;

            for (int i = 0; i < exh_flow.Length; i++)
            {
                exh_flow[i] *= 1e3;
                fvc[i] *= 1e3;
            }

            IVC = 0;
            PIF = 0;

            return true;
        }

        public enum HealtCondition
        {
            Healty, 
            Obstructuve,
            Restrictive,
            Invalid
        }

        public HealtCondition GetHealtConditionTIndex()
        {
            if (TIndex > 0.5 && TIndex <= 0.8)
                return HealtCondition.Healty;
            if (TIndex > 0.8) //&& TIndex <= 1.2)
                return HealtCondition.Obstructuve;
            if (TIndex <= 0.5)// && TIndex > 0.3)
                return HealtCondition.Restrictive;

            return HealtCondition.Invalid;
        }

        public HealtCondition GetHealtConditionVIndex()
        {
            if(VIndex <= 1.0) //if (VIndex <= 0.8)// && VIndex > 0.4)
                return HealtCondition.Healty;
            if (VIndex > 1.5)// && VIndex <= 4.5)
                return HealtCondition.Obstructuve;
            if(VIndex > 1.0 && VIndex <= 1.5)//if (VIndex > 0.8 && VIndex <= 1.5)
                return HealtCondition.Restrictive;

            return HealtCondition.Invalid;
        }

        public HealtCondition GetHealtConditionPIndex()
        {
            if (PIndex <= 0.8)// && PIndex > 0.3)
                return HealtCondition.Healty;
            if (PIndex > 1.4)// && PIndex <= 4)
                return HealtCondition.Obstructuve;
            if (PIndex > 0.8 && PIndex <= 1.4)
                return HealtCondition.Restrictive;

            return HealtCondition.Invalid;
        }

        public HealtCondition GetHealtConditionOIndex()
        {
            if (OIndex <= 1.3) // if (OIndex > 2 )
                return HealtCondition.Healty;
            if (OIndex > 2) //if (OIndex >= 2 && OIndex <= 4.0)
                return HealtCondition.Obstructuve;
            if (OIndex <= 2 && OIndex > 1.3)// if (OIndex < 2)
                return HealtCondition.Restrictive;

            return HealtCondition.Invalid;
        }

        private static double CalcPredictedTLC(double age, double height, double weight, string gender)
        {
            double TLCpr;
            if (age < 18)
            {
                if (gender.Equals("Male"))
                    TLCpr = (38.1842 * age + 23.0973 * height + 44.5411 * weight - 2236.7774) / 1000;
                else
                    TLCpr = (13.0601 * age + 40.4346 * height + 14.526 * weight - 3495.2291) / 1000;
            }
            else
            {
                if (gender.Equals("Male"))
                    TLCpr = 0.003 * age + 0.08 * height - 7.333;
                else
                    TLCpr = 0.059 * height - 4.537;
            }

            return TLCpr;
        }

        public string[] Commends
        {
            get { return commends.ToArray(); }
            set { commends = value.ToList(); }
        }

        public double[] Pressure => rawPressure;
       
        public double[] FlowVC => fvc;
       
        public double[] Exh_Flow => exh_flow;
       
        public double TLCPredicted
        {
            get;
            private set;
        }
        public double TLCMeasuredAvg123
        {
            get;
            private set;
        }
        public double FEV1
        {
            get;
            private set;
        }
        public double PEF
        {
            get;
            private set;
        }
        public double FVC
        {
            get;
            private set;
        }
        public double AR
        {
            get;
            private set;
        }
        public double TGVAvg123
        {
            get;
            private set;
        }
        public double TLCMeasuredAvg13
        {
            get;
            private set;
        }
        public double TGVAvg13
        {
            get;
            private set;
        }
        public double TIndex
        {
            get;
            private set;
        }
        public double VIndex
        {
            get;
            private set;
        }
        public double PIndex
        {
            get;
            private set;
        }
        public double OIndex
        {
            get;
            private set;
        }
        public double Compliance
        {
            get;
            private set;
        }
        
        public double RV
        {
            get;
            private set;
        }

        public double FEV6
        {
            get;
            private set;
        }

        public double FEV3
        {
            get;
            private set;
        }

        public double FEF25_75
        {
            get;
            private set;
        }

        public double IVC
        {
            get;
            private set;
        }

        public double PIF
        {
            get;
            private set;
        }

      

        private double[] Gaussian_filter(double[] arr, int N)
        {
            double[] array = arr;
            double sigma = N;
            int kernelRadius = (int)Math.Ceiling(sigma * 2.57); // significant radius
            double[] kernel = GaussianKernel1d(kernelRadius, sigma);
            double[] result = Filter(array, kernel);

            return result;
        }

        private static double[] Filter(double[] arr, double[] kernel)
        {
            //Assert(kernel.Length % 2 == 1); //kernel size must be odd.

            int kernelRadius = kernel.Length / 2;
            int width = arr.GetLength(0);
            double[] result = new double[width];
            for (int x = 0; x < width; x++)
            {
                double sumOfValues = 0;
                double sumOfWeights = 0;
                for (int i = -kernelRadius; i <= kernelRadius; i++)
                {
                    double value = arr[Clamp(x + i, 0, width - 1)];
                    double weight = kernel[kernelRadius + i];
                    sumOfValues += value * weight;
                    sumOfWeights += weight;
                }
                result[x] = sumOfValues / sumOfWeights;
            }
            return result;
        }

        private static double[] GaussianKernel1d(int kernelRadius, double sigma)
        {
            double[] kernel = new double[kernelRadius + 1 + kernelRadius];
            for (int xx = -kernelRadius; xx <= kernelRadius; xx++)
                kernel[kernelRadius + xx] = Math.Exp(-(xx * xx) / (2 * sigma * sigma)) /
                        (Math.PI * 2 * sigma * sigma);
            return kernel;
        }

        private static int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        private double[] linspace(double start, double stop, int count)
        {
            double[] newArr = new double[count];
            double amount = (stop - start) / (count - 1);

            for (int i = 0; i < count; i++)
                newArr[i] = start + amount * i;

            return newArr;
        }

        private double getMax(double[] arr)
        {
            double mx = -1e64;
            int mxpos = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > mx)
                {
                    mx = arr[i];
                    mxpos = i;
                }
            }

            return mxpos;
        }

        public static (List<(double, double)> max, List<(double, double)> min) peakdet(double[] v, int delta)
        {
            List<(double, double)> maxTab = new List<(double, double)>();
            List<(double, double)> minTab = new List<(double, double)>();

            double[] x = new double[v.Length];

            for (int i = 0; i < x.Length; i++)
                x[i] = i;

            double mn = 1e64, mx = -1e64; // infinate max and min
            double mnpos = 0, mxpos = 0;

            bool lookformax = true;

            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] > mx)
                {
                    mx = v[i];
                    mxpos = x[i];
                }
                if (v[i] < mn)
                {
                    mn = v[i];
                    mnpos = x[i];
                }

                if (lookformax)
                {
                    if (v[i] < mx - delta)
                    {
                        maxTab.Add((mxpos, mx));
                        mn = v[i];
                        mnpos = x[i];
                        lookformax = false;
                    }
                }
                else
                {
                    if (v[i] > mn + delta)
                    {
                        minTab.Add((mnpos, mn));
                        mx = v[i];
                        mxpos = x[i];
                        lookformax = true;
                    }
                }
            }

            return (maxTab, minTab);
        }

        private double[] getPartArray(double[] arr, int start, int end)
        {
            double[] newArr = new double[end - start];
            for (int i = start; i < end; i++)
                newArr[i - start] = arr[i];

            return newArr;
        }

        public void ProcessCalibVector(double[] rawP, double ds, double cs, ref double  v, ref double a, ref double b, ref double As)
        {
            // detect start and end and remove the rest
            double N = 9.12e-3;

            double avgAmbient = 0;
            for (int i = 0; i < Math.Min(100, rawP.Length); i++)
                avgAmbient += rawP[i];
            avgAmbient /= Math.Min(100, rawP.Length);

            double Pam = ci.Kp * avgAmbient + ci.Pcom;

            int idx_start = -1;
            int idx_end = -1;
            for (int i = 0; i < rawP.Length; i++)
            {
                if (idx_start == -1 && rawP[i] > avgAmbient + 200)
                    idx_start = i;

                if (idx_end == -1 && idx_start > 0 && rawP[i] < avgAmbient + 200)
                    idx_end = i;
            }

            double[] P = new double[idx_end-idx_start];
            for (int i = idx_start; i < idx_end; i++)
                P[i- idx_start] = ci.Kp * rawP[i] + ci.Pcom;

            double dt = (1 / sf);
            double T = P.Length * dt;

            // Caclulate VC1 (11) - calculated volume
            v = 0;

        
            for (int i = 0; i < P.Length; i++)
            {
                double Asi = ds * P[i] + cs;
                v += ((2 * dt * fi * N) / Rho) * (Asi * Math.Sqrt(Pam * (P[i] - Pam)));
            }
            

            double Pm11a = P.Average();
            
            // Calc A:
            a = 2 * T * fi * N * Pm11a * Math.Sqrt(Pam * (Pm11a - Pam)) / Rho;

            // Calc B:
            b = 2 * T * fi * N * Math.Sqrt(Pam * (Pm11a - Pam)) / Rho;

         
            double VSY = 3 * 0.001;
          
            double PP = 0;
            for (int i = 0; i < P.Length; i++)
                PP += Math.Sqrt(Pam * (P[i] - Pam));

            As = VSY * Rho / (2 * dt * fi * N * PP);

        }
    }
}