using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoozyEngine.Entity
{
    public class Background : Sprite
    {
        public Background(string asset): base(asset)
        {
            
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) {
            this.SpriteBatch.Draw(this.texture, this.Position, null, Color.White, 0, Vector2.Zero, 1, this.flip, this.layer);
        }
    }
}
