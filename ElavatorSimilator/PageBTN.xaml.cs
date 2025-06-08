using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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

namespace ElavatorSimilator
{
    /// <summary>
    /// Interaction logic for PageBTN.xaml
    /// </summary>
    /// 

    public partial class PageBTN : Page
    {

        private MainViewModel _viewModel;
        public PageBTN()
        {
            InitializeComponent();

            _viewModel = new MainViewModel();
            this.DataContext = _viewModel;

            _viewModel.UpdateButtonColor(2, 2, 1, Brushes.Green );

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


        // 📁 ButtonInfo.cs
        public class ButtonInfo
        {
            public int Floor { get; set; }
            public int Direction { get; set; } // 0=UP, 1=UP-DOWN, 2=DOWN
            public int Door { get; set; }

            public string Display => Direction switch
            {
                0 => "\u2191", // ↑
                1 => "\u21C5", // ⇅
                2 => "\u2193", // ↓
                _ => "?"
            };
        }

        // 📁 ButtonViewModel.cs
        public class ButtonViewModel : INotifyPropertyChanged
        {
            public ButtonInfo Info { get; }
            public ICommand ClickCommand { get; }
            private Brush _buttonColor = Brushes.LightGray;
            public Brush ButtonColor
            {
                get => _buttonColor;
                set { _buttonColor = value; OnPropertyChanged(); }
            }

            public static event Action<ButtonInfo> ButtonClicked;

            public ButtonViewModel(ButtonInfo info)
            {
                Info = info;
                ClickCommand = new RelayCommand(OnClick);
            }

            private void OnClick()
            {
                ButtonColor = Brushes.Red;
                ButtonClicked?.Invoke(Info);
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged([CallerMemberName] string name = null)
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        // 📁 GroupViewModel.cs
        public class GroupViewModel
        {
            public ObservableCollection<ButtonViewModel> Buttons { get; set; } = new();
        }

        // 📁 FloorViewModel.cs
        public class FloorViewModel
        {
            public ObservableCollection<GroupViewModel> Groups { get; set; } = new();
        }

        // 📁 MainViewModel.cs
        public class MainViewModel
        {
            public ObservableCollection<FloorViewModel> Floors { get; set; } = new();

            public MainViewModel()
            {
                for (int floor = 0; floor < 5; floor++)
                {
                    var floorVm = new FloorViewModel();
                    for (int door = 0; door < 3; door++)
                    {
                        var groupVm = new GroupViewModel();
                        for (int dir = 0; dir < 3; dir++)
                        {
                            var info = new ButtonInfo
                            {
                                Floor = floor,
                                Direction = dir,
                                Door = door

                            };
                            groupVm.Buttons.Add(new ButtonViewModel(info));
                        }
                        floorVm.Groups.Add(groupVm);
                    }
                    Floors.Add(floorVm);
                }

                ButtonViewModel.ButtonClicked += OnButtonClicked;
            }

            private void OnButtonClicked(ButtonInfo info)
            {
                string address = $"F:{info.Floor} D:{info.Direction} " +
                                 $"F:{info.Door} ";
  
                Debug.WriteLine($"Send to serial: {address}");
            }

            public void UpdateButtonColor(int floor, int door,  int direction,  Brush newColor)
            {
                var btn = Floors
                    .SelectMany(f => f.Groups)
                    .SelectMany(g => g.Buttons)
                    .FirstOrDefault(b => b.Info.Floor == floor && b.Info.Direction == direction && b.Info.Door == door );

                if (btn != null) btn.ButtonColor = newColor;
            }
        }

        // 📁 RelayCommand.cs
        public class RelayCommand : ICommand
        {
            private readonly Action _execute;
            public RelayCommand(Action execute) => _execute = execute;

            public bool CanExecute(object parameter) => true;
            public void Execute(object parameter) => _execute();

            public event EventHandler CanExecuteChanged;
        }


    }
}


/*
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
*/