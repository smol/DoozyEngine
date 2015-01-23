using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoozyEngine
{
    //public struct GraphicData
    //{
    //    public int WidthScreen;
    //    public int HeightScreen;

    //    public bool FullScreen;
    //}

    public class GraphicController
    {
        public static short TILE_SIZE = 128;

        public GraphicsDeviceManager GraphicsManager = null;

        public int Width { get { return this.GraphicsManager.PreferredBackBufferWidth; } }
        public int Height { get { return this.GraphicsManager.PreferredBackBufferHeight; } }
        public bool FullScreen { get { return this.GraphicsManager.IsFullScreen; } }

        public DisplayModeCollection DisplayModes { get { return GraphicsAdapter.DefaultAdapter.SupportedDisplayModes; } }

        private Vector2 scale;
        public Vector2 Scale { get { return this.scale; } }

        private Game game;

        public GraphicController(Game game)
        {

            this.game = game;
            // TODO: Complete member initialization
            this.GraphicsManager = new GraphicsDeviceManager(game);
        }

        /*
         * 600 est l'échelle de base pour afficher a la bonne taille les sprites
         */
        public void ResetGraphic()
        {
            if (this.GraphicsManager == null) return;


            Screen screen = Screen.AllScreens.First(e => e.Primary);
            
            
            //this.game.Window.IsBorderless = RootEngine.Modules.GraphicsParser.FullScreen;
            //this.game.Window.Position = new Point((screen.Bounds.Width / 2) - (RootEngine.Modules.GraphicsParser.Width / 2), (screen.Bounds.Height / 2) - (RootEngine.Modules.GraphicsParser.Height / 2));
            
            

            this.GraphicsManager.PreferredBackBufferWidth = RootEngine.GraphicConfig.Width;
            this.GraphicsManager.PreferredBackBufferHeight = RootEngine.GraphicConfig.Height;
            this.GraphicsManager.IsFullScreen = RootEngine.GraphicConfig.FullScreen;
            this.scale.X = this.scale.Y = (float)(this.GraphicsManager.PreferredBackBufferWidth) / 1920;
            //this.scale.X = this.scale.Y = 0.7f;
            this.GraphicsManager.ApplyChanges();
        }

    }
}
