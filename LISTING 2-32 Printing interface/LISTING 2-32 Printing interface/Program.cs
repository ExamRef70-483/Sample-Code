using System;

namespace LISTING_2_32_Printing_interface
{

    interface iPrintable
    {
        string GetPrintableText(int pageWidth, int pageHeight);
        string GetTitle();
    }

    interface iDisplay
    {
        string GetTitle();
    }

    class Report : iPrintable, iDisplay
    {
        string iPrintable.GetPrintableText(int pageWidth, int pageHeight)
        {
            return "Report text to be printed";
        }

        string iPrintable.GetTitle()
        {
            return "Report title to be printed";
        }

        string iDisplay.GetTitle()
        {
            return "Report title to be displayed";
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

            iPrintable printItem = myReport;
            Console.WriteLine(printItem.GetTitle());
            Console.WriteLine(printItem.GetPrintableText(pageWidth:80, pageHeight:23));
            Console.ReadKey();
        }
    }
}
