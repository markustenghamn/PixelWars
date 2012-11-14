using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pixelwars
{
    class Portal
    {

        public Rectangle Box;
        Texture2D Pillar_texture;
        GraphicsDeviceManager graphics;
        public int portD = 20;

        public Portal(int x, int y, GraphicsDeviceManager graphics)
        {

            this.graphics = graphics;
            Box = new Rectangle(x, y, 50, 50);

        }

        public void Loadcontent()
        {

            Pillar_texture = new Texture2D(graphics.GraphicsDevice, 1, 1);
            Pillar_texture.SetData(new[] { Color.Chocolate });

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            // TODO: Add your drawing code here
            spriteBatch.Draw(Pillar_texture, Box, Color.Chocolate);


        }

    }
}