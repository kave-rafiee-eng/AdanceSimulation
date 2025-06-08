using ElavatorSimilator.ViewModels;
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
    /// Interaction logic for SystemPanelView.xaml
    /// </summary>
    public partial class SystemPanelView : UserControl
    {
        public SystemPanelViewModel ViewModel { get; private set; }

        public SystemPanelView()
        {
            InitializeComponent();

            ViewModel = new SystemPanelViewModel();
            DataContext = ViewModel;
        }
    }
}
