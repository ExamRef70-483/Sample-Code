using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_4_68_Custom_collection
{

    class MusicTrack
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public string test { get; set; }
    }

class TrackStore : List<MusicTrack>
{
    public int RemoveArtist(string removeName)
    {
        List<MusicTrack> removeList = new List<MusicTrack>();
        foreach (MusicTrack track in this)
            if (track.Artist == removeName)
                removeList.Add(track);

        foreach (MusicTrack track in removeList)
            this.Remove(track);

        return removeList.Count;
    }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            foreach (MusicTrack track in this)
                output.AppendFormat("Title:{0} Artist:{1} Length:{2}\n",
                    track.Title, track.Artist, track.Length);

                return output.ToString();
        }

        public static TrackStore GetTestTrackStore()
        {
            TrackStore result = new TrackStore();

            string[] artistNames = new string[] { "Rob Miles", "Fred Bloggs", "The Bloggs Singers", "Immy Brown" };
            string[] titleNames = new string[] { "My Way", "Your Way", "His Way", "Her Way", "Milky Way" };

            Random rand = new Random(1);

            foreach (string artistName in artistNames)
            {
                foreach (string titleName in titleNames)
                {
                    MusicTrack newTrack = new MusicTrack
                    {
                        Artist = artistName,
                        Title = titleName,
                        Length = rand.Next(20, 600)
                    };
                    result.Add(newTrack);
                }
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TrackStore tracks = TrackStore.GetTestTrackStore();
            tracks.RemoveArtist("Fred Bloggs");
            Console.WriteLine(tracks);
            Console.ReadKey();
        }
    }
}
