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
        private Vector2 targetDistance;

        private Vector2 velocity;
        private Vector2 direction;
        private int accelerationMultiplier;
        
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

        #endregion

        #region Methods

        public CameraController(Viewport viewPort)
        {
            origin = new Vector2(viewPort.Width / 2, viewPort.Height / 2);
            position = origin;
            velocity = Vector2.Zero;
            direction = Vector2.Zero;
            targetDistance = Vector2.Zero;
            target = origin;
            directionAngle = 0f;
            accelerationMultiplier = 2;

        }

        public void Update(GameTime gameTime)
        {
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
            target = point;
            targetDistance = new Vector2(target.X - position.X, target.Y - position.Y);

            directionAngle = (float)Math.Atan2(targetDistance.Y, targetDistance.X);

            direction = new Vector2((float)Math.Cos(directionAngle), (float)Math.Sin(directionAngle));

        }

        private void Move()
        {
            if (position != target)
            {
                velocity = direction;
            }

            else
            {
                velocity = Vector2.Zero;
            }
        }

        #endregion
    }
}
