using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace LISTING_4_51_Binary_versions
{
    [Serializable]
    class Artist
    {
        public string Name { get; set; }
    }

    [Serializable]
    class MusicTrack
    {
        public Artist Artist { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }

        [OptionalField]
        public string Style;

        [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context)
        {
            Style = "unknown";
        }
    }

    [Serializable]
    class MusicDataStore
    {
        List<Artist> Artists = new List<Artist>();
        List<MusicTrack> MusicTracks = new List<MusicTrack>();

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
                result.AppendFormat("Artist:{0} Title:{1} Style:{2}\n", track.Artist.Name, track.Title, track.Style);
            }

            return result.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MusicDataStore musicData = MusicDataStore.TestData();

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream outputStream =
                new FileStream("MusicTracks.bin", FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(outputStream, musicData);
            }

            MusicDataStore inputData;

            using (FileStream inputStream =
                new FileStream("MusicTracks.bin", FileMode.Open, FileAccess.Read))
            {
                inputData = (MusicDataStore)formatter.Deserialize(inputStream);
            }

            Console.WriteLine(inputData);

            Console.ReadKey();
        }
    }
}
