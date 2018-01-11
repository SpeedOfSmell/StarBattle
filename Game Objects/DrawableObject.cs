using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarBattle.Game_Objects {
    public abstract class DrawableObject {
        public Texture2D texture;
        public Vector2 position; // Position of our texture. Has a X and Y property

        public Nullable<Rectangle> sourceRectangle; // The part of the texture to draw
        public int spriteWidth;
        public int spriteHeight;
        public int currentFrame;
        public int frameColumns;
        public int frameRows;

        public Color color = Color.White;
        public float rotation; // Rotation is usually radians but here is later multiplied to be in degrees
        public Vector2 origin; // The texture's pivot point. Also the offset for the texture's position
        public float scale;
        public SpriteEffects spriteEffect = SpriteEffects.None;
        public float zDepth; // Controls layering of textures
        public abstract Rectangle hitBox { get; }

        public virtual int width { get { return (int)(texture.Width * scale); } }
        public virtual int height { get { return (int)(texture.Height * scale); } }

        /// <summary>
        /// Constructor used to create a sprite from a whole texture
        /// </summary> 
        public DrawableObject(Texture2D texture, float rotation = 0, float scale = 1, float z = 0) {
            this.texture = texture;
            this.scale = scale;
            this.rotation = rotation * 0.0174533f;
            this.zDepth = z;
            sourceRectangle = null;
        }

        /// <summary>
        /// Constructor used to create a sprite from a sprite sheet
        /// </summary> 
        public DrawableObject(Texture2D texture, int spriteWidth, int spriteHeight, int frame, float rotation = 0, float scale = 1, float z = 0) {
            this.texture = texture;
            this.scale = scale;
            this.rotation = rotation * 0.0174533f;
            this.zDepth = z;

            // Time to do some math
            frameColumns = texture.Width / spriteWidth; // This should hopefully end up being a round number 🤷‍ <- I hope this emoji doesn't break anything
            frameRows = texture.Height / spriteHeight; // Same

            // That was much simpler than I expected

            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
            currentFrame = frame;

            sourceRectangle = new Rectangle((currentFrame % frameColumns) * spriteWidth, (currentFrame % frameRows) * spriteHeight, spriteWidth, spriteHeight);
        }

        public virtual void Draw(SpriteBatch sp) {
            sp.Draw(
                texture,
                position,
                sourceRectangle,
                color,
                rotation,
                origin,
                scale,
                spriteEffect,
                zDepth
            );
        }

        public abstract void Update();
    }
}
