using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Bungee
{
    class Player
    {
        private Texture2D texture;
        private Rectangle frame;
        private Rectangle startingRectangle;
        private Rectangle currentRectangle;
        private Rectangle rampRectangle;
        private Vector2 velocity = new Vector2(0);

        private float angle;

        StreamWriter log = new StreamWriter(@"C:/a.txt");

        public Player(Texture2D texture,Ramp ramp,Rectangle frame)
        {
            this.texture = texture;
            this.frame = frame;
            rampRectangle = ramp.rectangle;

            #region creating rectangle for player
            startingRectangle = ramp.rectangle;
            startingRectangle.Height = texture.Height;
            startingRectangle.Width = texture.Width;
            startingRectangle.X = ramp.rectangle.Width - startingRectangle.Width;
            startingRectangle.Y = rampRectangle.Y - 50;
            #endregion


            currentRectangle = startingRectangle;
        }

        public void Update(KeyboardState oldKeyboard, KeyboardState currentKeyboard)
        {
            #region when player is outside frame, appears at top of ramp
            if (currentRectangle.Bottom > frame.Bottom || currentRectangle.Right > frame.Right || currentRectangle.Left < frame.Left || currentRectangle.Top < frame.Top)
            {
                currentRectangle = startingRectangle;
                velocity = new Vector2(0);
            }
            #endregion

            #region jumping
            if (currentKeyboard.IsKeyDown(Keys.Enter)&& oldKeyboard.IsKeyUp(Keys.Enter))
            {
                velocity.Y -= 10;
                velocity.X += 10;
            }
            #endregion

            #region falling
            if (true)
            {
                velocity.Y += 1;
            }
            #endregion

            #region collision detection

            if (currentRectangle.Bottom+velocity.Y > rampRectangle.Top && currentRectangle.Left < rampRectangle.Right)
            {
                velocity = new Vector2(0);
            }

            #endregion

            #region rotating player

            if (velocity.X != 0)
            {
                angle = (float)Math.Atan(velocity.Y / velocity.X);
                angle *= 2;
            }
            else
            {
                angle = 0;
            }

            //log.WriteLine(velocity.X.ToString() + "   " + velocity.Y.ToString() + "   " + angle, ToString());

            #endregion

            #region updating position
            currentRectangle.X += (int)velocity.X;
            currentRectangle.Y += (int)velocity.Y;
            velocity.X -= velocity.X * 0.05f;
            #endregion
        }


        public void Draw(SpriteBatch spriteBatch,SpriteFont font){

            spriteBatch.Begin();

            //spriteBatch.Draw(texture, currentRectangle, Color.White);
                                                                            //
            spriteBatch.Draw(texture, currentRectangle, null, Color.White, angle, new Vector2(texture.Width/2,texture.Height/2), SpriteEffects.None, 1);

            spriteBatch.DrawString(font, "player X - " + currentRectangle.X.ToString() + "\n" +
                                         "player Y - " + currentRectangle.Y.ToString() +"\n" +
                                         "player velocity" + velocity.ToString()+"\n",new Vector2 (0,0), Color.White);

            spriteBatch.End();

        }


    }
}