using System;
using System.Net;

namespace LISTING_4_14_WebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            string siteText = client.DownloadString("http://www.microsoft.com");
            Console.WriteLine(siteText);

            Console.ReadKey();
        }
    }
}
