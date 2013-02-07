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
        Rectangle playGameButtonRectangle;

        public MenuScreen(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IStartGameScreen), this);
        }

        protected override void LoadContent()
        {
            playGameButtonTexture = Content.Load<Texture2D>("Sprites/playGameButton");
            playGameButtonRectangle = new Rectangle(100, 100, playGameButtonTexture.Width, playGameButtonTexture.Height);
            Globals.SoundsEnabled = true;
            MusicManager.Instance.LoadContent(Content);
            MusicManager.Instance.PlayMenuMusic();
        }

        public override void Update(GameTime gameTime)
        {
            if (playGameButtonRectangle.Contains((int)InputManager.TouchPosition.X, (int)InputManager.TouchPosition.Y))
            {
                ScreenManager.PushScreen((GameScreen)XGame.PlayGameScreen);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            XGame.SpriteBatch.Begin();

            GraphicsDevice.Clear(Color.LightSkyBlue);

            XGame.SpriteBatch.Draw(playGameButtonTexture, playGameButtonRectangle, Color.White);

            base.Draw(gameTime);

            XGame.SpriteBatch.End();
        }
    }
}
