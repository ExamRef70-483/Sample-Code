using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LISTING_4_46_Modify_XML_with_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string XMLText =
                "<MusicTracks>" +
                    "<MusicTrack>" +
                        "<Artist>Rob Miles</Artist>  " +
                        "<Title>my Way</Title>  " +
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
                                                   where (string)track.Element("Title") == "my Way"
                                                   select track;

            foreach (XElement item in selectedTracks)
            {
                item.Element("Title").FirstNode.ReplaceWith("My Way");
            }

            Console.WriteLine(musicTracksDocument.ToString());
            Console.ReadKey();
        }
    }
}
