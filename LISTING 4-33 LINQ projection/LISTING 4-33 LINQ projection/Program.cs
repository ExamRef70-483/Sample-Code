using System;
using System.Collections.Generic;
using System.Linq;

namespace LISTING_4_33_LINQ_projection
{
    class Artist
    {
        public string Name { get; set; }
    }

    class MusicTrack
    {
        public Artist Artist { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
    }

    class TrackDetails
    {
        public string ArtistName;
        public string Title;
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] artistNames = new string[] { "Rob Miles", "Fred Bloggs", "The Bloggs Singers", "Immy Brown" };
            string[] titleNames = new string[] { "My Way", "Your Way", "His Way", "Her Way", "Milky Way" };

            List<Artist> artists = new List<Artist>();
            List<MusicTrack> musicTracks = new List<MusicTrack>();

            Random rand = new Random(1);

            foreach (string artistName in artistNames)
            {
                Artist newArtist = new Artist { Name = artistName };
                artists.Add(newArtist);
                foreach (string titleName in titleNames)
                {
                    MusicTrack newTrack = new MusicTrack
                    {
                        Artist = newArtist,
                        Title = titleName,
                        Length = rand.Next(20, 600)
                    };
                    musicTracks.Add(newTrack);
                }
            }

            var selectedTracks = from track in musicTracks
                                 where track.Artist.Name == "Rob Miles"
                                 select new TrackDetails
                                 {
                                     ArtistName = track.Artist.Name,
                                     Title = track.Title
                                 };

            foreach (var item in selectedTracks)
            {
                Console.WriteLine("Artist:{0} Title:{1}", item.ArtistName, item.Title);
            }

            Console.ReadKey();
        }
    }
}
