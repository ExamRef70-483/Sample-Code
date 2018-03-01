using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_1_70_Aggregating_exceptions
{
    class AlarmEventArgs : EventArgs
    {
        public string Location { get; set; }

        public AlarmEventArgs(string location)
        {
            Location = location;
        }
    }

    class Alarm
    {
        // Delegate for the alarm event
        public event EventHandler<AlarmEventArgs> OnAlarmRaised = delegate { };

        // Called to raise an alarm
        public void RaiseAlarm(string location)
        {
            List<Exception> exceptionList = new List<Exception>();

            foreach (Delegate handler in OnAlarmRaised.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, new AlarmEventArgs(location));
                }
                catch (TargetInvocationException e)
                {
                    exceptionList.Add(e.InnerException);
                }
            }
            if (exceptionList.Count > 0)
                throw new AggregateException(exceptionList);
        }
    }

    class Program
    {

        // Method that must run when the alarm is raised
        static void AlarmListener1(object source, AlarmEventArgs args)
        {
            Console.WriteLine("Alarm listener 1 called");
            Console.WriteLine("Alarm in {0}", args.Location);
            throw new Exception("Bang");
        }

        // Method that must run when the alarm is raised
        static void AlarmListener2(object source, AlarmEventArgs args)
        {
            Console.WriteLine("Alarm listener 2 called");
            Console.WriteLine("Alarm in {0}", args.Location);
            throw new Exception("Boom");
        }

        static void Main(string[] args)
        {
            // Create a new alarm
            Alarm alarm = new Alarm();

            // Connect the two listener methods
            alarm.OnAlarmRaised += AlarmListener1;
            alarm.OnAlarmRaised += AlarmListener2;

            // raise the alarm
            try
            {
                alarm.RaiseAlarm("Kitchen");
            }
            catch (AggregateException agg)
            {
                foreach (Exception ex in agg.InnerExceptions)
                    Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Alarm raised");

            Console.ReadKey();
        }
    }
}
