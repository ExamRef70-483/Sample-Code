using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MusicTracks.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MusicTracksContext(
                serviceProvider.GetRequiredService<DbContextOptions<MusicTracksContext>>()))
            {
                context.Database.Migrate();

                string[] artists = new string[] { "Rob Miles", "Fred Bloggs", "The Bloggs Singers", "Immy Brown" };
                string[] titles = new string[] { "My Way", "Your Way", "His Way", "Her Way", "Milky Way" };


                //if (!context.MusicTrack.Any())
                //{
                //    //need to populate the database with sample data
                //    foreach( string artist in artists)
                //    {

                //    }
                //    context.MusicTrack.Add(
                //        new MusicTrack
                //        {
                //            Title = "My Way",
                //            Artist = "Rob Miles",
                //            Length 
                //        })
                //}

            }
        }
    }
}
