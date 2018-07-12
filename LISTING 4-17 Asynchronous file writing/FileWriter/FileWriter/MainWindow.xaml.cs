using System;
using System.IO;
using System.Windows;

namespace FileWriter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        async void WriteBytesAsync(string filename, byte[] items)
        {
            using (FileStream outStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write))
            {
                await outStream.WriteAsync(items, 0, items.Length);
            }
        }

        void WriteBytesSync(string filename, byte[] items)
        {
            using (FileStream outStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write))
            {
                outStream.Write(items, 0, items.Length);
            }
        }

        private async void StartAsyncButton_Click(object sender, RoutedEventArgs e)
        {
            long noOfValues = long.Parse(NumberOfValuesTextBox.Text);

            byte[] data = new byte[noOfValues];

            try
            {
                WriteBytesAsync("demo.dat", data);
            }
            catch (Exception writeException)
            {
                MessageBox.Show(writeException.Message, "File write failed");
            }
        }

        private void StartSyncButton_Click(object sender, RoutedEventArgs e)
        {
            long noOfValues = long.Parse(NumberOfValuesTextBox.Text);

            byte[] data = new byte[noOfValues];

            WriteBytesSync("demo.dat", data);
        }

        private void TimeButton_Click(object sender, RoutedEventArgs e)
        {
            TimeTextBlock.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
