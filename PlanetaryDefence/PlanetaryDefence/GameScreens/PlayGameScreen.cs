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

namespace XnaGame
{
    public sealed class PlayGameScreen : MainGameScreen, IPlayGameScreen
    {
        Turret turret;

        List<Projectile> turretProjectiles;

        public PlayGameScreen(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IPlayGameScreen), this);
        }

        public override void Initialize()
        {
            turret = new Turret(new Vector2(350, 200));
            turretProjectiles = new List<Projectile>();
            Globals.SoundsEnabled = true;
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            turret.LoadContent(Content);
            Projectile.LoadSpriteSheet(Content);
            SoundEffectManager.Instance.LoadContent(Content);
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
            
            base.Update(gameTime);

            turret.FacePoint(InputManager.TouchPosition);
            PhysicsHandler.ApplyCharacterPhysics(turret);
            turret.Update(gameTime);

            if ((InputManager.TouchState == TouchLocationState.Pressed) || (InputManager.TouchState == TouchLocationState.Moved))
            {
                turret.ShootMainBarrel(InputManager.TouchPosition);
            }

            if (turret.ShotInQueue && turret.Velocity.Z == 0)
                turret.ShootMainBarrel(InputManager.TouchPosition);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);

            turret.DrawProjectiles(XGame.SpriteBatch);
            turret.DrawTurret(XGame.SpriteBatch);
            

            base.Draw(gameTime);
        }
    }
}