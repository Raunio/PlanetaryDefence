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
    /// <summary>
    /// Class for spawning enemies.
    /// </summary>
    class EnemySpawner : Spawner
    {
        #region Members

        private List<Constants.EnemyType> spawnableEnemies;
        private Texture2D enemySpriteSheet;
        private float timer;
        private TimeSpan minSpawnRate;

        #endregion


        #region Getters and setters

        /// <summary>
        /// Gets or sets the length in milliseconds of the current wave.
        /// </summary>
        public float WaveTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum ammount of waves.
        /// </summary>
        public int MaxWaves
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the current wave count.
        /// </summary>
        public int WaveCounter
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the ammount of time in milliseconds to with increase the next wave time.
        /// </summary>
        public float WaveTimeIncreasement
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ammount of time in milliseconds to with decrease the spawn rate in the next waves.
        /// </summary>
        public TimeSpan SpawnRateDecreasement
        {
            get;
            set;
        }


        #endregion


        #region Methods

        /// <summary>
        /// Creates an EnemySpawner object.
        /// </summary>
        /// <param name="gameTime">Gives the start time of the first wave in milliseconds.</param>
        /// <param name="WaveTime">Sets the starting wave time in milliseconds.</param>
        /// <param name="MaxWaves">Sets the maximum wave count.</param>
        /// <param name="WaveTimeIncreasement">Sets the ammount of  wave time in milliseconds to increase on every new wave.</param>
        /// <param name="SpawnRate">Sets the starting spawn rate in milliseconds.</param>
        /// <param name="SpawnRateDecreasement">How much spawn rate decreases on every new wave in milliseconds.</param>
        /// <param name="minSpawnRate">Sets the minimum spawn rate in milliseconds.</param>
        /// <param name="possibleUpCordinates">Sets the min and max cordinate values for spawning enemies up from the screen view. Table index [0] being the min values and [1] the max values</param>
        /// <param name="possibleDownCordinates">Sets the min and max cordinate values for spawning enemies down from the screen view. Table index [0] being the min values and [1] the max values</param>
        /// <param name="possibleLeftCordinates">Sets the min and max cordinate values for spawning enemies left from the screen view. Table index [0] being the min values and [1] the max values</param>
        /// <param name="possibleRightCordinates">Sets the min and max cordinate values for spawning enemies right from the screen view. Table index [0] being the min values and [1] the max values</param>
        public EnemySpawner(GameTime gameTime, int MaxWaves, float WaveTime, float WaveTimeIncreasement, float SpawnRate, float SpawnRateDecreasement, float minSpawnRate,
                            Vector2[] possibleUpCordinates, Vector2[] possibleDownCordinates, Vector2[] possibleLeftCordinates, Vector2[] possibleRightCordinates)
        {
            this.possibleUpCordinates = possibleUpCordinates;
            this.possibleDownCordinates = possibleDownCordinates;
            this.possibleLeftCordinates = possibleLeftCordinates;
            this.possibleRightCordinates = possibleRightCordinates;

            spawnableEnemies = new List<Constants.EnemyType>();
            SpawnedEntities = new List<Entity>();

            randomNumber = new Random();

            previousSpawnTime = TimeSpan.Zero;
            this.SpawnRate = TimeSpan.FromMilliseconds(SpawnRate);
            this.WaveTime = WaveTime;
            this.WaveTimeIncreasement = WaveTimeIncreasement; 
            this.SpawnRateDecreasement = TimeSpan.FromMilliseconds(SpawnRateDecreasement);
            this.minSpawnRate = TimeSpan.FromMilliseconds(minSpawnRate);
            timer = 0f;

            WaveCounter = 1;
            this.MaxWaves = MaxWaves;
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

            for (int i = 0; i < WaveCounter; i++)
            {
                spawnableEnemies.Add((Constants.EnemyType)i);

                if (i >= sizeof(Constants.EnemyType) / sizeof(int))
                {
                    break;
                }
                  

            }

        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;


            if (timer >= WaveTime && WaveCounter < MaxWaves)
            {
                timer = 0;
                WaveCounter++;
                WaveTime += WaveTimeIncreasement;

                if(SpawnRate > minSpawnRate)
                    SpawnRate -= SpawnRateDecreasement;

                previousSpawnTime = gameTime.TotalGameTime;
                InitializeWave();

            }

            if (gameTime.TotalGameTime - previousSpawnTime > SpawnRate && WaveCounter < MaxWaves)
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
