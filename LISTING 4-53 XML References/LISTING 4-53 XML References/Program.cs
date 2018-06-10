using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace LISTING_4_53_XML_References
{
    public class Artist
    {
        public string Name { get; set; }
    }

    public class MusicTrack
    {
        public Artist Artist { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
    }

    public class MusicDataStore
    {
        public List<Artist> Artists = new List<Artist>();
        public List<MusicTrack> MusicTracks = new List<MusicTrack>();

        public static MusicDataStore TestData()
        {
            MusicDataStore result = new MusicDataStore();

            string[] artistNames = new string[] { "Rob Miles", "Fred Bloggs", "The Bloggs Singers", "Immy Brown" };
            string[] titleNames = new string[] { "My Way", "Your Way", "His Way", "Her Way", "Milky Way" };

            Random rand = new Random(1);

            foreach (string artistName in artistNames)
            {
                Artist newArtist = new Artist { Name = artistName };
                result.Artists.Add(newArtist);
                foreach (string titleName in titleNames)
                {
                    MusicTrack newTrack = new MusicTrack
                    {
                        Artist = newArtist,
                        Title = titleName,
                        Length = rand.Next(20, 600)
                    };
                    result.MusicTracks.Add(newTrack);
                }
            }
            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (MusicTrack track in MusicTracks)
            {
                result.AppendFormat("Artist:{0} Title:{1}\n", track.Artist.Name, track.Title);
            }

            return result.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MusicDataStore musicData = MusicDataStore.TestData();

            XmlSerializer formatter = new XmlSerializer(typeof(MusicDataStore));

            using (FileStream outputStream =
                new FileStream("MusicTracks.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(outputStream, musicData);
            }

            MusicDataStore inputData;

            using (FileStream inputStream =
                new FileStream("MusicTracks.xml", FileMode.Open, FileAccess.Read))
            {
                inputData = (MusicDataStore)formatter.Deserialize(inputStream);
            }

            Console.WriteLine(inputData);

            Console.ReadKey();
        }
    }
}
