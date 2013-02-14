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
using PlanetaryDefence.Gameplay.Behaviours;

namespace PlanetaryDefence.Gameplay.Levels
{
    public class GameLevel
    {
        Turret turret;
        Vector2 origin;

        
        CameraController camControll;
        Viewport viewPort;

        List<Projectile> turretProjectiles;
        List<Entity> enemies;

        GraphicsDevice graphics;

        EnemySpawner enemySpawner;

        Vector2[] upCords;
        Vector2[] leftCords;
        Vector2[] rightCords;
        Vector2[] downCords;

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

            upCords = new Vector2[2] { new Vector2(20, 20), new Vector2(400, 100) };
            leftCords = new Vector2[2] { new Vector2(20, 20), new Vector2(20, 400) };
            rightCords = new Vector2[2] { new Vector2(400, 20), new Vector2(450, 400) };
            downCords = new Vector2[2] { new Vector2(20, 400), new Vector2(400, 450) };

            enemySpawner = new EnemySpawner(new GameTime(), 100, 60000.0f, 5000.0f, 5000.0f, 500.0f, 1000.0f, upCords, downCords, leftCords, rightCords);

            enemies = enemySpawner.SpawnedEntities;

            Behaviour.Initialize(turret.Position + turret.Origin);
            
        }

        public void LoadContent(ContentManager content)
        {
            turret.LoadContent(content);
            Projectile.LoadSpriteSheet(content);
            SoundEffectManager.Instance.LoadContent(content);
            enemySpawner.LoadContent(content);
        }

        public void Update(GameTime gameTime)
        {
            camControll.Update(gameTime);
            GameCamera.LookAt(camControll.Position);

            turret.FacePoint(InputManager.TouchPosition);
            PhysicsHandler.ApplyCharacterPhysics(turret);
            turret.Update(gameTime);

            enemySpawner.Update(gameTime);

            foreach (Entity e in enemies)
                e.Update(gameTime);

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

            foreach (Entity e in enemies)
                e.Draw(spriteBatch);
        }
    }
}
