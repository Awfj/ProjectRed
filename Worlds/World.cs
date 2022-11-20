using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using SharpDX.Mathematics.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRed
{
    internal class World
    {
        internal Texture2D background;
        internal Rectangle worldRectangle;
        List<Sprite> sprites;
        internal int end;

        internal virtual void LoadContent(ContentManager content) { }

        internal void Update(GameTime gameTime)
        {
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, worldRectangle, Color.White);
        }
    }
}
