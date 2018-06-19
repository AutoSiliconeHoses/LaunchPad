using System.ComponentModel;
using System.Threading;
using System.Windows;


namespace LaunchPad
{
    public partial class Progress : Window
    {
        private int Items()
        {
            int fileCount = System.IO.Directory.GetFiles(@"\\DISKSTATION\Feeds\Stock File Fetcher\Upload").Length;
            //MessageBox.Show(fileCount.ToString());
            //MessageBox.Show(SFF.count.ToString());
            double percent = ((double)fileCount / (double)SFF.count) * 100;
            int percentage = (int)percent;
            System.Diagnostics.Debug.WriteLine(percentage.ToString());
            return percentage;
        }

        private void Counter_DoWork(object sender, DoWorkEventArgs e)
        {
            // run all background tasks here
        }

        private void Counter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //update ui once worker complete his work
        }

        public Progress()
        {
            InitializeComponent();

            //private BackgroundWorker worker = new BackgroundWorker();

            //SFF.count = 5;
            //while (Items() != 100)
            //{
            //    Thread.Sleep(500);
            //    prg_bar.Value = Items();
            //}
            //this.Close();
        }
    }
}
