using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoozyEngine.Utils;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//using SocksAdventureLibrary;

namespace DoozyEngine.Entity
{
    public class Animation
    {
        public int[] Scale;

        private float speed;
        public float Speed {
            set { speed = value; }
            get { return speed / Key.Count(); }
        }

        public List<int[]> Key;
    }

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
                    currentAnimation = this.animations[animationName];
                }
            }
        }

        private int animationIndex = 0;
        public int AnimationIndex {
            set {
                if (animationIndex != value) {
                    animationIndex = value;
                    //                    currentAnim = this.animations.ElementAt(animationIndex).Animation[animationName];
                }
            }
            get { return this.animationIndex; }
        }

        private int animationFrame = 0;

        private bool animated = true;

        private Animation currentAnimation = null;
        private Dictionary<string, Animation> animations = new Dictionary<string, Animation>();

        public Dictionary<string, Animation> Animations {
            set {
                if (value != null && value.Count > 0)
                    this.currentAnimation = value.ElementAt(0).Value;

                this.animations = value;
            }
        }



        private float lastFrame = 0;

        public AnimatedSprite(String asset) :
            base(asset) {

            

//            this.animations = content.Load<List<AnimationEntity>>("animations/" + asset);
//
//            this.currentAnim = this.animations.ElementAt(animationIndex).Animation[animationName];
//            this.SourceRectangle = new Rectangle(currentAnim.AnimationFrame[0][0], currentAnim.AnimationFrame[0][1], currentAnim.AnimationFrame[0][2], currentAnim.AnimationFrame[0][3]);
//
//            this.hitBox.Height = currentAnim.AnimationFrame[0][2] * 128;
//            this.hitBox.Width = currentAnim.AnimationFrame[0][3] * 128;
        }

        public override void Draw(GameTime gameTime) {
            if (this.currentAnimation == null) {
                return;
            }

            if (!RootEngine.IsPause) {
IncreaseAnimation:
                this.lastFrame += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (this.lastFrame > this.currentAnimation.Speed) {
                    this.lastFrame = 0;
                    if (this.animated) {
                        ++animationFrame;
                        if (animationFrame >= currentAnimation.Key.Count)
                            animationFrame = 0;
                    }
                }

                if (animationFrame >= currentAnimation.Key.Count)
                    goto IncreaseAnimation;

                this.SourceRectangle = new Rectangle(currentAnimation.Key[animationFrame][0], currentAnimation.Key[animationFrame][1], currentAnimation.Key[animationFrame][2], currentAnimation.Key[animationFrame][3]);
                //this.SourceRectangle = RectangleUtils.Multiply(this.SourceRectangle, 128);
                this.origin = -new Vector2(this.SourceRectangle.Width, this.SourceRectangle.Height);

                if (currentAnimation.Scale[1] < 0)
                    flip = SpriteEffects.FlipHorizontally;
                else
                    flip = SpriteEffects.None;
            }
            base.Draw(gameTime);
        }
    }
}
