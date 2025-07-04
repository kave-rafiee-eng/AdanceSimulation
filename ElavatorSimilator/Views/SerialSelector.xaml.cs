﻿using ElavatorSimilator.process;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace ElavatorSimilator.Views
{
    /// <summary>
    /// Interaction logic for SerialSelector.xaml
    /// </summary>
    /// 

    public partial class SerialSelector : UserControl, INotifyPropertyChanged
    {
        private DispatcherTimer T_BlinkLed;

        private Brush _indicatorBrush = Brushes.Gray;
        public Brush IndicatorBrush
        {
            get => _indicatorBrush;
            set
            {
                _indicatorBrush = value;
                OnPropertyChanged(nameof(IndicatorBrush));
            }
        }

        private bool DataRecievedBlink;
        private bool F_recive;
        public static SerialSelector Instance { get; private set; }
        public SerialPortManager portManager { get; private set; }
        public event Action<string> DataReceived;

        public SerialSelector()
        {
            InitializeComponent();

            this.DataContext = this;
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

            var serialControl = SerialSelector.Instance;
            if (serialControl != null)
            {
                serialControl.DataReceived += OnDataReceived;
            }

            T_BlinkLed = new DispatcherTimer();
            T_BlinkLed.Interval = TimeSpan.FromMilliseconds(500); // هر نیم ثانیه
            T_BlinkLed.Tick += updateLed;
            T_BlinkLed.Start();

        }

        private void OnDataReceived(string data)
        {
            F_recive = true;

            MessageBus.Instance.SendSerialData(data);

        }

        private void updateLed(object sender, EventArgs e)
        {
            if (F_recive)
            {
                F_recive = false;

                DataRecievedBlink = !DataRecievedBlink;

                Application.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (DataRecievedBlink == true)
                    {
                        IndicatorBrush = Brushes.Gray;
                    }
                    else
                    {
                        IndicatorBrush = Brushes.Gold;
                    }
                });
            }
            else
            {
                Application.Current.Dispatcher.BeginInvoke(() =>
                {

                   IndicatorBrush = Brushes.Gray;
   
                });
            }

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



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
