using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_13_Task_Factory

// This is a bonus example program that shows how to use the TaskFactory object
// Normally you'd use Task.Factory.StartNew or the thread pool in preference
// Task.Factory.StartNew is used in Listing 1-17 and the thread pool is described in Listing 1-28

// The example creates a task factory and uses it to create a task that runs until it completes.
// If you press enter before five seconds have elapsed the task is terminated and the program ends. 

{
    class Program
    {
        static void Main(string[] args)
        {
            // Used to allow us to control the an executing task
            CancellationTokenSource cts = new CancellationTokenSource();

            // Create the task factory

            TaskFactory factory = new TaskFactory(
               cts.Token,
               TaskCreationOptions.PreferFairness,
               TaskContinuationOptions.ExecuteSynchronously,
               null); // custom scheduler could go here. 

            // Use the factory to create a new Task running do work
            Task t2 = factory.StartNew(() => DoWork());

            Console.WriteLine("Press enter to dispose of the task");
            Console.ReadLine();

            Console.WriteLine("Disposing of the task");

            // Cancel the task
            // dispose of the task using the cancellation token
            cts.Dispose();

        }

        static void DoWork()
        {
            Console.WriteLine("Doing work..");

            int total = 0;

            for (int i = 0; i < 5000; i++)
            {
                Thread.Sleep(1);
                total += i;
            }

            Console.WriteLine("Result: " + total);
        }
    }
}
