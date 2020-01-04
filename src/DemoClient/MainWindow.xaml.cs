using System;
using System.Configuration;
using System.Threading;
using System.Windows;

namespace DemoClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var key = ConfigurationManager.AppSettings["ApiKey"];
            var client = new LogMyTime.LogMyTimeClient(key);

            try
            {
                var result = await client.CurrentStopWatch(CancellationToken.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
