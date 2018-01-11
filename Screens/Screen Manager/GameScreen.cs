using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using StarBattle.Game_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBattle.Screens {

    /// <summary>
    /// Enum describes the screen transition state.
    /// </summary>
    public enum ScreenState {
        TransitionOn,
        Active,
        TransitionOff,
        Hidden,
    }

    public abstract class GameScreen {
        private SpriteBatch spriteBatch;
        protected ContentManager content;
        public Dictionary<string, List<DrawableObject>> objectsOnScreen { get; protected set; }
        protected InputHelper input;
        public ScreenState state;
        public bool paused;
        public bool mouseVisible;

        public GameScreen() {
            content = new ContentManager(Game.instance.Content.ServiceProvider, Game.instance.Content.RootDirectory);
            objectsOnScreen = new Dictionary<string, List<DrawableObject>>();

            input = new InputHelper();
            input.Update();
            state = ScreenState.Active;
            paused = false;
        }

        virtual public void Update(GameTime gameTime) {
            input.Update();
            HandleInput();

            foreach (List<DrawableObject> list in objectsOnScreen.Values) {
                foreach (DrawableObject obj in list) {
                    obj.Update();
                }
            }
        }

        abstract public void LoadContent();
        public virtual void UnloadContent() {
            content.Unload();
            objectsOnScreen.Clear();
        }

        abstract protected void HandleInput();
        abstract public void Draw();
    }
}
