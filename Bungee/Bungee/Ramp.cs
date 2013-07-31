using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;



namespace Bungee
{
    class Ramp
    {

        private Texture2D texture;
        private Vector2 position = new Vector2();
        public Rectangle rectangle;


        

        public Ramp(Texture2D texture,Rectangle frame)
        {
            this.texture = texture;

            //position = (0, frame.Height - texture.Height);
            position.Y = frame.Height - texture.Height;
            position.X = 0;

            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch,SpriteFont font)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(texture,rectangle,Color.White);
            //spriteBatch.DrawString(font,Frame.Width.ToString()+" "+Frame.Height.ToString(),new Vector2(0),Color.White);

            spriteBatch.End();
        }
    }
}
