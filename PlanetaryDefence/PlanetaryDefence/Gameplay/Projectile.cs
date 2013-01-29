using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetaryDefence.Gameplay.Entities;
using Microsoft.Xna.Framework;
using PlanetaryDefence.Engine;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PlanetaryDefence.Gameplay
{
    class Projectile : MovingEntity
    {
        #region Members

        private Constants.ProjectileType projectileType;

        private static Texture2D spriteSheet;

        #endregion


        #region Gets & Sets

        /// <summary>
        /// Gets or sets the state of the projectile.
        /// </summary>
        public bool IsActive
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the damage of the projectile.
        /// </summary>
        public int Damage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the number of penetrated entities of the projectile.
        /// </summary>
        public int PenetratedEntities
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public Projectile(Constants.ProjectileType type, Vector2 position, float barrelRotation)
        {
            Initialize();
            IsActive = true;
            PenetratedEntities = 0;
            float vX = (float)Math.Cos(barrelRotation) * TangentialVelocity;
            float vY = (float)Math.Sin(barrelRotation) * TangentialVelocity;

            this.Velocity = new Vector3(vX, vY, 0);
            this.projectileType = type;
            Position = position;          
        }

        private void Initialize()
        {
            switch (projectileType)
            {
                case Constants.ProjectileType.PlasmaBall:
                    currentAnimation = new Animation(spriteSheet, 0, 15, 15, 0, 0, 100, false, true);
                    TangentialVelocity = 25f;
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            currentAnimation.Animate(gameTime);
        }

        public static void LoadSpriteSheet(ContentManager content)
        {
            spriteSheet = content.Load<Texture2D>(Constants.ProjectileSpriteSheet);
        }

        #endregion

        
    }
}
