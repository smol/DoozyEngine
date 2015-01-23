using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DoozyEngine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoozyEngine.Entity
{
    public class Light
    {
        private Vector2 position = Vector2.Zero;
        public Vector2 Position {
            get { return this.position; }
            set { this.position = value; }
        }

        private Texture2D texture = null;
        private SpriteBatch spriteBatch = null;

        public Light() {
            //this.texture = TextureManager.Instance.GetTexture(@"images\halo");

            this.spriteBatch = DisplayManager.SpriteBatch;
        }

        public void Update(GameTime gameTime) {
            if (Keyboard.GetState().IsKeyDown(Keys.NumPad2))
                position.Y += 5.0f;
            if (Keyboard.GetState().IsKeyDown(Keys.NumPad8))
                position.Y -= 5.0f;
            if (Keyboard.GetState().IsKeyDown(Keys.NumPad6))
                position.X += 5.0f;
            if (Keyboard.GetState().IsKeyDown(Keys.NumPad4))
                position.X -= 5.0f;
        }

        public void Draw(GameTime gameTime) {
            //this.spriteBatch.Draw(this.texture, this.position, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 1);
            

        }
    }
}
