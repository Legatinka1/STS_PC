using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public enum Enum_TestStatus
    {
        NotKnown,
        Proccesing, 
        Finished
    }

    public enum Enum_TestType
    {
        NotKnown,
        Spiro_TLC
    }

    public enum Enum_PUAParameters
    {
        FVC,
        FEV1,
        FEV1_FVC,
        FEV6,
        FEV3,
        FEV3_FVC,
        PEF,
        FEF25_75,
        VC,
        TLC,
        TGV,
        RV,
        TGV_TLC,
        RV_TLC,
        RAW,
        CL,
        IVC,
        PIF
    }

    public enum Enum_ExamplePresure
    {
        Healthy,
        Obstructive,
        Restrictive
    }

    public enum Enum_TestCommunication
    {
        Simulated,
        BlueTooth,
        Serial
    }

    public enum Enum_ConnectionLog
    {
        Connected,
        Connecting,
        Failed,
        Disconnected,
    }
}
