using System;
using System.Diagnostics;

namespace LISTING_3_36_Trace_listener
{
    class Program
    {
        static void Main(string[] args)
        {
            TraceListener consoleListener = new ConsoleTraceListener();
            Trace.Listeners.Add(consoleListener);
            Trace.WriteLine("Starting the program");
            Trace.Indent();
            Trace.WriteLine("Inside a function");
            Trace.Unindent();
            Trace.WriteLine("Outside a function");

            Trace.TraceInformation("This is an information message");
            Trace.TraceWarning("This is a warning message");
            Trace.TraceError("This is an error message");

            Console.ReadKey();
        }
    }
}
