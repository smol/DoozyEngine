using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using DoozyEngine.Input;
using DoozyEngine;
using System.Reflection;
using DoozyEngine.Entity;
using Microsoft.Xna.Framework.Input.Touch;

namespace DoozyEngine.Menu
{
    public class MenuScreen
    {
        protected Cursor cursor = null;

        public static int DOWN = 0, UP = 1, RIGHT = 2, LEFT = 3, ENTER = 4;

        public delegate void CallbackScreen();

        protected CallbackScreen backCallback;

        private Texture2D texture;

        private MenuScreen nextScreen = null;
        public MenuScreen NextScreen
        { 
            get { return this.nextScreen; }
            set { this.nextScreen = value; }
        }

        protected SpriteBatch spriteBatch;

        private MouseState MouseState;

        // spriteFont
        private SpriteFont spriteFont;

        // position de la premiere entree
        private Vector2 entryPosition;

        private MenuEntry first = null, last = null;

        protected MenuEntry menuEntrySelected = null;

        protected static int indexEntrySelected = -1;

        // list des entrees
        protected List<MenuEntry> menuEntry = new List<MenuEntry>();
        protected MenuEntry AddMenuEntry
        {
            set
            {
                this.menuEntry.Add(value); 


                if (this.menuEntry.Count > 0)
                {
                    this.first = (this.menuEntry[0] as ButtonMenu);
                    this.last = (this.menuEntry[this.menuEntry.Count - 1] as ButtonMenu);
                }

            }
        }

        // index
        protected int indexEntry = 0;

        protected string title;

        protected Vector2 offSet = Vector2.Zero;

        private Vector2 tapPosition = Vector2.Zero;

        protected MenuScreen()
        {

            MouseState = Mouse.GetState();

            this.spriteFont = RootEngine.ContentManager.Load<SpriteFont>("interface/font");

            this.texture = TextureManager.Instance.GetTexture("MENU_BACKGROUND");

            TouchPanel.EnabledGestures = GestureType.Tap;

        }

        public virtual void LoadContent()
        {

            this.cursor = new Cursor();

            this.spriteBatch = new SpriteBatch(RootEngine.Graphics);
        }

        public virtual void UnloadContent() {
            
        }

        public virtual void ChangeIndex(int amount)
        {
            // deplacement de la selection
            this.indexEntry += amount;
        }

        public virtual void Update(GameTime gameTime)
        {
            this.tapPosition = Vector2.Zero;
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();

                if (gesture.GestureType == GestureType.HorizontalDrag)
                {
                    if ((gesture.Delta.X > 0 && !first.IsSelected) ||
                        (gesture.Delta.X < 0 && !last.IsSelected))
                        this.offSet.X += gesture.Delta.X;
                }

                if (gesture.GestureType == GestureType.VerticalDrag)
                {
                    if ((gesture.Delta.Y > 0 && !first.IsSelected) ||
                        (gesture.Delta.Y < 0 && !last.IsSelected))
                            this.offSet.Y += gesture.Delta.Y;
                }

                if (gesture.GestureType == GestureType.Tap)
                {
                    this.tapPosition = gesture.Position;
                    return;
                }
            }

            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //    this.backCallback();
        }

        private void DrawString(MenuEntry entry, Vector2 entryPosition, Color color, int index)
        {
            //index = index - this.indexEntry;

            //if (entry.Values == null)
            //    this.spriteBatch.DrawString(this.spriteFont, entry.Text, entryPosition, color, 0, Vector2.Zero, 0.7f, SpriteEffects.None, 1);
            //else
            //{ 
            //    this.spriteBatch.DrawString(this.spriteFont, entry.Text + " : " + entry.Values[entry.IndexValue], entryPosition, color, 0, Vector2.Zero, 0.70f, SpriteEffects.None, 1);

            //}
        }

        public virtual void Draw(GameTime gameTime)
        {
            if (this.spriteBatch == null) return;

            this.spriteBatch.Begin();

            this.spriteBatch.Draw(this.texture, new Rectangle(0,0, RootEngine.GraphicController.Width, RootEngine.GraphicController.Height), Color.White);

            
            // centre le menu a la verticale
            int i = (RootEngine.GraphicController.GraphicsManager.PreferredBackBufferHeight / 2) - ((menuEntry.Count / 2) * 30);
            this.entryPosition.Y = i;

            // parcours de ttes les entrees
            for (int index = 0; index < this.menuEntry.Count; index++)
            {
                // centre l'entree a l'horizontale
                //this.entryPosition.X = (RootEngine.GraphicController.GraphicsManager.PreferredBackBufferWidth / 2) -
                //        (this.spriteFont.MeasureString(this.menuEntry[index].Text).X / 2);

                // si entree selectionne, affichage en rouge, sinon affichage en blanc
                //Color color =  (index == this.indexEntry ? Color.Red : Color.White);
                //this.DrawString(this.menuEntry[index], this.entryPosition, color, index);

                if (this.menuEntry[index].GetType() == typeof(ButtonMenu)) {
                    ButtonMenu temp = this.menuEntry[index] as ButtonMenu;
                    Vector2 position = (temp.Position + this.offSet);

                    if ((position.X >= first.Position.X && position.X <= first.Position.X + temp.Size.X && (TouchPanel.EnabledGestures & GestureType.HorizontalDrag) == GestureType.HorizontalDrag) ||
                        ((position.Y >= first.Position.Y && position.Y <= first.Position.Y + temp.Size.Y) && (TouchPanel.EnabledGestures & GestureType.VerticalDrag) == GestureType.VerticalDrag))
                    {
                        this.menuEntrySelected = temp;
                        temp.IsSelected = true;
                    }
                    else
                    {
                        temp.IsSelected = false;
                    }

                    temp.Offset = this.offSet;

                    if (temp.Callback != null && tapPosition != Vector2.Zero && temp.IsSelected && temp.IsPressed(tapPosition))
                    {
                        MenuScreen.indexEntrySelected = index;
                        temp.Callback();
                    }
                }
                
                this.menuEntry[index].Draw(this.spriteBatch);
            }

            this.spriteBatch.End();

            this.cursor.Draw(this.spriteBatch);
        }
    }
}
