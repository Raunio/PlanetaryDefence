using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetaryDefence.Gameplay;
using Microsoft.Xna.Framework;
using PlanetaryDefence.Engine;

namespace PlanetaryDefence.Gameplay.Entities
{
    public class Enemy : Entity
    {
        #region Members

        private Animation walking;
        private Animation dying;
        private Animation stopped;

        

        #endregion

        #region Gets & Sets
        /// <summary>
        /// Gets or sets the health of the entity.
        /// </summary>
        public float Health
        {
            get;
            set;
        }
        /// <summary>
        /// Gets the state of the enemy.
        /// </summary>
        public Constants.CharacterState currentState
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the type of the enemy.
        /// </summary>
        public Constants.EnemyType enemyType
        {
            get;
            private set;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="enemyType">Sets the type of the enemy</param>
        /// <param name="position">Sets the initial position of the enemy</param>
        public Enemy(Constants.EnemyType enemyType, Vector2 position)
        {
            this.enemyType = enemyType;
            this.Position = position;
        }

        private void InitBehaviour()
        {

        }

        private void InitAnimations()
        {

        }

        public override void Update(GameTime gameTime)
        {
            currentAnimation.Animate(gameTime);
        }

        private void HandleAnimations()
        {
            switch (currentState)
            {
                case Constants.CharacterState.Attacking:
                    break;
                case Constants.CharacterState.Dead:
                    break;
                case Constants.CharacterState.Disabled:
                    break;
                case Constants.CharacterState.Stopped:
                    break;
                case Constants.CharacterState.Walking:
                    break;
            }
        }

        #endregion
    }
}
