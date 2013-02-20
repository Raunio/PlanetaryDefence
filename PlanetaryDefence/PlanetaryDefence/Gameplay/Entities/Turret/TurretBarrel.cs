using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PlanetaryDefence.Engine;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PlanetaryDefence.Engine.Physics;

namespace PlanetaryDefence.Gameplay.Entities.Turret
{
    class TurretBarrel : Entity
    {
        #region Members

        private Constants.ProjectileType projectileType;

        private Animation idleAnimation;
        private Animation shootingAnimation;

        private Constants.TurretBarrelState barrelState;

        private float shootTimer;

        #endregion


        #region Gets & Sets

        public List<Projectile> Projectiles
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the firerate of the barrel.
        /// </summary>
        public int Firerate
        {
            get;
            set;
        }

        #endregion


        #region Methods

        public TurretBarrel()
        {         
            barrelState = Constants.TurretBarrelState.Idle;
            
            projectileType = Constants.ProjectileType.PlasmaBall;

            Projectiles = new List<Projectile>();

            Firerate = 500;
        }

        public void LoadContent(ContentManager content)
        {
            idleAnimation = new Animation(content.Load<Texture2D>(Constants.TurretMainBarrelSpritesheet), 0, 75, 20, 0, 0, 100, false, true);
            shootingAnimation = new Animation(content.Load<Texture2D>(Constants.TurretMainBarrelSpritesheet), 1, 1, 1, 1, 1, 100, false, false);

            currentAnimation = idleAnimation;

            this.Origin = new Vector2(0, currentAnimation.FrameHeight / 2);
        }

        public override void Update(GameTime gameTime)
        {

        }

        public void Update(GameTime gameTime, float rotation)
        {
            currentAnimation.Animate(gameTime);
            this.Rotation = rotation;
            HandleAnimations();

            foreach (Projectile p in Projectiles)
            {
                p.Update(gameTime);
                PhysicsHandler.ApplyBulletPhysics(p);
            }

            shootTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            CleanProjectiles();
        }

        private void HandleAnimations()
        {
            switch (barrelState)
            {
                case Constants.TurretBarrelState.Idle:
                    currentAnimation = idleAnimation;
                    break;
                case Constants.TurretBarrelState.Shooting:
                    currentAnimation = shootingAnimation;
                    break;
            }
        }

        public void Shoot(Vector2 touchLoc)
        {
            if (shootTimer >= Firerate)
            {
                Projectiles.Add(new Projectile(projectileType, Position, Rotation));

                shootTimer = 0;

                SoundEffectManager.Instance.PlasmaGunFire();
            }
        }

        public void DrawProjectiles(SpriteBatch spriteBatch)
        {
            foreach (Projectile p in Projectiles)
                p.Draw(spriteBatch);
        }

        private void CleanProjectiles()
        {
            for (int i = 0; i < Projectiles.Count; i++)
                if (!Projectiles[i].IsActive)
                    Projectiles.RemoveAt(i);
        }

        #endregion
    }
}
