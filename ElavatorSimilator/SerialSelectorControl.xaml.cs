using System;
using System.Collections.Generic;
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
using System.IO.Ports;

namespace ElavatorSimilator
{
    /// <summary>
    /// Interaction logic for SerialSelectorControl.xaml
    /// </summary>
    public partial class SerialSelectorControl : UserControl
    {

        public static SerialSelectorControl Instance { get; private set; }
        public SerialPortManager portManager { get; private set; }
        public event Action<string> DataReceived;

        public SerialSelectorControl()
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
    }
}
