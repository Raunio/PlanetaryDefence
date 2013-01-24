using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PlanetaryDefence.Gameplay.Entities.Turret
{
    class TurretBarrel : Entity
    {
        #region Members

        protected Projectile projectile;
        protected List<Projectile> projectiles;

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

        }

        public override void Update(GameTime gameTime)
        {

        }

        #endregion
    }
}
