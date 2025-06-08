using ElavatorSimulator.ViewModels;
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
    /// Interaction logic for CallsDataGrid.xaml
    /// </summary>
    public partial class CallsDataGrid : UserControl
    {
        public CallsViewModel ViewModel { get; private set; }

        public CallsDataGrid()
        {
            InitializeComponent();
            ViewModel = new CallsViewModel();
            DataContext = ViewModel;
        }
    }

}
