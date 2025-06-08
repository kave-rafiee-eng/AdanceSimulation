using System.Collections.ObjectModel;
using System.ComponentModel;

using ElavatorSimilator.Models;

namespace ElavatorSimulator.ViewModels
{
    public class CallsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Call> _calls;
        public ObservableCollection<Call> Calls
        {
            get => _calls;
            set
            {
                _calls = value;
                OnPropertyChanged(nameof(Calls));
            }
        }

        public CallsViewModel()
        {
            Calls = new ObservableCollection<Call>
            {
                new Call { advance = 1, From = "A", Floor = 3, door1 = "Yes", door2 = "No", door3 = "No", dir = "Up", Timer = 10 },
                new Call { advance = 2, From = "B", Floor = 5, door1 = "No", door2 = "Yes", door3 = "No", dir = "Down", Timer = 7 }
            };
        }

        public void AddCall(Call call)
        {
            Calls.Add(call);
        }

        public void RemoveCall(Call call)
        {
            Calls.Remove(call);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}