using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_69_EventHandler_data
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

        // Caled to raise an alarm
        public void RaiseAlarm(string location)
        {
            OnAlarmRaised(this, new AlarmEventArgs(location));
        }
    }

    class Program
    {

        // Method that must run when the alarm is raised
        static void AlarmListener1(object source, AlarmEventArgs args)
        {
            Console.WriteLine("Alarm listener 1 called");
            Console.WriteLine("Alarm in {0}", args.Location);
        }

        // Method that must run when the alarm is raised
        static void AlarmListener2(object source, AlarmEventArgs args)
        {
            Console.WriteLine("Alarm listener 2 called");
            Console.WriteLine("Alarm in {0}", args.Location);
        }

        static void Main(string[] args)
        {
            // Create a new alarm
            Alarm alarm = new Alarm();

            // Connect the two listener methods
            alarm.OnAlarmRaised += AlarmListener1;
            alarm.OnAlarmRaised += AlarmListener2;

            // raise the alarm
            alarm.RaiseAlarm("Kitchen");

            Console.WriteLine("Alarm raised");

            Console.ReadKey();
        }
    }
}
