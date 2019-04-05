using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace LaunchPad
{
    public partial class Zeroing : Window
    {

        // Define tags/supplier lists
        private List<string> tags = new List<string>();
        private List<string> suppliers = new List<string>();

        public Zeroing()
        {
            InitializeComponent();
            Loaded += (sender, e) =>
            MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));

            // Build list of suppliers and their respective tags
            using (var reader = new StreamReader(@"\\DISKSTATION\Feeds\SDK\sku-tag.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    tags.Add(values[0]);
                    suppliers.Add(values[1]);
                }
            }
        }

        void EnterClicked(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                AddList.Text = AddBox.Text + Environment.NewLine + AddList.Text;
                AddBox.Text = "";
                e.Handled = true;
            }
        }

        public bool IsDirectoryEmpty(string path)
        {
            IEnumerable<string> items = Directory.EnumerateFileSystemEntries(path);
            using (IEnumerator<string> en = items.GetEnumerator())
            {
                return !en.MoveNext();
            }
        }

        private void Btn_clear_click(object sender, RoutedEventArgs e)
        {
            AddList.Text = "";
            AddBox.Text = "";
            MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }

        private void Btn_submit_Click(object sender, RoutedEventArgs e)
        {
            // Define folder and clear old files
            DirectoryInfo stockFileFolder = new DirectoryInfo(@"\\DISKSTATION\Feeds\LaunchPad\LaunchPad\Resources\StockFiles");
            FileInfo[] oldFiles = stockFileFolder.GetFiles();
            
            foreach (FileInfo file in oldFiles)
            {
                file.Delete();
            }

            // Get items from AddList
            string listContent = AddList.Text;
            using (StringReader reader = new StringReader(listContent))
            {
                string stock;
                while ((stock = reader.ReadLine()) != null)
                {
                    // Loop through tags available to find which supplier the sku belongs to
                    foreach (string tag in tags)
                    {
                        if (stock.ToLower().EndsWith(tag))
                        {
                            string supplier = suppliers[tags.IndexOf(tag)];
                            string path = @"\\DISKSTATION\Feeds\LaunchPad\LaunchPad\Resources\StockFiles\" + supplier + ".txt";
                            System.Diagnostics.Debug.WriteLine(stock + " is a " + supplier + " SKU");
                            // Create header
                            if (!File.Exists(@path))
                            {
                                File.AppendAllText(@path, "sku\tprice\tminimum-seller-allowed-price\tmaximum-seller-allowed-price\tquantity\tleadtime-to-ship\n");
                            }
                            // Add sku to upload file
                            File.AppendAllText(@path, stock + "\t\t\t\t0\t4\n");

                            // Add sku to alterations file
                            try
                            {
                                File.AppendAllText(@"\\DISKSTATION\Feeds\Stock File Fetcher\StockFeed\GUI\alterations.csv", stock + ",0\n");
                            } catch (IOException err)
                            {
                                MessageBox.Show(err.Message);
                            }
                        }
                        
                    }
                }
            }
            // Check to make sure there were valid skus
            if (IsDirectoryEmpty(@"\\DISKSTATION\Feeds\LaunchPad\LaunchPad\Resources\StockFiles\")) {
                System.Diagnostics.Debug.WriteLine("Directory empty");
            }
            else
            {
                FileInfo[] DispatchFiles = stockFileFolder.GetFiles();
                foreach (FileInfo file in DispatchFiles)
                {
                    if (chk_amazon.IsChecked == true)
                    {
                        string originalFileName = file.FullName;
                        string newFileName = @"\\STOCKMACHINE\AmazonTransport\production\outgoing\ZEROING" + file.Name;
                        File.Copy(originalFileName, newFileName);
                    }
                }
            }
        }
    }
}