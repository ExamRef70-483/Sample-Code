using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicTracks.Models
{
    public class MusicTrack
    {
        public int ID { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
    }
}
