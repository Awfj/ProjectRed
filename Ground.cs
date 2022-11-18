using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRed
{
    internal class Ground
    {
        public ContentManager content;
        public Player player;
        public Texture2D texture;
        public Vector2 position;
        public int width, height;
        public Rectangle gnd;

        public Ground(ContentManager content, Player player, string tex, int x, int y)
        {
            this.player = player;
            this.content = content;
            texture = content.Load<Texture2D>(tex);
            width = texture.Width;
            height = texture.Height;
            position = new Vector2(x, y);
            gnd = new Rectangle((int)position.X, (int)position.Y, width, height);

        }
    }
}
