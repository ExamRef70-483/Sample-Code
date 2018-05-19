using System.Diagnostics;

namespace LISTING_3_34_Trace_code_tracing
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.WriteLine("Starting the program");
            Trace.TraceInformation("This is an information message");
            Trace.TraceWarning("This is a warning message");
            Trace.TraceError("This is an error message");
        }
    }
}
