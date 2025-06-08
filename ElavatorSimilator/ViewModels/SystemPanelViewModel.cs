using ElavatorSimilator.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ElavatorSimilator.ViewModels
{
    public class SystemPanelViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<SystemPanelData> _panels;
        public ObservableCollection<SystemPanelData> Panels
        {
            get => _panels;
            set
            {
                _panels = value;
                OnPropertyChanged(nameof(Panels));
            }
        }

        public SystemPanelViewModel()
        {
            Panels = new ObservableCollection<SystemPanelData>();
        }

        public void AddPanel(SystemPanelData panel)
        {
            Panels.Add(panel);
            OnPropertyChanged(nameof(Panels));
        }

        public void ClearPanels()
        {
            Panels.Clear();
            OnPropertyChanged(nameof(Panels));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}