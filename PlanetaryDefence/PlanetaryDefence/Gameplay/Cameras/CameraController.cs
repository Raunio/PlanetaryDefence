using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetaryDefence.Gameplay.Cameras
{
    /// <summary>
    /// The camera controller class is used for maneuvering the camera of the game.
    /// </summary>
    class CameraController
    {
        #region Members

        private Vector2 position;
        private Vector2 velocity;
        private Vector2 target;

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
            position = new Vector2(viewPort.Width / 2, viewPort.Height / 2);
            velocity = Vector2.Zero;
            target = new Vector2(viewPort.Width / 2, viewPort.Height / 2);
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            Move();
        }

        public void AssingPoint(Vector2 point)
        {
            target = point;
        }

        private void Move()
        {
            if (position != target)
            {
                //Sets the velocity.X according to target and the current velocity.
                if (position.X < target.X && velocity.X >= 0)
                {
                    velocity.X += 1;
                }
                else if (position.X < target.X && velocity.X < 0)
                {
                    velocity.X = 1;
                }
                else if (position.X > target.X && velocity.X <= 0)
                {
                    velocity.X -= 1;
                }
                else if (position.X > target.X && velocity.X > 0)
                {
                    velocity.X = -1;
                }
                else
                {
                    velocity.X = 0;
                }

                //Sets the velocity.Y according to the target and the current velocity.
                if (position.Y < target.Y && velocity.Y >= 0)
                {
                    velocity.Y += 1;
                }
                else if (position.Y < target.Y && velocity.Y < 0)
                {
                    velocity.Y = 1;
                }
                else if (position.Y > target.Y && velocity.Y <= 0)
                {
                    velocity.Y -= 1;
                }
                else if (position.Y > target.Y && velocity.Y > 0)
                {
                    velocity.Y = -1;
                }
                else
                {
                    velocity.Y = 0;
                }
            }

            else
            {
                velocity = Vector2.Zero;
            }
        }

        #endregion
    }
}
