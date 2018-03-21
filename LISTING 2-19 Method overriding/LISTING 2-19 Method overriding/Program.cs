using System;

namespace LISTING_2_19_Method_overriding
{
    class Document
    {
        public void GetDate()
        {
            Console.WriteLine("Hello from GetDate in Document");
        }

        public virtual void DoPrint()
        {
            Console.WriteLine("Hello from DoPrint in Document");
        }
    }

    class Invoice:Document
    {
        public override void DoPrint()
        {
            Console.WriteLine("Hello from DoPrint in Invoice");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Invoice c = new Invoice();
            c.GetDate();
            c.DoPrint();

            Console.ReadKey();
        }
    }
}
