using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// <summary>
    /// Interaction logic for PageElevator.xaml
    /// </summary>
    public partial class PageElevator : Page
    {
        public PageElevator()
        {
            InitializeComponent();

            CreateGroupedButtons();

            List<SystemPanelData> allPanels = new List<SystemPanelData>();

            for (int s = 1; s <= 3; s++)
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

                allPanels.Add(panel);
            }

            var vm = new MainViewModel();

           

            // 2. ست کردن DataContext به ویو مدل
            this.DataContext = vm;

            vm.Panels[0].Items[0].Label = "aaaaa";

            // this.DataContext = new MainViewModel();


            //CreateAllSystemPanels(allPanels);

        }

        private void CreateGroupedButtons()
        {
            // فرض کن اینجا یک StackPanel عمودی داریم که همه floor ها را می‌گیرد:
            StackPanel FloorsPanel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(10),
                Background = Brushes.LightYellow // برای تست بهتر قابل تغییر
            };

            // تعداد floor ها (مثلا 5 تا)
            int numberOfFloors = 5;

            for (int floorIndex = 0; floorIndex < numberOfFloors; floorIndex++)
            {
                // هر floor یک StackPanel افقی هست
                StackPanel Floor = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(0, 2, 0, 2),
                    Background = Brushes.LightBlue
                };

                // مثلا هر floor شامل 3 گروه است
                for (int indexDoor = 0; indexDoor < 3; indexDoor++)
                {
                    StackPanel groupPanel = new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Background = Brushes.LightGray
                    };

                    for (int i = 0; i < 3; i++)
                    {

                        dynamic obj = new ExpandoObject();

                        string BtnContent = string.Empty;
                        switch (i)
                        {
                            case 0:
                                BtnContent = "\u2191";  // UP arrow
                                obj.dir = 0;
                                break;
                            case 1:
                                BtnContent = "\u21C5";  // UP-DOWN arrow (uni)
                                obj.dir = 1;
                                break;
                            case 2:
                                BtnContent = "\u2193";  // DOWN arrow
                                obj.dir = 2;
                                break;
                        }

                        obj.floor = floorIndex;
                        if (indexDoor == 0) obj.door1 = 1;
                        if (indexDoor == 1) obj.door2 = 1;
                        if (indexDoor == 2) obj.door3 = 1;

                        // تبدیل به JSON:
                        string tagJson = JsonConvert.SerializeObject(obj);

                        Button btn = new Button
                        {
                            //Content = $"Floor {floorIndex + 1} - کلید {i + 1}",

                            Content = BtnContent,
                            Margin = new Thickness(2),
                            Padding = new Thickness(2, 2, 2, 2),
                            Tag = tagJson,
                            FontSize = 16
                        };
                        btn.Click += Button_Click;
                        groupPanel.Children.Add(btn);
                    }

                    Border border = new Border
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1),
                        CornerRadius = new CornerRadius(3),
                        Padding = new Thickness(5),
                        Margin = new Thickness(5, 0, 5, 0),
                        Child = groupPanel,
                        Background = Brushes.LightGray
                    };

                    Floor.Children.Add(border);
                }

                FloorsPanel.Children.Add(Floor);
            }

            // حالا FloorsPanel را به پنل اصلی یا هر جایی که می‌خواهی اضافه کن:
            ButtonPanel.Children.Add(FloorsPanel);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                MessageBox.Show(btn.Tag.ToString());
                btn.Background = Brushes.Red;
            }
        }


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

        public class MainViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<SystemPanelData> Panels { get; set; }

            public MainViewModel()
            {
                Panels = new ObservableCollection<SystemPanelData>();

                for (int s = 1; s <= 3; s++)
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
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }


        public class SystemItem
        {
            public string Label { get; set; }
            public string Value { get; set; }
        }

        public class SystemPanelData
        {
            public string Title { get; set; }
            public List<SystemItem> Items { get; set; } = new List<SystemItem>();
        }
    }

    
}
