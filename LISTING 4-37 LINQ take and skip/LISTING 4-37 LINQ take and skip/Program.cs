using System;
using System.Collections.Generic;
using System.Linq;

namespace LISTING_4_37_LINQ_take_and_skip
{
    class Artist
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    class MusicTrack
    {
        public int ID { get; set; }
        public int ArtistID { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
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
            int IDcount = 0;

            foreach (string artistName in artistNames)
            {
                Artist newArtist = new Artist { ID = IDcount++, Name = artistName };
                artists.Add(newArtist);
                foreach (string titleName in titleNames)
                {
                    MusicTrack newTrack = new MusicTrack
                    {
                        ID = IDcount++,
                        ArtistID = newArtist.ID,
                        Title = titleName,
                        Length = rand.Next(20, 600)
                    };
                    musicTracks.Add(newTrack);
                }
            }

            int pageNo = 0;
            int pageSize = 10;

            while(true)
            {
                // Get the track information
                var trackList = from musicTrack in musicTracks.Skip(pageNo*pageSize).Take(pageSize)
                                join artist in artists on musicTrack.ArtistID equals artist.ID
                                select new
                                {
                                    ArtistName = artist.Name,
                                    musicTrack.Title
                                };

                // Quit if we reached the end of the data
                if (trackList.Count() == 0)
                    break;

                // Display the query result
                foreach (var item in trackList)
                {
                    Console.WriteLine("Artist:{0} Title:{1}",
                       item.ArtistName, item.Title);
                }

                Console.Write("Press any key to continue");
                Console.ReadKey();

                // move on to the next page
                pageNo++;
            }

            Console.Write("Press any key to exit");
            Console.ReadKey();
        }
    }
}
