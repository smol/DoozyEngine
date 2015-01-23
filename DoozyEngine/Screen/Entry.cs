using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoozyEngine.Entity;
using Microsoft.Xna.Framework.Input;

namespace DoozyEngine.Menu
{
    public class MenuEntry
    {
        public bool IsSelected = false;

        protected Vector2 position;
        public virtual Vector2 Position
        {
            get { return position; }
            set
            {
                position = value * RootEngine.GraphicController.Scale * GraphicController.TILE_SIZE;

                this.HitBox.X = (int)(position.X);
                this.HitBox.Y = (int)(position.Y);
            }
        }


        protected string text;
        public virtual string Text 
        {
            set
            {
                this.text = value;

                this.HitBox.Width = (int)(TextureManager.Instance.GetFont(@"interface\font").MeasureString(value).X * RootEngine.GraphicController.Scale.X);
                this.HitBox.Height = (int)(TextureManager.Instance.GetFont(@"interface\font").MeasureString(value).Y * RootEngine.GraphicController.Scale.Y);
            }
        }

        public MenuScreen.CallbackScreen Callback;

        public int IndexValue = 0;
        public List<object> Values = null;

        public Color NotSelected = Color.White;
        public Color Selected = Color.Red;

        protected Rectangle HitBox = Rectangle.Empty;
        public Vector2 Size
        {
            get {
                return new Vector2(HitBox.Width, HitBox.Height);
            }
        }

        public virtual void Update()
        {
            MouseState state = Mouse.GetState();

            Vector2 mouse = new Vector2(state.X, state.Y) * RootEngine.GraphicController.Scale;

            if (mouse.X >= HitBox.X && mouse.Y <= (HitBox.X + HitBox.Width))
            {
                if (mouse.Y >= HitBox.Y && mouse.Y <= (HitBox.Y + HitBox.Height))
                    this.IsSelected = true;
            }
            else
                this.IsSelected = false;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            MouseState mouseState = Mouse.GetState();

            Vector2 mouse = new Vector2(mouseState.X, mouseState.Y);

            if (text == "Exit")
                Console.Write("PWET");

            if ((mouse.X >= HitBox.X && mouse.X <= (HitBox.X + HitBox.Width)) &&
                (mouse.Y >= HitBox.Y && mouse.Y <= (HitBox.Y + HitBox.Height)))
                    this.IsSelected = true;
            else
                this.IsSelected = false;

            if (this.IsSelected && Callback != null && mouseState.LeftButton == ButtonState.Pressed)
                this.Callback();

            if (!IsSelected)
                spriteBatch.DrawString(TextureManager.Instance.GetFont(@"interface\font"), text, Position, NotSelected, 0, Vector2.Zero, 0.7f, SpriteEffects.None, 1);
            else
                spriteBatch.DrawString(TextureManager.Instance.GetFont(@"interface\font"), text, Position, Selected, 0, Vector2.Zero, 0.7f, SpriteEffects.None, 1);
        }
    }
}
