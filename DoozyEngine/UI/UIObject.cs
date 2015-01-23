using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using DoozyEngine.Entity;
using DoozyEngine.Utils;

namespace DoozyEngine.UI
{
    public class UIObject
    {
        
        protected Texture2D uiTexture2D = null;

        protected Rectangle? background = null;
        
        protected Color backgroundColor = Color.Transparent;

        // position and size of the object
        protected Rectangle frame = Rectangle.Empty;

        public UIView Parent = null;
        public float Layer = 1f;

        protected bool isVisible = true;
        public bool IsVisible {
            get { return this.isVisible; }
            set { this.isVisible = value; }
        }

        public Rectangle Frame {
            get { return this.frame; }
            set { this.frame = value;}
        }

        public Vector2 Position {
            get { return new Vector2(this.frame.X, this.frame.Y);}
            set {
                this.frame.X = (int)value.X;
                this.frame.Y = (int)value.Y;
            }
        }

        public UIObject() {
            if (!(this is UILabel)) 
                this.uiTexture2D = TextureManager.Instance.GetTexture(@"interface\ui");
        }

        public virtual int Update(GameTime gameTime) {
            return 0;
        }

        public virtual void Draw(GameTime gameTime) {
            if (this.uiTexture2D != null) {

                DisplayManager.SpriteBatch.Draw(this.uiTexture2D, this.frame,
                    this.background, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, this.Layer);
            }
        }

        public void RemoveFromParent() {
            this.Parent.RemoveChildren(this);
        }
    }

    //public abstract class HudObject
    //{
    //    public bool IsEnable = true;

    //    public bool IsPressed { get; protected set; }

    //    protected Texture2D texture;
    //    protected Vector2 position;

    //    protected int id = -1;

    //    protected Rectangle hitbox;
    //    public Rectangle Hitbox { get { return this.hitbox; } }

    //    protected Vector2 offset = Vector2.Zero;

    //    protected float timer = 0;

    //    public HudObject(Vector2 position)
    //    {
    //        this.IsPressed = false;
    //        this.position = position;
    //    }

    //    public HudObject() {
    //        this.position = Vector2.Zero;
    //    }

    //    public virtual void Update(GameTime gameTime)
    //    {
    //        TouchCollection touches = TouchPanel.GetState();

    //        timer = 1;

    //        int i = 0;
    //        for (; i < touches.Count; i++)
    //        {
    //            if (RectangleUtils.VectorIntersects(touches[i].Position, this.hitbox) && this.id != touches[i].Id)
    //            {
    //                this.offset = touches[i].Position - this.position;
    //                this.id = touches[i].Id;
    //                break;
    //            }
    //            else if (touches[i].Id == this.id)
    //                break;
    //        }

    //        if (i >= touches.Count)
    //            this.Release(gameTime);
    //        else
    //            this.Pressed(touches[i], gameTime);
    //    }

    //    public abstract void Release(GameTime gameTime);

    //    public abstract void Pressed(TouchLocation touch, GameTime gameTime);

    //    public abstract void Draw(GameTime gameTime);
    //}
}
