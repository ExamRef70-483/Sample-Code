using System;

namespace LISTING_2_33_iPrintable_interface
{
    interface IPrintable
    {
        string GetPrintableText(int pageWidth, int pageHeight);
        string GetTitle();
    }
    class Report : IPrintable
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
        public void PrintItem(IPrintable item)
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
