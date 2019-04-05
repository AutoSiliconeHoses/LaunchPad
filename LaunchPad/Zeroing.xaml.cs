using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace LaunchPad
{
    public partial class Zeroing : Window
    {

        private List<string> tags = new List<string>();
        private List<string> suppliers = new List<string>();

        public Zeroing()
        {
            InitializeComponent();
            Loaded += (sender, e) =>
            MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            using (var reader = new StreamReader(@"\\DISKSTATION\Feeds\SDK\sku-tag.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split('\t');

                    tags.Add(values[0]);
                    suppliers.Add(values[1]);
                }
            }
        }

        void EnterClicked(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                AddTo();
                AddBox.Text = "";
                e.Handled = true;
            }
        }

        void AddTo()
        {
            AddList.Text = AddBox.Text + Environment.NewLine + AddList.Text;
        }

        private void Btn_clear_click(object sender, RoutedEventArgs e)
        {
            AddList.Text = "";
            AddBox.Text = "";
            MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }

        private void Btn_submit_Click(object sender, RoutedEventArgs e)
        {
            string listContent = AddList.Text;
            using (StringReader reader = new StringReader(listContent))
            {
                string stock;
                while ((stock = reader.ReadLine()) != null)
                {
                    foreach (string tag in tags)
                    {
                        if (stock.ToLower().EndsWith(tag))
                        {
                            string supplier = suppliers[tags.IndexOf(tag)];
                            System.Diagnostics.Debug.WriteLine(stock + " is a " + supplier + " SKU");
                        }
                    }
                }
            }
        }
    }
}