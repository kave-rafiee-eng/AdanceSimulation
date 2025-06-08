using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElavatorSimilator
{

    public class Person : INotifyPropertyChanged
    {
        private string _personName;
        private int _age;

        public string PersonName
        {
            get => _personName;
            set
            {
                if (_personName != value)
                {
                    _personName = value;
                    OnPropertyChanged(nameof(PersonName));
                }
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }

        public Person()
        {
            PersonName = "kaveh";
            Age = 30;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}