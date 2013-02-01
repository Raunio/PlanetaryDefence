using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetaryDefence.Gameplay.Entities;
using PlanetaryDefence.Gameplay.Entities.Turret;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using PlanetaryDefence.Gameplay.Cameras;
using PlanetaryDefence.Engine.Input;
using PlanetaryDefence.Engine.Physics;
using Microsoft.Xna.Framework.Input.Touch;

namespace PlanetaryDefence.Gameplay.Levels
{
    public class GameLevel
    {
        Turret turret;
        Vector2 origin;

        
        CameraController camControll;
        Viewport viewPort;

        List<Projectile> turretProjectiles;

        GraphicsDevice graphics;

        public Camera GameCamera
        {
            get;
            private set;
        }

        public void Initialize(GraphicsDevice graphics)
        {
            this.graphics = graphics;

            viewPort = graphics.Viewport;
            origin = new Vector2(viewPort.Width / 2, viewPort.Height / 2);

            turret = new Turret(origin);
            turretProjectiles = new List<Projectile>();

            //shitty test
            camControll = new CameraController(origin);
            GameCamera = new Camera(viewPort);     
        }

        public void LoadContent(ContentManager content)
        {
            turret.LoadContent(content);
            Projectile.LoadSpriteSheet(content);
            SoundEffectManager.Instance.LoadContent(content);
        }

        public void Update(GameTime gameTime)
        {
            camControll.Update(gameTime);
            GameCamera.LookAt(camControll.Position);

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

        public void Draw(SpriteBatch spriteBatch)
        {
            turret.DrawProjectiles(spriteBatch);
            turret.DrawTurret(spriteBatch);
        }
    }
}
