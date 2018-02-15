using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LISTING_1_34_Awaiting_parallel_tasks
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

static async Task<IEnumerable<string>> FetchWebPages(string [] urls)
{
    var tasks = new List<Task<String>>();

    foreach (string url in urls)
    {
        tasks.Add(FetchWebPage(url));
    }

    return await Task.WhenAll(tasks);
}

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var pages = await FetchWebPages( new string [] { @"http://www.dotnetfoundation.org", @"http:\\microsoft.com" });

                string fullText = "";

                foreach(string page in pages)
                {
                    fullText += page;
                }
                ResultTextBlock.Text = fullText;
                StatusTextBlock.Text = "Pages loaded";

            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = ex.Message;
            }
            //catch (AggregateException aggregate)
            //{
            //    string errorMessage = "";
            //    foreach (Exception ex in aggregate.InnerExceptions)
            //        errorMessage += ex.Message;
            //    StatusTextBlock.Text = errorMessage;
            //}
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
