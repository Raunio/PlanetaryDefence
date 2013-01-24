using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetaryDefence.Gameplay;

namespace PlanetaryDefence.Gameplay.Entities
{
    public class Enemy : Entity
    {
        /// <summary>
        /// Gets or sets the walkspeed of the entity
        /// </summary>
        public float WalkSpeed
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the runspeed of the entity
        /// </summary>
        public float RunSpeed
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the tangential velcoity of the entity.
        /// </summary>
        public float TangentialVelocity
        {
            get;
            set;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
