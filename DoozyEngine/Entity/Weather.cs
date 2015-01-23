using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Timers;
using System.Threading;
using DoozyEngine.Entity;

namespace DoozyEngine
{
    // TODO : Afficher des nuages
    // TODO : pluie + vent + neige (systeme de particules)
    // TODO : Cycle Jour / Nuit
    public class Weather
    {
        private Thread thread;

        #region TIME_ATTRIBUTES

        // timer pour le temps
        private System.Timers.Timer timer;

        private Effect effect;

        // texture bleu pour simuler la nuit
        private RenderTarget2D render = null;
        public RenderTarget2D RenderTarget { set { this.render = value; } }

        private Texture2D nightTexture;
        // alpha pour afficher la nuit
        private float nightAlpha = 1f;

        // si le temp est en cours de transition
        private bool isTransition = true;
        // si il fait nuit
        private bool isNight = true;

        #endregion

        // systeme de particules
        //private ParticleEngine particleEngine;

        //private CloudEngine cloudEngine;
        private object weather;

        public string SetWeather {
            set {
                if (value == "Rain")
                    weather = new Rain();

            }
        }

        public Weather() {
            this.thread = new Thread(this.Update);
            this.thread.IsBackground = true;

            // region pour le system de temps
            #region TIME

            // initialisation du timer pour le temps
            this.timer = new System.Timers.Timer();
            // tick rate setter a sec * 1000ms/
            this.timer.Interval = 30 * 1000;
            // event lors du tick rate
            //this.timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            // start du timer
            this.timer.Start();

            // initialisation de la texture pour simuler la nuit
            
            // set une couleur bleue nuit
            

            #endregion

            // region pour le systeme de particules
            #region PARTICULE_SYSTEM

            // initialisation du systeme de particules
            //this.particleEngine = new SnowParticle();

            #endregion


            // region pour le systeme de nuages (et de brouillard)
            #region CLOUD_SYSTEM

            //this.cloudEngine = new CloudEngine();


            #endregion
        }

        public void Start() {
            //this.thread.Start();
        }

        public void LoadContent() {
            TextureManager.Instance.AddTexture(@"images/weather");

            this.render = new RenderTarget2D(RootEngine.Graphics, RootEngine.GraphicController.Width, RootEngine.GraphicController.Height);
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e) {
            this.isTransition = true;
        }

        private void ChangeTime() {
            // si le tps est en cours de transition
            if (this.isTransition) {
                // si il fait nuit et que la luminosite est toujours basse
                if (this.isNight && this.nightAlpha > 0)
                    this.nightAlpha -= 0.005f;
                // si il fait jour et que la luminosite est toujours haute
                else if (!this.isNight && this.nightAlpha < 0.6f)
                    this.nightAlpha += 0.005f;

                // arrondi du float pck sinon on se retrouve avec des valeurs comme : 0.0000001
                this.nightAlpha = (float)(Math.Round(this.nightAlpha, 3));
                // si la luminosite est a fond
                if (this.nightAlpha == 0f || this.nightAlpha == 0.6f) {
                    // on est plus en transition
                    this.isTransition = false;

                    // si nightAplah == 0 alors on est le jour
                    if (this.nightAlpha == 0) this.isNight = false;
                    // si nightAplha == 0.6f alors on est la nuit
                    else this.isNight = true;
                }
            }
        }

        private void Update() {
            while (this.thread.IsAlive) {
                //this.cloudEngine.Update();
                //this.particleEngine.Update();

                if (!RootEngine.IsPause)
                    this.ChangeTime();

                Thread.Sleep(16);
            }
        }

        public void Update(GameTime gameTime) {
            if (this.weather is Rain)
                ((Rain)this.weather).Update(gameTime);
        }

        public RenderTarget2D Draw(RenderTarget2D prerender, GameTime gameTime) {
            if (this.weather is Rain)
                ((Rain)this.weather).Draw(gameTime);

            RootEngine.Graphics.SetRenderTargets(this.render);
            RootEngine.Graphics.Clear(Color.TransparentBlack);

            DisplayManager.SpriteBatch.Begin();

            DisplayManager.SpriteBatch.Draw((Texture2D)prerender, Vector2.Zero, Color.White * this.nightAlpha);

            if (this.weather is Rain)
                DisplayManager.SpriteBatch.Draw((Texture2D)((Rain)this.weather).Render, Vector2.Zero, Color.White);

            DisplayManager.SpriteBatch.End();

            return this.render;
        }
    }
}
