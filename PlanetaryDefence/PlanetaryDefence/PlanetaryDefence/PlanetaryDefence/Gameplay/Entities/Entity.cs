using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PlanetaryDefence.Engine;

namespace PlanetaryDefence.Engine.Entities
{
    /// <summary>
    /// Base class for all game characters.
    /// </summary>
    abstract class Entity
    {
        #region Members
        protected Animation currentAnimation;
        #endregion

        #region Gets & Sets
        /// <summary>
        /// Gets the position of the entity.
        /// </summary>
        public Vector2 Position
        {
            get;
            protected set;
        }
        #endregion

        
    }
}
