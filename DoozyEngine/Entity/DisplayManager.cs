using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DoozyEngine.UI;
using DoozyEngine.Particle;

namespace DoozyEngine.Entity
{
    public class DisplayManager
    {
        static private SpriteBatch spriteBatch;
        static public SpriteBatch SpriteBatch { get { return DisplayManager.spriteBatch; } }

        static protected LightEngine lightEngine = new LightEngine();
        static protected Weather weather =null;
        static public Weather Weather { get { return DisplayManager.weather; } }

        static protected List<UIObject> floatUiViews = new List<UIObject>();
        static protected List<UIObject> uiViews = new List<UIObject>();

        static protected List<BackgroundElement> backgroundElements = new List<BackgroundElement>();
        static protected List<Sprite> sprites = new List<Sprite>();

        private RenderTarget2D floatElements = null;
        private RenderTarget2D rain = null;

        static public List<ParticleEngine> Particles = new List<ParticleEngine>();

        public static Color AmbientColor = Color.White;


        #region REMOVE

        static public void RemoveSprite(Sprite sprite) {
            DisplayManager.sprites.Remove(sprite);
        }

        static public void RemoveUI(UIObject uiObject) {
            if (DisplayManager.uiViews.Contains(uiObject))
                DisplayManager.uiViews.Remove(uiObject);
            else if (DisplayManager.floatUiViews.Contains(uiObject))
                DisplayManager.floatUiViews.Remove(uiObject);
        }

        #endregion // REMOVE

        #region ADD

        static public int AddBackgroundElement(BackgroundElement element) {
            DisplayManager.backgroundElements.Add(element);
            return 0;
        }

        static public int AddUI(UIObject element, bool isFloat = false) {
            if (isFloat && DisplayManager.floatUiViews != null && !DisplayManager.floatUiViews.Contains(element)) {
                DisplayManager.floatUiViews.Add(element);
                return 0;
            }
            else if (DisplayManager.uiViews != null && !DisplayManager.uiViews.Contains(element)) {
                DisplayManager.uiViews.Add(element);
                return 0;
            }
            return -1;
        }

        static public int AddSprite(Sprite sprite) {
            if (DisplayManager.sprites != null && sprite != null) {
                DisplayManager.sprites.Add(sprite);
                return 0;
            }
            return -1;
        }

        #endregion // ADD


        #region GET

        static public List<object> GetSprites<T>() {
            List<object> list = new List<object>();

            for (int i = 0; i < DisplayManager.sprites.Count; i++) {
                if (DisplayManager.sprites[i] is T)
                    list.Add(DisplayManager.sprites[i]);
            }

            return list;
        }

        #endregion

        public virtual void LoadContent()
        {
            
            DisplayManager.spriteBatch = new SpriteBatch(RootEngine.Graphics);
            
            //if (RootEngine.Modules.Light)
                DisplayManager.lightEngine.LoadContent();

            this.floatElements = new RenderTarget2D(RootEngine.Graphics, RootEngine.GraphicController.Width, RootEngine.GraphicController.Height);

            //DisplayManager.weather = new Weather();
            //DisplayManager.weather.LoadContent();
            //DisplayManager.weather.Start();
        }

        public virtual void UnloadContent() {
            
        }

        public virtual int Update(GameTime gameTime)
        {

            if (RootEngine.IsPause) return -1;

            //if (DisplayManager.uiViews.Count > 0) {
                
            //    for (int i = 0; i < DisplayManager.uiViews.Count; i++)
            //        DisplayManager.uiViews[i].Update(gameTime);

            //}
            int returnCode = 0;

            for (int i = DisplayManager.uiViews.Count - 1; i >= 0 && DisplayManager.uiViews.Count > 0; i--) {
                returnCode = DisplayManager.uiViews[i].Update(gameTime);
                if (returnCode == -1) {
                    DisplayManager.uiViews.RemoveAt(i);
                    i++;
                }
                else if (returnCode == 1)
                    return -1;

                if (i >= DisplayManager.uiViews.Count)
                    i = DisplayManager.uiViews.Count - 1;
            }

            if (returnCode == 1)
                return -1;

            for (int i = DisplayManager.floatUiViews.Count - 1; i >= 0 && DisplayManager.floatUiViews.Count > 0; i--) {
                returnCode = DisplayManager.floatUiViews[i].Update(gameTime);
                if (returnCode == -1) {
                    DisplayManager.floatUiViews.RemoveAt(i);
                    i++;
                }
                else if (returnCode == 1)
                    return -1;

                if (i >= DisplayManager.floatUiViews.Count)
                    i = DisplayManager.floatUiViews.Count - 1;
            }

            if (returnCode == 1)
                return -1;

            for (int i = 0; i < DisplayManager.sprites.Count; i++)
                DisplayManager.sprites[i].Update(gameTime);

            for (int i = 0; i < DisplayManager.Particles.Count; i++)
                DisplayManager.Particles[i].Update(gameTime);

            //if (RootEngine.Modules.Light)
                DisplayManager.lightEngine.Update(gameTime);

            //for (int i = 0; i < DisplayManager.backgroundElements.Count; i++)
            //    DisplayManager.backgroundElements[i].Update(gameTime);


            //for (int i = 0; i < DisplayManager.floatBars.Count; i++)
            //    DisplayManager.floatBars[i].Update(gameTime);

            //if (DisplayManager.weather != null)
            //    DisplayManager.weather.Update(gameTime);

            return 0;
        }

        public virtual void Draw(GameTime gameTime)
        {
            
            RootEngine.Graphics.SetRenderTarget(this.floatElements);
            DisplayManager.spriteBatch.Begin(SpriteSortMode.FrontToBack,
                    BlendState.AlphaBlend, SamplerState.LinearWrap,
                    null, null, null, Camera.GetTransform());

            try
            {

                for (int i = 0; i < DisplayManager.sprites.Count; i++)
                    DisplayManager.sprites[i].Draw(gameTime);

                for (int i = 0; i < DisplayManager.Particles.Count; i++)
                    DisplayManager.Particles[i].Draw();

                //for (int i = 0; i < DisplayManager.floatUiViews.Count; i++)
                //   



                for (int i = 0; i < DisplayManager.floatUiViews.Count; i++)
                    DisplayManager.floatUiViews[i].Draw(gameTime);

                //for (int i = 0; i < DisplayManager.floatUiViews.Count; i++)
                //    DisplayManager.floatUiViews[i].Draw(gameTime);

                //for (int i = 0; i < DisplayManager.backgroundElements.Count; i++)
                //    DisplayManager.backgroundElements[i].Draw(gameTime);

            }
            finally
            {
                DisplayManager.spriteBatch.End();
                
                //if (DisplayManager.weather != null)
                //    this.rain = DisplayManager.weather.Draw(this.floatElements, gameTime);

                RootEngine.Graphics.SetRenderTarget(null);
                
                RootEngine.Graphics.Clear(Color.Black);

                DisplayManager.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
                DisplayManager.SpriteBatch.Draw((Texture2D)this.floatElements, Vector2.Zero, DisplayManager.AmbientColor);
                DisplayManager.SpriteBatch.End();
                

            }

            //DisplayManager.spriteBatch.Begin(SpriteSortMode.FrontToBack,
            //       BlendState.Additive, SamplerState.LinearWrap,
            //       null, null, null, Camera.GetTransform());

            //DisplayManager.lightEngine.Draw(gameTime);

            //DisplayManager.spriteBatch.End();

            #region FIXED ELEMENTS

            DisplayManager.spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend,
                null, null, null, null);

            try
            {
                //for (int i = 0; i < DisplayManager.fixedStrings.Count; i++)
                //    DisplayManager.spriteBatch.DrawString(DisplayManager.fixedStrings[i].SpriteFont, DisplayManager.fixedStrings[i].Text, DisplayManager.fixedStrings[i].Position, DisplayManager.fixedStrings[i].Color,
                //                                DisplayManager.fixedStrings[i].Rotation, DisplayManager.fixedStrings[i].Origin, DisplayManager.fixedStrings[i].Scale, DisplayManager.fixedStrings[i].SpriteEffects, DisplayManager.fixedStrings[i].LayerDepth);

                //for (int i = 0; i < DisplayManager.fixedBars.Count; i++)
                //    DisplayManager.fixedBars[i].Draw(gameTime);

                //if (RootEngine.Modules.Hud) {
                //    for (int i = 0; i < DisplayManager.uiViews.Count; i++)
                //        DisplayManager.uiViews[i].Draw(gameTime);
                //}
            }
            finally
            {
                DisplayManager.spriteBatch.End();
            }

            #endregion // FIXED ELEMENT
        }
    }
}
