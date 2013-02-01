using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PlanetaryDefence.Engine;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PlanetaryDefence.Gameplay.Entities
{
    class EnemySpawner
    {
        #region Members

        private List<Constants.EnemyType> spawnableEnemies;
        private TimeSpan previousSpawnTime;
        private Random randomNumber;

        private Texture2D enemySpriteSheet;

        private int waveCounter;
        private Vector2[] upCordinates;
        private Vector2[] downCordinates;
        private Vector2[] leftCordinates;
        private Vector2[] rightCordinates;

        #endregion


        #region Getters and setters

        /// <summary>
        /// Gets the list of spawned enemies.
        /// </summary>
        public List<Enemy> SpawnedEnemies
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets the spawn rate of the spawning enemies.
        /// </summary>
        public TimeSpan SpawnRate
        {
            get;
            private set;
        }

        #endregion


        #region Methods

        public EnemySpawner(Vector2[] upCordinates, Vector2[] downCordinates, Vector2[] leftCordinates, Vector2[] rightCordinates)
        {
            this.upCordinates = upCordinates;
            this.downCordinates = downCordinates;
            this.leftCordinates = leftCordinates;
            this.rightCordinates = rightCordinates;

            spawnableEnemies = new List<Constants.EnemyType>();
            SpawnedEnemies = new List<Enemy>();

            previousSpawnTime = TimeSpan.Zero;
            SpawnRate = TimeSpan.FromMilliseconds(5000.0f);

            waveCounter = 1;
            InitializeWave();

            randomNumber = new Random();
        }

        public void LoadContent(ContentManager content)
        {
            
        }

        private void InitializeWave()
        {
            spawnableEnemies.Clear();

            for (int i = 0; i < waveCounter; i++)
            {
                spawnableEnemies.Add((Constants.EnemyType)i);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime - previousSpawnTime > SpawnRate)
            {
                previousSpawnTime = gameTime.TotalGameTime;

                int spawnableEnemyIndex = randomNumber.Next(0, waveCounter - 1);

                SpawnEnemy(spawnableEnemies[spawnableEnemyIndex]);
            }
        }

        private void SpawnEnemy(Constants.EnemyType enemyType)
        {
            int directionIndex = randomNumber.Next(0, 3);
            Constants.Direction direction = (Constants.Direction)directionIndex;

            switch (direction)
            {
                case Constants.Direction.Up:
                    break;

                case Constants.Direction.Down:
                    break;

                case Constants.Direction.Left:
                    break;

                case Constants.Direction.Right:
                    break;

            }

            Vector2 spawnPoint = new Vector2(1,1);

            Enemy enemy = new Enemy(/*enemySpriteSheet, */enemyType, spawnPoint);

            SpawnedEnemies.Add(enemy);
        }

        #endregion
    }
}
