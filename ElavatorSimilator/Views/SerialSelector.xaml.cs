using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElavatorSimilator.Views
{
    /// <summary>
    /// Interaction logic for SerialSelector.xaml
    /// </summary>
    public partial class SerialSelector : UserControl
    {

        public static SerialSelector Instance { get; private set; }
        public SerialPortManager portManager { get; private set; }
        public event Action<string> DataReceived;

        public SerialSelector()
        {
            InitializeComponent();

            Instance = this;

            SerialComboBox.ItemsSource = SerialPort.GetPortNames();
            if (SerialComboBox.Items.Count > 0)
                SerialComboBox.SelectedIndex = 0;

            OpenButton.Click += (s, e) =>
            {
                string selectedPort = SerialComboBox.SelectedItem as string;
                if (selectedPort != null)
                {
                    TryOpenPort(selectedPort);
                }
            };

            colseButton.Click += (s, e) =>
            {
                portManager.Close();
                MessageBox.Show("Port Close");
            };

        }

        private void TryOpenPort(string portName)
        {
            portManager?.Close();
            portManager = new SerialPortManager(portName, 115200);
            portManager.DataReceived += (data) =>
            {
                // انتقال داده دریافتی به بیرون
                DataReceived?.Invoke(data);
            };
            portManager.Open();

            if (!portManager.IsPortAvailable(portName))
                MessageBox.Show($"پورت {portName} در دسترس نیست.");
            else
                MessageBox.Show($"پورت {portName} با موفقیت باز شد.");
        }


        public void Send(string message)
        {
            if (portManager != null )
            {
                try
                {
                    portManager.Send(message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطا در ارسال داده: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("پورت باز نیست یا تنظیم نشده است.");
            }
        }
    }
}
