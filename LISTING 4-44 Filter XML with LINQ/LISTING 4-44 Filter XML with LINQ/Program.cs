using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LISTING_4_44_Filter_XML_with_LINQ
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
                                                   where (string)track.Element("Artist") == "Rob Miles"
                                                   select track;

            // Method-based query implementation
            //IEnumerable<XElement> selectedTracks = musicTracksDocument.Descendants("MusicTrack").Where(element => (string)element.Element("Artist") == "Rob Miles");


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
