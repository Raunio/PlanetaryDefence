/*
    StartGameScreen.cs
    Copyright © Markku Rahikainen 2011.
	www.Stickmansoft.com
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlanetaryDefence.Engine.Input;
using PlanetaryDefence.Engine.Audio;
using PlanetaryDefence;

namespace XnaGame
{
    public sealed class MenuScreen : MainGameScreen, IStartGameScreen
    {
        Texture2D playGameButtonTexture;
        Texture2D exitButtonTexture;
        Rectangle exitButtonRectangle;
        Rectangle playGameButtonRectangle;
        Texture2D bg;

        public MenuScreen(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IStartGameScreen), this);
        }

        protected override void LoadContent()
        {
            playGameButtonTexture = Content.Load<Texture2D>("Sprites/playButton");
            playGameButtonRectangle = new Rectangle(100, 350, playGameButtonTexture.Width, playGameButtonTexture.Height);
            exitButtonTexture = Content.Load<Texture2D>("Sprites/exitButton");
            exitButtonRectangle = new Rectangle(420, 350, exitButtonTexture.Width, exitButtonTexture.Height);
            Globals.SoundsEnabled = true;
            MusicManager.Instance.LoadContent(Content);
            MusicManager.Instance.PlayMenuMusic();
            bg = Content.Load<Texture2D>("Textures/splash");
        }

        public override void Update(GameTime gameTime)
        {
            if (playGameButtonRectangle.Contains((int)InputManager.TouchPosition.X, (int)InputManager.TouchPosition.Y))
            {
                ScreenManager.ChangeScreen((GameScreen)XGame.PlayGameScreen);
            }

            if (exitButtonRectangle.Contains((int)InputManager.TouchPosition.X, (int)InputManager.TouchPosition.Y))
            {
                XGame.Exit();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            XGame.SpriteBatch.Begin();

            GraphicsDevice.Clear(Color.LightSkyBlue);

            XGame.SpriteBatch.Draw(bg, Vector2.Zero, Color.White);

            XGame.SpriteBatch.Draw(playGameButtonTexture, playGameButtonRectangle, Color.White);
            XGame.SpriteBatch.Draw(exitButtonTexture, exitButtonRectangle, Color.White);

            base.Draw(gameTime);

            XGame.SpriteBatch.End();
        }
    }
}
