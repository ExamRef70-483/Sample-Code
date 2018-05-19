using System;
using System.Diagnostics;

namespace LISTING_3_46_Bind_to_the_event_log
{
    class Program
    {
        static void Main(string[] args)
        {
            string categoryName = "Image Processing";

            EventLog imageEventLog = new EventLog();
            imageEventLog.Source = categoryName;
            imageEventLog.EntryWritten += ImageEventLog_EntryWritten;
            imageEventLog.EnableRaisingEvents = true;

            Console.WriteLine("Listening for log events");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void ImageEventLog_EntryWritten(object sender, EntryWrittenEventArgs e)
        {
            Console.WriteLine(e.Entry.Message);
        }
    }
}
