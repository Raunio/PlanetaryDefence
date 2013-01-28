﻿/*
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

namespace XnaGame
{
    public sealed class PlayGameScreen : MainGameScreen, IPlayGameScreen
    {
        Turret turret;

        public PlayGameScreen(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IPlayGameScreen), this);
        }

        public override void Initialize()
        {
            turret = new Turret(new Vector2(100, 100));
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            turret.LoadContent(Content);
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
            turret.Update(gameTime);
            base.Update(gameTime);

            turret.FacePoint(InputManager.TouchPosition);
            PhysicsHandler.ApplyPhysics(turret);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSkyBlue);

            turret.DrawTurret(XGame.SpriteBatch);

            base.Draw(gameTime);
        }
    }
}