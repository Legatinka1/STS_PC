using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class ButtonTagParameters
    {
        public bool Pressed
        {
            get;
            set;
        }
        public bool Enabled
        {
            get;
            set;
        }
    }
    public class VirtualButtonStatus
    {
        public bool Pressed
        {
            get;
            set;
        }
        public bool MouseEntered
        {
            get;
            set;
        }
    }
}
