using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetaryDefence.Engine;
using Microsoft.Xna.Framework;

namespace PlanetaryDefence.Gameplay.Entities
{
    /// <summary>
    /// Base class for all moving game entities.
    /// </summary>
    class MovingEntity : Entity
    {
        #region Members

        #endregion

        #region Gets & Sets
        /// <summary>
        /// Gets or sets the velocity of the entity. Z-axis represents rotation velocity.
        /// </summary>
        public Vector3 Velocity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the rotation direction of the entity.
        /// </summary>
        public Constants.EntityRotationDirection RotationDirection
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the rotation acceleration of the entity.
        /// </summary>
        public float RotationAcceleration
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the acceleration of the entity.
        /// </summary>
        public float Acceleration
        {
            get;
            set;
        }
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

        #endregion

        #region Methods

        public override void Update(GameTime gameTime)
        {
            
        }

        protected void Rotate()
        {
            float newRotation = Rotation;

            if (facingPoint != null)
            {
                Vector2 distance = new Vector2(Position.X - facingPoint.X, Position.Y - facingPoint.Y);
                newRotation = (float)Math.Atan2(distance.Y, distance.X);
            }

            if (newRotation < Rotation)
                RotationDirection = Constants.EntityRotationDirection.Clockwise;

            else if (newRotation > Rotation)
                RotationDirection = Constants.EntityRotationDirection.Counterclockwise;

            else
                RotationDirection = Constants.EntityRotationDirection.None;
        }
        #endregion
    }
}
