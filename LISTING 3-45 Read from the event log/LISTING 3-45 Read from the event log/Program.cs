using System;
using System.Diagnostics;

namespace LISTING_3_45_Read_from_the_event_log
{
    class Program
    {
        static void Main(string[] args)
        {
            string categoryName = "Image Processing";

            if (!EventLog.SourceExists(categoryName))
            {
                Console.WriteLine("Event log not present");
            }
            else
            {
                EventLog imageEventLog = new EventLog();
                imageEventLog.Source = categoryName;
                foreach(EventLogEntry entry in imageEventLog.Entries)
                {
                    Console.WriteLine("Source: {0} Type: {1} Time: {2} Message: {3}",
                        entry.Source, entry.EntryType, entry.TimeWritten, entry.Message);
                }
            }

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
}
