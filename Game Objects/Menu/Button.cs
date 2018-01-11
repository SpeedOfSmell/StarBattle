using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StarBattle.Game_Objects.Menu_Objects {
    class Button : DrawableObject {

        public override Rectangle hitBox {
            get {
                return new Rectangle(
                    (int) position.X - (width / 2),
                    (int) position.Y - (height / 2),
                    width,
                    height
                );
            }
        }

        public Button (Texture2D texture, float scale) : base(texture, scale) {
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public override void Update() {
            throw new NotImplementedException();
        }
    }
}
