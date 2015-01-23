using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using DoozyEngine.Entity;

namespace DoozyEngine.Particle
{
    public class BloodParticles : ParticleEngine
    {

        public BloodParticles() :
            base(TextureManager.Instance.GetTexture(@"images\bloodParticle"))
        {
            this.particleNb = 20;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override Particle GenerateNewParticle()
        {
            Vector2 velocity = new Vector2(this.random.Next(-2,3), this.random.Next(-2,3));
            velocity.X *= (float)(this.random.NextDouble());
            velocity.Y *= (float)(this.random.NextDouble());

            float size = (float)(random.NextDouble());
            int ttl = 30 + random.Next(50);

            return new Particle(this.texture, this.position, velocity, Color.Red * (float)(random.NextDouble()), size, ttl);
        }
    }
}
