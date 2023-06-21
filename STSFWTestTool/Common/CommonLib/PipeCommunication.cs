using NamedPipeWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    [Serializable]
    public class PipeMessage
    {
        public const string WATCHDOG = "WATCHDOG";
        public const string RELOADLCC = "RELOADLCC";

        [NonSerialized]
        public const string UniqueId = "d2e4acd6-3017-41ec-8c65-ebbaec11ae1b";

        public (byte opcode, byte[] payload) Command { get; set; }
        
        public byte[] Data { get; set; }
        public int StationId { get; set; }
        public int[] Class { get; set; }
        public double[] Percent { get; set; }

        //public string ToInfo()
        //{
        //    if (string.IsNullOrEmpty(Data))
        //        return string.Empty;


        //    string[] data = Data.Split(',');

        //    if(data.Length < 7)
        //        return string.Empty;


        //    StringBuilder sb = new StringBuilder();

        //    sb.Append(data[0] + Environment.NewLine);
        //    sb.Append("Counter = " + data[1] + Environment.NewLine);
        //    sb.Append("Area = " + data[2] + Environment.NewLine);
        //    sb.Append(data[3] + "," + data[4] + Environment.NewLine);
        //    int numCat = Convert.ToUInt16(data[6]);
        //    for (int i = 0; i < numCat; i++)
        //    {
        //        sb.Append("CAT" + (i + 1) + " = " + data[7 + i] + Environment.NewLine);
        //    }

        //    return sb.ToString();

        //}
    }

    public class PipeServer
    {
        private NamedPipeServer<PipeMessage> _server = new NamedPipeServer<PipeMessage>(PipeMessage.UniqueId);

        public PipeServer()
        {
            _server.Error += ex => { throw ex; };
            _server.ClientMessage += (_, message) => OnMessageReceived?.Invoke(message);
            _server.Start();
        }

        public PipeServer(string uniqueId)
        {
            _server = new NamedPipeServer<PipeMessage>(uniqueId);
            _server.Error += ex => { throw ex; };
            _server.ClientMessage += (_, message) => OnMessageReceived?.Invoke(message);
            _server.Start();
        }

        ~PipeServer()
        {
            _server.Stop();
        }

        public delegate void PipeMessageReceived(PipeMessage message);
        public event PipeMessageReceived OnMessageReceived;
    }

    public class PipeClient
    {
        private NamedPipeClient<PipeMessage> _client = new NamedPipeClient<PipeMessage>(PipeMessage.UniqueId) { AutoReconnect = true };

        public PipeClient()
        {
            _client.Error += ex => { throw ex; };
            _client.Start();
        }

        public PipeClient(string uniqueId)
        {
            _client = new NamedPipeClient<PipeMessage>(uniqueId) { AutoReconnect = true };
            _client.Error += ex => { throw ex; };
            _client.Start();
        }

        ~PipeClient()
        {
            _client.Stop();
        }

        public void Send(PipeMessage message) => _client.PushMessage(message);

        public async Task SendAsync(PipeMessage message) =>
            await Task.Factory.StartNew(() => _client.PushMessage(message)).ConfigureAwait(false);

    }
}
