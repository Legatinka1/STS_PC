using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CommonLib
{
    public class LoggerWrapper
    {
        public static void Log(string log)
        {
            Debug.WriteLine(log);
        }
        public static void LogException(Exception e, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null)
        {
            if (e.InnerException != null)
                Debug.WriteLine("Inner Exception: "+e.InnerException + ", At Line: " + lineNumber + " (" + caller + ")");
            else
                Debug.WriteLine("Exception: " + e.Message + ", At Line: " + lineNumber + " (" + caller + ")");
        }
    }
}
