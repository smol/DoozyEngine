using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoozyEngine.Utils;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SocksAdventureLibrary;

namespace DoozyEngine.Entity
{
    public class AnimatedSprite : Sprite
    {
        private bool isTouched = false;
        public bool IsTouched {
            get { return this.isTouched; }
            set { this.isTouched = value; }
        }

        private String animationName = "Idle";
        public String AnimationName {
            set {
                if (animationName != value) {
                    animationName = value;
                    currentAnim = this.animations.ElementAt(animationIndex).Animation[animationName];
                }
            }
        }

        private int animationIndex = 0;
        public int AnimationIndex {
            set {
                if (animationIndex != value) {
                    animationIndex = value;
                    currentAnim = this.animations.ElementAt(animationIndex).Animation[animationName];
                }
            }
            get { return this.animationIndex; }
        }

        private int animationFrame = 0;

        private bool animated = true;


        private AnimationInfo currentAnim;
        private List<AnimationEntity> animations = new List<AnimationEntity>();
        private float lastFrame = 0;

        public AnimatedSprite(String asset, ContentManager content) :
            base(asset) {
            this.animations = content.Load<List<AnimationEntity>>("animations/" + asset);

            this.currentAnim = this.animations.ElementAt(animationIndex).Animation[animationName];
            this.SourceRectangle = new Rectangle(currentAnim.AnimationFrame[0][0], currentAnim.AnimationFrame[0][1], currentAnim.AnimationFrame[0][2], currentAnim.AnimationFrame[0][3]);

            this.hitBox.Height = currentAnim.AnimationFrame[0][2] * 128;
            this.hitBox.Width = currentAnim.AnimationFrame[0][3] * 128;
        }

        public override void Draw(GameTime gameTime) {
            if (!RootEngine.IsPause) {
IncreaseAnimation:
                this.lastFrame += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (this.lastFrame > this.currentAnim.Speed) {
                    this.lastFrame = 0;
                    if (this.animated) {
                        ++animationFrame;
                        if (animationFrame >= currentAnim.AnimationFrame.Count)
                            animationFrame = 0;
                    }
                }

                if (animationFrame >= currentAnim.AnimationFrame.Count)
                    goto IncreaseAnimation;

                this.SourceRectangle = new Rectangle(currentAnim.AnimationFrame[animationFrame][0], currentAnim.AnimationFrame[animationFrame][1], currentAnim.AnimationFrame[animationFrame][2], currentAnim.AnimationFrame[animationFrame][3]);
                this.SourceRectangle = RectangleUtils.Multiply(this.SourceRectangle, 128);
                this.origin = -new Vector2(this.SourceRectangle.Width, this.SourceRectangle.Height);

                if (currentAnim.Scale[1] < 0)
                    flip = SpriteEffects.FlipHorizontally;
                else
                    flip = SpriteEffects.None;
            }
            base.Draw(gameTime);
        }
        public AnimatedSprite(string asset) : base(asset) {
        }
    }
}
