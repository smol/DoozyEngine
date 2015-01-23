using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoozyEngine.Entity;
using Microsoft.Xna.Framework.Input.Touch;
using DoozyEngine.Utils;

namespace DoozyEngine.UI
{
    //public class UIButton : HudObject
    //{
    //    private readonly short BUTTON_SIZE = 64;

    //    private Texture2D texture;

    //    private Vector2 position;

    //    private float timer = 1;

    //    public delegate void callBack(object obj);

    //    private callBack callback;
    //    private object obj;

    //    public Button(string asset, Vector2 position, callBack callback, object obj) : base(position)
    //    {
    //        this.callback = callback;
    //        this.obj = obj;

    //        this.position = position;
    //        this.texture = TextureManager.Instance.GetTexture(asset);

    //        this.hitbox = new Rectangle((int)(position.X - (BUTTON_SIZE / 2)), (int)(position.Y - (BUTTON_SIZE / 2)),
    //                                    (int)(BUTTON_SIZE), (int)(BUTTON_SIZE));

    //    }

    //    public override void Release(GameTime gameTime)
    //    {
    //        if (this.IsPressed && this.callback != null)
    //            this.callback(this.obj);

    //        this.IsPressed = false;
    //        this.id = -1;
    //    }

    //    public override void  Pressed(TouchLocation touch, GameTime gameTime)
    //    {
    //        this.IsPressed = true;
    //    }

    //    public override void Draw(GameTime gameTime)
    //    {
    //        DisplayManager.SpriteBatch.Draw(texture, position, (!this.IsPressed ? new Rectangle(0,0,BUTTON_SIZE,BUTTON_SIZE) : new Rectangle(BUTTON_SIZE,0,BUTTON_SIZE,BUTTON_SIZE)), Color.White * timer, 0.0f, new Vector2(BUTTON_SIZE / 2, BUTTON_SIZE / 2), 1, SpriteEffects.None, 1f);
    //    }

    //}
}
