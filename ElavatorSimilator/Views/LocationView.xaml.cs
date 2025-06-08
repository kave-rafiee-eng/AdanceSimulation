using ElavatorSimilator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElavatorSimilator.Views
{
    /// <summary>
    /// Interaction logic for LocationView.xaml
    /// </summary>
    public partial class LocationView : UserControl
    {
        public LocationViewModel ViewModel { get; set; }
        public LocationView()
        {
            InitializeComponent();

            ViewModel = new LocationViewModel();

            for (int i = 0; i < 8; i++)
            {

                System.Windows.Shapes.Rectangle square = new System.Windows.Shapes.Rectangle();
                square.Width = 100;
                square.Height = 50;
                square.Stroke = Brushes.Black;
                square.StrokeThickness = 1;

                // موقعیت دادن در Canvas
                Canvas.SetLeft(square, 50);
                Canvas.SetTop(square, 50 * i);

                // اضافه کردن به Canvas
                Elevator.Children.Add(square);

                for (int j = 1; j < 4; j++)
                {
                    Line line = new Line();
                    line.X1 = 50;
                    line.Y1 = i * 50 + j * 12.5;
                    line.X2 = 150;
                    line.Y2 = i * 50 + j * 12.5;

                    line.StrokeThickness = 0.5;
                    line.Stroke = Brushes.Blue;
                    Elevator.Children.Add(line);

                }

            }

            DataContext = ViewModel;

        }
    }
}
