using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DoozyEngine.Menu
{
    public class MenuRoot
    {
        // menu courant a afficher et a update
        private MenuScreen currentScreen;

        public MenuRoot(MenuScreen screen)
        {
            // le premier menu est 'toujours' le menu principal
            this.currentScreen = screen;
        }

        public void LoadContent()
        {
            // load des ressources du menu courant
            if (this.currentScreen != null)
                this.currentScreen.LoadContent();
        }

        public void UnloadContent() {
            if (this.currentScreen != null)
                this.currentScreen.UnloadContent();
        }

        public bool Update(GameTime gameTime)
        {
            if (this.currentScreen == null)
                return false;

            this.currentScreen.Update(gameTime);

            // update du menu courant, retour du prochain menu
            MenuScreen screen = this.currentScreen.NextScreen;
            
            // si temp est setter ou qu'il est different du menu courant 
            // alors menu suivant
            if (screen != null && screen != this.currentScreen)
            {
                this.currentScreen.UnloadContent();
                this.currentScreen = screen;
                this.currentScreen.LoadContent();
            }

            return true;
        }

        public void Draw(GameTime gameTime)
        {
            if (this.currentScreen == null)
                return;

            this.currentScreen.Draw(gameTime);
        }
    }
}
