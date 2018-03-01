using System;

namespace LISTING_1_67_Event_based_alarm
{
    class Alarm
    {
        // Delegate for the alarm event
        public event Action OnAlarmRaised = delegate { };

        // Called to raise an alarm
        public void RaiseAlarm()
        {
            OnAlarmRaised();
        }
    }

    class Program
    {
        // Method that must run when the alarm is raised
        static void AlarmListener1()
        {
            Console.WriteLine("Alarm listener 1 called");
        }

        // Method that must run when the alarm is raised
        static void AlarmListener2()
        {
            Console.WriteLine("Alarm listener 2 called");
        }

        static void Main(string[] args)
        {
            // Create a new alarm
            Alarm alarm = new Alarm();

            alarm.RaiseAlarm();

            // Connect the two listener methods
            alarm.OnAlarmRaised += AlarmListener1;
            alarm.OnAlarmRaised += AlarmListener2;

            alarm.RaiseAlarm();

            Console.WriteLine("Alarm raised");
            Console.ReadKey();
        }
    }
}
