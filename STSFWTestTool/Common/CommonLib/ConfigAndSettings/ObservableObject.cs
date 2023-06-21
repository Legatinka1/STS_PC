using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CommonLib
{
    [Serializable]
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            //sync, event exception unsafe
            if (PropertyChanged != null)
            {
                // Get invocation list and invoke each delegate in try section
                // in order to continue calling delegates even if one has
                // unhandled exception
                Delegate[] dlgs = this.PropertyChanged.GetInvocationList();
                foreach (Delegate dlg in dlgs)
                {
                    try
                    {
                        (dlg as PropertyChangedEventHandler)(this, new PropertyChangedEventArgs(propertyName));
                    }
                    catch(Exception ee)
                    {
                    }
                }
            }
        }

        protected void NotifyPropertyChanged(PropertyChangedEventArgs args)
        {
            //sync, event exception unsafe
            if (PropertyChanged != null)
            {
                // Get invocation list and invoke each delegate in try section
                // in order to continue calling delegates even if one has
                // unhandled exception
                Delegate[] dlgs = this.PropertyChanged.GetInvocationList();
                foreach (Delegate dlg in dlgs)
                {
                    try
                    {
                        (dlg as PropertyChangedEventHandler)(this, args);
                    }
                    catch(Exception ee1)
                    {
                    }
                }
            }
        }

        #endregion

        public virtual void SetDefaultValueToParameters()
        {

        }
        public virtual bool IsNeedSetDefaultValueToParameters()
        {
            return false;
        }

        private bool deserializeFinish=false;
        [XmlIgnore]
        public virtual bool DeserializeFinish
        {
            get 
            {
                return deserializeFinish; 
            }
            set
            {
                deserializeFinish = value;
                if(deserializeFinish==true && IsNeedSetDefaultValueToParameters())
                    SetDefaultValueToParameters();
            }
        }

        [XmlIgnore]
        public virtual string ConfigFileName
        {
            get { return "Configuration.xml"; }
        }
    }
}
