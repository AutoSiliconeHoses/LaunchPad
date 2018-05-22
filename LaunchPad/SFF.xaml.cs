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

namespace LaunchPad {
    public partial class SFF : Window {
        public SFF() {
            InitializeComponent();
        }

        private void Checker (bool opt) {
			foreach (Control chk in stck_checks.Children) {
				if (chk.GetType() == typeof(CheckBox)) {
					((CheckBox)chk).IsChecked = opt;
				}
			}
		}

        private void Btn_chkAll_Click(object sender, RoutedEventArgs e) {
			Checker(true);
        }

		private void Btn_unchkAll_Click(object sender, RoutedEventArgs e)
		{
			Checker(false);
		}

		private void Btn_Run_Click(object sender, RoutedEventArgs e) {
            string arguments = " ";

            if (chk_sx.IsChecked.Value == true) {
                arguments += "sx ";
            }
            if (chk_tb.IsChecked.Value == true) {
                arguments += "tb ";
            }
            if (chk_hh.IsChecked.Value == true) {
                arguments += "hh ";
            }
            if (chk_ts.IsChecked.Value == true) {
                arguments += "ts ";
            }
            if (chk_dp.IsChecked.Value == true) {
                arguments += "dp ";
            }
            if (chk_vo.IsChecked.Value == true) {
                arguments += "vo ";
            }
            if (chk_tl.IsChecked.Value == true) {
                arguments += "tl ";
            }
            if (chk_kb.IsChecked.Value == true) {
                arguments += "kb ";
            }
            if (chk_vo.IsChecked.Value == true) {
                arguments += "dc ";
            }
            if (chk_kn.IsChecked.Value == true) {
                arguments += "kn ";
            }

            //Open file after completion
			if (chk_open.IsChecked.Value == true) {
				arguments = arguments + "op";
			}

			Process.Start("Powershell.exe", @"& '\\DISKSTATION\Feeds\Stock File Fetcher\StockFeed\GUI\runall.ps1'" + arguments);

            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string timeString = DateTime.Now.ToString("h:mm:ss tt");

            lbl_history.Content = "Last run by " + userName + " @ " + timeString;
        }
    }
}
