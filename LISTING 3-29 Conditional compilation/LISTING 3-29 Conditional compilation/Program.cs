#
#define DIAGNOSTICS

using System;

namespace LISTING_3_29_Conditional_compilation
{
    public class MusicTrack
    {
        public static bool DebugMode = false;

        public string Artist { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }

        // ToString that overrides the behavior in the base class
        public override string ToString()
        {
            return Artist + " " + Title + " " + Length.ToString() + " seconds long";
        }

        public MusicTrack(string artist, string title, int length)
        {
            Artist = artist;
            Title = title;
            Length = length;

#if TERSE
            Console.WriteLine("Hello");
#elif NORMAL
            Console.WriteLine("Hello Rob");
#elif CHATTY
            Console.WriteLine("Hello Rob. And how are you");
#endif


#if DIAGNOSTICS && DEBUG
            Console.WriteLine("Music track created: {0}", this.ToString());
#else

#endif
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MusicTrack.DebugMode = true;

            MusicTrack m = new MusicTrack(artist: "Rob Miles", title: "My Way", length: 150);
            Console.ReadKey();
        }
    }
}
