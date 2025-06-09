using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElavatorSimilator
{
    public class MessageBus
    {
        private static MessageBus _instance;
        public static MessageBus Instance => _instance ??= new MessageBus();

        private MessageBus() { }

        public event Action<SerialDataMessage> SerialDataReceived;

        public void SendSerialData(string data)
        {
            SerialDataReceived?.Invoke(new SerialDataMessage { Data = data });
        }
    }

    public class SerialDataMessage
    {
        public string Data { get; set; }
    }
}
