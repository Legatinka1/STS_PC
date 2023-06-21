using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STSFWTestTool
{
    public static class Utils
    {
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

    }
}
