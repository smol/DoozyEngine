using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using DoozyEngine;

namespace DoozyEngine.Particle
{
    //public class SnowParticle : ParticleEngine
    //{
    //    public SnowParticle() :
    //        base(RootEngine.ContentManager.Load<Texture2D>("images/snowParticle"))
    //    {
    //    }

    //    public override Particle GenerateNewParticle()
    //    {
    //        Vector2 position = new Vector2(random.Next((int)(RootEngine.GraphicController.Width - Camera.Position.X) + 200),
    //                                       random.Next((int)(RootEngine.GraphicController.Height - Camera.Position.Y) + 200));
    //        position.X -= 200;
    //        position.Y -= 200;

    //        Vector2 velocity = Vector2.One;
    //        //1f * (float)(random.NextDouble() * 2 - 1),
    //        //1f * (float)(random.NextDouble() * 2 - 1));

    //        float size = (float)(random.NextDouble() / 2);
    //        int ttl = 20 + random.Next(40);

    //        return new Particle(this.texture, position, velocity, Color.White, size, ttl);
    //    }
    //}
}
