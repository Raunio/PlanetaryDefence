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
using PlanetaryDefence.Gameplay.HUD;
using PlanetaryDefence.Engine;

namespace PlanetaryDefence.Gameplay.Levels
{
    public class GameLevel
    {
        Turret turret;
        Vector2 origin;

        
        CameraController camControll;
        Viewport viewPort;
        Rectangle gameArea;

        List<Projectile> turretProjectiles;
        List<Enemy> enemies;
        GroundClutter[] clutter;

        GraphicsDevice graphics;

        EnemySpawner enemySpawner;
        HeadsUpDisplay hud;

        Vector2[] upCords;
        Vector2[] leftCords;
        Vector2[] rightCords;
        Vector2[] downCords;

        Texture2D groundTexture;
        Texture2D rockTexture;
        Texture2D bushTexture;

        private const int clutterAmount = 50;

        public Camera GameCamera
        {
            get;
            private set;
        }

        public bool IsTurretDead
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

            camControll = new CameraController(origin);
            GameCamera = new Camera(viewPort);
            gameArea = new Rectangle(-400, -400, viewPort.Width + 800, viewPort.Height + 800);
            CombatHandler.Instance.GameArea = gameArea;
            CombatHandler.Instance.TotalScore = 0;

            upCords = new Vector2[2] { new Vector2(-10, -camControll.MovingRadius - 210), new Vector2(viewPort.Width + 10, -camControll.MovingRadius - 10) };
            leftCords = new Vector2[2] { new Vector2(-camControll.MovingRadius - 210, -10), new Vector2(-camControll.MovingRadius - 10, viewPort.Height + 10) };
            rightCords = new Vector2[2] { new Vector2(viewPort.Width + camControll.MovingRadius + 10, -10), new Vector2(viewPort.Width + camControll.MovingRadius + 210, viewPort.Height + 10) };
            downCords = new Vector2[2] { new Vector2(-10, viewPort.Height + camControll.MovingRadius + 10), new Vector2(viewPort.Width + 10, viewPort.Height + camControll.MovingRadius + 210) };

            enemySpawner = new EnemySpawner(new GameTime(), 1000, 20000.0f, 5000.0f, 5000.0f, 500.0f, 500.0f, upCords, downCords, leftCords, rightCords);

            hud = new HeadsUpDisplay((int)turret.CurrentHealth);

            enemies = enemySpawner.SpawnedEnemies;

            Behaviour.Initialize(turret.Position + turret.Origin);

            clutter = new GroundClutter[clutterAmount];
            
        }

        public void LoadContent(ContentManager content)
        {
            turret.LoadContent(content);
            Projectile.LoadSpriteSheet(content);
            SoundEffectManager.Instance.LoadContent(content);
            enemySpawner.LoadContent(content);
            hud.LoadContent(content);
            groundTexture = content.Load<Texture2D>(Constants.groundTextureAsset);
            rockTexture = content.Load<Texture2D>(Constants.rockTextureAsset);
            bushTexture = content.Load<Texture2D>(Constants.bushTextureAsset);

            for (int i = 0; i < clutterAmount; i++)
            {
                Random r = new Random();

                int number = r.Next(0, 100);

                if (number < 50)
                    clutter[i] = new GroundClutter(rockTexture, Constants.ClutterType.Rock);
                else
                    clutter[i] = new GroundClutter(bushTexture, Constants.ClutterType.Bush);
            }
        }

        public void Update(GameTime gameTime)
        {
            camControll.Update(gameTime);
            GameCamera.LookAt(camControll.Position);

            turret.FacePoint(InputManager.TouchPosition);
            PhysicsHandler.ApplyCharacterPhysics(turret);
            turret.Update(gameTime);

            enemySpawner.Update(gameTime);
            hud.Update(CombatHandler.Instance.TotalScore, (int)turret.CurrentHealth, GameCamera.Pos + new Vector2(210, viewPort.Height / 2 - 50), GameCamera.Pos + new Vector2(-400, viewPort.Height / 2 - 50));

            foreach (Entity e in enemies)
                e.Update(gameTime);

            if ((InputManager.TouchState == TouchLocationState.Pressed) || (InputManager.TouchState == TouchLocationState.Moved))
            {
                turret.ShootMainBarrel(InputManager.TouchPosition);
            }

            if (turret.ShotInQueue && turret.Velocity.Z == 0)
                turret.ShootMainBarrel(InputManager.TouchPosition);

            CombatHandler.Instance.Update(gameTime, turret, enemies);

            if (turret.CurrentState == Constants.CharacterState.Dead)
            {
                IsTurretDead = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawGroundTexture(spriteBatch);
            foreach (GroundClutter c in clutter)
                c.Draw(spriteBatch);

            turret.DrawProjectiles(spriteBatch);
            turret.DrawTurret(spriteBatch);

            foreach (Entity e in enemies)
                e.Draw(spriteBatch);

            hud.Draw(spriteBatch);
        }

        private void DrawGroundTexture(SpriteBatch spriteBatch)
        {
            //int x = -400;
            //int y = -400;
            int x = (int)-camControll.MovingRadius - 10;
            int y = (int)-camControll.MovingRadius - 10;
            //int width = gameArea.Width;
            //int height = gameArea.Height;
            int width = (int)(camControll.MovingRadius + 10)*2 + viewPort.Width;
            int height = (int)(camControll.MovingRadius + 20) * 2 + viewPort.Height;

            double paska = width / groundTexture.Width;
            double kyrpa = height / groundTexture.Height;

            int textureCountX = (int)Math.Round(paska);
            int textureCountY = (int)Math.Round(kyrpa);

            for (int i = 0; i < textureCountX; i++)
            {
                for (int j = 0; j < textureCountY; j++)
                {
                    spriteBatch.Draw(groundTexture, new Vector2(x + i * groundTexture.Width, y + j * groundTexture.Height), Color.White);
                }
            }
        }
    }
}
