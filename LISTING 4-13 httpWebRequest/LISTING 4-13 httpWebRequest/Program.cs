using System;
using System.IO;
using System.Net;

namespace LISTING_4_13_httpWebRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest webRequest = WebRequest.Create("http://www.microsoft.com");
            WebResponse webResponse = webRequest.GetResponse();

            using (StreamReader responseReader = new StreamReader(webResponse.GetResponseStream()))
            {
                string siteText = responseReader.ReadToEnd();
                Console.WriteLine(siteText);
            }

            Console.ReadKey();
        }
    }
}
