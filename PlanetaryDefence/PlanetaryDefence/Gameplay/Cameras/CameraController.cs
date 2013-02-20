using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlanetaryDefence.Engine.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace PlanetaryDefence.Gameplay.Cameras
{
    /// <summary>
    /// The camera controller class is used for maneuvering the camera of the game.
    /// </summary>
    class CameraController
    {
        #region Members

        private Vector2 origin;
        private Vector2 position;
        private Vector2 target;
        private Vector2 targetDistanceVector;
        private Vector2 originToPoint;

        private Vector2 velocity;
        private Vector2 direction;
        private float acceleration;
        private float tangentialVelocity;
        private float tangentialVelocityMax;
        private float tangentialVelocityMin;
        
        private float directionAngle;

        
        #endregion

        #region Getters and setters

        /// <summary>
        /// Gets the position of the camera controller object for the camera object to follow.
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public float MovingRadius
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        public CameraController(Vector2 origin)
        {
            this.origin = origin;
            position = origin;
            velocity = Vector2.Zero;
            direction = Vector2.Zero;
            targetDistanceVector = Vector2.Zero;
            originToPoint = Vector2.Zero;
            target = origin;
            directionAngle = 0f;
            acceleration = 0.1f;
            tangentialVelocityMin = 0.1f;
            tangentialVelocityMax = 5.0f;
            tangentialVelocity = tangentialVelocityMin;
            MovingRadius = 100.0f;
        }

        private Vector2 CalculateDistanceVector(Vector2 pointTo, Vector2 pointFrom)
        {
            Vector2 calculatedDistanceVector = new Vector2(pointTo.X - pointFrom.X, pointTo.Y - pointFrom.Y);
            return calculatedDistanceVector;
        }

        private float CalculateDistanceLenght(Vector2 pointTo, Vector2 pointFrom)
        {
            Vector2 lengthFrom = CalculateDistanceVector(target, position);
            return lengthFrom.Length();
        }

        public void Update(GameTime gameTime)
        {
            if (position == origin || position == target)
            {
                tangentialVelocity = tangentialVelocityMin;
            }

            if ((InputManager.TouchState == TouchLocationState.Pressed) || (InputManager.TouchState == TouchLocationState.Moved))
            {
                AssingPoint(InputManager.TouchPosition);
                position += velocity;
                Move();
            }
            else
            {
                AssingPoint(origin);
                position += velocity;
                Move();
            }
        }

        public void AssingPoint(Vector2 point)
        {
            originToPoint = CalculateDistanceVector(point, origin);

            if (originToPoint.Length() > MovingRadius)
            {
                float pointAngle = (float)Math.Atan2(originToPoint.Y, originToPoint.X);
                Vector2 pointDirection = new Vector2((float)Math.Cos(pointAngle), (float)Math.Sin(pointAngle));
                target = origin + MovingRadius * pointDirection;
            }

            else
            {
                target = point;
            }

            targetDistanceVector = CalculateDistanceVector(target, position);

            directionAngle = (float)Math.Atan2(targetDistanceVector.Y, targetDistanceVector.X);

            direction = new Vector2((float)Math.Cos(directionAngle), (float)Math.Sin(directionAngle));

            
        }

        private void Move()
        {
            float positionToTarget = CalculateDistanceLenght(target, position);

            if (positionToTarget < tangentialVelocityMax / acceleration && tangentialVelocity > 0)
                tangentialVelocity -= acceleration;
            else if (tangentialVelocity < tangentialVelocityMax)
                tangentialVelocity += acceleration;
            else
                tangentialVelocity = tangentialVelocityMax;

            if (positionToTarget <= tangentialVelocityMax)
            {
                position = target;
                velocity = Vector2.Zero;
            }
            else
            {
                velocity = direction * tangentialVelocity;
            }
        }

        #endregion
    }
}
