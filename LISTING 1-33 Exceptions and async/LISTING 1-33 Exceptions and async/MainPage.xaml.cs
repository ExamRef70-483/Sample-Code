using System;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LISTING_1_33_Exceptions_and_async
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        static async Task<string> FetchWebPage(string url)
        {
            HttpClient _httpClient = new HttpClient();
            return await _httpClient.GetStringAsync(url);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ResultTextBlock.Text = await FetchWebPage(@"bad name");
                StatusTextBlock.Text = "Page Loaded";
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = ex.Message;
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Another_Button_Click(object sender, RoutedEventArgs e)
        {
            StatusTextBlock.Text = "Another button";
        }
    }
}
