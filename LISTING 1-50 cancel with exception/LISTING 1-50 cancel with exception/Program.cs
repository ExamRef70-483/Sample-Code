using System;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_50_cancel_with_exception
{
    class Program
    {
        static void Clock(CancellationToken cancellationToken)
        {
            int tickCount = 0;

            while (!cancellationToken.IsCancellationRequested &&
                   tickCount < 20)
            {
                tickCount++;
                Console.WriteLine("Tick");
                Thread.Sleep(500);
            }

            cancellationToken.ThrowIfCancellationRequested();
        }

        static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            Task clock = Task.Run(() => Clock(cancellationTokenSource.Token));

            Console.WriteLine("Press any key to stop the clock");

            Console.ReadKey();

            if (clock.IsCompleted)
            {
                Console.WriteLine("Clock task completed");
            }
            else
            {
                try
                {
                    cancellationTokenSource.Cancel();
                    clock.Wait();
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine("Clock stopped: {0}", ex.InnerExceptions[0].ToString());
                }
            }
            Console.ReadKey();
        }
    }
}
