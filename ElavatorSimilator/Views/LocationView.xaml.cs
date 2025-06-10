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
        public bool ModeENCactive;
        public LocationViewModel ViewModel { get; set; }
        public LocationView()
        {
            InitializeComponent();
            initialElementCount = Elevator.Children.Count;
            ViewModel = new LocationViewModel();

            CanvasManage(0);

            /*ENC_1CF_DN(3.3);
            ENC_1CF_UP(4);
            ENC_Floor(3.5);*/

            //var heightList = new List<double> { 1.0, 2.5, 3.7, 10 };

            //ViewModel.Initialize_1CFUP(heightList);
            //ViewModel.InitializeFloorMarkers(heightList);

            DataContext = ViewModel;

        }

        public void CanvasManage( int selectedIndex)
        {

            if (Elevator != null)
            {

                ViewModel.ClearENCcanvas();
                ClearCanvasRuntimeElements();

                System.Windows.Shapes.Rectangle Mainsquare = new System.Windows.Shapes.Rectangle();
                Mainsquare.Width = 100;
                Mainsquare.Height = 400;
                Mainsquare.Stroke = Brushes.Black;
                Mainsquare.StrokeThickness = 2;

                // موقعیت دادن در Canvas
                Canvas.SetLeft(Mainsquare, 50);
                Canvas.SetTop(Mainsquare, 0);

                // اضافه کردن به Canvas
                Elevator.Children.Add(Mainsquare);


                if (selectedIndex == 0)
                {
                    ModeENCactive = false;
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
                }
                if (selectedIndex == 0)
                {
                    ModeENCactive = true;

                }

            }

        }
        public void SelectMode_SelectionChanged(object sender, EventArgs e)
        {

            int selectedIndex = SelectMode.SelectedIndex;

            CanvasManage(selectedIndex);
        }

        int initialElementCount;

        // در رویداد Loaded یا بعد از InitializeComponent
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        // برای پاک کردن فقط عناصر اضافه شده در کد
        private void ClearCanvasRuntimeElements()
        {
            // از انتها به ابتدا پاک می‌کنیم تا index به‌هم نخوره
            for (int i = Elevator.Children.Count - 1; i >= initialElementCount; i--)
            {
                Elevator.Children.RemoveAt(i);
            }
        }

        public void ENC_Floor( double Height)
        {

            Line line = new Line();
            line.X1 = 50;
            line.Y1 = 400 - ( 50 / 3 ) * Height;
            line.X2 = 180;
            line.Y2 = line.Y1;

            line.StrokeThickness = 2;
            line.Stroke = Brushes.Black;
            Elevator.Children.Add(line);


            Label label = new Label();
            label.Content = Height.ToString(); 
            label.FontSize = 12;

            Canvas.SetLeft(label, line.X2 -30); 
            Canvas.SetTop(label, line.Y2 - 20); 
            Elevator.Children.Add(label);

        }

        public void ENC_1CF_UP(double Height)
        {

            Line line = new Line();
            line.X1 = 20;
            line.Y1 = 400 - (50 / 3) * Height;
            line.X2 = 150;
            line.Y2 = line.Y1;

            line.StrokeThickness = 0.5;
            line.Stroke = Brushes.Red;
            Elevator.Children.Add(line);


            Label label = new Label();
            label.Content = "1.23";
            label.FontSize = 12;
            label.Foreground = Brushes.Red;

            Canvas.SetLeft(label, line.X1 );
            Canvas.SetTop(label, line.Y2 - 20);
            Elevator.Children.Add(label);

        }


        public void ENC_1CF_DN(double Height)
        {

            Line line = new Line();
            line.X1 = 20;
            line.Y1 = 400 - (50 / 3) * Height;
            line.X2 = 150;
            line.Y2 = line.Y1;

            line.StrokeThickness = 0.5;
            line.Stroke = Brushes.Blue;
            Elevator.Children.Add(line);


            Label label = new Label();
            label.Content = "1.23";
            label.FontSize = 12;
            label.Foreground = Brushes.Blue;

            Canvas.SetLeft(label, line.X1);
            Canvas.SetTop(label, line.Y2 -5);
            Elevator.Children.Add(label);

        }

    }
}
