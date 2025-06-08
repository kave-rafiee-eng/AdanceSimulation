using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ElavatorSimilator
{
    public class SerialPortManager
    {
        
        public int ReciveCounter { get; set; } = 0;

        private SerialPort serialPort;
        //SerialPort serialPort = new SerialPort();

        public event Action<string> DataReceived;  // رویداد برای انتقال داده به UI
        private string portName;
        private int baudRate;

        public bool IsPortAvailable(string portName)
        {
            return SerialPort.GetPortNames().Contains(portName);
        }

        public SerialPortManager(string portName, int baudRate = 115200)
        {

            this.portName = portName;
            this.baudRate = baudRate;


        }

        public void Open()
        {
            if (serialPort == null)
            {
                serialPort = new SerialPort(portName, baudRate);
                serialPort.DataReceived += SerialPort_DataReceived;
            }

            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }
        }

        public void Close()
        {
            if (serialPort.IsOpen)
                serialPort.Close();
        }

        private StringBuilder buffer = new StringBuilder();
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    string incoming = serialPort.ReadExisting(); // دریافت هرچی تو بافر هست
                    buffer.Append(incoming); // اضافه کردن به بافر

                    while (true)
                    {
                        int index = buffer.ToString().IndexOf('#');
                        if (index == -1)
                            break; // تا وقتی که # پیدا نشده، چیزی ارسال نمی‌کنیم

                        string message = buffer.ToString(0, index); // پیام کامل تا #
                        buffer.Remove(0, index + 1); // حذف پیام از بافر (با #)

                        if (!string.IsNullOrWhiteSpace(message))
                        {
                            DataReceived?.Invoke(message);
                        }
                    }
                }

            }
            catch (IOException ex)
            {
                // مثلاً:
                System.Diagnostics.Debug.WriteLine("SerialPort IOException: " + ex.Message);
            }
        }


        public void Send(string data)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Write(data);
                    System.Diagnostics.Debug.WriteLine("Sent: " + data);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Serial port not open. Cannot send data.");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Send failed: " + ex.Message);
            }
        }
    }

}
