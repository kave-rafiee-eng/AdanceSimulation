using ElavatorSimilator.Models;
using ElavatorSimilator.process;
using ElavatorSimilator.ViewModels;
using ElavatorSimilator.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
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

namespace ElavatorSimilator
{

    public partial class PageElevator : Page
    {

        private ChartViewModel _chartmotorfer_VM;

        public PageElevator()
        {

            Console.WriteLine("Page Elevator");

            InitializeComponent();

            _chartmotorfer_VM = new ChartViewModel();
            this.DataContext = _chartmotorfer_VM;

           /* var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) =>
            {
                var newValue = new Random().Next(0, 100);
                _chartmotorfer_VM.UpdateBuffer(newValue);
            };
            timer.Start();*/


            MessageBus.Instance.SerialDataReceived += OnSerialDataReceived;


            CallsDataGridInstance.ViewModel.AddCall(new Call
            {
                advance = 3,
                From = "C",
                Floor = 1,
                door1 = "Yes",
                door2 = "Yes",
                door3 = "No",
                dir = "Up",
                Timer = 15
            });


        }

        private void OnSerialDataReceived(SerialDataMessage msg)
        {

            var processor = new JsonProcessor(SystemPanelViewInstance.ViewModel, CallsDataGridInstance.ViewModel , LocationViewInstance.ViewModel , ButtonsViewInstance.ViewModel , _chartmotorfer_VM );
            processor.Process(msg.Data);

        }


    }

    
}


/* for (int s = 1; s <= 3; s++)
 {
     var panel = new SystemPanelData
     {
         Title = $"سیستم شماره {s}"
     };

     for (int i = 1; i <= 3; i++)
     {
         panel.Items.Add(new SystemItem
         {
             Label = $"Label {i}",
             Value = $"Value {i * s * 10}"
         });
     }

     Panels.Add(panel);
 }*/

/* data =
     @"
     {
       ""id"": 1,
       ""user"": {
         ""username"": ""kave""
       },
       ""isActive"": true
     }
     ";*/

/*
        private void CreateAllSystemPanels(List<SystemPanelData> panelDataList)
        {


            StackPanel masterStack = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(10),
                Background = Brushes.WhiteSmoke
            };

            foreach (var panelData in panelDataList)
            {
                // عنوان
                TextBlock title = new TextBlock
                {
                    Text = panelData.Title,
                    FontSize = 16,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.DarkSlateBlue,
                    Margin = new Thickness(0, 0, 0, 5)
                };

                StackPanel mainPanel = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    Background = Brushes.LightGray,
                    Margin = new Thickness(5),
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };

                foreach (var item in panelData.Items)
                {
                    StackPanel itemPanel = new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Margin = new Thickness(5),
                        Background = Brushes.AliceBlue,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };

                    Label lbl = new Label
                    {
                        Content = item.Label,
                        Foreground = Brushes.DarkBlue,
                        FontWeight = FontWeights.Bold,
                        Width = 80
                    };

                    TextBlock valueText = new TextBlock
                    {
                        Text = item.Value,
                        Foreground = Brushes.DarkGreen,
                        FontSize = 14,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    itemPanel.Children.Add(lbl);
                    itemPanel.Children.Add(valueText);

                    Border itemBorder = new Border
                    {
                        BorderBrush = Brushes.Gray,
                        BorderThickness = new Thickness(1),
                        CornerRadius = new CornerRadius(5),
                        Padding = new Thickness(5),
                        Margin = new Thickness(5, 2, 5, 2),
                        Child = itemPanel,
                        Background = Brushes.LightYellow
                    };

                    mainPanel.Children.Add(itemBorder);
                }

                StackPanel systemPanel = new StackPanel
                {
                    Orientation = Orientation.Vertical
                };

                systemPanel.Children.Add(title);
                systemPanel.Children.Add(mainPanel);

                Border systemBorder = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(2),
                    CornerRadius = new CornerRadius(8),
                    Padding = new Thickness(10),
                    Margin = new Thickness(10),
                    Background = Brushes.White,
                    Child = systemPanel
                };

                masterStack.Children.Add(systemBorder);
            }

            MyGrid.Children.Clear(); // پاکسازی قبلی‌ها
            MyGrid.Children.Add(masterStack);
        }
*/
