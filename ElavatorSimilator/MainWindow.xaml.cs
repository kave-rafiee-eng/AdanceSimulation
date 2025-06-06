using LiveCharts;
using LiveCharts.Wpf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Dynamic;
using System.IO.Ports;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static ElavatorSimilator.MainWindow;

namespace ElavatorSimilator
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

            MainFrame.Navigate(new Page1());
        }

        private void MenuTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selectedItem = MenuTreeView.SelectedItem as TreeViewItem;
            if (selectedItem == null)
                return;

            string pageName = selectedItem.Tag as string;
            if (string.IsNullOrEmpty(pageName))
                return;

            switch (pageName)
            {
                /*case "Page1":
                    MainFrame.Navigate(new Page1());
                    break;
                case "Page2":
                    MainFrame.Navigate(new Page2());
                    break;
                case "SettingsPage":
                    MainFrame.Navigate(new SettingsPage());
                    break;
                case "AdvancedSettingsPage":
                    MainFrame.Navigate(new AdvancedSettingsPage());
                    break;*/
            }

            // بعد از انتخاب، منو بسته شود
            MenuToggleButton.IsChecked = false;
        }

    }



}