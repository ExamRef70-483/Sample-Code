using System;
using System.IO;
using System.Xml.Serialization;

namespace LISTING_3_2_Creating_XML
{
    public class MusicTrack
    {
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
        }
        public MusicTrack()
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MusicTrack track = new MusicTrack(artist: "Rob Miles", title: "My Way", length: 150);
            XmlSerializer musicTrackSerializer = new XmlSerializer(typeof(MusicTrack));

            TextWriter serWriter = new StringWriter();
            musicTrackSerializer.Serialize(textWriter:serWriter, o:track);
            serWriter.Close();

            string trackXML = serWriter.ToString();

            Console.WriteLine("Track XML");
            Console.WriteLine(trackXML);

            TextReader serReader = new StringReader(trackXML);

            MusicTrack trackRead = musicTrackSerializer.Deserialize(serReader) as MusicTrack;

            Console.Write("Read back: ");
            Console.WriteLine(trackRead);

            Console.ReadKey();
        }
    }
}
