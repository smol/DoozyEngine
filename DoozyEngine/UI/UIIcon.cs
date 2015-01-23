using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DoozyEngine.UI {
    public class UIIcon : UIObject {
        public UIIcon(Rectangle sourceRectangle) {
            this.background = sourceRectangle;

            this.frame = new Rectangle(0,0,this.background.Value.Width, this.background.Value.Height);
        }

    }
}
