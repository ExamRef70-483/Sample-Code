using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LISTING_1_32_Using_async
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
            ResultTextBlock.Text = await FetchWebPage(@"http:\\hullpixelbotcontroller.azurewebsites.net");
            StatusTextBlock.Text = "Page Loaded";
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
