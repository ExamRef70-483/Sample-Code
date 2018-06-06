using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicManager.Models;

namespace MusicManager.Models
{
    public class MusicManagerContext : DbContext
    {
        public MusicManagerContext (DbContextOptions<MusicManagerContext> options)
            : base(options)
        {
        }

        public DbSet<MusicManager.Models.Artist> Artist { get; set; }

        public DbSet<MusicManager.Models.MusicTrack> MusicTrack { get; set; }

        public DbSet<MusicManager.Models.PlayList> PlayList { get; set; }

        public DbSet<MusicManager.Models.TrackPlaylistMapping> TrackPlaylistMapping { get; set; }
    }
}
