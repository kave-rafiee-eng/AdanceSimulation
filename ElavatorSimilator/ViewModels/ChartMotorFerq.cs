using LiveCharts;
using LiveCharts.Definitions.Charts;
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
using System.Windows.Threading;
using System.Windows;


namespace ElavatorSimilator.ViewModels
{

    public class ChartViewModel : INotifyPropertyChanged
    {
        public List<double> Pre_buffer; // بافر داده برای نمودار
        public ChartValues<double> _buffer; // بافر داده برای نمودار

        private DispatcherTimer T_updateChart;
        public SeriesCollection SeriesCollection { get; set; }
        public CartesianChart CartesianChart { get; set; } 

        public ChartViewModel()
        {
            _buffer = new ChartValues<double> { 0 };
            Pre_buffer = new List<double> { 0 };

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = _buffer,
                    PointGeometry = null,  // برای نمایش فقط خطوط، بدون نقطه
                    LineSmoothness = 0,    // برای کاهش محاسبات بی‌فایده
                    StrokeThickness = 1,
                    Fill = Brushes.Transparent,
                }
            };

            T_updateChart = new DispatcherTimer();
            T_updateChart.Interval = TimeSpan.FromMilliseconds(50); // هر نیم ثانیه
            T_updateChart.Tick += updateChart;
            T_updateChart.Start();
        }

        private void updateChart(object sender, EventArgs e)
        {

            Application.Current.Dispatcher.BeginInvoke(() =>
            {
                if (Pre_buffer.Count > _buffer.Count)
                {
                    while (_buffer.Count < Pre_buffer.Count)
                    {
                        _buffer.Add(Pre_buffer[_buffer.Count]);
                    }

                    OnPropertyChanged(nameof(SeriesCollection));
                }
                
            });


        }
        // متد برای آپدیت بافر و حرکت به جلو در محور X
        public void UpdateBuffer(double newValue)
        {
            Pre_buffer.Add(newValue);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // متد برای اعلان تغییرات
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
