using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace LaunchPad {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

		private void Btn_Stocks_Click(object sender, RoutedEventArgs e)
		{
			SFF stocks = new SFF();
			stocks.Show();
		}

        private void Btn_pricing_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("\\\\DISKSTATION\\Feeds\\Pricing File Fetcher\\StockFeed\\GUI\\menu.hta");
        }

        private void Btn_zeroing_Click(object sender, RoutedEventArgs e)
        {
            Zeroing zero = new Zeroing();
            zero.Show();
        }
    }
}
