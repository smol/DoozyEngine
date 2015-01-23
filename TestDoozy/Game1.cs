#region Using Statements
using System;
using System.Collections.Generic;
using DoozyEngine.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using DoozyEngine;
using DoozyEngine.Entity;

#endregion

namespace TestDoozy {

    public class Space : Sprite
    {
        private InputEvent input = InputEvent.Instance;

        public Space() : base("spaceship1") {
            
        }

        public override void Update(GameTime gameTime) {
            if (input["moveLeft"])
                position.X -= (float)gameTime.ElapsedGameTime.TotalSeconds * 20f;
            if (input["moveRight"])
                position.X += (float)gameTime.ElapsedGameTime.TotalSeconds * 20f;
            if (input["moveUp"])
                position.Y -= (float)gameTime.ElapsedGameTime.TotalSeconds * 20f;
            if (input["moveDown"])
                position.Y += (float)gameTime.ElapsedGameTime.TotalSeconds * 20f;
            base.Update(gameTime);
        }
    }

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        private RootEngine engine;
        private DisplayManager displayManager;

        private Texture2D text;

        private InputEvent inputEvent;

        public Game1()
            : base() {
            this.engine = new RootEngine(this);
            this.displayManager = new DisplayManager();

            this.inputEvent = InputEvent.Instance;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent() {
            this.engine.LoadContent();

            this.displayManager.LoadContent();

            TextureManager.Instance.AddTexture("background_space");
            TextureManager.Instance.AddTexture("spaceship1");

            this.text = TextureManager.Instance.GetTexture("background_space");

            DisplayManager.AddSprite(new Sprite("background_space") { Position = Vector2.Zero, Layer = 0 });
            DisplayManager.AddSprite(new Space() { Position = new Vector2(1,1), Layer = 1});



            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            this.displayManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            this.engine.Draw(gameTime);


            this.displayManager.Draw(gameTime);

            //DisplayManager.SpriteBatch.Begin();

            //DisplayManager.SpriteBatch.Draw(this.text, Vector2.Zero, Color.White);

            //DisplayManager.SpriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
