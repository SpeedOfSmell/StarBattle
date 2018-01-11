using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarBattle.Game_Objects.Gameplay {
    class Player : AnimatedSprite {

        public int speed;

        public Player(Texture2D texture, int width, int height, float interval,
                      int totalFrames, float rotation = 0, float scale = 1, float z = 0)
        : base(texture, width, height, interval, totalFrames, rotation, scale, z) {

            position = new Vector2(Game.instance.screenWidth / 2, Game.instance.screenHeight / 2);
            origin = new Vector2(spriteWidth / 2, spriteHeight / 2);

            speed = 10;
        }

        public void Move(Vector2 offset) {
            position += offset;
        }
    }
}
