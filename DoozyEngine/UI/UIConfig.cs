using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using DoozyEngine.Entity;

namespace DoozyEngine.UI
{
    public class UIConfig
    {
        static private Texture2D texture = new Texture2D(RootEngine.Graphics, 1, 1);
        static private Texture2D backgroundText = new Texture2D(RootEngine.Graphics, 1, 1);
        static private SpriteFont spriteFont;

        static public SpriteFont SpriteFont { get { return UIConfig.spriteFont; } }

        public UIConfig()
        {
            UIConfig.texture.SetData(new Color[] { Color.White });
            UIConfig.backgroundText.SetData(new Color[] { Color.Black });
            UIConfig.spriteFont = TextureManager.Instance.GetFont("FONT");
        }
    }
}
