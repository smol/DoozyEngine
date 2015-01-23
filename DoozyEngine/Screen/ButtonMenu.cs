using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using DoozyEngine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoozyEngine.Menu
{
    public class ButtonMenu : MenuEntry
    {
        private Texture2D texture;

        public override Vector2 Position
        {
            get { return this.position; }
            set {
                value.X *= this.HitBox.Width + 10;
                value.Y *= this.HitBox.Height + 10;

                //value *= RootEngine.GraphicController.Scale;

                this.HitBox.X = (int)value.X;
                this.HitBox.Y = (int)value.Y;

                this.position = value;

            }
        }

        public override string Text
        {
            set { this.text = value; }
        }

        public Vector2 Offset = Vector2.Zero;
        
        private float scale = 1f;

        public ButtonMenu()
        {
            this.texture = TextureManager.Instance.GetTexture(@"images\button");

            this.HitBox = new Rectangle() { Width = this.texture.Width, Height = this.texture.Height};
        }

        public bool IsPressed(Vector2 tapPosition)
        {
            if (tapPosition.X >= this.position.X + this.Offset.X && tapPosition.X <= this.Offset.X + this.position.X + this.Size.X &&
                tapPosition.Y >= this.position.Y + this.Offset.Y && tapPosition.Y <= this.Offset.Y + this.position.Y + this.Size.Y)
                return true;

            return false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            this.scale = (this.IsSelected ? 1f : 0.8f);

            spriteBatch.DrawString(TextureManager.Instance.GetFont(@"interface\font"), text, this.position + this.Offset, NotSelected, 0, this.Size / 2, this.scale, SpriteEffects.None, 1);
            spriteBatch.Draw(this.texture, this.position + this.Offset, null, Color.White, 0f, this.Size / 2, this.scale, SpriteEffects.None, 1f);


            //base.Draw(spriteBatch);
        }
    }
}
