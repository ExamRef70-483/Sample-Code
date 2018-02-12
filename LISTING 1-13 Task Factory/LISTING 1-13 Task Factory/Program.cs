using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LISTING_1_13_Task_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationToken cancl = new CancellationToken();

            TaskFactory factory = new TaskFactory(TaskCreationOptions.AttachedToParent,
                TaskContinuationOptions.None);
                cancl,
                TaskContinuationOptions.AttachedToParent,
                TaskContinuationOptions.LongRunning, null);

            t.StartNew()
            t<int>.StartNew()
        }
    }
}
