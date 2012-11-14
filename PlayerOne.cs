using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pixelwars
{
    class PlayerOne
    {

        GraphicsDeviceManager graphics;
        Texture2D Player_texture;
        Vector2 Player_size;
        public int Player_speed = 10;
        Rectangle Player_box;
        int score;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public Vector2 Position
        {
            get { return new Vector2(Player_box.X, Player_box.Y); }
            set { Player_box.X = (int)value.X; Player_box.Y = (int)value.Y; }
        }

        public bool Intersects(PlayerTwo playerTwo)
        {
            if (Player_box.Intersects(new Rectangle((int)playerTwo.Position.X, (int)playerTwo.Position.Y, (int)playerTwo.Size.X, (int)playerTwo.Size.Y)))
            {
                return true;
            }
            return false;
        }

        public bool Intersects(Rectangle rectangle)
        {
            if (Player_box.Intersects(rectangle))
            {
                return true;
            }
            return false;
        }

        public Vector2 Size
        {
            get { return new Vector2(Player_box.Width, Player_box.Height); }
        }

        public PlayerOne(int x, int y, GraphicsDeviceManager graphics)
        {

            Player_size = new Vector2(25, 25);
            Player_box = new Rectangle(x, y, (int)Player_size.X, (int)Player_size.Y);
            this.graphics = graphics;

        }

        public void Loadcontent()
        {

            Player_texture = new Texture2D(graphics.GraphicsDevice, 1, 1);
            Player_texture.SetData(new[] { Color.Black });

        }

        public void Update()
        {


            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.W))
            {
                Player_box.Y -= Player_speed;
            }
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.S))
            {
                Player_box.Y += Player_speed;
            }
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.A))
            {
                Player_box.X -= Player_speed;
            }
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.D))
            {
                Player_box.X += Player_speed;
            }



            if (Player_box.Y < 0)
            {
                Player_box.Y = 0;
            }
            if (Player_box.Y > (1080 - Player_size.Y))
            {
                Player_box.Y = (1080 - (int)Player_size.Y);
            }
            if (Player_box.X < 0)
            {
                Player_box.X = 0;
            }
            if (Player_box.X > (1920 - Player_size.X))
            {
                Player_box.X = (1920 - (int)Player_size.X);
            }

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            
            // TODO: Add your drawing code here
            spriteBatch.Draw(Player_texture, Player_box, Color.Chocolate);


        }

    }
}
