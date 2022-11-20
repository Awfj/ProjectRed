using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace ProjectRed
{
    internal class Mario : MovableSprite
    {
        static Texture2D texture;

        internal Mario(int x, int y)
        {
            positionRectangle = new Rectangle(x, y, 11, 16);
        }

        internal static void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("sprites/mario");
        }

        internal override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            //GetFrametoDraw((float)gameTime.ElapsedGameTime.TotalMilliseconds);
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, positionRectangle, Color.White);
        }
    }
}
