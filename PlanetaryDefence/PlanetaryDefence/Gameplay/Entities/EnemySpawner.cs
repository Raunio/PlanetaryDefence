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

        /// <summary>
        /// Gets or sets the length of the current wave.
        /// </summary>
        public TimeSpan WaveTime
        {
            get;
            set;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Creates an EnemySpawner object.
        /// </summary>
        /// <param name="gameTime">Gives the start time of the first wave.</param>
        /// <param name="possibleUpCordinates">Sets the min and max cordinate values for spawning enemies up from the screen view. Table index [0] being the min values and [1] the max values</param>
        /// <param name="possibleDownCordinates">Sets the min and max cordinate values for spawning enemies down from the screen view. Table index [0] being the min values and [1] the max values</param>
        /// <param name="possibleLeftCordinates">Sets the min and max cordinate values for spawning enemies left from the screen view. Table index [0] being the min values and [1] the max values</param>
        /// <param name="possibleRightCordinates">Sets the min and max cordinate values for spawning enemies right from the screen view. Table index [0] being the min values and [1] the max values</param>
        public EnemySpawner(GameTime gameTime, Vector2[] possibleUpCordinates, Vector2[] possibleDownCordinates, Vector2[] possibleLeftCordinates, Vector2[] possibleRightCordinates)
        {
            this.possibleUpCordinates = possibleUpCordinates;
            this.possibleDownCordinates = possibleDownCordinates;
            this.possibleLeftCordinates = possibleLeftCordinates;
            this.possibleRightCordinates = possibleRightCordinates;

            spawnableEnemies = new List<Constants.EnemyType>();
            SpawnedEntities = new List<Entity>();

            randomNumber = new Random();

            previousSpawnTime = TimeSpan.Zero;
            SpawnRate = TimeSpan.FromMilliseconds(5000.0f);
            WaveTime = TimeSpan.FromMilliseconds(60000.0f);

            waveCounter = 1;
            gameStartTime = gameTime.TotalGameTime;
            
            InitializeWave();           
        }

        public void LoadContent(ContentManager content)
        {
            enemySpriteSheet = content.Load<Texture2D>(Constants.EnemySpriteSheet);
        }

        private void InitializeWave()
        {
            spawnableEnemies.Clear();

            for (int i = 0; i < waveCounter; i++)
            {
                spawnableEnemies.Add((Constants.EnemyType)i);

                if (i >= sizeof(Constants.EnemyType) / sizeof(int))
                {
                    return;
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime - gameStartTime >= WaveTime)
            {
                waveCounter++;

                if (waveCounter == 99) //edit this.
                {

                }

                //SpawnRate -= joku aikamääre

                previousSpawnTime = gameTime.TotalGameTime;
                InitializeWave();

            }

            if (gameTime.TotalGameTime - previousSpawnTime > SpawnRate)
            {
                previousSpawnTime = gameTime.TotalGameTime;

                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            Enemy enemy = new Enemy(enemySpriteSheet, GetRandomEnemyType(), GetSpawnPoint());

            SpawnedEntities.Add(enemy);
        }

        private Constants.EnemyType GetRandomEnemyType()
        {
            int spawnableEnemyIndex = randomNumber.Next(0, spawnableEnemies.Count -1);
            Constants.EnemyType enemyType = spawnableEnemies[spawnableEnemyIndex];
            return enemyType;
        }

        #endregion
    }
}
