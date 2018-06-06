using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicManager.Models
{
    public class TrackPlaylistMapping
    {
        public int ID { get; set; }
        public int TrackID { get; set; }
        public int PlaylistID { get; set; }
    }
}
