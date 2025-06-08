using ElavatorSimilator.Views;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace ElavatorSimilator
{
    /// <summary>
    /// Interaction logic for Location.xaml
    /// </summary>
    public partial class PageLocation : Page
    {
        //private Location location;

        private double floor = 2;
        private double Infloor = 1;

        private SimpleData simpleData;

        public PageLocation()
        {
            InitializeComponent();

            var serialControl = SerialSelector.Instance;
            if (serialControl != null)
            {
                // مثلا استفاده از portManager
                var manager = serialControl.portManager;
                // یا subscribe به DataReceived
                serialControl.DataReceived += OnDataReceived;
            }


            /**location = new Location();

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

            DataContext = location;*/

        }


        private void OnDataReceived(string data)
        {

            if (TryParseJson(data, out JToken token))
            {
                token = JToken.Parse(data);
                if (token["calls"] != null)
                {

                }
                else if (token["data1"] != null)
                {
                    simpleData = token.ToObject<SimpleData>();

                    var serialControl = SerialSelector.Instance;
                    serialControl.portManager.ReciveCounter++;

                    floor = simpleData.data1;
                    Infloor = simpleData.data2;
                    //location.Y = (floor * 50 + (Infloor - 1) * 12.5);


                }

            }

        }

        private bool TryParseJson(string data, out JToken token)
        {
            try
            {
                token = JToken.Parse(data);
                return true;
            }
            catch
            {
                token = null;
                return false;

            }
        }

        private class SimpleData
        {
            public int data1 { get; set; }
            public int data2 { get; set; }
            public int data3 { get; set; }
            public int data4 { get; set; }
            public int data5 { get; set; }
            public int data6 { get; set; }
            public string name1 { get; set; }
            public int value1 { get; set; }
            public string name2 { get; set; }
            public int value2 { get; set; }
            public string name3 { get; set; }
            public int value3 { get; set; }
        }

    }
}
