using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoozyEngine.Particle
{
    public abstract class ParticleEngine
    {
        public enum Type : int {
            Blood = 0,  
        };

        protected int particleNb;

        protected Random random;

        protected List<Particle> particles;
        public List<Particle> Particles { get { return this.particles; } }

        protected Texture2D texture;

        protected Vector2 position;


        public ParticleEngine(Texture2D texture)
        {
            this.particleNb = 20;
            this.texture = texture;
            this.particles = new List<Particle>();
            random = new Random();
        }

        public virtual void Update(GameTime gameTime)
        {
            for (int particle = 0; particle < this.particles.Count; particle++)
            {
                this.particles[particle].Update();
                if (this.particles[particle].TTL <= 0)
                {
                    this.particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        public void AddParticle(Vector2 position)
        {
            this.position = position;

            for (int i = 0; i < this.random.Next(this.particleNb / 2, this.particleNb); i++)
                this.particles.Add(GenerateNewParticle());
        }

        public abstract Particle GenerateNewParticle();

        public void Draw()
        {
            for (int index = 0; index < particles.Count; index++)
            {
                try { particles[index].Draw(); }
                catch (ArgumentOutOfRangeException exception)
                {
                    Console.WriteLine("Error in the particle drawing", exception);
                    index = -1;
                }
            }
        }
    }
}
