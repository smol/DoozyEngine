using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using DoozyEngine.Entity;

namespace DoozyEngine.UI
{
    public enum UILabelHorizontalAlignement { Left, Center, Right };
    public enum UILabelVerticalAlignement { Top, Middle, Bottom };

    public class UILabel : UIObject
    {
        public UILabelHorizontalAlignement Alignement = UILabelHorizontalAlignement.Left;
        public UILabelVerticalAlignement VerticalAlignement = UILabelVerticalAlignement.Middle;

        protected SpriteFont SpriteFont = UIConfig.SpriteFont;
        
        public string Text = "";
        
        public Vector2 Position = Vector2.Zero;
        public Vector2 Origin = Vector2.Zero;
        
        public Color Color = Color.White;
        
        public float Scale = 0.5f;
        public float Rotation = 0f;

        public SpriteEffects SpriteEffects = SpriteEffects.None;

        public UILabel() : base() {            
        }

        public override void Draw(GameTime gameTime) {
            Vector2 position = this.Position;

            Vector2 measure = this.SpriteFont.MeasureString(this.Text) * this.Scale;

            if (this.Alignement == UILabelHorizontalAlignement.Center)
                position.X += (this.frame.Width/2) - (measure.X/2);
            else if (this.Alignement == UILabelHorizontalAlignement.Right)
                position.X += this.frame.Width - measure.X;

            if (this.VerticalAlignement == UILabelVerticalAlignement.Middle)
                position.Y += (this.frame.Height/2) - (measure.Y/2);
            else if (this.VerticalAlignement == UILabelVerticalAlignement.Bottom)
                position.Y += this.frame.Height - measure.Y;

            DisplayManager.SpriteBatch.DrawString(this.SpriteFont, this.Text, position, this.Color, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.Layer);
        }
    }

    public class UIAnimatedBar : UIBar
    {
        private float animateValue = -1;

        public Rectangle ProgressBar;

        public float Value {
            get { return base.Value; }
            set {
                base.Value = value;
            }
        }

        public float MaxValue {
            get { return base.MaxValue; }
            set { 
                base.MaxValue = value;
                this.animateValue = value;
            }
        }

        public UIAnimatedBar()
            : base() {
            
        }

        public override int Update(GameTime gameTime) {
            if (this.animateValue > this.Value && this.animateValue > 0)
                this.animateValue -= ((float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.15f);
            return 0;
        }

        public override void Draw(GameTime gameTime) {
            Rectangle value = this.frame;
            Rectangle animateRect = value;

            value.Width = (int)(Math.Round((this.Value * this.frame.Width) / this.MaxValue));
             
            animateRect.Width = (int)(Math.Round((this.animateValue * this.frame.Width) / this.MaxValue));
            this.ProgressBar.Width = animateRect.Width;
            this.Bar.Width = value.Width;

            DisplayManager.SpriteBatch.Draw(this.uiTexture2D, this.frame, this.Background, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, this.Layer - 0.000002f);
            DisplayManager.SpriteBatch.Draw(this.uiTexture2D, animateRect, this.ProgressBar, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, this.Layer - 0.000001f);
            DisplayManager.SpriteBatch.Draw(this.uiTexture2D, value, this.Bar, Color.White, 0.0f, Vector2.Zero, SpriteEffects.None, this.Layer);

            //if (this.ShowLabel) {
            //    Vector2 position = new Vector2(this.frame.X + 10, this.frame.Y + 10);
            //    //DisplayManager.SpriteBatch.DrawString(this.SpriteFont, this.Value.ToString() + " / " + this.MaxValue.ToString(), position, this.Color,
            //                            //this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth + 0.000002f);
            //}
        }
    }

    public class UIBar : UIObject
    {
        public Rectangle? Background = null;
        public Rectangle Bar;

        public bool Flat = true;

        //public Rectangle Rectangle = Rectangle.Empty;
        public float Value = 0f;
        public float MaxValue = 0f;

        private bool showLabel = true;
        public bool ShowLabel {
            get { return this.showLabel; }
            set {
                this.showLabel = value;
                if (this.label == null && this.showLabel) {
                    this.label = new UILabel();
                    this.label.Alignement = UILabelHorizontalAlignement.Center;
                    this.label.Frame = this.frame;
                    this.label.Layer = this.Layer;
                }
            }
        }
        public Color ColorBar = Color.White;

        private UILabel label = null;

        public UIBar() : base() {
            this.ShowLabel = this.showLabel;
            
        }

        public override int Update(GameTime gameTime) {
            return 0;
        }

        public override void Draw(GameTime gameTime) {
            Rectangle value = this.frame;

            value.Width = (int)((this.Value * this.frame.Width) / this.MaxValue);

            this.Bar.Width = value.Width;
            
            this.label.Frame = this.frame;

            if (this.Background != null)
                DisplayManager.SpriteBatch.Draw(this.uiTexture2D, this.frame, this.Background, Color.White, 0.0f, Vector2.Zero, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, this.Layer - 0.000002f);
                
            DisplayManager.SpriteBatch.Draw(this.uiTexture2D, value, this.Bar, Color.White, 0.0f, Vector2.Zero, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, this.Layer - 0.000001f);

            if (this.label != null) {
                Vector2 position = new Vector2(this.frame.X, this.frame.Y);
                this.label.Text = this.Value.ToString() + " / " + this.MaxValue.ToString();
                this.label.Position = position;
                
                this.label.Draw(gameTime);
            }
        }
    }
}
