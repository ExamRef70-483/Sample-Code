using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LISTING_4_47_Add_XML_with_LINQ
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
                                                   where track.Element("Style") == null
                                                   select track;

            foreach (XElement item in selectedTracks)
            {
                item.Add(new XElement("Style", "Pop"));
            }

            Console.WriteLine(musicTracksDocument.ToString());
            Console.ReadKey();
        }
    }
}

