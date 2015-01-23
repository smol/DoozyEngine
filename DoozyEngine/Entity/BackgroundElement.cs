using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
//using SocksAdventureLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoozyEngine.Entity
{
    //class SpriteElement
    //{
    //    public Vector2 Position = new Vector2();
    //    public AnimationEntity.OrientationState Orientation = AnimationEntity.OrientationState.LEFT;
    //    private string AnimationName = "Idle";
    //    public float TTL = 0;

    //    private float nextRandomTimer = 0;
    //    private int dirRandom = 0;
    //    private int axeRandom = 0;
    //    private int animationIndex = 0;
    //    private float lastFrame = 0;

    //    private AnimationInfo currentAnimation = new AnimationInfo();
    //    public List<AnimationEntity> Animation = new List<AnimationEntity>();

    //    private Texture2D texture;

    //    public SpriteElement(Texture2D texture, List<AnimationEntity> animation) {
    //        this.texture = texture;
    //        this.Animation = animation;
    //        this.currentAnimation = Animation[(int)AnimationEntity.OrientationState.LEFT].Animation["Idle"];
    //    }

    //    public void Draw(GameTime gameTime) {
    //    IncreaseAnimation:
    //        this.lastFrame += (float)gameTime.ElapsedGameTime.TotalSeconds;

    //        if (this.lastFrame > this.currentAnimation.Speed) {
    //            this.lastFrame = 0;
    //            ++animationIndex;
    //            if (animationIndex >= this.currentAnimation.AnimationFrame.Count)
    //                animationIndex = 0;
    //        }

    //        if (animationIndex >= currentAnimation.AnimationFrame.Count)
    //            goto IncreaseAnimation;


    //        Rectangle source = new Rectangle() {
    //            X = this.currentAnimation.AnimationFrame[animationIndex][0],
    //            Y = this.currentAnimation.AnimationFrame[animationIndex][1],
    //            Width = this.currentAnimation.AnimationFrame[animationIndex][2],
    //            Height = this.currentAnimation.AnimationFrame[animationIndex][3]
    //        };

    //        DisplayManager.SpriteBatch.Draw(this.texture, this.Position * GraphicController.TILE_SIZE, source, Color.White, 0.0f, Vector2.Zero, 1f, (this.currentAnimation.Scale[1] == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 0.002f);
    //    }

    //    public void Update(GameTime gameTime) {
    //        Random random = new Random();

    //        if (nextRandomTimer > 1)
    //            nextRandomTimer = 0;

    //        if (nextRandomTimer == 0) {
    //            dirRandom = random.Next(-1, 2);
    //            axeRandom = random.Next(-1, 2);

    //            if (axeRandom < 0) {
    //                if (dirRandom > 0)
    //                    this.currentAnimation = Animation[(int)AnimationEntity.OrientationState.DOWN].Animation["Walk"];
    //                else if (dirRandom < 0)
    //                    this.currentAnimation = Animation[(int)AnimationEntity.OrientationState.UP].Animation["Walk"];
    //                else
    //                    this.currentAnimation = Animation[(int)AnimationEntity.OrientationState.UP].Animation["Idle"];
    //            }
    //            else if (axeRandom > 0) {
    //                if (dirRandom < 0)
    //                    this.currentAnimation = Animation[(int)AnimationEntity.OrientationState.LEFT].Animation["Walk"];
    //                else if (dirRandom > 0)
    //                    this.currentAnimation = Animation[(int)AnimationEntity.OrientationState.RIGHT].Animation["Walk"];
    //                else
    //                    this.currentAnimation = Animation[(int)AnimationEntity.OrientationState.RIGHT].Animation["Idle"];
    //            }
    //            else {
    //                this.currentAnimation = Animation[(int)AnimationEntity.OrientationState.RIGHT].Animation["Idle"];
    //            }
    //        }

    //        if (axeRandom < 0)
    //            this.Position.Y += (float)(0.03f * dirRandom);
    //        else  if (axeRandom > 0)
    //            this.Position.X += (float)(0.03f * dirRandom);



    //        nextRandomTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

    //        TTL -= (float)gameTime.ElapsedGameTime.TotalSeconds;
    //    }
    //}
    
    public class BackgroundElement
    {
        //private List<AnimationEntity> animation = new List<AnimationEntity>();
        private Texture2D texture;

        //private WildLife wildlife;
        private float second = 0;

        //private List<SpriteElement> elements = new List<SpriteElement>();
        
        
        //public BackgroundElement(WildLife wildlife, ContentManager contentManager) {
        //    this.wildlife = wildlife;
        //    this.animation = contentManager.Load<List<AnimationEntity>>("animations/" + wildlife.Type);

        //    texture = TextureManager.Instance.GetTexture(@"images\" + wildlife.Type);
        //}


        //public void Update(GameTime gameTime) {
        //    for (int i = 0; i < this.elements.Count; i++) {
        //        if (i < this.elements.Count)
        //            this.elements[i].Update(gameTime);

        //        if (this.elements[i].TTL <= 0) {
        //            this.elements.RemoveAt(i);
        //            --i;
        //        }
        //    }


        //    if (this.elements.Count > 3)
        //        return;

        //    Random random = new Random();
        //    //int X = random.Next(this.wildlife.Zone[0], this.wildlife.Zone[2]);
        //    //int Y = random.Next(this.wildlife.Zone[1], this.wildlife.Zone[3]);

        //    //this.second += (float)gameTime.ElapsedGameTime.TotalSeconds;
        //    //if (this.second >= random.Next(0, 5)) {
        //    //    this.second = 0;
        //    //    this.elements.Add(new SpriteElement(texture, this.animation) { Position = new Vector2(X, Y), TTL = 20 });
        //    //}

            

        //}

        //public void Draw(GameTime gameTime) {
        //    foreach (SpriteElement sprite in this.elements)
        //        sprite.Draw(gameTime);
        
        //}
    }
}
