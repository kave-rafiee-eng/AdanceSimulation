using ElavatorSimilator.Models;
using ElavatorSimilator.process;
using ElavatorSimilator.ViewModels;
using ElavatorSimilator.Views;
using LiveCharts;
using LiveCharts.Definitions.Charts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OxyPlot;
using OxyPlot.Series;
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
using System.Windows.Threading;

namespace ElavatorSimilator
{
    
    public partial class PageElevator : Page
    {
        private DispatcherTimer T_update;

        private ChartViewModel _chartmotorfer_VM;

        private ChartPlotViewModel chartPlot_VM;

        public PageElevator()
        {

            Console.WriteLine("Page Elevator");

            InitializeComponent();

            _chartmotorfer_VM = new ChartViewModel();
            this.DataContext = _chartmotorfer_VM;

            /*cartesianChart.Zoom = ZoomingOptions.X; // زوم در هر دو محور X و Y
            cartesianChart.Pan = PanningOptions.X;  // اسکرول در هر دو محور X و Y

            cartesianChart.AxisX[0].MinValue = 0;
            cartesianChart.AxisX[0].MaxValue = 150;*/

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


            T_update = new DispatcherTimer();
            T_update.Interval = TimeSpan.FromMilliseconds(2000); // هر نیم ثانیه
            T_update.Tick += testupdateChart;
            T_update.Start();

            //--------------------------------------



            chartPlot_VM = new ChartPlotViewModel();
            this.DataContext = chartPlot_VM;
            

        }

        int ChartSelected = 0;
        private void SelectChart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectChart.SelectedItem is ComboBoxItem selectedItem)
            {
                int SlectedIndex = SelectChart.SelectedIndex;
                ChartSelected = SlectedIndex;
                // حالا می‌تونی اینجا نمودارها یا StackPanelها رو تغییر بدی:
                if (SlectedIndex == 0)
                {
                    if (PanelChart2 != null && PanelChart1 != null)
                    {
                        PanelChart1.Visibility = Visibility.Visible;
                        PanelChart2.Visibility = Visibility.Collapsed;
                    }

                }
                else if (SlectedIndex == 1 )
                {
                    
                    if (PanelChart1 != null && PanelChart2 != null)
                    {
                        PanelChart2.Visibility = Visibility.Visible;
                        PanelChart1.Visibility = Visibility.Collapsed;
                    }
                }
            }

           
        }

        int test = 0;
        private void testupdateChart(object sender, EventArgs e)
        {
            test = 1 - test;

        }
        //----------------------------------------------------------

        double visibleDataCountPlot2 = 2000;
        double Plot2_ZoomX_Min = 0;
        double Plot2_ZoomX_Max = 0;

        double Plot2_ZoomY_Min = 0;
        double Plot2_ZoomY_Max = 1;

        private void PosMin_LostFocus(object sender, RoutedEventArgs e)
        {
            string value = PosMin.Text;
            if (double.TryParse(value, out double result))
            {

                Plot2_ZoomX_Min = result * 1000 ;
                chartPlot_VM.ChangeZoom(1, Plot2_ZoomX_Min , Plot2_ZoomX_Max, Plot2_ZoomY_Min , Plot2_ZoomY_Max);

                chartPlot_VM.PlotUpdate(1);
            }
            else
            {
                MessageBox.Show("لطفاً یک عدد معتبر وارد کنید.");
            }
        }

        private void PosMax_LostFocus(object sender, RoutedEventArgs e)
        {
            string value = PosMax.Text;
            if (double.TryParse(value, out double result))
            {

                Plot2_ZoomX_Max = result * 1000;
                chartPlot_VM.ChangeZoom(1, Plot2_ZoomX_Min, Plot2_ZoomX_Max, Plot2_ZoomY_Min, Plot2_ZoomY_Max);

                chartPlot_VM.PlotUpdate(1);
            }
            else
            {
                MessageBox.Show("لطفاً یک عدد معتبر وارد کنید.");
            }
        }

        private void ClearChart2(object sender, RoutedEventArgs e)
        {
            chartPlot_VM.ClearAllPoints(1, 0);
            chartPlot_VM.ClearAllPoints(1, 1);

            chartPlot_VM.AddDataPoint(1, 0, 0, 0);
            chartPlot_VM.AddDataPoint(1, 1, 0, 0);

            Application.Current.Dispatcher.BeginInvoke(() =>
            {
                chartPlot_VM.PlotUpdate(1);

            });
        }

        private void Plot2zoomInc(object sender, RoutedEventArgs e)
        {
            visibleDataCountPlot2 *= 2;
            Application.Current.Dispatcher.BeginInvoke(() =>
            {

            });
        }

        private void Plot2zoomDec(object sender, RoutedEventArgs e)
        {
            visibleDataCountPlot2 /= 2;
            Application.Current.Dispatcher.BeginInvoke(() =>
            {

            });
        }

        //----------------------------------------------------------

        int visibleDataCount = 200;

        private void zoomInc(object sender, RoutedEventArgs e)
        {
            visibleDataCount *= 2;
            Application.Current.Dispatcher.BeginInvoke(() =>
            {
                zoomMax = 0;
                CalculateZool();
                chartPlot_VM.PlotUpdate( 0 );
            });
        }

        private void zoomDec(object sender, RoutedEventArgs e)
        {
            visibleDataCount /= 2;
            Application.Current.Dispatcher.BeginInvoke(() =>
            {
                zoomMax = 0;
                CalculateZool();
                chartPlot_VM.PlotUpdate( 0 );
            });
        }

        private void ClearChart(object sender, RoutedEventArgs e)
        {
            chartPlot_VM.ClearAllPoints( 0 , 0);
            chartPlot_VM.ClearAllPoints(0 , 1);

            chartPlot_VM.AddDataPoint( 0 , 0 , 0 ,0  );
            chartPlot_VM.AddDataPoint( 0 , 1, 0 , 0 );

            Application.Current.Dispatcher.BeginInvoke(() =>
            {
                zoomMax = 0;
                CalculateZool();
                chartPlot_VM.PlotUpdate(0);

            });
        }


        double zoomMax = 0;
        double zoomMin = 0;
        private void CalculateZool()
        {
            double totalDataCount = chartPlot_VM.GetPointCount(0);

            double MaxZoomY = 0;
            if (totalDataCount > visibleDataCount)
            {
                if (totalDataCount >= zoomMax)
                {
                     MaxZoomY = chartPlot_VM.GetMaxYPoint(0) ;
                    MaxZoomY += MaxZoomY / 3;
                    zoomMax = totalDataCount + visibleDataCount / 3;
                    zoomMin = totalDataCount - visibleDataCount;
                    chartPlot_VM.ChangeZoom( 0, zoomMin, zoomMax, 0, MaxZoomY );
                }
            }
            else
            {
                if (totalDataCount > zoomMax)
                {
                     MaxZoomY = chartPlot_VM.GetMaxYPoint(0);
                    MaxZoomY += MaxZoomY / 3;
                    zoomMax = visibleDataCount;
                    zoomMin =0;
                    chartPlot_VM.ChangeZoom( 0 , zoomMin, zoomMax, 0, MaxZoomY );
                }
            }

             MaxZoomY = chartPlot_VM.GetMaxYPoint(0);
            MaxZoomY += MaxZoomY / 3;
            chartPlot_VM.ChangeZoom( 0 , zoomMin, zoomMax, 0, MaxZoomY);

        }
        private void OnSerialDataReceived(SerialDataMessage msg)
        {

            var processor = new JsonProcessor(SystemPanelViewInstance.ViewModel, CallsDataGridInstance.ViewModel , LocationViewInstance.ViewModel , ButtonsViewInstance.ViewModel , chartPlot_VM);
            processor.Process(msg.Data);

            Application.Current.Dispatcher.BeginInvoke(() =>
            {

                CalculateZool();

                double Location = LocationViewInstance.ViewModel.LocationInMiles;

                Plot2_ZoomY_Max = chartPlot_VM.GetMaxYPoint(1);
                Plot2_ZoomY_Max += Plot2_ZoomY_Max / 3;

                Plot2_ZoomX_Max = Location + visibleDataCountPlot2;
                Plot2_ZoomX_Min = Location - visibleDataCountPlot2;
                chartPlot_VM.ChangeZoom( 1 , Plot2_ZoomX_Min, Plot2_ZoomX_Max, Plot2_ZoomY_Min, Plot2_ZoomY_Max);

                

                chartPlot_VM.PlotUpdate(ChartSelected);

            });

            /*Application.Current.Dispatcher.BeginInvoke(() =>
            {

                double totalDataCount = _chartmotorfer_VM._buffer.Count;

                double visibleDataCount = 200; 

                if (cartesianChart.Zoom != ZoomingOptions.None)
                {
                    visibleDataCount = cartesianChart.AxisX[0].MaxValue - cartesianChart.AxisX[0].MinValue;
                }

                if (totalDataCount > visibleDataCount)
                {
                    cartesianChart.AxisX[0].MaxValue = totalDataCount;
                    cartesianChart.AxisX[0].MinValue = totalDataCount - visibleDataCount;
                }
                else
                {
                    cartesianChart.AxisX[0].MaxValue = visibleDataCount;
                    cartesianChart.AxisX[0].MinValue = 0;
                }

               // cartesianChart.Update(true);

            });*/


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
