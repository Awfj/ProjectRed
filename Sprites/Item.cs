using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRed
{
    internal class Item
    {
        internal static Texture2D texture;

        internal Item()
        {

        }

        internal static void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("sprites/items");
        }
    }
}
