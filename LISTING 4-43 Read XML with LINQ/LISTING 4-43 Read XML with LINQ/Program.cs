using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LISTING_4_43_Read_XML_with_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string XMLText =
                "<MusicTracks>" +
                    "<MusicTrack>" +
                        "<Artist>Rob Miles</Artist>  " +
                        "<Title>My Way</Title>  " +
                        "<Length>150</Length>" +
                    "</MusicTrack>" +

                    "<MusicTrack>" +
                        "<Artist>Immy Brown</Artist>  " +
                        "<Title>Her Way</Title>  " +
                        "<Length>200</Length>" +
                    "</MusicTrack>" +
                "</MusicTracks>";

            XDocument musicTracksDocument = XDocument.Parse(XMLText);

            IEnumerable<XElement> selectedTracks = from track in musicTracksDocument.Descendants("MusicTrack")
                                                   select track;

            foreach (XElement item in selectedTracks)
            {
                Console.WriteLine("Artist:{0} Title:{1}",
                    item.Element("Artist").FirstNode,
                    item.Element("Title").FirstNode);
            }

            Console.ReadKey();
        }
    }
}
