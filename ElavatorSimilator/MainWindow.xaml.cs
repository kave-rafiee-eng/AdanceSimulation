using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.IO.Ports;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static ElavatorSimilator.MainWindow;
using LiveCharts;
using LiveCharts.Wpf;

namespace ElavatorSimilator
{


    public partial class MainWindow : Window
    {
        private string latestData = null;
        private DispatcherTimer updateTimer;

        private int[] dataBuffer = new int[1000];
        private int bufferCounter = 0;
        private ChartValues<int> chartValues = new ChartValues<int>();

        SerialPortManager portManager;
        public MainWindow()
        {
            InitializeComponent();

            portManager = new SerialPortManager("COM4", 115200);
            portManager.DataReceived += OnDataReceived;

            string[] ports = SerialPort.GetPortNames();

            SerialComboBox.ItemsSource = SerialPort.GetPortNames();
            SerialComboBox.SelectedIndex = 0;

            BTNopenSerial.Click += (s, e) =>
            {
                string selectedPort = SerialComboBox.SelectedItem as string;
                if (selectedPort != null)
                {
                    portManager.Close(); // بستن پورت قبلی
                    portManager = new SerialPortManager(selectedPort, 115200);
                    portManager.DataReceived += OnDataReceived;
                    portManager.Open();
                    if (!portManager.IsPortAvailable(selectedPort))
                    {
                        MessageBox.Show($"پورت {selectedPort} موجود نیست یا متصل نیست.");
                    }
                    else
                    {
                        MessageBox.Show($"پورت {selectedPort} با موفقیت باز شد.");
                    }
                }
            };

            updateTimer = new DispatcherTimer();
            updateTimer.Interval = TimeSpan.FromMilliseconds(500); // هر نیم ثانیه
            updateTimer.Tick += UpdateUI;
            updateTimer.Start();

            MyChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Random Data",
                    Values = chartValues,
                    PointGeometry = null // حذف نقاط برای روان‌تر بودن
                }
            };


        }


        private RootWithCalls rootCalls;
        private SimpleData simpleData;

        private void OnDataReceived(string data)
        {

            if (TryParseJson(data, out JToken token))
            {
                token = JToken.Parse(data);
                if (token["calls"] != null)
                {
                    rootCalls = token.ToObject<RootWithCalls>();
                    portManager.ReciveCounter++;
                }
                else if (token["data1"] != null)
                {
                    simpleData = token.ToObject<SimpleData>();

                    AddValueToBuffer(simpleData.data1);
                }

                latestData = data;
            }
        

        }


        public bool TryParseJson(string data, out JToken token)
        {
            try
            {
                token = JToken.Parse(data);
                return true;
            }
            catch
            {
                token = null;
                return false;

            }
         }

        private void AddValueToBuffer(int newValue)
        {
            if (bufferCounter < dataBuffer.Length)
            {
                dataBuffer[bufferCounter++] = newValue;
            }
            else
            {
                // sliding window: جابه‌جایی داده‌ها
                for (int i = 1; i < dataBuffer.Length; i++)
                {
                    dataBuffer[i - 1] = dataBuffer[i];
                }
                dataBuffer[dataBuffer.Length - 1] = newValue;
            }
        }

        private void UpdateChart()
        {
            chartValues.Clear();
            for (int i = 0; i < bufferCounter; i++)
            {
                chartValues.Add(dataBuffer[i]);
            }
        }

        private void UpdateUI(object sender, EventArgs e)
        {

            Dispatcher.Invoke(() =>
            {

                if (rootCalls != null )
                    DataGridCalls.ItemsSource = rootCalls.calls;

                if (simpleData != null  )
                    DataGridSimpleData.ItemsSource = new List<SimpleData> { simpleData };

                conter.Text = portManager.ReciveCounter.ToString(); ;

                textBoxOutput.AppendText(latestData + "\n");

                UpdateChart();

            });

        }

        private void ClickTest(object sender, RoutedEventArgs e)
        {
            conter.Text = portManager.ReciveCounter.ToString();
            //MessageBox.Show(portManager.ReciveCounter.ToString());
        }

        public class Call
        {
            public int advance { get; set; }
            public string From { get; set; }
            public int Floor { get; set; }
            public string door1 { get; set; }
            public string door2 { get; set; }
            public string door3 { get; set; }
            public string dir { get; set; }
            public int Timer { get; set; }
        }

        public class RootWithCalls
        {
            public int test { get; set; }
            public List<Call> calls { get; set; }
        }

        public class SimpleData
        {
            public int data1 { get; set; }
            public int data2 { get; set; }
            public int data3 { get; set; }
            public int data4 { get; set; }
            public int data5 { get; set; }
            public int data6 { get; set; }
            public string name1 { get; set; }
            public int value1 { get; set; }
            public string name2 { get; set; }
            public int value2 { get; set; }
            public string name3 { get; set; }
            public int value3 { get; set; }
        }

    }
}