using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StarBattle.Screens;
using StarBattle.Screens.Gameplay;

namespace StarBattle {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game {

        public static Game instance;

        GraphicsDeviceManager graphics;
        public ScreenManager screenManager;

        public float screenWidth {
            get {
                return graphics.PreferredBackBufferWidth;
            }
        }
        public float screenHeight {
            get {
                return graphics.PreferredBackBufferHeight;
            }
        }

        public Game() {
            instance = this;

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsFixedTimeStep = true;
            TargetElapsedTime = System.TimeSpan.FromMilliseconds(16);

            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 576;

            screenManager = new ScreenManager();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // TODO: use this.Content to load your game content here

            screenManager.LoadContent();
            screenManager.addScreen(new MazeRun());
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            // TODO: Add your update logic here

            base.Update(gameTime);
            screenManager.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            screenManager.Draw();
            base.Draw(gameTime);          
        }
    }
}
