using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using DoozyEngine.Hud;

namespace DoozyEngine.Input
{
    public class InputKey
    {
        // parameters
        public Keys? Key;
        public Buttons? Button;
        public Vector2? ThumbStickValue;

        public float Cooldown = 250;

        // modified value
        private float timer;
        public Vector2? oldThumbStickValue;

        public void Update(GameTime gameTime) {
            this.timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public bool isPressed() {
            bool ret = this.timer >= this.Cooldown &&
                ((Key.HasValue && Keyboard.GetState().IsKeyDown(Key.Value)) || (Button.HasValue && GamePad.GetState(PlayerIndex.One).IsButtonDown(Button.Value)));

            if (ret)
                this.timer = 0;
            return ret;
        }
    };
}
