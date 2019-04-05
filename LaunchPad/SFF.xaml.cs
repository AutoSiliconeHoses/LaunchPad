using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Net.Http;

namespace LaunchPad
{
    public partial class SFF : Window {
        public static int count;
        private static readonly HttpClient client = new HttpClient();

        public SFF() {
            InitializeComponent();
            txtblk_history.Text = File.ReadLines("log.txt").Last();
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
            txtblk_history.Text = File.ReadLines("log.txt").Last();
        }

        private void Btn_Run_Click(object sender, RoutedEventArgs e) {
            string arguments = " ";
            int ship = 4;
            count = 0;

            //Shipping Argument
            ship = (int)sli_ship.Value;
            arguments += ship.ToString() + " ";

            //Supplier Arguments
            foreach (Control chk in stck_checks.Children)
            {
                if(chk is CheckBox) {
                    if(((CheckBox)chk).IsChecked == true) {
                        arguments += chk.Name.Replace("chk_","") + "- ";
                        count++;
                    }
                }
            }

            //Open file after completion
            if (chk_open.IsChecked.Value == true) { arguments = arguments + "op- "; }

            //Auto-Upload
            if (chk_upload.IsChecked.Value == true) { arguments = arguments + "up- "; }

            //Check for empty list
            if (count == 0) {
                MessageBox.Show("No Suppliers Selected");
                return;
            }

            //MessageBox.Show(arguments);

            //Start Powershell
            Process.Start("PowerShell.exe", @"-ExecutionPolicy Bypass & '\\DISKSTATION\Feeds\Stock File Fetcher\StockFeed\GUI\runall.ps1' " + arguments);

            //Update Log
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string timeString = DateTime.Now.ToString("d/M/yyyy htt");
            HistoryWrite(Environment.NewLine + "Last run by " + userName + " @ " + timeString);
            txtblk_history.Text = File.ReadLines("log.txt").Last();
        }
    }
}
