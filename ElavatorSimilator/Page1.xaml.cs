using ElavatorSimilator.Views;
using LiveCharts;
using LiveCharts;
using LiveCharts.Wpf;
using Newtonsoft.Json.Linq;
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
using System.Windows.Threading;

namespace ElavatorSimilator
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {

        private string latestData = null;
        private DispatcherTimer updateTimer;

        private int[] dataBuffer = new int[1000];
        private int bufferCounter = 0;
        private ChartValues<int> chartValues = new ChartValues<int>();

        SerialPortManager portManager;
        public Page1()
        {
            InitializeComponent();

            var serialControl = SerialSelector.Instance;
            if (serialControl != null)
            {
                // مثلا استفاده از portManager
                var manager = serialControl.portManager;
                // یا subscribe به DataReceived
                serialControl.DataReceived += OnDataReceived;
            }

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
                    
                }
                else if (token["data1"] != null)
                {
                    simpleData = token.ToObject<SimpleData>();

                    AddValueToBuffer(simpleData.data1);

                    var serialControl = SerialSelector.Instance;
                    serialControl.portManager.ReciveCounter++;
                }

                latestData = data;
            }

        }


        private bool TryParseJson(string data, out JToken token)
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

                if (rootCalls != null)
                    DataGridCalls.ItemsSource = rootCalls.calls;

                if (simpleData != null)
                    DataGridSimpleData.ItemsSource = new List<SimpleData> { simpleData };

                var serialControl = SerialSelector.Instance;
                if (serialControl.portManager != null)
                {
                    conter.Text = serialControl.portManager.ReciveCounter.ToString();
                }


                textBoxOutput.AppendText(latestData + "\n");

                UpdateChart();

            });

        }

        private void ClickTest(object sender, RoutedEventArgs e)
        {
            conter.Text = portManager.ReciveCounter.ToString();
            //MessageBox.Show(portManager.ReciveCounter.ToString());
            
        }

        private class Call
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

        private class RootWithCalls
        {
            public int test { get; set; }
            public List<Call> calls { get; set; }
        }

               private class SimpleData
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
