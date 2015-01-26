using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DoozyEngine.Entity
{
    public class TextureManager
    {
        private ContentManager ContentManager;
        
        public static TextureManager Instance { get; private set; }

        private Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();
        private Dictionary<string, SpriteFont> SpriteFonts = new Dictionary<string, SpriteFont>();
        private Dictionary<string, int[]> UIConfig = new Dictionary<string, int[]>();

        public TextureManager(ContentManager ContentManager)
        {
            this.ContentManager = ContentManager;

            TextureManager.Instance = this;
        }

        public void AddUIConfig(string key, string path) {
            this.UIConfig = ContentManager.Load<Dictionary<string, int[]>>(path);
        }

        public void AddTexture(string key, string path)
        {
            if (!this.Textures.ContainsKey(key))
                this.Textures.Add(key, ContentManager.Load<Texture2D>(path));
        }

        public void AddFont(string key, string path)
        {
            this.SpriteFonts.Add(key, ContentManager.Load<SpriteFont>(path));
        }

        public Rectangle GetUI(string key) {
            int[] temp = this.UIConfig[key];

            return new Rectangle() {
                X = temp[0], Y = temp[1],
                Width = temp[2], Height = temp[3]
            };
        }

        public SpriteFont GetFont(string key)
        {
            return this.SpriteFonts[key];
        }

        public Texture2D GetTexture(string key)
        {
            return this.Textures[key];
        }

    }
}
