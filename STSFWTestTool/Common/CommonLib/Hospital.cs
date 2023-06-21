using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class Hospital
    {
        static Config config = ConfigurationFileManager<Config>.Instance.GetData;

        public Hospital()
        {
            HospitalName = config.HospitalName;
            ClassName = config.ClassName;
        }

        public Hospital(Hospital other)
        {
            HospitalName = other.HospitalName;
            ClassName = other.ClassName;
        }

        public Hospital(string hospitalName, string className)
        {
            HospitalName = hospitalName;
            ClassName = className;
        }

        public string HospitalName
        {
            get;
            set;
        }

        public string ClassName
        {
            get;
            set;
        }
    }
}
