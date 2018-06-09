using System;
using System.Xml;

namespace LISTING_4_27_XML_DOM
{
    class Program
    {
        static void Main(string[] args)
        {
            string XMLDocument = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
                "<MusicTrack xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  " +
                "<Artist>Rob Miles</Artist>  " +
                "<Title>My Way</Title>  " +
                "<Length>150</Length>" +
                "</MusicTrack>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(XMLDocument);

            System.Xml.XmlElement rootElement = doc.DocumentElement;
            // make sure it is the right element
            if (rootElement.Name != "MusicTrack")
            {
                Console.WriteLine("Not a music track");
            }
            else
            {
                string artist = rootElement["Artist"].FirstChild.Value;
                Console.WriteLine("", artist);
                string title = rootElement["Title"].FirstChild.Value;
                Console.WriteLine("Artist:{0} Title:{1}", artist, title);
            }

            Console.ReadKey();
        }
    }
}
