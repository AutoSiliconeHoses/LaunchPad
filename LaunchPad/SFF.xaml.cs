using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Shapes;
using System.Xml;
using System.Management.Automation;
using System.Net.Http;

namespace LaunchPad {
    public partial class SFF : Window {
        public static int count;
        private static readonly HttpClient client = new HttpClient();

        public SFF() {
            InitializeComponent();
            lbl_history.Content = File.ReadLines("log.txt").Last();
        }

        private void Checker (bool opt) {
			foreach (Control chk in stck_checks.Children) {
				if (chk.GetType() == typeof(CheckBox)) {
					((CheckBox)chk).IsChecked = opt;
				}
			}
		}

        private void HistoryWrite (string textToAdd) {
            string fileName = "log.txt";

            using (StreamWriter writer = new StreamWriter(fileName, true)) {
                writer.Write(textToAdd);
            }
        }

        private void Btn_chkAll_Click(object sender, RoutedEventArgs e) {
			Checker(true);
        }

		private void Btn_unchkAll_Click(object sender, RoutedEventArgs e) {
			Checker(false);
		}

        private void Btn_openSite_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://sellercentral.amazon.co.uk/listing/upload?_encoding=UTF8&ref=xx_download_apvu_xx");
        }

        private void Btn_openFolder_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@"\\DISKSTATION\Feeds\Stock File Fetcher\Upload");
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            lbl_history.Content = File.ReadLines("log.txt").Last();
        }

        private void Btn_Run_Click(object sender, RoutedEventArgs e) {
            string arguments = " ";
            int ship = 4;
            count = 0;

            //Shipping Argument
            ship = (int)sli_ship.Value;
            arguments += ship.ToString() + " ";

            //Supplier Arguments
            if (chk_dc.IsChecked.Value == true)
            {
                arguments += "dc- ";
                count++;
            }
            if (chk_dp.IsChecked.Value == true)
            {
                arguments += "dp- ";
                count++;
            }
            if (chk_fi.IsChecked.Value == true)
            {
                arguments += "fi- ";
                count++;
            }
            if (chk_fps.IsChecked.Value == true)
            {
                arguments += "fps- ";
                count++;
            }
            if (chk_hh.IsChecked.Value == true)
            {
                arguments += "hh- ";
                count++;
            }
            if (chk_kn.IsChecked.Value == true)
            {
                arguments += "kn- ";
                count++;
            }
            if (chk_kb.IsChecked.Value == true)
            {
                arguments += "kb- ";
                count++;
            }
            if (chk_rp.IsChecked.Value == true)
            {
                arguments += "rp- ";
                count++;
            }
            if (chk_sx.IsChecked.Value == true) {
                arguments += "sx- ";
                count++;
            }
            if (chk_sxp.IsChecked.Value == true) {
                arguments += "sxp- ";
                count++;
            }
            if (chk_tl.IsChecked.Value == true)
            {
                arguments += "tl- ";
                count++;
            }
            if (chk_tb.IsChecked.Value == true) {
                arguments += "tb- ";
                count++;
            }
            if (chk_tbp.IsChecked.Value == true)
            {
                arguments += "tbp- ";
                count++;
            }
            if (chk_ts.IsChecked.Value == true) {
                arguments += "ts- ";
                count++;
            }
            if (chk_vo.IsChecked.Value == true) {
                arguments += "vo- ";
                count++;
            }
            if (chk_ww.IsChecked.Value == true)
            {
                arguments += "ww- ";
                count++;
            }

            //Open file after completion
            if (chk_open.IsChecked.Value == true) {
                arguments = arguments + "op-";
            }

            //Auto-Upload
            if (chk_upload.IsChecked.Value == true)
            {
                arguments = arguments + "up-";
            }

            if (count == 0)
            {
                System.Windows.Forms.MessageBox.Show("No Suppliers Selected");
                return;
            }

            //Start Powershell
            Process.Start("PowerShell.exe", @"-ExecutionPolicy Bypass & '\\DISKSTATION\Feeds\Stock File Fetcher\StockFeed\GUI\runall.ps1'" + arguments);

            //Update Log
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string timeString = DateTime.Now.ToString("d/M/yyyy htt");
            HistoryWrite(Environment.NewLine + "Last run by " + userName + " @ " + timeString);
            lbl_history.Content = File.ReadLines("log.txt").Last();
        }

        private void Btn_test_Click(object sender, RoutedEventArgs e)
        {
            Progress bar = new Progress();
            bar.Show();
        }
    }
}
