using System;
using System.IO;
using System.Xml;

namespace LISTING_4_26_XML_elements
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

            using (StringReader stringReader = new StringReader(XMLDocument))
            {
                XmlTextReader reader = new XmlTextReader(stringReader);

                while (reader.Read())
                {
                    string description = string.Format("Type:{0} Name:{1} Value:{2}",
                        reader.NodeType.ToString(),
                        reader.Name,
                        reader.Value);
                    Console.WriteLine(description);
                }
            }

            Console.ReadKey();
        }
    }
}
