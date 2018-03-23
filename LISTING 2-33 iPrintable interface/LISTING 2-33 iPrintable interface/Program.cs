using System;

namespace LISTING_2_33_iPrintable_interface
{
    interface iPrintable
    {
        string GetPrintableText(int pageWidth, int pageHeight);
        string GetTitle();
    }
    class Report : iPrintable
    {
        public string GetPrintableText(int pageWidth, int pageHeight)
        {
            return "Report text";
        }

        public string GetTitle()
        {
            return "Report title";
        }
    }

    class ConsolePrinter
    {
        public void PrintItem(iPrintable item)
        {
            Console.WriteLine(item.GetTitle());
            Console.WriteLine(item.GetPrintableText(pageWidth: 80, pageHeight: 25));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Report myReport = new Report();
            ConsolePrinter printer = new ConsolePrinter();
            printer.PrintItem(myReport);

            Console.ReadKey();
        }
    }
}
