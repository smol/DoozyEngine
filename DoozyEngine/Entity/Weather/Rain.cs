using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoozyEngine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoozyEngine
{
    class Item
    {
        public Vector2 Position = Vector2.Zero;
        public float Time = 0;
        public float TTL = 0;
        public bool IsFinish = false;
        public int indexAnimation = 0;
    }

    public class Rain
    {
        private Rectangle drop = new Rectangle(0, 18, 18, 34);
        private List<Rectangle> dropped = new List<Rectangle>();
        private Texture2D texture;
        private RenderTarget2D render;
        public RenderTarget2D Render { get { return this.render; } }


        private List<Item> items = new List<Item>();
        private Random rand = new Random();
        private float timeLapsed = 0f, timeDuring = 0f;

        private Vector2 size = new Vector2(2048, 2048);

        public Rain() {
            this.texture = TextureManager.Instance.GetTexture(@"images/weather");
            this.render = new RenderTarget2D(RootEngine.Graphics, RootEngine.GraphicController.Width, RootEngine.GraphicController.Height);
            this.dropped.Add(new Rectangle(38, 0, 16, 16));
            this.dropped.Add(new Rectangle(18, 0, 16, 16));
            this.dropped.Add(new Rectangle(2, 0, 16, 16));
        }

        public void Update(GameTime gameTime) {
            timeLapsed += (float)(gameTime.ElapsedGameTime.TotalMilliseconds);
            timeDuring += (float)(gameTime.ElapsedGameTime.TotalMilliseconds);


            if (timeLapsed >= 0) {
                this.items.Add(new Item() { 
                    Position = new Vector2((float)(rand.NextDouble() * (size.X - Camera.Position.X)), (float)(rand.NextDouble() * (10 - Camera.Position.Y))),
                    TTL = rand.Next(100, 2000)
                });
                timeLapsed = 0;
            }

            if (timeDuring >= 20){
                for (int i = 0; i < this.items.Count; i++) {
                    this.items[i].Time += (float)(gameTime.ElapsedGameTime.TotalMilliseconds);

                    if (this.items[i].IsFinish) {
                        if (this.items[i].indexAnimation >= this.dropped.Count) {
                            this.items.RemoveAt(i);
                            i--;
                        }
                        continue;
                    }

                    if (this.items[i].Time >= this.items[i].TTL) {
                        this.items[i].IsFinish = true;
                        this.items[i].Time = 0;
                    }
                    else {
                        this.items[i].Position.Y += 20;
                        this.items[i].Position.X -= 10;
                    }
                }
                timeDuring = 0;
            }
        }

        public void Draw(GameTime gameTime) {
            RootEngine.Graphics.SetRenderTarget(this.render);
            RootEngine.Graphics.Clear(Color.TransparentBlack);
            DisplayManager.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.LinearWrap, null, null, null, Camera.GetTransform());
            //DisplayManager.SpriteBatch.Begin();
            for (int i = 0; i < this.items.Count; i++) {
                if (!this.items[i].IsFinish)
                    DisplayManager.SpriteBatch.Draw(this.texture, this.items[i].Position, this.drop, Color.White);
                else {
                    this.items[i].Time += (float)(gameTime.ElapsedGameTime.TotalMilliseconds);

                    if (this.items[i].Time > 500) {
                        this.items[i].Time = 0;

                        this.items[i].indexAnimation++;

                    }
                    if (this.items[i].indexAnimation < this.dropped.Count)
                        DisplayManager.SpriteBatch.Draw(this.texture, this.items[i].Position, this.dropped[this.items[i].indexAnimation], Color.White);
                }
            }

            DisplayManager.SpriteBatch.End();
        }
    }
}
