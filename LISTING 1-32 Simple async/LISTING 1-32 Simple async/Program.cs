using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_32_Simple_async
{
    class Program
    {
        static async Task<string> FetchWebPage(string url)
        {
            HttpClient _httpClient = new HttpClient();

            using (EventWaitHandle tmpEvent = new ManualResetEvent(false))
            {
                tmpEvent.WaitOne(TimeSpan.FromMilliseconds(1000));
            }

            return await _httpClient.GetStringAsync(url);
        }

        static void Main(string[] args)
        {
            string result = await FetchWebPage(@"http:\\www.robmiles.com");
            Console.WriteLine(result);
        }
    }
}
