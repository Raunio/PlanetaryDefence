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

        private Vector2 position;
        private Vector2 velocity;
        private Vector2 target;
        private float direction;
        private Vector2 origin;
        private Vector2 distance;
        private bool touchActive;
        private int updateTimes;

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
            target = origin;
            direction = 0f;
            touchActive = false;
            updateTimes = 0;
        }

        public void Update(GameTime gameTime)
        {
            if ((InputManager.TouchState == TouchLocationState.Pressed) || (InputManager.TouchState == TouchLocationState.Moved))
            {
                touchActive = true;
                updateTimes++;
            }
            else
            {
                touchActive = false;
                updateTimes = 0;
            }


            if (updateTimes > 20)
            {
                position += velocity;
                Move();
            }
            else if (!touchActive)
            {
                AssingPoint(origin);
                position += velocity;
                Move();
            }
        }

        public void AssingPoint(Vector2 point)
        {
            target = point;
            distance = new Vector2(target.X - origin.X, target.Y - origin.Y);

            if (target.X > origin.X + 200)
                target.X = origin.X + 200;

            else if(target.X < origin.X - 200)
                target.X = origin.X - 200;

            if (target.Y > origin.Y + 200)
                target.Y = origin.Y + 200;

            else if(target.Y < origin.Y - 200)
                target.Y = origin.Y - 200;

        }

        private void Move()
        {
            if (position != target)
            {
                //Sets the velocity.X according to target and the current velocity.
                if (position.X < target.X && velocity.X >= 0)
                {
                    velocity.X += 2;
                }
                else if (position.X < target.X && velocity.X < 0)
                {
                    velocity.X = 2;
                }
                else if (position.X > target.X && velocity.X <= 0)
                {
                    velocity.X -= 2;
                }
                else if (position.X > target.X && velocity.X > 0)
                {
                    velocity.X = -2;
                }
                else
                {
                    velocity.X = 0;
                }

                //Sets the velocity.Y according to the target and the current velocity.
                if (position.Y < target.Y && velocity.Y >= 0)
                {
                    velocity.Y += 2;
                }
                else if (position.Y < target.Y && velocity.Y < 0)
                {
                    velocity.Y = 2;
                }
                else if (position.Y > target.Y && velocity.Y <= 0)
                {
                    velocity.Y -= 2;
                }
                else if (position.Y > target.Y && velocity.Y > 0)
                {
                    velocity.Y = -2;
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
