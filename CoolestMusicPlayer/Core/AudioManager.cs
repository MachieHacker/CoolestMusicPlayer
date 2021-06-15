using CoolestMusicPlayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolestMusicPlayer.Core
{
    public static class AudioManager
    {
        public static List<Music> Playlist { get; set; } = new List<Music>();
    }
}
