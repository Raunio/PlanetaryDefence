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

namespace XnaGame
{
    public sealed class MenuScreen : MainGameScreen, IStartGameScreen
    {

        public MenuScreen(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IStartGameScreen), this);
        }

        protected override void LoadContent()
        {

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
