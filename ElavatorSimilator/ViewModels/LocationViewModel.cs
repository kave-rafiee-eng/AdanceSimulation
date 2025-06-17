using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using static ElavatorSimilator.ViewModels.LocationViewModel;

namespace ElavatorSimilator.ViewModels
{

    public class LocationViewModel : INotifyPropertyChanged
    {

        public bool ModeENCactive { get; set; } = false;
        public ObservableCollection<ENC_Floor> _ENC_Floor { get; } = new ObservableCollection<ENC_Floor>();
        public class ENC_Floor
        {
            public double Y_Floor { get; set; }
        }

        public ObservableCollection<ENC_Floor_Marker> _ENC_Floor_Marker { get; } = new ObservableCollection<ENC_Floor_Marker>();
        public class ENC_Floor_Marker
        {
            public string STR_Floor_Marker { get; set; }
            public double Y_Floor_Marker { get; set; }
        }

        public ObservableCollection<ENC_1CFUP> _ENC_1CFUP { get; } = new ObservableCollection<ENC_1CFUP>();
        public class ENC_1CFUP
        {
            public double Y_1CFUP { get; set; }
        }

        public ObservableCollection<ENC_1CFUP_Marker> _ENC_1CFUP_Marker { get; } = new ObservableCollection<ENC_1CFUP_Marker>();
        public class ENC_1CFUP_Marker
        {
            public string STR_1CFUP_Marker { get; set; }
            public double Y_1CFUP_Marker { get; set; }
        }

        public void ClearENCcanvas(){

            _ENC_Floor.Clear();
            _ENC_Floor_Marker.Clear();
            _ENC_1CFUP.Clear();
            _ENC_1CFUP_Marker.Clear();
        }
        
        public void InitializeFloorMarkers(List<double> heights)
        {
            _ENC_Floor.Clear();
            _ENC_Floor_Marker.Clear();

            foreach (var height in heights)
            {
                _ENC_Floor.Add(new ENC_Floor { Y_Floor = 400 - (50 / 3) * height });
                _ENC_Floor_Marker.Add(new ENC_Floor_Marker { STR_Floor_Marker = height.ToString(), Y_Floor_Marker = 380 - (50 / 3) * height });
            }
        }


        public void Initialize_1CFUP(List<double> heights)
        {
            _ENC_1CFUP.Clear();
            _ENC_1CFUP_Marker.Clear();
            foreach (var height in heights)
            {
                _ENC_1CFUP.Add(new ENC_1CFUP { Y_1CFUP = 400 - (50 / 3) * height });
                _ENC_1CFUP_Marker.Add(new ENC_1CFUP_Marker { STR_1CFUP_Marker = height.ToString(), Y_1CFUP_Marker = 380 - (50 / 3) * height });
            }
        }


        public double Floor { get; set; }
        public double InFloor { get; set; }

        public double Goal { get; set; }
        public double PreGoal { get; set; }

        private double _ferq;
        private double _y;

        private double _y_goal;

        private double _y_pregoal;

        private double _LocInMeter;
        

        public double Y_Goal
        {
            get => _y_goal;
            set
            {
                if (_y_goal != value)
                {
                    _y_goal = value;
                    OnPropertyChanged(nameof(Y_Goal));
                }
            }
        }
        
        public double LocInMeter
        {
            get => _LocInMeter;
            set
            {
                if (_LocInMeter != value)
                {
                    _LocInMeter = value;
                    OnPropertyChanged(nameof(LocInMeter));
                }
            }
        }

        public double Ferq
        {
            get => _ferq;
            set
            {
                if (_ferq != value)
                {
                    _ferq = value;
                    OnPropertyChanged(nameof(Ferq));
                }
            }
        }

        public double Y_PreGoal
        {
            get => _y_pregoal;
            set
            {
                if (_y_pregoal != value)
                {
                    _y_pregoal = value;
                    OnPropertyChanged(nameof(Y_PreGoal));
                }
            }
        }

        public double Y
        {
            get => _y;
            set
            {
                if (_y != value)
                {
                    _y = value;
                    OnPropertyChanged(nameof(Y));
                }
            }
        }

        public LocationViewModel()
        {
            Y = 0;
            Y_Goal = 0;
            Y_PreGoal = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
