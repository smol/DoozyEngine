using Microsoft.Xna.Framework;
using DoozyEngine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoozyEngine.Particle
{
    public class FireParticles : ParticleEngine
    {
        private Vector2 position;

        protected int size;

        private float timer;

        

        public FireParticles(Vector2 position) :
            base(TextureManager.Instance.GetTexture(@"images\snowParticle"))
        {
            this.particleNb = 2;
            this.position = position;
        }

        public override void Update(GameTime gameTime)
        {
                this.AddParticle(this.position);

            base.Update(gameTime);
        }


        public override Particle GenerateNewParticle() 
        {
            Vector2 velocity = new Vector2(0, -(float)(1));
            //velocity.X *= (float)(this.random.NextDouble());
            //velocity.Y *= (float)(this.random.NextDouble());
            //1f * (float)(random.NextDouble() * 2 - 1),
            //1f * (float)(random.NextDouble() * 2 - 1));

            float size = (float)(random.NextDouble() * 2);
            int ttl = 200 + random.Next(100);

            Vector2[] param = { velocity, Vector2.Zero };

            //this.position.X += (float)(this.random.NextDouble());
            Vector2 position = this.position;
            position.X += (float)(this.random.NextDouble());

            return new FireParticle(this.texture, position, velocity, Color.Orange * (float)(random.NextDouble()), size, ttl);
        }
    }
}
