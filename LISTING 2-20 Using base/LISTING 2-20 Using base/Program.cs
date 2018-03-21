using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_2_20_Using_base
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

    class Invoice : Document
    {
        public override void DoPrint()
        {
            Console.WriteLine("Hello from DoPrint in Invoice");
        }
    }

class PrePaidInvoice: Invoice
{
    public override void DoPrint()
    {
        base.DoPrint();
        Console.WriteLine("Hello from DoPrint in PrePaidInvoice");
    }
}

    class Program
    {
        static void Main(string[] args)
        {
PrePaidInvoice p = new PrePaidInvoice();
p.GetDate();
p.DoPrint();

            Console.ReadKey();
        }
    }
}
