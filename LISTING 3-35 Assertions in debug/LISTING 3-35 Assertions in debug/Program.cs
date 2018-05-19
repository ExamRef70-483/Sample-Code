using System.Diagnostics;

namespace LISTING_3_35_Assertions_in_debug
{
    class Program
    {
        static void Main(string[] args)
        {
            string customerName = "Rob";

            Debug.Assert(!string.IsNullOrWhiteSpace(customerName));

            customerName = "";

            Debug.Assert(!string.IsNullOrWhiteSpace(customerName));
        }
    }
}
