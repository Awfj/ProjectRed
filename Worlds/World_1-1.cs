using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRed
{
    internal class World_1_1 : World
    {
        internal override void LoadContent(ContentManager content)
        {
            background = content.Load<Texture2D>("worlds/world_1-1");
        }

        internal World_1_1()
        {
            //var w = background.Bounds.Width;
            worldRectangle = new Rectangle(0, 0, 3392, 224);
            end = 3270;
        }
    }
}
