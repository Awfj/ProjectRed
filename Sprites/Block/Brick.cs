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
    internal class Brick : UnmovableSprite
    {
        Item item;
        internal enum State { initial, breaking, hit, afterHit}
        internal State state { get; set; }
        private FrameSelector initialB, breakingH, hitI, afterHitI;
        public static Texture2D texture;
        private DateTime breakingTime;

        internal Brick(int x, int y)
        {
            positionRectangle = new(x, y, 16, 16);
            Init();
        }

        internal static void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("sprites/bricks");
        }

        internal override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (state == State.breaking)
            {
                if ((DateTime.Now - breakingTime).TotalMilliseconds > Constants.brickBreakingTime)
                {
                    canRemove = true;
                }
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, positionRectangle, GetFrame(), Color.White);
        }

        internal Rectangle GetFrame()
        {
            float nothing = 0;
            return state switch
            {
                State.initial => initialB.GetFrame(ref nothing),
                State.hit => hitI.GetFrame(ref nothing),
                State.breaking => breakingH.GetFrame(ref nothing),
                State.afterHit => afterHitI.GetFrame(ref nothing),
                _ => new(),
            };
        }

        internal void Init()
        {
            Rectangle temp;
            List<Rectangle> temps;

            temp = new(272, 112, 16, 16);
            temps = new();
            temps.Add(temp);
            initialB = new(0.1f, temps);

            temp = new(304, 112, 16, 16);
            temps = new();
            temps.Add(temp);
            breakingH = new(0.1f, temps);

            temp = new(320, 112, 16, 16);
            temps = new();
            temps.Add(temp);
            hitI = new(0.1f, temps);

            temp = new(336, 112, 16, 16);
            temps = new();
            temps.Add(temp);
            afterHitI = new(0.1f, temps);
        }
    }
}
