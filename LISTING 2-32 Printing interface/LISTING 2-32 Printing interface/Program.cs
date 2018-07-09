using System;

namespace LISTING_2_32_Printing_interface
{

    interface IPrintable
    {
        string GetPrintableText(int pageWidth, int pageHeight);
        string GetTitle();
    }

    interface IDisplay
    {
        string GetTitle();
    }

    class Report : IPrintable, IDisplay
    {
        string IPrintable.GetPrintableText(int pageWidth, int pageHeight)
        {
            return "Report text to be printed";
        }

        string IPrintable.GetTitle()
        {
            return "Report title to be printed";
        }

        string IDisplay.GetTitle()
        {
            return "Report title to be displayed";
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

            IPrintable printItem = myReport;
            Console.WriteLine(printItem.GetTitle());
            Console.WriteLine(printItem.GetPrintableText(pageWidth:80, pageHeight:23));
            Console.ReadKey();
        }
    }
}
