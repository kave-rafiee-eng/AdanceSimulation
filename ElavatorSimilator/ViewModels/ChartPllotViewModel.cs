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
using System.Windows.Controls.Primitives;
using System.Xml.Linq;

namespace ElavatorSimilator.ViewModels
{
    public class ChartPlotViewModel : INotifyPropertyChanged
    {

        private double _xMin = 0;
        private double _xMax = 100;
        private double _yMin = 0;
        private double _yMax = 50;

        private PlotModel _plotModel;
        private PlotModel _plotModel2;


        public OxyPlot.Series.LineSeries[] _lineSeries;
        public OxyPlot.Series.LineSeries[] _lineSeries2;

        public ChartPlotViewModel()
        {

            _plotModel = new PlotModel { Title = "Speed" };
            _plotModel2 = new PlotModel { Title = "Pos" };

            _lineSeries = new OxyPlot.Series.LineSeries[2];
            _lineSeries2 = new OxyPlot.Series.LineSeries[2];

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

            _lineSeries[0].Points.Add(new DataPoint(0, 0));
            _lineSeries[1].Points.Add(new DataPoint(0, 0));

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

            //---------------------------------------

            _lineSeries2[0] = new OxyPlot.Series.LineSeries
            {
                Title = "Line 1",
                MarkerType = MarkerType.Circle, 
                MarkerSize = 0.5,
                MarkerStroke = OxyColors.Red,
                MarkerFill = OxyColors.Red,
                LineStyle = LineStyle.None,      
                StrokeThickness = 0               
            };

            _lineSeries2[1] = new OxyPlot.Series.LineSeries
            {
                Title = "Line 2",
                MarkerType = MarkerType.Circle,
                MarkerSize = 0.5,
                MarkerStroke = OxyColors.Gold,
                MarkerFill = OxyColors.Blue,
                LineStyle = LineStyle.None,
                StrokeThickness = 0
            };

            _lineSeries2[0].Points.Add(new DataPoint(0, 0));
            _lineSeries2[1].Points.Add(new DataPoint(0, 0));

            _plotModel2.Series.Add(_lineSeries2[0]);
            _plotModel2.Series.Add(_lineSeries2[1]);

            _plotModel2.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 1000,
                IsZoomEnabled = false,
                IsPanEnabled = false
            });

            _plotModel2.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                Minimum = 0,
                Maximum = 2,
                IsZoomEnabled = false,
                IsPanEnabled = false
            });
        }

        public void ChangeZoom(double xModel , double xMin, double xMax, double yMin, double yMax)
        {
            if(xModel == 0)
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

            if (xModel == 1)
            {
                _xMin = xMin;
                _xMax = xMax;
                _yMin = yMin;
                _yMax = yMax;

                var xAxis = _plotModel2.Axes[0];
                var yAxis = _plotModel2.Axes[1];

                xAxis.Minimum = _xMin;
                xAxis.Maximum = _xMax;
                yAxis.Minimum = _yMin;
                yAxis.Maximum = _yMax;

            }

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

        public PlotModel PlotModel2
        {
            get { return _plotModel2; }
            set
            {
                _plotModel2 = value;

                OnPropertyChanged(nameof(PlotModel2));
            }
        }

        private double CounterX = 0;


        public void AddDataPoint( double xModel , int Select , double y, double x)
        {
            if (xModel == 0)
            {
                _lineSeries[Select].Points.Add(new DataPoint(CounterX, y));
                CounterX++;
            }

            if (xModel == 1)
            {
                _lineSeries2[Select].Points.Add(new DataPoint(x, y));
            }

        }

        public void PlotUpdate( double xModel )
        {

            if (xModel == 0)
            {
                _plotModel.InvalidatePlot(true);
                OnPropertyChanged(nameof(PlotModel));
            }

            if (xModel == 1)
            {
                _plotModel2.InvalidatePlot(true);
                OnPropertyChanged(nameof(PlotModel2));
            }

        }

        public double GetPointCount(double xModel )
        {

            if (xModel == 0)
            {
                double maxXLine1 = _lineSeries[0].Points.OrderByDescending(p => p.X).First().X;
                double maxXLine2 = _lineSeries[1].Points.OrderByDescending(p => p.X).First().X;

                if (maxXLine1 > maxXLine2)
                    return maxXLine1;
                else
                    return maxXLine2;
            }

            if (xModel == 1)
            {
                double maxXLine1 = _lineSeries2[0].Points.OrderByDescending(p => p.X).First().X;
                double maxXLine2 = _lineSeries2[1].Points.OrderByDescending(p => p.X).First().X;

                if (maxXLine1 > maxXLine2)
                    return maxXLine1;
                else
                    return maxXLine2;
            }

            return 0;

        }

        public void ClearAllPoints(double xModel , int select )
        {

            if (xModel == 0)
            {
                CounterX = 0;
                _lineSeries[select].Points.Clear();

                _plotModel.InvalidatePlot(true);
                OnPropertyChanged(nameof(PlotModel));
            }

            if (xModel == 1)
            {

                _lineSeries2[select].Points.Clear();

                _plotModel.InvalidatePlot(true);
                OnPropertyChanged(nameof(PlotModel));


            }

        }

        public double GetMaxYPoint(double xModel )
        {
            double x = _lineSeries[0].Points.Count;

            if (xModel == 0)
            {
                var maxYLine1 = _lineSeries[0].Points.OrderByDescending(p => p.Y).First().Y;
                var maxYLine2 = _lineSeries[1].Points.OrderByDescending(p => p.Y).First().Y;

                if (maxYLine1 > maxYLine2)
                    return maxYLine1;
                else
                    return maxYLine2;
            }

            if (xModel == 1)
            {
                var maxYLine1 = _lineSeries2[0].Points.OrderByDescending(p => p.Y).First().Y;
                var maxYLine2 = _lineSeries2[1].Points.OrderByDescending(p => p.Y).First().Y;

                if (maxYLine1 > maxYLine2)
                    return maxYLine1;
                else
                    return maxYLine2;
            }

            return 0;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
