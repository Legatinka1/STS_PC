using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CommonLib
{

    [Serializable]
    public class Config : ObservableObject
    {

        #region Constructor

        public Config()
        {
        }
        public Config(Config other)
        {
            CopyPropertyFromOther(other);
        }
        public void CopyPropertyFromOther(Config other)
        {
            if (other == this)
                return;

            isDbSimulation = other.IsDbSimulation;
            testCommunication = other.TestCommunication;
            plumpDeviceComPortNumber = other.PlumpDeviceComPortNumber;
            frequency = other.Frequency;
            isLoadingDBFile = other.IsLoadingDBFile;
            dBFilePath = other.DBFilePath;

            hospitalName = other.HospitalName;
            className = other.ClassName;

            unitSystem = other.UnitSystem;
            rawThreshold = other.RawThreshold;
            minThreshold = other.MinThreshold;

            videoPath = other.videoPath;

            calibrationName = other.calibrationName;
        }

        #endregion

        #region Property

        #region IsDbSimulation

        public bool IsDbSimulation
        {
            get
            {
                return isDbSimulation;
            }
            set
            {
                if (value != isDbSimulation)
                {
                    isDbSimulation = value;
                    NotifyPropertyChanged("IsDbSimulation");
                }
            }
        }
        private bool isDbSimulation = true;

        #endregion

        #region IsTesterSimulation

        public Enum_TestCommunication TestCommunication
        {
            get
            {
                return testCommunication;
            }
            set
            {
                if (value != testCommunication)
                {
                    testCommunication = value;
                    NotifyPropertyChanged("TestingCommunication");
                }
            }
        }
        private Enum_TestCommunication testCommunication = Enum_TestCommunication.BlueTooth;

        public int PlumpDeviceComPortNumber
        {
            get
            {
                return plumpDeviceComPortNumber;
            }
            set
            {
                if (value != plumpDeviceComPortNumber)
                {
                    plumpDeviceComPortNumber = value;
                    NotifyPropertyChanged("PlumpDeviceComPort");
                }
            }
        }
        private int plumpDeviceComPortNumber = 0;

        public int Frequency
        {
            get
            {
                return frequency;
            }
            set
            {
                if (value != frequency)
                {
                    frequency = value;
                    NotifyPropertyChanged("PlumpDeviceFrequency");
                }
            }
        }
        private int frequency = 1000;

        public int RawThreshold
        {
            get
            {
                return rawThreshold;
            }
            set
            {
                if (value != rawThreshold)
                {
                    rawThreshold = value;
                    NotifyPropertyChanged("RawThreshold");
                }
            }
        }
        private int rawThreshold = 300;

        public int MinThreshold
        {
            get
            {
                return minThreshold;
            }
            set
            {
                if (value != minThreshold)
                {
                    minThreshold = value;
                    NotifyPropertyChanged("MinThreshold");
                }
            }
        }
        private int minThreshold = 3000;

        public bool IsLoadingDBFile
        {
            get
            {
                return isLoadingDBFile;
            }
            set
            {
                if (value != isLoadingDBFile)
                {
                    isLoadingDBFile = value;
                    NotifyPropertyChanged("IsLoadingDBFile");
                }
            }
        }
        private bool isLoadingDBFile = false;

        public string DBFilePath
        {
            get
            {
                return dBFilePath;
            }
            set
            {
                if (value != dBFilePath)
                {
                    dBFilePath = value;
                    NotifyPropertyChanged("DBFilePath");
                }
            }
        }
        private string dBFilePath = "C:\\";

        public string HospitalName
        {
            get
            {
                return hospitalName;
            }
            set
            {
                if (value != hospitalName)
                {
                    hospitalName = value;
                    NotifyPropertyChanged("HospitalName");
                }
            }
        }
        private string hospitalName = "N/A";

        public string ClassName
        {
            get
            {
                return className;
            }
            set
            {
                if (value != className)
                {
                    className = value;
                    NotifyPropertyChanged("ClassName");
                }
            }
        }
        private string className = "N/A";

        public Enum_Unit_System UnitSystem
        {
            get
            {
                return unitSystem;
            }
            set
            {
                if (value != unitSystem)
                {
                    unitSystem = value;
                    NotifyPropertyChanged("UnitSystem");
                }
            }
        }
        private Enum_Unit_System unitSystem = Enum_Unit_System.Metric;

        public string VideoPath
        {
            get
            {
                return videoPath;
            }
            set
            {
                if (value != videoPath)
                {
                    videoPath = value;
                    NotifyPropertyChanged("VideoPath");
                }
            }
        }
        private string videoPath = "C:\\";

        public string CalibrationName
        {
            get
            {
                return calibrationName;
            }
            set
            {
                if (value != calibrationName)
                {
                    calibrationName = value;
                    NotifyPropertyChanged("CalibrationName");
                }
            }
        }
        private string calibrationName = "";

        #endregion

        #endregion

        #region Override property ConfigFileName

        public override bool IsNeedSetDefaultValueToParameters()
        {
            return false;
        }

        public override string ConfigFileName
        {
            get { return "STSConfig.xml"; }
        }

        public override void SetDefaultValueToParameters()
        {
            isDbSimulation = true;
            testCommunication = Enum_TestCommunication.BlueTooth;
            plumpDeviceComPortNumber = 0;
            frequency = 1000;
            isLoadingDBFile = false;
            dBFilePath = "C:\\";
            hospitalName = "N/A";
            className = "N/A";
            unitSystem = Enum_Unit_System.Metric;
            rawThreshold = 300;
            minThreshold = 3000;
            videoPath = "C:\\";
            calibrationName = "";
        }

        #endregion
    }
}
