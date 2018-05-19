using System;
using System.Diagnostics;

namespace LISTING_3_38_TraceSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            TraceSwitch control = new TraceSwitch("Control", "Control the trace output");
            control.Level = TraceLevel.Warning;

            if (control.TraceError)
            {
                Console.WriteLine("An error has occurred");
            }

            Trace.WriteLineIf(control.TraceWarning, "A warning message");

        }
    }
}
