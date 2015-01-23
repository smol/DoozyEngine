using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using DoozyEngine.Hud;

namespace DoozyEngine.Input
{
    public class InputEvent
    {
        struct Input
        {
            public float cooldown;
            public float timer;

            public Keys? keys;
            public Buttons? buttons;
        }

        private GamePadState gamePad = GamePad.GetState(PlayerIndex.One);

        private static InputEvent instance = null;
        public static InputEvent Instance {
            get {
                if (InputEvent.instance == null)
                    InputEvent.instance = new InputEvent();
                return InputEvent.instance;
            }
        }

        public Dictionary<string, InputKey> Actions;

        private GameTime gameTime = null;
        private float cooldown = 0;

        public bool this[string value] {
            get { return this.Actions[value].isPressed(); }
        }

        private InputEvent()
        {
            this.Actions = new Dictionary<string, InputKey>();
            this.Actions.Add("debugMode", new InputKey() { Key = Keys.F1 });
            this.Actions.Add("activate", new InputKey() { Key = Keys.E, Button = Buttons.A});

            this.Actions.Add("changeSpellUp", new InputKey() { Button = Buttons.LeftShoulder });
            this.Actions.Add("changeSpellDown", new InputKey() { Button = Buttons.RightShoulder });

            this.Actions.Add("moveDown", new InputKey() { Key = Keys.S, Cooldown = 0 });
            this.Actions.Add("moveUp", new InputKey() { Key = Keys.Z, Cooldown = 0 });
            this.Actions.Add("moveLeft", new InputKey() { Key = Keys.Q, Cooldown = 0 });
            this.Actions.Add("moveRight", new InputKey() { Key = Keys.D, Cooldown = 0 });

            this.Actions.Add("spellDown", new InputKey() { Key = Keys.Down, Button = Buttons.DPadDown, Cooldown = 0 });
            this.Actions.Add("spellUp", new InputKey() { Key = Keys.Up, Button = Buttons.DPadUp, Cooldown = 0 });
            this.Actions.Add("spellLeft", new InputKey() { Key = Keys.Left, Button = Buttons.DPadLeft, Cooldown = 0 });
            this.Actions.Add("spellRight", new InputKey() { Key = Keys.Right, Button = Buttons.DPadRight, Cooldown = 0 });

            this.Actions.Add("menu", new InputKey() { Key = Keys.LeftControl, Button = Buttons.RightTrigger, Cooldown = 0 });
        }

        public bool Update(GameTime gameTime)
        {
            this.gameTime = gameTime;
            this.cooldown += (float)this.gameTime.ElapsedGameTime.TotalMilliseconds;
            if (this.cooldown > 10000)
                this.cooldown = 0;

            foreach (KeyValuePair<string, InputKey> keyValuePair in this.Actions) {
                keyValuePair.Value.Update(gameTime);
            }

            // Allows the game to exit
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
            //    Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    return false;

            if (this["debugMode"])
                RootEngine.DebugMode = !RootEngine.DebugMode;

            return true;
        }
    }
}
