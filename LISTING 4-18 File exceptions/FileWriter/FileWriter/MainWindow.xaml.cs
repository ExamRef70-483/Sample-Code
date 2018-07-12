using System;
using System.IO;
using System.Threading.Tasks;
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

        // Correct version that returns a task
        async Task WriteBytesAsyncTask(string filename, byte [] items)
        {
            using (FileStream outStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write))
            {
                await outStream.WriteAsync(items, 0, items.Length);
            }
        }

        private async void StartTaskButton_Click(object sender, RoutedEventArgs e)
        {
            byte[] data = new byte[100];

            try
            {
                await WriteBytesAsyncTask("demo:.dat", data); // note that the filename is invalid
            }
            catch (Exception writeException)
            {
                MessageBox.Show(writeException.Message, "File write failed");
            }
        }

        // Incorrect version that is void
        async void WriteBytesAsyncVoid(string filename, byte[] items)
        {
            using (FileStream outStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write))
            {
                await outStream.WriteAsync(items, 0, items.Length);
            }
        }

        private void StartVoidButton_Click(object sender, RoutedEventArgs e)
        {
            byte[] data = new byte[100];

            try
            {
                WriteBytesAsyncVoid("demo:.dat", data);  // note that the filename is invalid
            }
            catch (Exception writeException)
            {
                MessageBox.Show(writeException.Message, "File write failed");
            }
        }

    }
}
