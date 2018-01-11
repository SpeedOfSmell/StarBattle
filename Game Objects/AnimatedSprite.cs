using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarBattle.Game_Objects {
    class AnimatedSprite : DrawableObject {

        DateTime prevTime;
        DateTime curTime;
        DateTime lastFrameUpdate;
        float interval;
        int totalFrames;

        public AnimatedSprite(Texture2D texture, int width, int height, float interval,
                              int totalFrames, float rotation = 0, float scale = 1, float z = 0) 
        : base(texture, width, height, 0, rotation, scale, z) {
            this.interval = interval;
            curTime = DateTime.Now;
            lastFrameUpdate = curTime;

            this.totalFrames = totalFrames;
        }

        public override Rectangle hitBox {
            get {
                throw new NotImplementedException();
            }
        }

        public override void Update() {
            prevTime = curTime;
            curTime = DateTime.Now;

            if ((curTime - lastFrameUpdate).TotalMilliseconds >= interval) {
                currentFrame++;
                if (currentFrame >= totalFrames) currentFrame = 0; // Loop back to first frame

                sourceRectangle = new Rectangle((currentFrame % frameColumns) * spriteWidth, (currentFrame % frameRows) * spriteHeight, spriteWidth, spriteHeight);
                lastFrameUpdate = curTime;
            }

        }
    }
}
