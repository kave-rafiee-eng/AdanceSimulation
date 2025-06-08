using ElavatorSimilator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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
            for (int floor = 0; floor < 10; floor++)
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

        public void UpdateButtonColor(int floor, int door, int direction, Brush newColor)
        {
            var btn = Floors
                .SelectMany(f => f.Groups)
                .SelectMany(g => g.Buttons)
                .FirstOrDefault(b => b.Info.Floor == floor && b.Info.Direction == direction && b.Info.Door == door);

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
