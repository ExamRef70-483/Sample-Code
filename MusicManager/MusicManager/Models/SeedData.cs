using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicManager.Models
{
    public static class SeedData
    {

        public static void clearDatabase( MusicManagerContext context)
        {
            var artistQuery = from a in context.Artist select a;
            foreach (Artist artist in artistQuery)
                context.Artist.Remove(artist);

            var trackQuery = from t in context.MusicTrack select t;
            foreach (MusicTrack track in trackQuery)
                context.MusicTrack.Remove(track);

            var playlistQuery = from p in context.PlayList select p;
            foreach (PlayList playlist in playlistQuery)
                context.PlayList.Remove(playlist);

            var mapQuery = from m in context.TrackPlaylistMapping select m;
            foreach (TrackPlaylistMapping map in mapQuery)
                context.TrackPlaylistMapping.Remove(map);

            context.SaveChanges();
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MusicManagerContext(
                serviceProvider.GetRequiredService<DbContextOptions<MusicManagerContext>>()))
            {
                context.Database.Migrate();

                string[] artists = new string[] { "Rob Miles", "Fred Bloggs", "The Bloggs Singers", "Immy Brown" };
                string[] titles = new string[] { "My Way", "Your Way", "His Way", "Her Way", "Milky Way" };
                string[] playlists = new string[] { "Happy", "Sad", "Working" };

                // clearDatabase(context); - use this to force a database clear

                if (!context.MusicTrack.Any())
                {
                    //need to populate the database with sample data
                    foreach (string artistName in artists)
                    {
                        context.Artist.Add(new Artist { Name = artistName });
                    }

                    foreach (string playlistName in playlists)
                    {
                        context.PlayList.Add(new PlayList {  Name=playlistName });
                    }

                    context.SaveChanges();

                    Random rand = new Random(1);

                    // Now spin through the artists adding tracks 
                    // Note that we have to do this so that we can get
                    // the id value of the artist to add to the MusicTrack

                    var artistQuery = from a in context.Artist select a;

                    List<MusicTrack> allTracks = new List<MusicTrack>();

                    foreach (Artist artist in artistQuery)
                    {
                        foreach (string title in titles)
                        {
                            context.MusicTrack.Add(new MusicTrack { ArtistID = artist.ID, Title = title, Length = rand.Next(20, 600) });
                        }
                    }

                    foreach (Artist artist in artistQuery)
                    {
                        foreach (string title in titles)
                        {
                            context.MusicTrack.Add(new MusicTrack { ArtistID = artist.ID, Title = title, Length = rand.Next(20, 600) });
                        }
                    }

                    context.SaveChanges();

                    var trackQuery = from t in context.MusicTrack select t;

                    foreach(MusicTrack t in trackQuery)
                    {
                        allTracks.Add(t);
                    }

                    // now got a of tracks - can build some playlists

                    var playlistQuery = from p in context.PlayList where true select p;

                    foreach(PlayList p in playlistQuery)
                    {
                        foreach (MusicTrack m in allTracks)
                        {
                            if (rand.Next(10) > 6)
                                continue; // only include some of the records

                            context.TrackPlaylistMapping.Add(new TrackPlaylistMapping
                            {
                                PlaylistID = p.ID,
                                TrackID = m.ID
                            });
                        }
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
