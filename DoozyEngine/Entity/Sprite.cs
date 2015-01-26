using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using DoozyEngine.Utils;

namespace DoozyEngine.Entity
{
    public class Sprite
    {
        #region ATTRIBUTES
        public Vector2 Size { get; protected set; }

        protected Vector2 origin = Vector2.Zero;

        protected float layer = 1f;
        public float Layer { get { return this.layer; } set { this.layer = value; } }

        protected Rectangle hitBox;
        public Rectangle HitBox
        {
            get { return this.hitBox; }
        }
        
        private Vector2 position;
        public virtual Vector2 Position 
        {
            get { return position; }
            set 
            {
                this.hitBox.X = (int)(Math.Round(value.X, 0));
                this.hitBox.Y = (int)(Math.Round(value.Y, 0));
                this.position = value;
            }
        }
        
        public virtual float PositionX
        {
            get { return this.position.X; }
            set 
            {
                this.hitBox.X = (int)(Math.Round(value, 0));
                this.position.X = value;
            }
        }

        public virtual float PositionY
        {
            get { return this.position.Y; }
            set
            {
                this.hitBox.Y = (int)(Math.Round(value, 0));
                this.position.Y = value;
            }
        }

        protected Texture2D texture = null;
        protected Texture2D hitBoxTexture;

        protected SpriteEffects flip = SpriteEffects.None;

        private Rectangle sourceRectangle;
        public Rectangle SourceRectangle
        {
            get { return this.sourceRectangle; }
            protected set { this.sourceRectangle = value; }
        }

        protected SpriteBatch SpriteBatch
        {
            get { return DisplayManager.SpriteBatch; }
        }


#endregion // ATTRIBUTES


        public Sprite(string asset)
        {
            if (asset != null)
                this.texture = TextureManager.Instance.GetTexture(asset);

            this.Size = Vector2.Zero;
            if (this.texture != null)
                this.Size = new Vector2(-this.texture.Width, -this.texture.Height);

            this.hitBoxTexture = new Texture2D(RootEngine.Graphics, 1, 1);
            this.hitBoxTexture.SetData(new Color[] { Color.White });

            this.hitBox.Height = this.sourceRectangle.Height;
            this.hitBox.Width = this.sourceRectangle.Width;

            if (this.sourceRectangle != null && this.Size == Vector2.Zero)
                this.Size = new Vector2(this.sourceRectangle.Width, this.sourceRectangle.Height);

            //Rectangle rectangle = RectangleUtils.Multiply(this.sourceRectangle, GraphicController.TILE_SIZE);
            //this.origin = new Vector2(this.Size.X, this.Size.Y);
        }

        public virtual void Update(GameTime gameTime) {
            
        }

        public virtual void Draw(GameTime gameTime)
        {
            //Rectangle rectangle = RectangleUtils.Multiply(this.sourceRectangle, GraphicController.TILE_SIZE);

            //Rectangle hitbox = RectangleUtils.Multiply(this.HitBox, GraphicController.TILE_SIZE);

            //hitbox.X += GraphicController.TILE_SIZE / 2;
            //hitbox.Y += GraphicController.TILE_SIZE / 2;

            if (RootEngine.DebugMode)
            {
                this.SpriteBatch.Draw(this.hitBoxTexture, this.hitBox, null, Color.Red * 0.2f, 0, Vector2.Zero, SpriteEffects.None, this.layer - 0.01f);
                this.SpriteBatch.Draw(this.hitBoxTexture, this.sourceRectangle, null, Color.Yellow * 0.2f, 0, Vector2.Zero, SpriteEffects.None, this.layer - 0.02f);
            }

            if (this.texture == null) return;

            //Vector2 position = (this.Position * GraphicController.TILE_SIZE);// +new Vector2(GraphicController.TILE_SIZE / 2, GraphicController.TILE_SIZE / 2);

            if (this.sourceRectangle == Rectangle.Empty)
                this.SpriteBatch.Draw(this.texture, this.position, null, Color.White, 0, this.origin, 1, this.flip, this.layer);
            else
                this.SpriteBatch.Draw(this.texture, this.position, this.sourceRectangle, Color.White, 0, this.origin, 1, this.flip, this.layer);
        }

    }
}
