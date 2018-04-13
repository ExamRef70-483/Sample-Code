using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_2_73_Music_track_formatter
{
    class MusicTrack : IFormattable
    {
        string Artist { get; set; }
        string Title { get; set; }

        // ToString that implements the formatting behavior
        public string ToString(string format, IFormatProvider formatProvider)
        {
            // Select the default behavior if no format specified
            if (string.IsNullOrWhiteSpace(format))
                format = "G";

            switch (format)
            {
                case "A": return Artist;
                case "T": return Title;

                case "G": // default format
                case "F": return Artist + " " + Title;
                default:
                    throw new FormatException("Format specifier was invalid.");
            }
        }

        // ToString that overrides the behavior in the base class
        public override string ToString()
        {
            return Artist + " " + Title;
        }

        public MusicTrack(string artist, string title)
        {
            Artist = artist;
            Title = title;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MusicTrack song = new MusicTrack(artist: "Rob Miles", title: "My Way");

            Console.WriteLine("Track: {0:F}", song);
            Console.WriteLine("Artist: {0:A}", song);
            Console.WriteLine("Title: {0:T}", song);

            Console.ReadKey();
        }
    }
}
