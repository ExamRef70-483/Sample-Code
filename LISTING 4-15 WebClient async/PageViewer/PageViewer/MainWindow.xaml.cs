using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PageViewer
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

        async Task<string> readWebpage(string uri)
        {
            WebClient client = new WebClient();
            return await client.DownloadStringTaskAsync(uri);
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            string webText = await readWebpage(PageUriTextBox.Text);

            ResultTextBlock.Text = webText;
        }
    }
}
