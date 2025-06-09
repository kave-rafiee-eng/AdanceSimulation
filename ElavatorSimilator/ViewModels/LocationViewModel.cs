using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElavatorSimilator.ViewModels
{
    public class LocationViewModel : INotifyPropertyChanged
    {
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
