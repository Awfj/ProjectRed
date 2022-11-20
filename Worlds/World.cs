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
        internal List<Sprite> sprites;
        internal Mario mario;
        internal int end;

        internal virtual void LoadContent(ContentManager content) { }

        internal void Update(GameTime gameTime, Camera camera)
        {
            camera.UpdateLoopPosition(mario.positionRectangle);
            //if (mario.Level)

            foreach (Sprite sprite in sprites)
            {
                sprite.Update(gameTime, sprites);
            }

            if (mario.positionRectangle.X < camera.LeftRestrict)
            {
                mario.positionRectangle.X = camera.LeftRestrict;
            }

            if (mario.positionRectangle.X > end)
            {

            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, worldRectangle, Color.White);
            foreach(Sprite sprite in sprites)
            {
                sprite.Draw(spriteBatch);
            }
        }
    }
}
