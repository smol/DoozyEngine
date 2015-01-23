using System.Web.Script.Serialization;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using DoozyEngine.Input;

using System.IO;
//using Microsoft.Xna.Framework.Storage;
using DoozyEngine.Entity;
using DoozyEngine.UI;

namespace DoozyEngine
{
    public class RootEngine
    {
        public static bool DebugMode = false;
        public static bool IsPause = false;
        public static Color Color = Color.CornflowerBlue;

        public static ContentManager ContentManager;

        public static GraphicsDevice Graphics;
        public static GraphicsDeviceManager GraphicsManager;

        private static GraphicController graphicController;
        public static GraphicController GraphicController
        {
            get { return RootEngine.graphicController; }
        }

        private InputEvent inputEvent;

        private Game game;
        private UI.UIConfig uiConfig;
        

        public static Config.Graphic GraphicConfig;
        public static Config.Modules Modules;

        public RootEngine(Game game)
        {
#if DEBUG
            RootEngine.DebugMode = true;
#endif

            this.game = game;
            this.game.Content.RootDirectory = "Content";
            RootEngine.ContentManager = this.game.Content;

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            using (StreamReader sr = new StreamReader("Content/graphic_config.json")) {
                RootEngine.GraphicConfig = jsonSerializer.Deserialize<Config.Graphic>(sr.ReadToEnd());
            }

#if DEBUG
            using (StreamReader sr = new StreamReader("Content/module.json")) {
                RootEngine.Modules = jsonSerializer.Deserialize<Config.Modules>(sr.ReadToEnd());
            }
#endif

            RootEngine.graphicController = new GraphicController(game);
            RootEngine.graphicController.ResetGraphic();

#if WINDOWS_PHONE
            // Frame rate is 30 fps by default for Windows Phone.
            game.TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Extend battery life under lock.
            game.InactiveSleepTime = TimeSpan.FromSeconds(1);
#endif

            new TextureManager(game.Content);
            new SoundManager(game.Content);
        }

        public void LoadContent()
        {
            RootEngine.Graphics = this.game.GraphicsDevice;
            //RootEngine.Graphics.DepthStencilState = DepthStencilState.DepthRead;
            
            this.uiConfig = new UIConfig();
        }

        public void Initialize()
        {
            this.inputEvent = InputEvent.Instance;
        }

        public void Update(GameTime gameTime)
        {
            if (!this.inputEvent.Update(gameTime))
                this.game.Exit();

            
        }

        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(RootEngine.Color);

            
        }
    }
}
