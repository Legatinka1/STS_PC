using CommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLib
{
    public interface ISTSPUATest
    {
        bool IsConnected { get; }

        event Action<bool> PUALoadDone;
        event Action<bool, PUATestHelper> OneTestDone;
        event Action<bool, PUATestHelper> FinishCalculatePrediction;
        event Action<bool, PUATestResult> FinishAllTest;
        event Action StartTimer;
        event Action<Enum_ConnectionLog> ConnectionLog;

        bool Init(PatientVisit currentPatientVisit);
        bool Reconnect();
        void StartTest();
        void StopTest();
        PUATestHelper GetPrediction();
        PUATestResult GetAllTestResult();
    }
}
