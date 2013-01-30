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

namespace XnaGame
{
    public sealed class PlayGameScreen : MainGameScreen, IPlayGameScreen
    {
        Turret turret;
        Vector2 origin;

        Camera camera;
        CameraController camControll;
        Viewport viewPort;

        List<Projectile> turretProjectiles;

        public PlayGameScreen(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IPlayGameScreen), this);
        }

        public override void Initialize()
        {
            viewPort = XGame.GraphicsDevice.Viewport;
            origin = new Vector2(viewPort.Width / 2, viewPort.Height / 2);

            turret = new Turret(origin);
            turretProjectiles = new List<Projectile>();

            //shitty test
            camControll = new CameraController(origin);
            camera = new Camera(viewPort);

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

            camControll.Update(gameTime);
            camera.LookAt(camControll.Position);

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

            XGame.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied, SamplerState.LinearClamp, DepthStencilState.None, 
                RasterizerState.CullNone, null, camera.GetTransformation(XGame.SpriteBatch.GraphicsDevice));

            turret.DrawProjectiles(XGame.SpriteBatch);
            turret.DrawTurret(XGame.SpriteBatch);

            XGame.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}