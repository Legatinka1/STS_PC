using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public enum Enum_Unit_System
    {
        Metric,
        Imperial,
        USA
    }

    public enum Enum_Doctor_Level
    {
        Techniction,
        Admin
    }

    public enum Enum_Medication
    {
        None,
        Yes
    }

    public enum Enum_Smoking
    {
        Not,
        Yes,
        Quit
    }

    public enum Enum_Gender
    {
        Male,
        Female
    }

    public enum ENUM_Ethnicity
    {
        Caucasian,
        African_American,
        Asian
    }

    public class Ethnicity
    {
        public static double GetEthIndex(ENUM_Ethnicity eth)
        {
            switch (eth)
            {
                case ENUM_Ethnicity.Caucasian:
                    return 1;
                case ENUM_Ethnicity.African_American:
                    return 1.12;
                case ENUM_Ethnicity.Asian:
                    return 0.94;
            }

            return 1;
        }
    }
}
