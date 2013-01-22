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

namespace XnaGame
{
    public sealed class GameOverScreen : MainGameScreen, IGameOverScreen
    {
        public GameOverScreen(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IGameOverScreen), this);
        }

        protected override void LoadContent()
        {

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

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSkyBlue);

            base.Draw(gameTime);
        }
    }
}
