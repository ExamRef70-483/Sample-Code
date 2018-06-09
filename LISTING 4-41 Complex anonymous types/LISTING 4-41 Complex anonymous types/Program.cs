using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_4_40_Complex_query
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

            List<Artist> Artists = new List<Artist>();
            List<MusicTrack> MusicTracks = new List<MusicTrack>();

            Random rand = new Random(1);
            int IDcount = 0;

            foreach (string artistName in artistNames)
            {
                Artist newArtist = new Artist { ID = IDcount++, Name = artistName };
                Artists.Add(newArtist);
                foreach (string titleName in titleNames)
                {
                    MusicTrack newTrack = new MusicTrack
                    {
                        ID = IDcount++,
                        ArtistID = newArtist.ID,
                        Title = titleName,
                        Length = rand.Next(20, 600)
                    };
                    MusicTracks.Add(newTrack);
                }
            }

            var artistSummary = MusicTracks.Join(
                                    Artists,
                                    track => track.ArtistID,
                                    artist => artist.ID,
                                    (track, artist) =>
                                        new
                                        {
                                            track = track,
                                            artist = artist
                                        }
                                )
                                .GroupBy(
                                    temp0 => temp0.artist.Name,
                                    temp0 => temp0.track
                                )
                                .Select(
                                    artistTrackSummary =>
                                        new
                                        {
                                            ID = artistTrackSummary.Key,
                                            Length = artistTrackSummary.Sum(x => x.Length)
                                        }
                                );


            foreach (var summary in artistSummary)
            {
                Console.WriteLine("Name:{0}  Total length:{1}",
                    summary.ID, summary.Length);
            }
            Console.ReadKey();
        }
    }
}
