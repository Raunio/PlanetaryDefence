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

        //Shitty test
        CameraController camControll;
        Viewport viewPort;
        Texture2D playGameButtonTexture;
        Rectangle playGameButtonRectangle;
        Vector2 rectPosition;

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

            //shitty test
            viewPort = XGame.GraphicsDevice.Viewport;
            camControll = new CameraController(viewPort);

            Globals.SoundsEnabled = true;
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            turret.LoadContent(Content);
            Projectile.LoadSpriteSheet(Content);
            SoundEffectManager.Instance.LoadContent(Content);

            //shitty test
            playGameButtonTexture = Content.Load<Texture2D>("Sprites/playGameButton");
            rectPosition = new Vector2(viewPort.Width / 2, viewPort.Height / 2);
            playGameButtonRectangle = new Rectangle((int)rectPosition.X, (int)rectPosition.Y, playGameButtonTexture.Width, playGameButtonTexture.Height);

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

            //shitty test
            camControll.Update(gameTime);
            
            rectPosition = camControll.Position;
            playGameButtonRectangle.X = (int)rectPosition.X;
            playGameButtonRectangle.Y = (int)rectPosition.Y;

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
            
            //shitty test
            XGame.SpriteBatch.Draw(playGameButtonTexture, playGameButtonRectangle, Color.White);

            base.Draw(gameTime);
        }
    }
}