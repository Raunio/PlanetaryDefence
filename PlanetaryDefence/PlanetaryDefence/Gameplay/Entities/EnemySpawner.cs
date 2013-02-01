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
    class EnemySpawner : Spawner
    {
        #region Members

        private List<Constants.EnemyType> spawnableEnemies;
        private Texture2D enemySpriteSheet;

        #endregion


        #region Getters and setters

        //Getters and setters here.

        #endregion


        #region Methods

        public EnemySpawner(Vector2[] possibleUpCordinates, Vector2[] possibleDownCordinates, Vector2[] possibleLeftCordinates, Vector2[] possibleRightCordinates)
        {
            this.possibleUpCordinates = possibleUpCordinates;
            this.possibleDownCordinates = possibleDownCordinates;
            this.possibleLeftCordinates = possibleLeftCordinates;
            this.possibleRightCordinates = possibleRightCordinates;

            spawnableEnemies = new List<Constants.EnemyType>();
            SpawnedEntities = new List<Entity>();

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

                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            Enemy enemy = new Enemy(/*enemySpriteSheet, */GetEnemyType(), GetSpawnPoint());

            SpawnedEntities.Add(enemy);
        }

        private Constants.EnemyType GetEnemyType()
        {
            int spawnableEnemyIndex = randomNumber.Next(0, waveCounter - 1);
            Constants.EnemyType enemyType = spawnableEnemies[spawnableEnemyIndex];
            return enemyType;
        }

        #endregion
    }
}
