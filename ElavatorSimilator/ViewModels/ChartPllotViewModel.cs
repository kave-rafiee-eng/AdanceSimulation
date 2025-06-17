using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ElavatorSimilator.ViewModels
{
    public class ChartPlotViewModel : INotifyPropertyChanged
    {

        private double _xMin = 0;
        private double _xMax = 100;
        private double _yMin = 0;
        private double _yMax = 50;

        private PlotModel _plotModel;


        private OxyPlot.Series.LineSeries[] _lineSeries;


        public ChartPlotViewModel()
        {

            _plotModel = new PlotModel { Title = "Speed" };

            _lineSeries = new OxyPlot.Series.LineSeries[2];

            _lineSeries[0] = new OxyPlot.Series.LineSeries
            {
                Title = "Line 1",
                MarkerType = MarkerType.None,  
                MarkerSize = 0,               
                MarkerStroke = OxyColors.White,
                Color = OxyColors.Red,
                LineStyle = LineStyle.Solid,   
                StrokeThickness = 2            
            };

            _lineSeries[1] = new OxyPlot.Series.LineSeries
            {
                Title = "Line 2",
                MarkerType = MarkerType.None,  
                MarkerSize = 0,                
                MarkerStroke = OxyColors.White, 
                LineStyle = LineStyle.Solid,
                Color = OxyColors.Gold,
                StrokeThickness = 2            
            };

            _lineSeries[0].Points.Add(new DataPoint(5, 5));
            _lineSeries[1].Points.Add(new DataPoint(5, 5));

            _plotModel.Series.Add(_lineSeries[0]);
            _plotModel.Series.Add(_lineSeries[1]);

            _plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                Minimum = _xMin,  
                Maximum = _xMax, 
                IsZoomEnabled = false,   
                IsPanEnabled = false
            });

            _plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                Minimum = _yMin,  
                Maximum = _yMax, 
                IsZoomEnabled = false,   
                IsPanEnabled = false
            });

        }

        public void ChangeZoom(double xMin, double xMax, double yMin, double yMax)
        {
            _xMin = xMin;
            _xMax = xMax;
            _yMin = yMin;
            _yMax = yMax;

            var xAxis = _plotModel.Axes[0]; 
            var yAxis = _plotModel.Axes[1]; 

            xAxis.Minimum = _xMin;
            xAxis.Maximum = _xMax;
            yAxis.Minimum = _yMin;
            yAxis.Maximum = _yMax;

        }

        public PlotModel PlotModel
        {
            get { return _plotModel; }
            set
            {
                _plotModel = value;

                OnPropertyChanged(nameof(PlotModel));
            }
        }

        private double CounterX = 0;


        public void AddDataPoint( int Select , double y)
        {
            _lineSeries[Select].Points.Add(new DataPoint(CounterX, y));
            CounterX++;
        }

        public void PlotUpdate()
        {
            _plotModel.InvalidatePlot(true);
            OnPropertyChanged(nameof(PlotModel));
        }

        public int GetPointCount()
        {
            int count0 = _lineSeries[0].Points.Count;
            int count1 = _lineSeries[1].Points.Count;

            if (count0 > count1)
                return count0;  
            else
                return count1; 
        }

        public void ClearAllPoints( int select )
        {
            CounterX = 0;
            _lineSeries[select].Points.Clear();

            _plotModel.InvalidatePlot(true);
            OnPropertyChanged(nameof(PlotModel));
        }

        public double GetMaxYPoint()
        {
            var maxYLine1 = _lineSeries[0].Points.OrderByDescending(p => p.Y).First().Y;
            var maxYLine2 = _lineSeries[1].Points.OrderByDescending(p => p.Y).First().Y;

            if( maxYLine1 > maxYLine2 )
                return maxYLine1 + 5;  
            else
                return maxYLine2 + 5;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
