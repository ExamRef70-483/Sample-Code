using System;

namespace LISTING_2_19_Method_overriding
{
    class Document
    {
        // All documents have the same GetDate behavior so
        // this method will not be overridden
        public void GetDate()
        {
            Console.WriteLine("Hello from GetDate in Document");
        }

        // A document may have its own DoPrint behavior so
        // this method is virtual so it can be overriden
        public virtual void DoPrint()
        {
            Console.WriteLine("Hello from DoPrint in Document");
        }
    }

    // The Invoice class derives from the Document class
    class Invoice:Document
    {
        // Override the DoPrint method in the base class
        // to provide custom printing behaviour for an Invoice
        public override void DoPrint()
        {
            Console.WriteLine("Hello from DoPrint in Invoice");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create an Invoice
            Invoice c = new Invoice();
            // This will run the SetDate method from Document
            c.GetDate();
            // This will run the DoPrint method from Invoice
            c.DoPrint();

            Console.ReadKey();
        }
    }
}
