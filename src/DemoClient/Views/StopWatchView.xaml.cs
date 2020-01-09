using System.Windows.Controls;
using DemoClient.ViewModels;

namespace DemoClient.Views
{
    /// <summary>
    /// Interaction logic for StopWatchView.xaml
    /// </summary>
    public partial class StopWatchView : UserControl
    {
        public StopWatchView()
        {
            InitializeComponent();
            DataContext = new StopWatchViewModel();
        }
    }
}
