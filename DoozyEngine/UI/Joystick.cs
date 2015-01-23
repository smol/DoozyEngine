using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using DoozyEngine.Entity;
using DoozyEngine.Utils;
using Microsoft.Xna.Framework.Input;

namespace DoozyEngine.Hud
{
    //public class Joystick : HudObject
    //{
    //    private Texture2D stick;

    //    private static Vector2 stickPosition;
    //    public static Vector2 StickPosition { get { return -Joystick.stickPosition; } }

    //    readonly private float DEADZONE = 0.2f;

    //    public Joystick() : base(new Vector2(128, 352))
    //    {
    //        texture = TextureManager.Instance.GetTexture(@"interface\joystickBck");
    //        stick = TextureManager.Instance.GetTexture(@"interface\joystick");

    //        this.hitbox = new Rectangle(128 - (texture.Width / 2), 352 - (texture.Height / 2),
    //                                    128 + (texture.Width / 2), 352 + (texture.Height / 2));

    //        Joystick.stickPosition = Vector2.Zero;
    //    }

    //    public override void Release(GameTime gameTime)
    //    {
    //        this.id = -1;
    //        Joystick.stickPosition = Vector2.Zero;

    //        if (timer > 0.5f)
    //            timer -= (float)(gameTime.ElapsedGameTime.Milliseconds) / 1000f;
    //        if (timer < 0.5f)
    //            timer = 0.5f;
    //    }

    //    public override void Update(GameTime gameTime) {
    //        base.Update(gameTime);

    //        //if (RootEngine.DebugMode) {
           
    //        //}
    //    }

    //    public override void Pressed(TouchLocation touch, GameTime gameTime)
    //    {
    //        Joystick.stickPosition = ((touch.Position - this.position) - this.offset) / -64;
                        

    //        if (Joystick.stickPosition.X >= -DEADZONE && Joystick.stickPosition.X <= DEADZONE) Joystick.stickPosition.X = 0;
    //        if (Joystick.stickPosition.Y >= -DEADZONE && Joystick.stickPosition.Y <= DEADZONE) Joystick.stickPosition.Y = 0;

    //        if (Joystick.stickPosition.X > 1) Joystick.stickPosition.X = 1;
    //        if (Joystick.stickPosition.X < -1) Joystick.stickPosition.X = -1;

    //        if (Joystick.stickPosition.Y > 1) Joystick.stickPosition.Y = 1;
    //        if (Joystick.stickPosition.Y < -1) Joystick.stickPosition.Y = -1;
    //    }

    //    public override void Draw(GameTime gameTime)
    //    {
    //        DisplayManager.SpriteBatch.Draw(texture, this.position, null, Color.White * timer, 0.0f, new Vector2(texture.Width / 2, texture.Height / 2), 1, SpriteEffects.None, 0.9999f);

    //        DisplayManager.SpriteBatch.Draw(stick, this.position + (Joystick.stickPosition * -64), null, Color.White * timer, 0.0f, new Vector2(stick.Width / 2, stick.Height / 2), 1, SpriteEffects.None, 1f);
            
    //    }

    //}
}
