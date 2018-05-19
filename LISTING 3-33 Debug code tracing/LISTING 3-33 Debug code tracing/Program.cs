using System.Diagnostics;

namespace LISTING_3_33_Debug_code_tracing
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("Starting the program");
            Debug.Indent();
            Debug.WriteLine("Inside a function");
            Debug.Unindent();
            Debug.WriteLine("Outside a function");

            string customerName = "Rob";
            Debug.WriteLineIf(string.IsNullOrEmpty(customerName), "The name is empty");
        }
    }
}
