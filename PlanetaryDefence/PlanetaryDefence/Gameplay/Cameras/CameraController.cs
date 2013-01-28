using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PlanetaryDefence.Gameplay.Cameras
{
    /// <summary>
    /// The camera controller class is used for maneuvering the camera of the game.
    /// </summary>
    class CameraController
    {
        /// <summary>
        /// Gets the position of the camera controller object
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return position;   
            }
        }

        private Vector2 position;
        private Vector2 velocity;
        private Vector2 target;

        public CameraController()
        {

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
            if (position.X < target.X)
            {

            }
            else
            {

            }
            if (position.Y < target.Y)
            {

            }
            else
            {

            }
        }

    }
}
