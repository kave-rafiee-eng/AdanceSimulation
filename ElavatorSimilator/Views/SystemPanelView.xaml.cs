using ElavatorSimilator.ViewModels;
using ElavatorSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
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
    /// Interaction logic for SystemPanelView.xaml
    /// </summary>
    public partial class SystemPanelView : UserControl
    {
        public SystemPanelViewModel ViewModel { get; private set; }

        private DispatcherTimer T_sendSPselect;
        public SystemPanelView()
        {
            InitializeComponent();

            ViewModel = new SystemPanelViewModel();
            DataContext = ViewModel;

            T_sendSPselect = new DispatcherTimer();
            T_sendSPselect.Interval = TimeSpan.FromMilliseconds(2000); // هر نیم ثانیه
            T_sendSPselect.Tick += sendSPselect;
            T_sendSPselect.Start();

        }

        private void sendSPselect(object sender, EventArgs e)
        {
            int selectedIndex = SystemPanelConboBox.SelectedIndex;

            var serialControl = SerialSelector.Instance;
            if (serialControl?.portManager?.serialPort?.IsOpen == true)
            {
                var jsonObject = new JsonObject
                {
                    ["SPselect"] = selectedIndex
                };

                string json = jsonObject.ToJsonString();
                serialControl.Send(json);
            }
        }

        private void SystemPanelConboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = SystemPanelConboBox.SelectedIndex;

            if (selectedIndex >= 0)
            {
                Debug.WriteLine($"Index selected: {selectedIndex}");

                var serialControl = SerialSelector.Instance;
                if (serialControl?.portManager?.serialPort?.IsOpen == true)
                {

                    var jsonObject = new JsonObject
                    {
                        ["SPselect"] = selectedIndex,
                    };
                    string json = jsonObject.ToJsonString();
                    serialControl.Send(json);
                }

            }
        }


    }
}
