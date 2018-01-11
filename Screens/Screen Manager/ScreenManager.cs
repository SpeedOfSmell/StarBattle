using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBattle.Screens {
    enum Side { Left, Right } // Side of screen player is on
    enum PaddleColor { Blue, Orange } 

    public class ScreenManager {       
        private ContentManager content; // Content shared by all screens
        private Stack<GameScreen> screens; // Stack of the game's screens. When the top screen is popped, the one below appears
        public GameScreen topScreen { get; private set; }

        public SpriteBatch spriteBatch { get; protected set; } // Global spriteBatch used by all screens
        public SpriteFont font { get; private set; } // Global font 

        public ScreenManager() {
            content = new ContentManager(Game.instance.Content.ServiceProvider, Game.instance.Content.RootDirectory);
            screens = new Stack<GameScreen>();        
        }

        public void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(Game.instance.GraphicsDevice);
            font = content.Load<SpriteFont>("Global");
        }

        public void addScreen(GameScreen screen) {
            screens.Push(screen); // Add new screen
            topScreen = screen;
            topScreen.LoadContent(); // Add new content
            Game.instance.IsMouseVisible = topScreen.mouseVisible;
        }

        public void exitScreen() {
            topScreen.UnloadContent(); // Unload current content
            screens.Pop(); // Delete screen
            if (screens.Count > 0) {
                topScreen = screens.Peek();
                topScreen.state = ScreenState.Active;
                Game.instance.IsMouseVisible = topScreen.mouseVisible;
            } else Game.instance.Exit(); // Quit game if there are no screens
        }

        public void Update(GameTime gameTime) {
            GameScreen[] screensToUpdate = new GameScreen[screens.Count];
            screens.CopyTo(screensToUpdate, 0);

            for (int i = screensToUpdate.Length - 1; i >= 0; i--) {
                if ((screensToUpdate[i].state == ScreenState.TransitionOn || screensToUpdate[i].state == ScreenState.Active) && !screensToUpdate[i].paused)
                    screensToUpdate[i].Update(gameTime);
            }

            //topScreen.Update();
        }

        public void Draw() {         
            GameScreen[] screensToDraw = new GameScreen[screens.Count];
            screens.CopyTo(screensToDraw, 0);

            for (int i = screensToDraw.Length - 1; i >= 0; i--) {
                if (screensToDraw[i].state == ScreenState.TransitionOn || screensToDraw[i].state == ScreenState.Active)
                    screensToDraw[i].Draw();
            }

            /*
            spriteBatch.Begin();
            spriteBatch.DrawString(font, topScreen.objectsOnScreen["players"][0].sourceRectangle.ToString(), new Vector2(15, 15), Color.Black);
            spriteBatch.End();
            */

            //Console.WriteLine(topScreen.objectsOnScreen["players"][0].sourceRectangle.ToString());
            
        }
    }
}
