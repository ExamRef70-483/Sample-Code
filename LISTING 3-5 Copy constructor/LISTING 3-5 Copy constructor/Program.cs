using System;

namespace LISTING_3_5_Copy_constructor
{
    class MusicTrack
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }

        public MusicTrack(MusicTrack source)
        {
            Artist = source.Artist;
            Title = source.Title;
            Length = source.Length;

        }

        public MusicTrack(string artist, string title, int length)
        {
            Artist = artist;
            Title = title;
            Length = length;
        }
    }

    class Program
    {
        // Naughty PrintTrack method that changes the Artist property of the 
        // track being printed. 
        static void PrintTrack(MusicTrack track)
        {
            track.Artist = "Fred Bloggs";
        }

        static void Main(string[] args)
        {
            // Create a new music track instance

            MusicTrack track = new MusicTrack(artist: "Rob Miles", title: "My Way", length: 120);

            // Use the copy constructor to send a copy of the track to be printed
            // Changes made by the PrintTrack method will have no effect on the original
            PrintTrack(new MusicTrack(track));

            Console.WriteLine(track.Artist);
            Console.ReadKey();
        }
    }
}
