using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StarBattle.Game_Objects;
using StarBattle.Game_Objects.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBattle.Screens.Gameplay {
    class MazeRun : GameScreen {

        private int numPlayers;
        private int difficulty;

        private List<DrawableObject> players;
        
        public MazeRun(int numPlayers = 1, int difficulty = 1) : base() {
            this.numPlayers = numPlayers;
            this.difficulty = difficulty;

            players = new List<DrawableObject>();         
        }     

        public override void LoadContent() {
            Texture2D texture = content.Load<Texture2D>("Textures/Gameplay/spaceship");
            for (int i = 0; i < numPlayers; i++) {
                players.Add(new Player(texture, 8, 16, 75f, 5, scale: 10));
            }

            objectsOnScreen.Add("players", players);
        }

        protected override void HandleInput() {
            // Convert the players list to a list of actual players so we can work with it
            List<Player> players = objectsOnScreen["players"].Cast<Player>().ToList(); 
            Vector2 offset = new Vector2(0, 0);

            if (input.IsKeyDown(Keys.A)) {
                offset.X -= players[0].speed;
            } if (input.IsKeyDown(Keys.D)) {
                offset.X += players[0].speed;
            } if (input.IsKeyDown(Keys.W)) {
                offset.Y -= players[0].speed;
            } if (input.IsKeyDown(Keys.S)) {
                offset.Y += players[0].speed;
            }

            players[0].Move(offset);
        }

        public override void Draw() {
            SpriteBatch spriteBatch = Game.instance.screenManager.spriteBatch;
            spriteBatch.Begin(samplerState: SamplerState.PointClamp); // Setting to pointclamp removes blur from scaled sprites

            foreach (List<DrawableObject> list in objectsOnScreen.Values) {
                foreach (DrawableObject obj in list) {
                    obj.Draw(spriteBatch);
                }
            }

            spriteBatch.End();
        }
    }
}
