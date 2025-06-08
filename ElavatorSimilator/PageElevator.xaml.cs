using ElavatorSimilator.Models;
using ElavatorSimilator.process;
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


        public PageElevator()
        {

            Console.WriteLine("Page Elevator");

            InitializeComponent();
            
            var serialControl = SerialSelector.Instance;
            if (serialControl != null)
            {
                serialControl.DataReceived += OnDataReceived;
            }


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


        private void OnDataReceived(string data)
        {

            var processor = new JsonProcessor(SystemPanelViewInstance.ViewModel, CallsDataGridInstance.ViewModel , LocationViewInstance.ViewModel );
            processor.Process(data);

            /*if (TryParseJson(data, out JToken token))
            {

                if (token.Type == JTokenType.Object)
                {
                    Debug.WriteLine("Root is an object.");
                    var obj = (JObject)token;

                    var  GroupData = new List<SystemPanelData>();

                    foreach (var property in obj.Properties())
                    {
                        Debug.WriteLine($"Key: {property.Name}, Type: {property.Value.Type}");

                        if (property.Value.Type == JTokenType.Array)
                        {

                            Debug.WriteLine($"  → This is an array under key '{property.Name}'");

                            var Calls = new List<Call>();
                            Calls = property.Value.ToObject<List<Call>>();

                            foreach (var item in property.Value)
                            {
                                if (item.Type == JTokenType.Object)
                                {

                                    Debug.WriteLine("    → Item is an object with properties:");
                                    foreach (var field in ((JObject)item).Properties())
                                    {
                                        if (field.Value.Type == JTokenType.Object)
                                        {
                                            Debug.WriteLine($"       {field.Name} is a nested object:");
                                            foreach (var subField in ((JObject)field.Value).Properties())
                                            {
                                                Debug.WriteLine($"         {subField.Name}: {subField.Value}");

                                            }
                                        }
                                        else
                                        {
                                            Debug.WriteLine($"       {field.Name}: {field.Value}");

                                        }
                                    }
                                }
                                else
                                {
                                    Debug.WriteLine($"    → Item is not an object: {item}");
                                }
                            }

                            Application.Current.Dispatcher.BeginInvoke(() =>
                            {

                                SystemPanelViewInstance.ViewModel.ClearPanels();

                                CallsDataGridInstance.ViewModel.Calls.Clear();
                                foreach (var call in Calls)
                                {
                                    CallsDataGridInstance.ViewModel.AddCall(call);
                                }

                            });

                            
                        }
                        else if (property.Value.Type == JTokenType.Object )
                        {
                            
                            var panel = new SystemPanelData
                            {
                                Title = property.Name
                            };

                            Debug.WriteLine($"       {property.Name} is a nested object:");
                            foreach (var subField in ((JObject)property.Value).Properties())
                            {
                                Debug.WriteLine($"         {subField.Name}: {subField.Value}");

                                panel.Items.Add(new SystemItem
                                {
                                    Label = subField.Name,
                                    Value = subField.Value.ToString()
                                });
                            }

                            GroupData.Add(panel);

                        }
                    }


                    Application.Current.Dispatcher.BeginInvoke(() =>
                    {

                        SystemPanelViewInstance.ViewModel.ClearPanels();
                        foreach (var panel in GroupData)
                        {  
                            SystemPanelViewInstance.ViewModel.AddPanel(panel);
                        }

                    });

                }

            }*/

        }
/*
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
*/

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
