using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonLib;
using InterfacesLib;
using MathUtils;
using static CommonLib.PlumpDeviceStatusStruct;

namespace STSFWTestTool
{
    public class BaseDevice : ISTSPlumpDevice
    {
        public event Action<PlumpDeviceStatusStruct, double> OnNewData;
        public event Action OnErrorPacket;
        public event Action ConnectedSuccessfully;
        public event Action ConnectionFailed;
        public event Action Disconnected;
        public event Action<Enum_ConnectionLog> ConnectionLog;

        protected SerBuf collectedBytes = null;
        protected int errorPacketsReceived = 0;
        protected int totalPacketsReceived = 0;

        protected string name;

        protected void InvokeDisconnected() { Disconnected?.Invoke(); }
        protected void InvokeConnectionFailed() { ConnectionFailed?.Invoke(); }
        protected void InvokeConnectionSuccessFully() { ConnectedSuccessfully?.Invoke(); }
        protected void InvokeOnErrorPacket() { OnErrorPacket?.Invoke(); }
        protected void InvokeConnectionLog(Enum_ConnectionLog obj) { ConnectionLog?.Invoke(obj); }

        protected virtual void SendCommandMessage(byte opcode, byte[] payload)
        {
            throw new NotImplementedException();
        }

        public virtual bool Init(string comPort)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return name;
        }

        // raw, runAvg, lpf
        private List<SamplesObj> lstData = null;
        public List<SamplesObj> SessionSamplesList => lstData;

        RunninWindowAvg runAvg = new RunninWindowAvg(20);

        Dictionary<ESampleType, int> DicTimeStates = new Dictionary<ESampleType, int>();
        public int SolenoidTime { get; private set; }

        public void SendStartCommandMessage(int frequency)
        {
            byte opcode = 0;
            byte[] payload = new byte[2];

            payload[0] = (byte)(frequency & 0xFF);
            payload[1] = (byte)((frequency >> 8) & 0xFF);

            lstData = new List<SamplesObj>();
            avi_help = true;

            SendCommandMessage(opcode, payload);

        }

        public void SendStopCommandMessage()
        {
            byte opcode = 0;
            byte[] payload = new byte[2];

            payload[0] = 0;
            payload[1] = 0;

            SendCommandMessage(opcode, payload);
        }

        public void SendGPIOControlCommandMessage(byte LED_R1_PIN, byte LED_G1_PIN, byte LED_Y1_PIN, byte LED_R2_PIN,
            byte LED_G2_PIN, byte LED_Y2_PIN, byte DISABLE_CHG_PIN, byte SOLENOID_PIN, byte SUP_CLEAR_PIN)
        {
            shutterIsOpened = SOLENOID_PIN == 1;

            byte opcode = 1;
            byte[] payload = new byte[9];

            payload[0] = LED_R1_PIN;
            payload[1] = LED_G1_PIN;
            payload[2] = LED_Y1_PIN;
            payload[3] = LED_R2_PIN;
            payload[4] = LED_G2_PIN;
            payload[5] = LED_Y2_PIN;
            payload[6] = DISABLE_CHG_PIN;
            payload[7] = SOLENOID_PIN;
            payload[8] = SUP_CLEAR_PIN;

            SendCommandMessage(opcode, payload);
        }

        const byte PIN_CLEAR = 0;
        const byte PIN_SET = 1;
        const byte PIN_IGNORE = 2;

        private bool shutterIsOpened = false;

        public void SendShutterCloseMessage()
        {
            SendGPIOControlCommandMessage(PIN_IGNORE, PIN_IGNORE, PIN_IGNORE, PIN_IGNORE, PIN_IGNORE, PIN_IGNORE, PIN_IGNORE, PIN_CLEAR, PIN_IGNORE);
        }

        public void SendShutterOpenMessage()
        {
            SendGPIOControlCommandMessage(PIN_IGNORE, PIN_IGNORE, PIN_IGNORE, PIN_IGNORE, PIN_IGNORE, PIN_IGNORE, PIN_IGNORE, PIN_SET, PIN_IGNORE);
        }

        public bool IsShutterOpened()
        {
            return shutterIsOpened;
        }

        public void SendAcquireCommandMessage(int frequency_fast, int duration_fast, int frequency_slow, int duration_slow, int threshold_raw, int threshol_min)
        {
            byte opcode = 10;
            byte[] payload = new byte[12];

            payload[0] = (byte)(frequency_fast & 0xFF);
            payload[1] = (byte)((frequency_fast >> 8) & 0xFF);
            payload[2] = (byte)(duration_fast & 0xFF);
            payload[3] = (byte)((duration_fast >> 8) & 0xFF);
            payload[4] = (byte)(frequency_slow & 0xFF);
            payload[5] = (byte)((frequency_slow >> 8) & 0xFF);
            payload[6] = (byte)(duration_slow & 0xFF);
            payload[7] = (byte)((duration_slow >> 8) & 0xFF);
            payload[8] = (byte)(threshold_raw & 0xFF);
            payload[9] = (byte)((threshold_raw >> 8) & 0xFF);
            payload[10] = (byte)(threshol_min & 0xFF);
            payload[11] = (byte)((threshol_min >> 8) & 0xFF);


            lstData = new List<SamplesObj>();

            Thread.Sleep(20);
            avi_help = true;

            DicTimeStates = new Dictionary<ESampleType, int>();

            SendCommandMessage(opcode, payload);
        }

        private bool avi_help = false; // dont know why but somtimes lstData is nulll when it should not be
        private double vault = 0;

        private bool ProcessItem(byte opcode, byte[] payload, double lpf)
        {
            bool ret = false;
            switch (opcode)
            {
                case 0:
                    if (avi_help && lstData == null)
                        lstData = new List<SamplesObj>();

                    PlumpDeviceStatusStruct nndata = new PlumpDeviceStatusStruct();
                    if (nndata.Init(opcode, payload) && lstData != null)
                    {

                        Console.WriteLine($"{lstData.Count} - {nndata.SampleType}");

                        if (lstData != null && !DicTimeStates.ContainsKey(nndata.SampleType))
                        {
                            DicTimeStates.Add(nndata.SampleType, lstData.Count);
                            if (nndata.SampleType == ESampleType.RecordingMaxFreqPosMin)
                                SolenoidTime = lstData.Count;
                        }

                        double avg = 0;
                        if (lstData != null &&
                            nndata.SampleType >= PlumpDeviceStatusStruct.ESampleType.RecordingMaxFreqTillMax &&
                            nndata.SampleType <= PlumpDeviceStatusStruct.ESampleType.EndRecording)
                            AddCalcuateVlaues(nndata.Samples, lpf);// lstData.AddRange(nndata.Samples);
                        else if (lstData != null && nndata.SampleType == PlumpDeviceStatusStruct.ESampleType.FreeSampling)
                        {
                            AddCalcuateVlaues(nndata.Samples, lpf);// lstData.AddRange(nndata.Samples);
                            //lstData.AddRange(nndata.Samples);
                        }

                        OnNewData?.Invoke(nndata, avg);
                        ret = true;
                    }
                    break;
                default:
                    break;
            }
            return ret;
        }

        private void AddCalcuateVlaues(short[] nndataSamples, double lpf)
        {
            foreach (var item in nndataSamples)
            {
                SamplesObj s = new SamplesObj(item);
                s.RunAvg = runAvg.ComputeAverage(item);

                // not sure about that
                vault = CalcLPF(vault, lpf, item);
                s.Lpf = vault;

                lstData.Add(s);

                /*lstData.AddRange(nndata.Samples);

                avg = runAvg.ComputeAverage(item);
                // calc run avg
                lstDataRunAvg.Add(avg);
                // calc LPF
                vault = CalcLPF(vault, 0.5, item);
                lstData.Add(vault);*/
            }
        }

        private double CalcLPF(double vault, double weight, double value)
        {
            if ((weight < 0.0) || (weight > 1.0))
                weight = 0.5;
            vault = ((vault) * (1.0 - weight)) + (value * weight);
            return vault;
        }

        public void ClearSessionSamplesList()
        {
            lstData = null;
            DicTimeStates = null;

            avi_help = false;
        }

        private double lpf = 0.1;
        public double Lpf
        {
            get
            {
                return lpf;
            }
            set
            {
                lpf = value;
            }
        }

        protected void ProcessList(byte[] recivedBytes, double lpf)
        {
            byte opcode = 0;
            byte[] payload = null;
            int n = recivedBytes.Length, i, retrieved;
            for (i = 0; i < n; i++)
            {
                collectedBytes.AppendByte(recivedBytes[i]);
                do
                {
                    retrieved = collectedBytes.RetrieveCollected(ref opcode, ref payload);
                    if (retrieved > 0)
                    {
                        ++totalPacketsReceived;
                        if (!ProcessItem(opcode, payload, lpf))
                        {
                            ++errorPacketsReceived;
                            OnErrorPacket?.Invoke();
                        }
                    }
                }
                while (retrieved != 0);
            }
        }

        private double[] getAllAvg()
        {
            if (lstData == null)
                return null;

            List<double> allAvg = new List<double>();
            foreach (var item in lstData)
            {
                allAvg.Add(item.RunAvg);
            }

            return allAvg.ToArray();
        }

        private double[] getAllLpf()
        {
            if (lstData == null)
                return null;

            List<double> alllpf = new List<double>();
            foreach (var item in lstData)
            {
                alllpf.Add(item.Lpf);
            }

            return alllpf.ToArray();
        }

        public virtual Enum_TestCommunication GetCommunicationType()
        {
            throw new NotImplementedException();
        }
    }

    public class SamplesObj
    {
        public SamplesObj()
        {

        }

        public SamplesObj(short raw)
        {
            this.Raw = raw;
        }

        public SamplesObj(short raw, double runAvg, double lpf)
        {
            this.Raw = raw;
            this.RunAvg = runAvg;
            this.Lpf = lpf;
        }

        public short Raw
        {
            get;
            set;
        }
        public double RunAvg
        {
            get;
            set;
        }
        public double Lpf
        {
            get;
            set;
        }
    }
}