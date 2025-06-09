using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ElavatorSimilator.ViewModels
{

    public class ChartViewModel : INotifyPropertyChanged
    {
        private ChartValues<double> _buffer;

        public SeriesCollection SeriesCollection { get; set; }

        public ChartViewModel()
        {
            _buffer = new ChartValues<double> { 0 };

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = _buffer,
                    PointGeometry = null,
                    LineSmoothness = 0, // برای کاهش محاسبات بی‌فایده
                    StrokeThickness = 1,
                    Fill = Brushes.Transparent,
                }
            };
        }

        // متد برای آپدیت بافر
        public void UpdateBuffer(double newValue)
        {
            _buffer.Add(newValue);

            if (_buffer.Count > 500)
                _buffer.RemoveAt(0); // بافر حلقوی
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
