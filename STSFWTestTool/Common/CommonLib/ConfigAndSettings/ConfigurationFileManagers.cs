using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CommonLib
{
    public class ConfigurationFileManager<ConfigData> : IDisposable where ConfigData : ObservableObject,new()
    {
        #region Fields

        private static ConfigData configData=null;
        private bool disposed = false;// Track whether Dispose has been called.        
        private static ConfigurationFileManager<ConfigData> instance=null;
        private System.Timers.Timer serializeTimer = new System.Timers.Timer(500);
        private bool serializeImmediately = false;
        //private object serializLock = new object();

        #endregion

        #region Constructor

        private ConfigurationFileManager()
        {
            configData = new ConfigData();
            filePath = Path.Combine(Utils.GetConfigDirectory() , configData.ConfigFileName);
            GetData.PropertyChanged += PropertyChange;
            this.serializeTimer.Elapsed += (sender, e) =>
            {
                serializeTimer.Stop();
                Serialize();

            };
        }

        #endregion

        #region Property
        static object locker = new object();
        public static ConfigurationFileManager<ConfigData> Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)// when disposing, instance field will be set to null, so if some one will call for the factory - new instance will be created
                        instance = new ConfigurationFileManager<ConfigData>();
				}		
            	return instance;                
            }
        }

        public bool SerializeImmediately
        {
            set 
            {
                if (serializeImmediately)
                    serializeTimer.Stop();
                serializeImmediately = value; 
            }
            get { return serializeImmediately ; }
        }

        private string filePath;
        public string FilePath
        {
            get{return filePath;}
            set
            {
                filePath=value;
                Deserialize();
            }
        }


        public void Regresh()
        {
                instance = new ConfigurationFileManager<ConfigData>();

        }

        public ConfigData GetData
        {
            get
            {
                //lock (serializLock)
                //{
                    if (configData == null)
                        configData = new ConfigData();
                    if(!configData.DeserializeFinish) 
                    {
                        if (!Deserialize())
                            configData.SetDefaultValueToParameters();
                        configData.DeserializeFinish=true;
                        Serialize();
                    }
                //}
                return configData;
            }
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Writes the contents to the file
        /// </summary>
        public bool Serialize()
        {
            //lock (serializLock)
            //{
                return SerializeImpl();
            //}
        }

        public bool Deserialize()
        {
            if (configData == null)
                return false;
            try
            {
                if (File.Exists(FilePath))
                {
                    var serializer = new XmlSerializer(typeof(ConfigData));

                    using (var reader = new StreamReader(FilePath))
                    {
                        if (reader != null)
                        {
                            configData = (ConfigData)serializer.Deserialize(reader);
                            return true;
                        }
                    }
                }
                

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region Private Functions

        /// <summary>
        /// Writes the contents to the file
        /// </summary>
        private bool SerializeImpl()
        {
            if (configData == null)
                return false;
            if (!File.Exists(FilePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath));


                using (var filestream = File.Open(FilePath, FileMode.OpenOrCreate))
                {
                    filestream.Close();
                }
            }
            try
            {                
                var xmlToSave = LogDifferenceBeforeSaving();
                if (xmlToSave != null)                
                    File.WriteAllText(FilePath, xmlToSave);
                                 
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string LogDifferenceBeforeSaving()
        {
            string newXML, oldXML;
            newXML = oldXML = null;

            // exception in serializing new data is handled by caller
            var serializer = new XmlSerializer(typeof(ConfigData));
            using (StringWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, configData);
                newXML = textWriter.ToString();
            } 
                                                      
            // exception in serializing old data and comparing - masked
            try
            {
                oldXML = File.ReadAllText(FilePath);

                string diff = XmlDiff(XElement.Parse(oldXML), XElement.Parse(newXML));
                if (diff == "")
                    return null;
                //SimpleLogReporter.Logger.LogTextInfo("Config : " + diff);
            }
            catch (Exception ex)
            {
            }

            return newXML;
        }

        private string XmlDiff(XElement x1, XElement x2)
        {           
            string rc = ""; 

            if (XElement.DeepEquals(x1, x2))
                return rc;

            var name1 = x1.Name.ToString();
            var name2 = x2.Name.ToString();

            if (name1 == name2)
                rc = name1 + ":";
            else
                rc = name1 + "<>" + name2 + ":";

            var n1 = x1.Elements().ToArray();
            var n2 = x2.Elements().ToArray();

            List<string> names = new List<string>();

            int minLength = Math.Min(n1.Length, n2.Length);

            for (int i = 0; i < minLength; i++)
            {
                var innerxmlDiff = XmlDiff(n1[i],n2[i]);
                string number = InList(n1[i].Name.ToString(), names);			
                if (innerxmlDiff != "")
                    rc += number + innerxmlDiff;
                
            }
            for (int i = minLength; i < n1.Length; i++)
            {
			    rc += "(-)";
                rc += InList(n1[i].Name.ToString(), names);			
                rc += n1[i].ToString().Replace(Environment.NewLine, ""); 
                    
            }
            for (int i = minLength; i < n2.Length; i++)
            {
                rc += "(+)";
                rc += InList(n2[i].Name.ToString(), names);			
                rc += n2[i].ToString().Replace(Environment.NewLine, ""); 
            }


            if ((x1.FirstNode as XText) != null && (x2.FirstNode as XText) != null &&
                (x1.FirstNode as XText).Value != (x2.FirstNode as XText).Value)
            {
                rc += (x1.FirstNode as XText).Value + "->" + (x2.FirstNode as XText).Value;
            }
            return rc+",";
        }
        private string InList(string name, List<string> names)
        {
            names.Add(name);
            int nc = names.Count(x => x == name);
            if (nc > 1)
                return "[" + (nc - 1) + "]";
            return "";
        }

        private void PropertyChange(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (serializeImmediately)
                Serialize();
            else
            {
                serializeTimer.Stop();
                serializeTimer.Start();

            }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Implement IDisposable.
        /// </summary>
        /// <remarks>Do not make this method virtual. A derived class should not be able to override this method</remarks>
        public void Dispose()
        {
            Dispose(true);
            // Take yourself off the Finalization queue to prevent finalization code for this object from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Implements disposing in two distinct scenarios
        /// </summary>
        /// <param name="directDisposing">If true, the method has been called directly or indirectly by a user's code, 
        /// otherwise - method has been called by the runtime</param>
        /// <remarks>Dispose(bool disposing) executes in two distinct scenarios. 
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources can be disposed. 
        /// If disposing equals false, the method has been called by the runtime from inside the finalizer 
        /// and you should not reference other objects. Only unmanaged resources can be disposed.
        /// 
        /// Note, that this method is thread safe. No thread can start disposing the object after the managed resources are disposed, 
        /// but before the disposed flag is set to true</remarks>
        private void Dispose(bool directDisposing)
        {
            lock (this)
            {
                if (!this.disposed)
                {
                    if (directDisposing)//release managed objects
                    {
                        serializeTimer.Stop();
                        Serialize();
                        instance=null;
                        configData=null;
                    }
                }
                this.disposed = true;
            }
        }

        #endregion
    }
}
