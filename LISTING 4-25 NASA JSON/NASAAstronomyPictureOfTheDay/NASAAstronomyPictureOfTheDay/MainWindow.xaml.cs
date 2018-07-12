using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace NASAAstronomyPictureOfTheDay
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

        public async Task displayUrl(string url)
        {
            WebClient c = new WebClient();
            byte[] imageBytes = await c.DownloadDataTaskAsync(url);
            MemoryStream imageMemoryStream = new MemoryStream(imageBytes);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = imageMemoryStream;
            bitmapImage.EndInit();
            NASAImage.Source = bitmapImage;
        }

        public class ImageOfDay
        {
            public string date { get; set; }
            public string explanation { get; set; }
            public string hdurl { get; set; }
            public string media_type { get; set; }
            public string service_version { get; set; }
            public string title { get; set; }
            public string url { get; set; }
        }

        async Task<ImageOfDay> GetImageOfDay(string imageURL)
        {
            string NASAJson = await readWebpage(imageURL);

            ImageOfDay result = JsonConvert.DeserializeObject< ImageOfDay>(NASAJson);

            return result;
        }

        private async void LoadButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                ImageOfDay imageOfDay = await GetImageOfDay("https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY&date=2018-05-29");

                if (imageOfDay.media_type != "image")
                {
                    MessageBox.Show("It is not an image today");
                    return;
                }

                DescriptionTextBlock.Text = imageOfDay.explanation;

                await displayUrl(imageOfDay.url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fetch failed: {0}", ex.Message);
            }
        }
    }
}
