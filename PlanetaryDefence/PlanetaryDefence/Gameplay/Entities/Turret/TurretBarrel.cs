using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PlanetaryDefence.Engine;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetaryDefence.Gameplay.Entities.Turret
{
    class TurretBarrel : Entity
    {
        #region Members

        protected Projectile projectile;
        protected List<Projectile> projectiles;

        private Animation idleAnimation;
        private Animation shootingAnimation;

        private Constants.TurretBarrelState barrelState;

        #endregion


        #region Gets & Sets

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
            projectiles = new List<Projectile>();           
            barrelState = Constants.TurretBarrelState.Idle;
            this.Origin = new Vector2(0, 7);
        }

        public void LoadContent(ContentManager content)
        {
            idleAnimation = new Animation(content.Load<Texture2D>(Constants.TurretMainBarrelSpritesheet), 0, 60, 15, 0, 0, 100, false, true);
            shootingAnimation = new Animation(content.Load<Texture2D>(Constants.TurretMainBarrelSpritesheet), 1, 1, 1, 1, 1, 100, false, false);

            currentAnimation = idleAnimation;
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime, float rotation)
        {
            currentAnimation.Animate(gameTime);
            this.Rotation = rotation;
            HandleAnimations();
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

        

        #endregion
    }
}
