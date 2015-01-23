using Microsoft.Xna.Framework;
using DoozyEngine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoozyEngine.Entity
{
    public class LightEngine
    {
        public List<Light> lights = new List<Light>();

        public LightEngine() {
            

        }

        public void LoadContent() {
            //TextureManager.Instance.AddTexture(@"images\halo");

            this.lights.Add(new Light() { Position = new Vector2(200, 200) }); 
        }

        public void Update(GameTime gameTime) {
            foreach (Light prime in this.lights) {
                prime.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime) {
            foreach (Light prime in this.lights) {
                prime.Draw(gameTime);
            }
        }
    }
}
