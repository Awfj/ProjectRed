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
        internal enum Level { Big, Small };
        internal enum State { Standing, Walking };
        private FrameSelector bigStand;

        internal Level level { get; set; }
        internal State state{ get; set; }
        internal bool movingRight;
        private float stateTimer;

        internal Mario(int x, int y)
        {
            positionRectangle = new Rectangle(x, y, 11, 16);
            Init();
        }

        internal static void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("sprites/mario");
        }

        internal void Init()
        {
            int i = 0;

            List<Rectangle> standList = new();
            standList.Add(new Rectangle(16 * (i++), 0, 16, 32));
            bigStand = new FrameSelector(0.1f, standList);

            level = Level.Big;
            state = State.Standing;
            movingRight = true;
            stateTimer = 0;
        }

        private void GetFrameToDraw(float elapsedGameTime)
        {
            if (level == Level.Small)
            {

            }
            else
            {
                switch (state)
                {
                    case State.Walking:
                        break;
                    default:
                        sourceRectangle = bigStand.GetFrame(ref stateTimer);
                        Standing();
                        break;
                }
            }

            positionRectangle.Width = sourceRectangle.Width;
            positionRectangle.Height = sourceRectangle.Height;
            stateTimer += elapsedGameTime / 100;
        }

        private void Standing()
        {

        }

        internal override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            GetFrameToDraw((float)gameTime.ElapsedGameTime.TotalMilliseconds);
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            if (movingRight)
            {
                spriteBatch.Draw(texture, positionRectangle, sourceRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(texture, positionRectangle, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            }
        }
    }
}
