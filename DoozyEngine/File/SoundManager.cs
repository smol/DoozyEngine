using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoozyEngine
{
    public class SoundManager
    {
        public static SoundManager Instance { get; private set; }

        private ContentManager contentManager;

        private Dictionary<string, Song> songs = new Dictionary<string, Song>();
        private Dictionary<string, SoundEffect> sounds = new Dictionary<string, SoundEffect>();

        public SoundManager(ContentManager contentManager) {
            this.contentManager = contentManager;
            
            SoundManager.Instance = this;
        }

        public void PlaySong(string asset) {
            //if (RootEngine.Modules.Sounds) {
            //    Song song = this.songs[asset];
            //    MediaPlayer.IsRepeating = true;
            //    MediaPlayer.Play(song);
            //}
        }

        public void PlaySound(string asset) {
            //if (RootEngine.Modules.Sounds)
            //    this.sounds[asset].Play(0.5f, 1f, 0.3f);
        }

        public void AddSound(string asset) {
            this.sounds.Add(asset, this.contentManager.Load<SoundEffect>(asset));
        }

        public void AddSong(string asset) {
            this.songs.Add(asset, this.contentManager.Load<Song>(asset));
        }
    }
}
