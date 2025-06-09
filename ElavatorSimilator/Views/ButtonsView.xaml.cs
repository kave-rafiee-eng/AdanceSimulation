using ElavatorSimilator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
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
    /// Interaction logic for ButtonsView.xaml
    /// </summary>
    public partial class ButtonsView : UserControl
    {
        public ButtonsMainViewModel ViewModel { get; private set; }

        public ButtonsView()
        {
            InitializeComponent();

            ViewModel = new ButtonsMainViewModel();
            DataContext = ViewModel;
        }

        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // فقط اگر ورودی عدد بود، اجازه بده
           // e.Handled = !IsTextNumeric(e.Text);
        }

        private void CostomCall(object sender, RoutedEventArgs e)
        {
            int from = From.SelectedIndex;

            int floor = 0;
            if (int.TryParse(Floor.Text, out floor))
            {
            }
            else
            {
                MessageBox.Show("لطفاً یک عدد معتبر وارد کنید.");
            }

            int direction = 0;
            if (sender is Button button && button.Tag is string tagStr)
            {
                // اگر Tag عددی باشه
                if (int.TryParse(tagStr, out direction))
                {
                    // از tagValue استفاده کن
                    Console.WriteLine("Tag value: " + direction);
                }
            }

            int door1 = Door1.SelectedIndex;
            int door2 = Door2.SelectedIndex;
            int door3 = Door3.SelectedIndex;

            var jsonObject = new JsonObject
            {
                ["from"] = from,
                ["floor"] = floor,
                ["door1"] = door1,
                ["door2"] = door2,
                ["door3"] = door3,
                ["dir"] = direction,
            };

            string json = jsonObject.ToJsonString();


            var serialControl = SerialSelector.Instance;
            if (serialControl != null)
            {
                serialControl.Send(json);
            }
        }

    }
}
