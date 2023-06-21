using CommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLib
{
    public interface ISTSPlumpDevice
    {
        event Action<PlumpDeviceStatusStruct, double> OnNewData;
        event Action OnErrorPacket;
        event Action ConnectedSuccessfully;
        event Action ConnectionFailed;
        event Action Disconnected;
        event Action<Enum_ConnectionLog> ConnectionLog;

        Enum_TestCommunication GetCommunicationType();
        void SendStartCommandMessage(int frequency);
        void SendStopCommandMessage();
        void ClearSessionSamplesList();
        void SendShutterOpenMessage();
        void SendShutterCloseMessage();
        bool IsShutterOpened();
        void SendAcquireCommandMessage(int frequency_fast, int duration_fast, int frequency_slow, int duration_slow, int threshold_raw, int threshol_min);

        bool Init(string comPort);
        string GetName();
    }
}