using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using DoozyEngine.Entity;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace DoozyEngine.Menu
{
    public class Cursor
    {

        #region FIELDS

        public enum Button { Left, Middle, Right };

        public static Vector2 Position {
            get {
                MouseState state = Mouse.GetState();
                return new Vector2(state.X, state.Y);
            }
        }

        public static float X { get { return Mouse.GetState().X; } }
        public static float Y { get { return Mouse.GetState().Y; } }


        private Texture2D cursorTexture;

        #endregion // FIELD


        public Cursor()
        {
            TextureManager.Instance.AddTexture("UI", @"interface\ui");
            this.cursorTexture = TextureManager.Instance.GetTexture("UI");
        }


        // 0 - left button / 1 - middlebutton / 2 - rightbutton
        public static bool IsButtonPressed(Button button) {
            MouseState state = Mouse.GetState();

            if (button == Button.Left && state.LeftButton == ButtonState.Pressed)
                return true;
            else if (button == Button.Middle && state.MiddleButton == ButtonState.Pressed)
                return true;
            else if (button == Button.Right && state.RightButton == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        public static bool IsMouseOver(Rectangle rectangle) {
            MouseState state = Mouse.GetState();

            if ((state.X >= rectangle.X && state.X <= (rectangle.X + rectangle.Width)) &&
                (state.Y >= rectangle.Y && state.Y <= (rectangle.Y + rectangle.Height)))
                return true;
            return false;
        }

        static Vector2 temp = new Vector2();

        public void Draw(SpriteBatch sprite) {
            sprite.Begin();

            MouseState state = Mouse.GetState();

            sprite.Draw(this.cursorTexture, new Vector2(state.X, state.Y), new Rectangle(460, 0, 35, 37), Color.White);

            sprite.End();
        }

    }
}
