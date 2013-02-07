/*
    PlayGameScreen.cs
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
using PlanetaryDefence.Gameplay.Entities.Turret;
using PlanetaryDefence.Engine.Input;
using PlanetaryDefence.Engine.Physics;
using PlanetaryDefence.Engine;
using PlanetaryDefence.Gameplay;
using Microsoft.Xna.Framework.Input.Touch;
using PlanetaryDefence;
using PlanetaryDefence.Gameplay.Cameras;
using PlanetaryDefence.Gameplay.Levels;

namespace XnaGame
{
    public sealed class PlayGameScreen : MainGameScreen, IPlayGameScreen
    {
        private GameLevel mainGameLevel;

        public PlayGameScreen(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IPlayGameScreen), this);
        }

        public override void Initialize()
        {
            mainGameLevel = new GameLevel();

            mainGameLevel.Initialize(XGame.GraphicsDevice);

            Globals.SoundsEnabled = true;
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            mainGameLevel.LoadContent(Content);

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
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
            mainGameLevel.Update(gameTime);
            base.Update(gameTime);        
        }

        public override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.White);

            XGame.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied, SamplerState.LinearClamp, DepthStencilState.None, 
                RasterizerState.CullNone, null, mainGameLevel.GameCamera.GetTransformation(XGame.SpriteBatch.GraphicsDevice));

            mainGameLevel.Draw(XGame.SpriteBatch);

            XGame.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}