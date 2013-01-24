using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetaryDefence.Gameplay.Entities;
using Microsoft.Xna.Framework;

namespace PlanetaryDefence.Gameplay
{
    class Projectile : MovingEntity
    {
        #region Members

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


        #endregion

        #region Methods

        public Projectile()
        {
            IsActive = true;
        }

        public override void Update(GameTime gameTime)
        {
            currentAnimation.Animate(gameTime);
        }

        #endregion

        
    }
}
