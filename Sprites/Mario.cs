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
    internal class Mario : MovableSprite
    {
        static Texture2D texture;
        internal enum Level { Big, Small };
        internal enum State { Standing, Walking, Turn };
        private FrameSelector bigStand, bigWalk, bigTurn;

        internal Level level { get; set; }
        internal State state{ get; set; }
        internal bool movingRight;
        private float stateTimer;
        private KeyboardState keyboardCurrentState;

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


            // Standing
            List<Rectangle> standList = new();
            standList.Add(new Rectangle(16 * (i++), 0, 16, 32));
            bigStand = new(0.1f, standList);
            
            // Walking
            List<Rectangle> walkList = new();
            for (; i < 4; i++)
            {
                walkList.Add(new Rectangle(16 * i, 0, 16, 32));
            }
            bigWalk = new(0.1f, walkList);

            // Turn
            List<Rectangle> turnList = new();
            turnList.Add(new Rectangle(16 * (i++), 0, 16, 32));
            bigTurn = new(0.1f, turnList);

            level = Level.Big;
            state = State.Standing;
            movingRight = true;
            stateTimer = 0;
        }

        private void GetFrameToDraw(float elapsedGameTime)
        {
            if (level == Level.Big)
            {
                switch (state)
                {
                    case State.Walking:
                        sourceRectangle = bigWalk.GetFrame(ref stateTimer);
                        Walking();
                        break;
                    case State.Turn:
                        sourceRectangle = bigTurn.GetFrame(ref stateTimer);
                        Walking();
                        break;
                    default:
                        sourceRectangle = bigStand.GetFrame(ref stateTimer);
                        Standing();
                        break;
                }
            }
            else
            {
                
            }

            positionRectangle.Width = sourceRectangle.Width;
            positionRectangle.Height = sourceRectangle.Height;
            stateTimer += elapsedGameTime / 100;
        }

        private void Standing()
        {
            xVelocity = 0;
            yVelocity = 0;

            if (keyboardCurrentState.IsKeyDown(Keys.A))
            {
                movingRight = false;
                state = State.Walking;
            }
            if (keyboardCurrentState.IsKeyDown(Keys.D))
            {
                movingRight = true;
                state = State.Walking;
            }
        }

        private void Walking()
        {
            state = State.Walking;
            float maxV = Constants.maxWalkVelocity;
            xAcceleration = Constants.walkAcceleration;

            if (keyboardCurrentState.IsKeyDown(Keys.A))
            {
                movingRight = false;
                if (xVelocity > 0)
                {
                    state = State.Turn;
                    xAcceleration += 0.3f;
                }

                if (xVelocity < -maxV) xVelocity += xAcceleration;
                else if (xVelocity > -maxV) xVelocity -= xAcceleration;
            }
            else if (keyboardCurrentState.IsKeyDown(Keys.D))
            {
                movingRight = true;
                if (xVelocity < 0)
                {
                    state = State.Turn;
                    xAcceleration += 0.3f;
                }

                if (xVelocity > maxV) xVelocity -= xAcceleration;
                else if (xVelocity < maxV) xVelocity += xAcceleration;
            } else
            {
                if (movingRight)
                {
                    if (xVelocity > 0) xVelocity += xAcceleration * 5;
                    else
                    {
                        xVelocity = 0;
                        state = State.Standing;
                    }
                } else
                {
                    if (xVelocity < 0) xVelocity -= xAcceleration * 5;
                    else
                    {
                        xVelocity = 0;
                        state = State.Standing;
                    }
                }
            }
        }

        internal override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            keyboardCurrentState = Keyboard.GetState();
            GetFrameToDraw((float)gameTime.ElapsedGameTime.TotalMilliseconds);

            positionRectangle.X += (int)xVelocity;
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
