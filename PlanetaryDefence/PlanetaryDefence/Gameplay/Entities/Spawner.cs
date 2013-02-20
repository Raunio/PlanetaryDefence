using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PlanetaryDefence.Engine;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetaryDefence.Gameplay.Entities
{
    class Spawner
    {
        #region Members

        protected int waveCounter;
        protected Vector2[] possibleUpCordinates;
        protected Vector2[] possibleDownCordinates;
        protected Vector2[] possibleLeftCordinates;
        protected Vector2[] possibleRightCordinates;
        protected Vector2 spawnPoint;

        protected TimeSpan previousSpawnTime;
        protected TimeSpan gameStartTime;

        protected Random randomNumber;
        protected Texture2D entitySpriteSheet;

        #endregion


        #region Getters and setters

        /// <summary>
        /// Gets the list of spawned entities.
        /// </summary>
        public List<Enemy> SpawnedEntities
        {
            get;
            protected set;
        }
        /// <summary>
        /// Gets the spawn rate of the spawning enemies.
        /// </summary>
        public TimeSpan SpawnRate
        {
            get;
            protected set;
        }

        #endregion


        #region Methods

        protected Vector2 GetSpawnPoint()
        {
            int directionIndex = randomNumber.Next(0, 3);
            Constants.Direction direction = (Constants.Direction)directionIndex;

            switch (direction)
            {
                case Constants.Direction.Up:
                    spawnPoint = new Vector2(randomNumber.Next((int)possibleUpCordinates[0].X, (int)possibleUpCordinates[1].X), randomNumber.Next((int)possibleUpCordinates[0].Y, (int)possibleUpCordinates[1].Y));
                    break;

                case Constants.Direction.Down:
                    spawnPoint = new Vector2(randomNumber.Next((int)possibleDownCordinates[0].X, (int)possibleDownCordinates[1].X), randomNumber.Next((int)possibleDownCordinates[0].Y, (int)possibleDownCordinates[1].Y));
                    break;

                case Constants.Direction.Left:
                    spawnPoint = new Vector2(randomNumber.Next((int)possibleLeftCordinates[0].X, (int)possibleLeftCordinates[1].X), randomNumber.Next((int)possibleLeftCordinates[0].Y, (int)possibleLeftCordinates[1].Y));
                    break;

                case Constants.Direction.Right:
                    spawnPoint = new Vector2(randomNumber.Next((int)possibleRightCordinates[0].X, (int)possibleRightCordinates[1].X), randomNumber.Next((int)possibleRightCordinates[0].Y, (int)possibleRightCordinates[1].Y));
                    break;

            }

            return spawnPoint;
        }

        #endregion
    }
}
