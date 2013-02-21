/*
    GameOverScreen.cs
    Copyright © Markku Rahikainen 2011.
	www.Stickmansoft.com
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlanetaryDefence.Engine.Input;
using PlanetaryDefence.Gameplay;
using PlanetaryDefence.Engine;
using PlanetaryDefence.Engine.Audio;

namespace XnaGame
{
    public sealed class GameOverScreen : MainGameScreen, IGameOverScreen
    {
        Texture2D exitButtonTexture;
        Rectangle exitButtonRectangle;

        Texture2D bg;
        SpriteFont font;

        public GameOverScreen(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IGameOverScreen), this);
        }

        protected override void LoadContent()
        {
            bg = Content.Load<Texture2D>("Textures/gameover");

            exitButtonTexture = Content.Load<Texture2D>("Sprites/exitButton");
            exitButtonRectangle = new Rectangle(260, 350, exitButtonTexture.Width, exitButtonTexture.Height);
            font = Content.Load<SpriteFont>(Constants.HudFont);
            MusicManager.Instance.StopMusic();
            MusicManager.Instance.PlayMenuMusic();
        }

        internal protected override void ScreenChanged(object sender, EventArgs e)
        {
            base.ScreenChanged(sender, e);

            if (ScreenManager.TopScreen != this.Screen)
            {
                Visible = true;
            }
        }

        public override void Update(GameTime gameTime)
        {

            if (exitButtonRectangle.Contains((int)InputManager.TouchPosition.X, (int)InputManager.TouchPosition.Y))
            {
                XGame.Exit();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSkyBlue);

            XGame.SpriteBatch.Begin();

            XGame.SpriteBatch.Draw(bg, Vector2.Zero, Color.White);

            XGame.SpriteBatch.DrawString(font, "Score: " + CombatHandler.Instance.TotalScore, new Vector2(300, 250), Color.Yellow);

            XGame.SpriteBatch.Draw(exitButtonTexture, exitButtonRectangle, Color.White);

            XGame.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
