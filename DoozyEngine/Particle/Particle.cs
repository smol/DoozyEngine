using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using DoozyEngine.Entity;

namespace DoozyEngine.Particle
{
    public class FireParticle : Particle
    {
        private float PositionY;

        public FireParticle(Texture2D texture, Vector2 position, Vector2 velocity,
            Color color, float size, int ttl) : 
            base(texture, position, velocity, color, size, ttl)
        {
            PositionY = position.Y;
        }

        public override void Update()
        {
            this.TTL--;
            position += velocity;

            if (TTL < 100)
                this.color = Color.Black;
            else if (TTL > 200 && this.size > 0)
                this.size -= 0.01f;
            else
                this.color = Color.Orange;

            //base.Update();
        }
    }

    public class Particle
    {
        private Texture2D texture;

        protected Vector2 position;
        protected Vector2 velocity;

        protected float size;

        protected Color color;

        // le 'time-to-live' de la particule
        public int TTL {get; set; }
        protected int ttlMax;

        protected float layer = 1f;

        public Particle(Texture2D texture, Vector2 position, Vector2 velocity,
            Color color, float size, int ttl)
        {
            this.color = color;
            this.texture = texture;

            this.position = position;
            this.velocity = velocity;

            this.size = size;

            this.TTL = this.ttlMax = ttl;
        }


        public virtual void Update()
        {
            this.TTL--;
            position += velocity;

            if (this.size > 0)
                this.size -= 0.01f;
        }

        public void Draw()
        {
            Vector2 origin = new Vector2(this.texture.Width / 2, this.texture.Height / 2);
            DisplayManager.SpriteBatch.Draw(this.texture, this.position, null, 
                this.color, 0, origin, this.size, SpriteEffects.None, 1f);
        }
    }
}
