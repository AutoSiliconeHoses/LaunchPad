﻿using System;
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

namespace LaunchPad
{

    public partial class Progress : Window
    {
        private void ProcCount()
        {
            Process[] processlist = Process.GetProcesses();
            int size = processlist.Length;
            prg_bar.Value = size/count;
            return;
        }
        public Progress()
        {
            InitializeComponent();
            //ProcCount();            
        }

        
    }
}
