using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_3_40_Config_file
{
    class Program
    {
        static void Main(string[] args)
        {
            TraceSource trace = new TraceSource("configControl");

            trace.TraceEvent(TraceEventType.Start, 10000);
            trace.TraceEvent(TraceEventType.Warning, 10001);
            trace.TraceEvent(TraceEventType.Verbose, 10002, "At the end of the program");
            trace.TraceEvent(TraceEventType.Information, 10003, "Some information", new object[] { "line1", "line2" });
            trace.Flush();
            trace.Close();
        }
    }
}
