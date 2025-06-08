using LiveCharts;
using LiveCharts.Wpf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
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
using static ElavatorSimilator.Page1;

namespace ElavatorSimilator
{
    public partial class MainWindow : Window
    {

        private readonly Person person;

        private DispatcherTimer updatefloor;

        public MainWindow()
        {

            InitializeComponent();

            person = new Person();

            person.PersonName = "aaaa";



            updatefloor = new DispatcherTimer();
            updatefloor.Interval = TimeSpan.FromMilliseconds(500); // هر نیم ثانیه
            updatefloor.Tick += updatefloorUI;
            updatefloor.Start();

            MainFrame.Navigate(new PageBTN());
        }

        private void updatefloorUI(object sender, EventArgs e)
        {
           // Debug.WriteLine("Page Elevator");
        }


        
        private void MenuTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selectedItem = MenuTreeView.SelectedItem as TreeViewItem;
            if (selectedItem == null)
                return;

            string pageName = selectedItem.Tag as string;
            if (string.IsNullOrEmpty(pageName))
                return;

            switch (pageName)
            {
                case "Calls":
                    MainFrame.Navigate(new Page1());
                    break;
                case "Location":
                    MainFrame.Navigate(new PageLocation());
                    break;
                case "BTn":
                    MainFrame.Navigate(new PageElevator());
                    break;
            }

            // بعد از انتخاب، منو بسته شود
            MenuToggleButton.IsChecked = false;
        }



    }
}

