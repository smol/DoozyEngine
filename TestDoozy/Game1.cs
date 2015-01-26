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

    public class Shoot : Sprite
    {
        public delegate void Destroy(object self);

        private Vector2 direction = Vector2.Zero;
        public Destroy destroy = null;
        private float speed = 1f;

        public Shoot(Vector2 origin, Vector2 direction, Destroy destroy) : base("blast") {
            this.direction = direction;
            this.position = origin;

            this.destroy = destroy;
        }

        public override void Update(GameTime gameTime) {

            this.position.X += direction.X*(float)gameTime.ElapsedGameTime.Milliseconds * this.speed;
            this.position.Y += direction.Y*(float)gameTime.ElapsedGameTime.Milliseconds * this.speed;

            if (!Camera.ViewingRectangle.Contains(this.position))
                this.destroy(this);
            base.Update(gameTime);
        }
    }

    public class Space : Sprite
    {
        private InputEvent input = InputEvent.Instance;

        private double shootingTime = 0;
        private float speed = 0.5f;

        public Space() : base("spaceship1") {
            
        }

        public override void Update(GameTime gameTime) {
            if (input["moveLeft"])
                position.X -= (float)gameTime.ElapsedGameTime.Milliseconds * this.speed;
            if (input["moveRight"])
                position.X += (float)gameTime.ElapsedGameTime.Milliseconds * this.speed;
            if (input["moveUp"])
                position.Y -= (float)gameTime.ElapsedGameTime.Milliseconds * this.speed;
            if (input["moveDown"])
                position.Y += (float)gameTime.ElapsedGameTime.Milliseconds * this.speed;

            if (this.shootingTime >= 0.7f) {
                this.shootingTime = 0;
                Shoot shoot = new Shoot(this.position + (this.Size/-2), new Vector2(0, -1), this.RemoveShoot);


                DisplayManager.AddSprite(shoot);
            }

            this.shootingTime += gameTime.ElapsedGameTime.TotalSeconds;


            base.Update(gameTime);
        }

        private void RemoveShoot(object self) {
            DisplayManager.RemoveSprite(self as Sprite);
            self = null;
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
            TextureManager.Instance.AddTexture("blast");

            DisplayManager.AddSprite(new Sprite("background_space") { Position = Vector2.Zero, Layer = 0 });
            DisplayManager.AddSprite(new Space() { Position = new Vector2(100,100), Layer = 1});



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

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
