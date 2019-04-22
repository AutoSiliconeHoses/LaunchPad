using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace LaunchPad
{
    public partial class Zeroing : Window
    {

        // Define tags/supplier lists
        private readonly List<string> tags = new List<string>();
        private readonly List<string> suppliers = new List<string>();

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

        string RemoveWhitespace(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }
            string lineSeparator = ((char)0x2028).ToString();
            string paragraphSeparator = ((char)0x2029).ToString();

            return value.Replace("\r\n", string.Empty)
                        .Replace("\n", string.Empty)
                        .Replace("\r", string.Empty)
                        .Replace(" ", string.Empty)
                        .Replace(lineSeparator, string.Empty)
                        .Replace(paragraphSeparator, string.Empty);
        }

        void EnterClicked(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                using (StringReader reader = new StringReader(AddBox.Text))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string cleanLine = RemoveWhitespace(line);
                        AddList.Text += cleanLine + Environment.NewLine;
                        scrl_box.ScrollToBottom();
                    }
                }
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
                            Debug.WriteLine(stock + " is a " + supplier + " SKU");
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
                                File.AppendAllText(@"\\DISKSTATION\Feeds\Stock File Fetcher\StockFeed\GUI\alterations.csv", stock.ToUpper() + ",0\n");
                            }
                            catch (IOException err)
                            {
                                MessageBox.Show(err.Message);
                            }
                        }

                    }
                }
            }
            // Check to make sure there were valid skus
            if (IsDirectoryEmpty(@"\\DISKSTATION\Feeds\LaunchPad\LaunchPad\Resources\StockFiles\"))
            {
                MessageBox.Show("No valid skus found.");
            }
            else
            {
                FileInfo[] DispatchFiles = stockFileFolder.GetFiles();
                foreach (FileInfo file in DispatchFiles)
                {
                    if (chk_amazon.IsChecked == true)
                    {
                        string originalFileName = file.FullName;
                        string newFileName = @"\\STOCKMACHINE\AmazonTransport\production\outgoing\ZEROING-" + file.Name;
                        try
                        {
                            File.Copy(originalFileName, newFileName);
                        }
                        catch
                        {
                            MessageBox.Show("You don't have permission to move the files to the Stock Machine");
                        }

                    }
                    if (chk_ebay.IsChecked == true)
                    {
                        string zeroFolder = @"\\DISKSTATION\Feeds\Stock File Fetcher\StockFeed\eBay\Stock\Zeroing";
                        Directory.CreateDirectory(zeroFolder);

                        string originalFileName = file.FullName;
                        string newFileName = zeroFolder + "\\" + file.Name;
                        File.Copy(originalFileName, newFileName);

                        Process.Start("PowerShell.exe", @"-ExecutionPolicy Bypass & '\\DISKSTATION\Feeds\Stock File Fetcher\StockFeed\eBay\eBayZero.ps1'");
                    }
                }
                MessageBox.Show("Process complete.");
            }
        }
    }
}