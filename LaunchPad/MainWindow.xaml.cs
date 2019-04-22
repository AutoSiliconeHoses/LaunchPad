using System.Diagnostics;
using System.Windows;

namespace LaunchPad {
    public partial class MainWindow : Window {
        readonly SFF stocks = new SFF();
        readonly Zeroing zero = new Zeroing();

        public MainWindow() {
            InitializeComponent();
        }

		private void Btn_Stocks_Click(object sender, RoutedEventArgs e)
		{
            stocks.Show();
            stocks.WindowState = WindowState.Normal;
		}

        private void Btn_pricing_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@"\\DISKSTATION\Feeds\Pricing File Fetcher\StockFeed\GUI\menu.hta");
        }

        private void Btn_zeroing_Click(object sender, RoutedEventArgs e)
        {
            zero.Show();
            zero.WindowState = WindowState.Normal;
        }
    }
}
