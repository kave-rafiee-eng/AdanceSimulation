using ElavatorSimilator.Models;
using ElavatorSimilator.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace ElavatorSimilator.ViewModels
{

    // 📁 MainViewModel.cs
    public class ButtonsMainViewModel
    {

        public ObservableCollection<FloorViewModel> Floors { get; set; } = new();

        public ButtonsMainViewModel()
        {
            for (int floor = 8; floor >0; floor--)
            {
                var floorVm = new FloorViewModel();
                for (int door = 0; door < 3; door++)
                {
                    var groupVm = new GroupViewModel();
                    for (int dir = 0; dir < 3; dir++)
                    {
                        var info = new ButtonInfo
                        {
                            From = 0,
                            Floor = floor,
                            Direction = dir,
                            Door = door

                        };
                        groupVm.Buttons.Add(new ButtonViewModel(info));
                    }
                    floorVm.Groups.Add(groupVm);
                }

                for (int door = 0; door < 3; door++)
                {
                    var groupVm = new GroupViewModel();

                        var info = new ButtonInfo
                        {
                            From = 1,
                            Floor = floor,
                            Direction = 3,
                            Door = door

                        };
                        groupVm.Buttons.Add(new ButtonViewModel(info));
                    
                    floorVm.Groups.Add(groupVm);
                }

                Floors.Add(floorVm);

            }

            ButtonViewModel.ButtonClicked += OnButtonClicked;

        }

        private void OnButtonClicked(ButtonInfo info)
        {
            string address = $"From:{info.From} Floor:{info.Floor} Dir:{info.Direction} " +
                             $"Door:{info.Door} ";

            Debug.WriteLine($"Send to serial: {address}");

            var jsonObject = new JsonObject
            {
                ["from"] = info.From,
                ["floor"] = info.Floor,
            };

            switch (info.Door)
            {
                case 0:
                    jsonObject["door1"] = 1;
                    jsonObject["door2"] = 0;
                    jsonObject["door3"] = 0;
                break;
                case 1:
                    jsonObject["door1"] = 0;
                    jsonObject["door2"] = 1;
                    jsonObject["door3"] = 0;
                    break;
                case 2:
                    jsonObject["door1"] = 0;
                    jsonObject["door2"] = 0;
                    jsonObject["door3"] = 1;
                    break;
            }

            switch (info.Direction)
            {
                case 0:
                    jsonObject["dir"] = 2;
                    break;
                case 1:
                    jsonObject["dir"] = 0;
                break;
                case 2:
                    jsonObject["dir"] = 3;
                    break;
                case 3:
                    jsonObject["dir"] = 0;
                    break;
            }

            // تبدیل به رشته JSON
            string json = jsonObject.ToJsonString();

            var serialControl = SerialSelector.Instance;
            if (serialControl != null)
            {
                serialControl.Send(json);
            }
        }

        public void UpdateButtonColor(int from , int floor, int door, int direction, Brush newColor)
        {
            var btn = Floors
                .SelectMany(f => f.Groups)
                .SelectMany(g => g.Buttons)
                .FirstOrDefault(b => b.Info.From == from && b.Info.Floor == floor && b.Info.Direction == direction && b.Info.Door == door);

            if (btn != null) btn.ButtonColor = newColor;
        }
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
            ButtonColor = Brushes.Green;
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
