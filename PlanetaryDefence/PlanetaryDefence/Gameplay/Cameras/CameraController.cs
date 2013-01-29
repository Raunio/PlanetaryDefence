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

        private Viewport viewPort;
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 target;
        private Camera camera;

        #endregion

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

        public CameraController(Viewport viewPort)
        {
            this.viewPort = viewPort;
            position = new Vector2(viewPort.Width / 2, viewPort.Height / 2);
            velocity = Vector2.Zero;
            target = Vector2.Zero;
            camera = new Camera(viewPort);
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
