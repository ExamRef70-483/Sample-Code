using System;
using MusicStorage;

namespace LISTING_3_25_Assemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            MusicTrack m = new MusicTrack(artist: "Rob Miles", title: "My Way", length: 150);
            Console.WriteLine(m);
            Console.ReadKey();
        }
    }
}
