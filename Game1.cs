using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace ProjectRed
{
    public class Game1 : Game
    {
        Song song;

        Ground ground, ground2, ground3, kutular1, boru1, boru2, boru4, boru5, kutular2, kutular3, boru3,
                kutular4, kutular5, kutular6, kutular7, kutular8, miniboru1;
        List<Ground> currentGroundList;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        Texture2D background;
        Vector2 bgposition = new Vector2(0, 0);

        TimeSpan x = new TimeSpan(0, 0, 0);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferHeight = 768;
            graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ground = new Ground(Content, "aa", 0, 648);
            ground2 = new Ground(Content, "aa", 1280, 648);
            ground3 = new Ground(Content, "aa", 2560, 648);

            currentGroundList = new List<Ground>();
            currentGroundList.Add(ground);
            currentGroundList.Add(ground2);
            currentGroundList.Add(ground3);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("image_background");

            song = Content.Load<Song>("music_background");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);
            MediaPlayer.Volume = (float)0.4;

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Pink);
            spriteBatch.Begin();

            //Console.WriteLine(gameTime.ElapsedGameTime);
            x += gameTime.ElapsedGameTime;
            //Console.WriteLine(x.Milliseconds);
            if (x.Milliseconds == 100)
            {
                //mario.animate();
                x = gameTime.ElapsedGameTime;
            }

            spriteBatch.Draw(background, bgposition, Color.White);

            foreach (var gnd in currentGroundList)
            {
                spriteBatch.Draw(gnd.texture, gnd.position, Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}