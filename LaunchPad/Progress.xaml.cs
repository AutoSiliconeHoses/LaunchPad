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
using System.Windows.Shapes;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;
using System.Management.Automation;

namespace LaunchPad
{

    public partial class Progress : Window
    {
        public Progress()
        {
            InitializeComponent();
            //ProcCount();            
        }

        private void ProcCount()
        {
            using (PowerShell psinstance = PowerShell.Create())
            {
                psinstance.AddScript(@"C:\3rd\party\script.ps1");
                psinstance.Streams.Progress.DataAdded += (sender, eventargs) => {
                    PSDataCollection<ProgressRecord> progressRecords = (PSDataCollection<ProgressRecord>)sender;
                    Console.WriteLine("Progress is {0} percent complete", progressRecords[eventargs.Index].PercentComplete);
                };
                psinstance.Invoke();
            }
        }
    }
}
