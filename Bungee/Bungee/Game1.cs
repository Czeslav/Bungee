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

namespace Bungee
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Rectangle frame;
        KeyboardState currentKeyboard;
        KeyboardState oldKeyboard;


        Texture2D Texture_ramp;
        Texture2D Texture_player;


        Ramp ramp;
        Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        //============================================================================================
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            frame = GraphicsDevice.Viewport.Bounds;


            base.Initialize();
        }



        //============================================================================================
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Debug");


            Texture_ramp = Content.Load<Texture2D>("ramp");
            Texture_player = Content.Load<Texture2D>("player");


            ramp = new Ramp(Texture_ramp, frame);
            player = new Player(Texture_player, ramp,frame);
            // TODO: use this.Content to load your game content here
        }




        //============================================================================================
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }




        //============================================================================================
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            oldKeyboard = currentKeyboard;
            currentKeyboard = Keyboard.GetState();

            player.Update(oldKeyboard, currentKeyboard);

            base.Update(gameTime);
        }




//============================================================================================
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            ramp.Draw(spriteBatch,font);
            player.Draw(spriteBatch,font);


            spriteBatch.Begin();


            //debug log
            //spriteBatch.DrawString(font, "frame width - " + frame.Width.ToString() + "\n" +
            //                             "frame heigth - " + frame.Height.ToString() + "\n",
            //                             "frame bottom - " + frame.Bottom.ToString() + "\n" +                        
            //                             new Vector2(0), Color.Black);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
