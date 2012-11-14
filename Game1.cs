using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pixelwars
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<Portal> portals = new List<Portal>();
        PlayerOne playerOne;
        PlayerTwo playerTwo;
        bool turn = false;
        Random random = new Random(5);
        SpriteFont scoreFont;

        public Game1()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            int i = 0;
            while (i < 11)
            {
                Portal portal = new Portal(200 * i, 100 * i, graphics);
                portal.portD = random.Next(10, 25);
                portals.Add(portal);
                i++;
            }
            playerOne = new PlayerOne(400, 500, graphics);
            playerTwo = new PlayerTwo(1600, 500, graphics);

            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
            if (graphics.IsFullScreen)
            {
                graphics.ToggleFullScreen();
            }

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            foreach (Portal p in portals)
            {
                p.Loadcontent();
            }
            playerOne.Loadcontent();
            playerTwo.Loadcontent();
            scoreFont = Content.Load<SpriteFont>("Score");
            
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Escape))
            {
                //closes game
                this.Exit();
            }

            playerOne.Update();

            foreach (Portal p in portals)
            {
                if (playerOne.Intersects(p.Box))
                {

                    playerTwo.Score += 10;
                    playerOne.Position = new Vector2((float)random.Next(-1000, 1000), (float)random.Next(-1000, 1000));

                }
            }

            playerTwo.Update();

            foreach (Portal p in portals)
            {
                if (playerTwo.Intersects(p.Box))
                {

                    playerOne.Score += 10;
                    playerTwo.Position = new Vector2((float)random.Next(-1000, 1000), (float)random.Next(-1000, 1000));

                }
            }
            
            if (playerTwo.Intersects(playerOne))
            {

                if (turn)
                {

                    turn = false;
                    playerOne.Position += new Vector2((float)random.Next(-1000, 1000), (float)random.Next(-1000, 1000));

                }
                else
                {

                    turn = true;
                    playerTwo.Position += new Vector2((float)random.Next(-1000, 1000), (float)random.Next(-1000, 1000));

                }

            }
            foreach (Portal p in portals)
            {
                if (p.Box.Y >= 0 && p.Box.Y <= 1080)
                {
                    p.Box.Y += p.portD;
                }
                else
                {
                    if (p.portD < 0)
                    {
                        p.portD = random.Next(10, 25);
                        p.Box.Y = 0;
                    }
                    else
                    {
                        p.portD = random.Next(-25, -10);
                        p.Box.Y = 1080;
                    }
                }
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            foreach (Portal p in portals)
            {
                p.Draw(spriteBatch);
            }
            playerOne.Draw(spriteBatch);
            playerTwo.Draw(spriteBatch);
            spriteBatch.DrawString(scoreFont, "Player 1 Score " + playerOne.Score.ToString(), new Vector2(100, 100), Color.Black);
            spriteBatch.DrawString(scoreFont, "Player 2 Score " + playerTwo.Score.ToString(), new Vector2(1600, 100), Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
