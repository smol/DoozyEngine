using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoozyEngine.Entity;
using DoozyEngine.Hud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoozyEngine.UI
{
    public class UIView : UIObject
    {
        protected List<UIObject> children = new List<UIObject>();


        public UIView() : base() {
            
        }

        public override int Update(GameTime gameTime) {
            for (int i = 0; i < this.children.Count; i++) {
                this.children[i].Draw(gameTime);
            }
            return 0;
        }

        public override void Draw(GameTime gameTime) {
            for (int i = 0; i < this.children.Count; i++) {
                this.children[i].Draw(gameTime);
            }

            base.Draw(gameTime);
        }

        public void AddChildren(UIObject child) {
            child.Parent = this;
            this.Layer -= 0.001f;
            this.children.Add(child);
        }

        public void RemoveChildren(UIObject child) {
            this.children.Remove(child);
        }
    }
}
