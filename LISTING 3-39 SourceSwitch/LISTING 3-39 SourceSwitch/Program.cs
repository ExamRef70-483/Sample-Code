using System.Diagnostics;

namespace LISTING_3_39_SourceSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            TraceSource trace = new TraceSource("Tracer", SourceLevels.All);

            SourceSwitch control = new SourceSwitch("control", "Controls the tracing");
            control.Level = SourceLevels.Information;
            trace.Switch = control;

            trace.TraceEvent(TraceEventType.Start, 10000);
            trace.TraceEvent(TraceEventType.Warning, 10001);
            trace.TraceEvent(TraceEventType.Verbose, 10002, "At the end of the program");
            trace.TraceEvent(TraceEventType.Information, 10003, "Some information", new object[] { "line1", "line2" });
            trace.Flush();
            trace.Close();
        }
    }
}
