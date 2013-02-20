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
    public class MovingEntity : Entity
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
        /// Gets the direction Vector of the projectile.
        /// </summary>
        public Vector2 Direction
        {
            get;
            protected set;
        }
        /// <summary>
        /// Gets or sets the health of the entity.
        /// </summary>
        public float CurrentHealth
        {
            get;
            set;
        }
        public float MaxHealth
        {
            get;
            protected set;
        }
        /// <summary>
        /// Gets the state of the entity.
        /// </summary>
        public Constants.CharacterState CurrentState
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
        /// Gets or sets the maximun rotation speed of the entity.
        /// </summary>
        public float RotationSpeed
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
        /// <summary>
        /// Gets the last target rotation of the entity.
        /// </summary>
        public float TargetRotation
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        public override void Update(GameTime gameTime)
        {
            
        }

        public void UpdateRotation()
        {
            float newRotation = Rotation;

            if (facingPoint != null)
            {
                Vector2 distance2D = new Vector2(facingPoint.X - Position.X - Origin.X, facingPoint.Y - Position.Y - Origin.Y);

                newRotation = (float)Math.Atan2(distance2D.Y, distance2D.X);
            }

            if (newRotation < 0)
                newRotation += (float)Math.PI * 2;
            else if (newRotation > Math.PI * 2)
                newRotation -= (float)Math.PI * 2;
            if (Rotation < 0)
                Rotation += (float)Math.PI * 2;
            else if (Rotation > Math.PI * 2)
                Rotation -= (float)Math.PI * 2;


            float distance = Rotation < newRotation ? newRotation - Rotation : Rotation - newRotation;

            if (distance > RotationAcceleration * 2)
            {
                if (Rotation < newRotation)
                {
                    if (distance > Math.PI)
                    {
                        RotationDirection = Constants.EntityRotationDirection.Counterclockwise;
                    }
                    else
                    {
                        RotationDirection = Constants.EntityRotationDirection.Clockwise;
                    }
                }
                else
                {
                    if (distance > Math.PI)
                    {
                        RotationDirection = Constants.EntityRotationDirection.Clockwise;
                    }
                    else
                    {
                        RotationDirection = Constants.EntityRotationDirection.Counterclockwise;
                    }
                }
            }
            else
            {
                RotationDirection = Constants.EntityRotationDirection.None;
                Rotation = newRotation;
            }

            TargetRotation = newRotation;
        }

        

        #endregion
    }
}
