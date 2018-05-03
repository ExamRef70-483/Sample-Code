#
using System;
using MusicStorage;

namespace LISTING_3_26_Strong_names
{
    class Program
    {
        static void Main(string[] args)
        {
            string assemblyName = typeof(MusicTrack).Assembly.FullName;
            Console.WriteLine(assemblyName);
            Console.ReadKey();
        }
    }
}
