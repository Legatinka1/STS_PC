using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class PlumpDeviceStatusStruct
    {
        int length; // Length of payload
        byte opcode; // Command opcode
        short[] samples; //= new short[lengt >> 1]; 
        ushort num_of_samples;
        ushort sample_type;
        ushort sample_counter;
        DateTime received_time;

        public ESampleType SampleType => (ESampleType)sample_type;
        public ushort SampleCounter => sample_counter;
        public ushort NumOfSamples => num_of_samples;
        public byte Opcode => opcode;
        public short[] Samples => samples;
        public DateTime ReceivedTime => received_time;

        public void SetSampleFortesting(short[] s)
        {
            samples = s;
        }

        public enum ESampleType
        { 
            FreeSampling,        
            PreRecording,       
            RecordingMaxFreqTillMax,
            RecordingMaxFreqPosMax,
            RecordingMaxFreqPosMin,
            RecoringTrailSlowFreq,
            EndRecording,
            PreRecordingStart = 21
        }
        public static string BuildPhaseText(ESampleType objSampleType)
        {
            switch (objSampleType)
            {
                case ESampleType.FreeSampling:
                    return "not recorded samples(free sampling)";
                case ESampleType.PreRecording:
                    return " pre - recording sample(life signs, about once per second)";
                case ESampleType.RecordingMaxFreqTillMax:
                    return " pre - max recorded samples(at fast frequency)";
                case ESampleType.RecordingMaxFreqPosMax:
                    return " post - max recorded samples(at fast frequency)";
                case ESampleType.RecordingMaxFreqPosMin:
                    return "post - min recorded samples(at fast frequency)";
                case ESampleType.RecoringTrailSlowFreq:
                    return "trailing recorded samples(at slow frequency, in slow duration time)";
                case ESampleType.EndRecording:
                    return " post - recording sample(end of recording sign)";
            }

            return "n/a";
        }

        public bool Init(byte opcode_in, byte[] payload_in)
        {
            if (payload_in == null)
                return false;
            length = payload_in.Length;
            if (length < 6)
                return false;
            opcode = opcode_in;
            sample_type = BitConverter.ToUInt16(payload_in, 0);
            sample_counter = BitConverter.ToUInt16(payload_in, 2);
            num_of_samples = (ushort)((length - 4) >> 1);
            samples = new short[num_of_samples];
            for (int i = 0, j = 4; i < num_of_samples; i++, j += 2)
                samples[i] = BitConverter.ToInt16(payload_in, j);
            received_time = DateTime.Now;
            return true;
        }
    }
}
