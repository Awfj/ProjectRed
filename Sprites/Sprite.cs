using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRed
{
    internal class Sprite
    {
        internal Rectangle positionRectangle;
        internal Rectangle sourceRectangle;

        internal virtual void Update(GameTime gameTime, List<Sprite> sprites) { }
        internal virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
