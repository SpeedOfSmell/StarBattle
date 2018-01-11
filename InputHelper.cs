using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBattle {
    public class InputHelper {

        KeyboardState previousKState;
        KeyboardState currentKState;
        MouseState previousMState;
        MouseState currentMState;

        public InputHelper() {
            previousKState = new KeyboardState();
            currentKState = new KeyboardState();
            previousMState = new MouseState();
            currentMState = new MouseState();
        }

        public void Update() {
            previousKState = currentKState;
            currentKState = Keyboard.GetState();
            previousMState = currentMState;
            currentMState = Mouse.GetState();
        }

        public bool IsKeyDown(Keys key) {
            return currentKState.IsKeyDown(key);
        }

        public bool KeyPressed(Keys key) {
            return currentKState.IsKeyDown(key) && previousKState.IsKeyUp(key);
        }

        public bool MouseClicked() {
            return currentMState.LeftButton == ButtonState.Pressed && !(previousMState.LeftButton == ButtonState.Pressed);
        }

        public bool MouseClicked(Rectangle area) {
            return currentMState.LeftButton == ButtonState.Pressed && 
                   !(previousMState.LeftButton == ButtonState.Pressed) && 
                   area.Contains(currentMState.Position);
        }
    }
}
