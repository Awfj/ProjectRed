using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRed
{
    internal class Player
    {
        public static ContentManager content;
        public Texture2D currentTexture, textureStandRight;

        public int width, height;
        public Vector2 position;

        public Player(ContentManager content)
        {
            Player.content = content;
            textureStandRight = content.Load<Texture2D>("texture_stand_right");

            BoundingBox a = new BoundingBox();
            currentTexture = textureStandRight;
            width = currentTexture.Width;
            height = currentTexture.Height;

            // 120 - ground height, 2 - bottom offset
            position = new Vector2(0, 768 - height - 120 + 2);
        }
    }
}
