using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUtils
{
    public enum Ethnicity
    {
        Caucasian,
        African_American,
        Asian
    }

    public class PatientPP
    {       
        public double Age;
        public double Heigth;
        public double Weight;
        public Ethnicity Ethnic;
        public bool IsMale;

        public double Age2 => Age* Age;
        public double Heigth2 => Heigth * Heigth;

    }

    public class PredictionCalc
    {
               
        static double GetKetIndex(Ethnicity eth)
        {
            switch (eth)
            {
                case Ethnicity.Caucasian:
                    return 1;
                case Ethnicity.African_American:
                    return 1.12;
                case Ethnicity.Asian:
                    return 0.94;
            }

            return 0;
        }

        public static double CalcFVC(PatientPP pp)
        {
            if (pp.IsMale && pp.Age < 18)
                return GetKetIndex(pp.Ethnic) * (0.00018641 * pp.Heigth2 + 0.010133 * pp.Age2 - 0.20415 * pp.Age - 0.2584);
            else if (pp.IsMale && pp.Age >= 18)
                return GetKetIndex(pp.Ethnic) * (0.00018641 * pp.Heigth2 - 0.000269 * pp.Age2 - 0.00064 * pp.Age - 0.1933);
            if (!pp.IsMale && pp.Age < 18)
                return GetKetIndex(pp.Ethnic) * (0.00014815 * pp.Heigth2 + 0.05916 * pp.Age - 1.2082);
            else //if (!pp.IsMale && pp.Age >= 18)
                return GetKetIndex(pp.Ethnic) * (0.00014815 * pp.Heigth2 - 0.000382 * pp.Age2 + 0.0187 * pp.Age - 0.356);
        }

        public static double CalcFEV1(PatientPP pp)
        {
            if (pp.IsMale && pp.Age < 18)
                return GetKetIndex(pp.Ethnic) * (0.00014098 * pp.Heigth2 + 0.004477 * pp.Age2 - 0.04106 * pp.Age - 0.7453);
            else if (pp.IsMale && pp.Age >= 18)
                return GetKetIndex(pp.Ethnic) * (0.00014098 * pp.Heigth2 - 0.000172* pp.Age2 - 0.01303 * pp.Age + 0.5536);
            if (!pp.IsMale && pp.Age < 18)
                return GetKetIndex(pp.Ethnic) * (0.00011496 * pp.Heigth2 + 0.06537 * pp.Age - 0.871);
            else //if (!pp.IsMale && pp.Age >= 18)
                return GetKetIndex(pp.Ethnic) * (0.00011496 * pp.Heigth2 - 0.000194 * pp.Age2 - 0.00361 * pp.Age + 0.4333);
        }

        public static double CalcFEV1_FVC(PatientPP pp)
        {
            if (pp.IsMale)
                return 88.066 - 0.2066 * pp.Age;          
            else //if (!pp.IsMale)
                return 90.809 - 0.2125 * pp.Age;
        }

        public static double CalcPEF(PatientPP pp)
        {
            if (pp.IsMale && pp.Age < 18)
                return (0.00024962 * pp.Heigth2 + 0.013135 * pp.Age2 - 0.12357 * pp.Age - 0.5962) * GetKetIndex(pp.Ethnic);
            else if (pp.IsMale && pp.Age >= 18)
                return (0.00024962 * pp.Heigth2 - 0.001301 * pp.Age2 + 0.08272 * pp.Age + 1.0523) * GetKetIndex(pp.Ethnic);
            if (!pp.IsMale && pp.Age < 18)
                return (0.00018623 * pp.Heigth2 - 0.016846 * pp.Age2 + 0.60644 * pp.Age - 3.6181) * GetKetIndex(pp.Ethnic);
            else //if (!pp.IsMale && pp.Age >= 18)
                return (0.00018623 * pp.Heigth2 - 0.001031* pp.Age2 + 0.06929 * pp.Age + 0.9267) * GetKetIndex(pp.Ethnic);
        }

        public static double CalcTLC(PatientPP pp)
        {
            if (pp.IsMale && pp.Age < 18)
                return (0.0231 * pp.Heigth + 0.04454 * pp.Weight + 0.0382 * pp.Age - 2.2367) * GetKetIndex(pp.Ethnic);
            else if (pp.IsMale && pp.Age >= 18)
                return (0.08 * pp.Heigth + 0.0032 * pp.Age - 7.333) * GetKetIndex(pp.Ethnic);
            else if (!pp.IsMale && pp.Age < 18)
                return (0.0404 * pp.Heigth + 0.01453 * pp.Weight + 0.01306 * pp.Age - 3.34952) * GetKetIndex(pp.Ethnic);
            else //if (!pp.IsMale && pp.Age >= 18)
                return (0.059 * pp.Heigth - 4.537) * GetKetIndex(pp.Ethnic);

            //if (pp.IsMale && pp.Age < 18)
            //    return GetKetIndex(pp.Ethnic) * (0.0382 * pp.Age + 0.231 * pp.Heigth + 0.04454 * pp.Weight - 2.2367);
            //else if (pp.IsMale && pp.Age >= 18)
            //    return GetKetIndex(pp.Ethnic) * (0.0032 * pp.Age + 0.08 * pp.Heigth - 7.333);
            //if (!pp.IsMale && pp.Age < 18)
            //    return GetKetIndex(pp.Ethnic) * (0.01306 * pp.Age + 0.0404 * pp.Heigth + 0.01453 * pp.Weight - 3.34952);
            //else //if (!pp.IsMale && pp.Age >= 18)
            //    return GetKetIndex(pp.Ethnic) * (0.059* pp.Heigth - 4.537);
        }

        public static double CalcRV(PatientPP pp)
        {
            if (pp.IsMale)
                return (0.0131 * pp.Heigth + 0.022 * pp.Age - 1.23) * GetKetIndex(pp.Ethnic);
            else // if(!pp.IsMale)
                return (0.0181 * pp.Heigth + 0.016 * pp.Age - 2.0) * GetKetIndex(pp.Ethnic);

            //if (pp.IsMale)
            //    return GetKetIndex(pp.Ethnic) * (0.0246 * pp.Age + 0.01949 * pp.Heigth - 2.683);
            //else //if (!pp.IsMale)
            //    return GetKetIndex(pp.Ethnic) * (0.0216 * pp.Age + 0.00988 * pp.Heigth - 0.947);
        }

        public static double CalcTGV(PatientPP pp)
        {
            if (pp.IsMale && pp.Age < 18)
                return (0.000056 * pp.Heigth2 + 0.012422 * pp.Heigth - 1.05194) * GetKetIndex(pp.Ethnic);
            else if (pp.IsMale && pp.Age >= 18)
                return (0.036 * pp.Heigth + 0.0031 * pp.Age - 3.182) * GetKetIndex(pp.Ethnic);
            else if (!pp.IsMale && pp.Age < 18)
                return (0.000044 * pp.Heigth2 + 0.00922 * pp.Heigth - 0.90305) * GetKetIndex(pp.Ethnic);
            else //if (!pp.IsMale && pp.Age >= 18)
                return (0.0472 * pp.Heigth + 0.009 * pp.Age - 5.29) * GetKetIndex(pp.Ethnic);

            //if (pp.IsMale && pp.Age < 18)
            //    return GetKetIndex(pp.Ethnic) * (0.00056 * pp.Heigth2 + 0.12422 * pp.Heigth + 8.15194);
            //else if (pp.IsMale && pp.Age >= 18)
            //    return GetKetIndex(pp.Ethnic) * (0.0031 * pp.Age + 0.036 * pp.Heigth - 3.182);
            //else if (!pp.IsMale && pp.Age < 18)
            //    return GetKetIndex(pp.Ethnic) * (0.00044 * pp.Heigth2 + 0.0922 * pp.Heigth + 6.00305);
            //else //if (!pp.IsMale && pp.Age >= 18)
            //    return GetKetIndex(pp.Ethnic) * (0.009 * pp.Age + 0.0472 * pp.Heigth - 5.29);
        }

        public static double CalcRV_TLC(double RV, double TLC)
        {
            return RV / TLC * 100;
        }

        public static double CalcTGV_TLC(double TGV, double TLC)
        {
            return TGV / TLC * 100;
        }

        public static double CalcRAW(PatientPP pp)
        {
            return 1.613 - 0.0073 * pp.Heigth;
        }

        public static double CalcCL(PatientPP pp)
        {
            return 3.4149 - 0.014 * pp.Age;
        }

        public static double CalcFEV6(PatientPP pp)
        {
            if (pp.IsMale && pp.Age < 18)
                return GetKetIndex(pp.Ethnic) * (0.00018188 * pp.Heigth2 + 0.009717 * pp.Age2 - 0.18612 * pp.Age - 0.3119);
            else if(pp.IsMale && pp.Age >= 18)
                return GetKetIndex(pp.Ethnic) * (0.00018188 * pp.Heigth2 + 0.000223 * pp.Age2 - 0.00842 * pp.Age - 0.1102);
            else if(!pp.IsMale && pp.Age < 18)
                return GetKetIndex(pp.Ethnic) * (0.00014395 * pp.Heigth2 + 0.06544 * pp.Age - 1.1925);
            else // if (!pp.IsMale && pp.Age >= 18)
                return GetKetIndex(pp.Ethnic) * (0.00014395 * pp.Heigth2 - 0.000352* pp.Age2 + 0.01317 * pp.Age - 0.1373);
        }

        public static double CalcFEV1_FEV6(PatientPP pp) // not in use (igor told me)
        {
            if (pp.IsMale)
                return 88.066 - 0.2066 * pp.Age;
            else // if(!pp.IsMale)
                return 90.809 - 0.2125 * pp.Age;
        }

        public static double CalcFEV3(PatientPP pp, double FVC)
        {
            return (1.0054 - 0.0029 * pp.Age - 0.0075 * FVC) * FVC;
        }

        public static double CalcFEV3_FVC(double FEV3, double FVC)
        {
            return FEV3 / FVC * 100;
        }

        public static double CalcFEF25_75(PatientPP pp)
        {
            if (pp.IsMale && pp.Age < 18)
                return (0.00010345 * pp.Heigth2 + 0.13939 * pp.Age - 1.0863) * GetKetIndex(pp.Ethnic);
            else if (pp.IsMale && pp.Age >= 18)
                return (0.00010345 * pp.Heigth2 - 0.04995 * pp.Age + 2.7006) * GetKetIndex(pp.Ethnic);
            else if (!pp.IsMale && pp.Age < 18)
                return (0.00006982 * pp.Heigth2 - 0.015309 * pp.Age2 + 0.5249 * pp.Age - 2.5284) * GetKetIndex(pp.Ethnic);
            else // if (!pp.IsMale && pp.Age >= 18)
                return (0.00006982 * pp.Heigth2 - 0.0002 * pp.Age2 - 0.01904 * pp.Age + 2.367) * GetKetIndex(pp.Ethnic);
        }

        public static double CalcIVC(PatientPP pp)
        {
            if (pp.IsMale)
                return (0.05919 * pp.Heigth - 0.021 * pp.Age - 5.824) * GetKetIndex(pp.Ethnic);
            else // if(!pp.IsMale)
                return (0.03245 * pp.Heigth - 0.02 * pp.Age - 1.943) * GetKetIndex(pp.Ethnic);
        }

        public static double CalcPIF(PatientPP pp)
        {
            if (pp.IsMale)
                return (0.00362 * pp.Weight + 0.0093 * pp.Age + 2.89) * GetKetIndex(pp.Ethnic);
            else // if(!pp.IsMale)
                return (0.00362 * pp.Weight + 0.0093 * pp.Age + 2.4) * GetKetIndex(pp.Ethnic);
        }
    }
}
