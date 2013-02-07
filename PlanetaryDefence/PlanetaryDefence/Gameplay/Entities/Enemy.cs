using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetaryDefence.Gameplay;
using Microsoft.Xna.Framework;
using PlanetaryDefence.Engine;
using PlanetaryDefence.Engine.Physics;
using PlanetaryDefence.Gameplay.Behaviours;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetaryDefence.Gameplay.Entities
{
    public class Enemy : MovingEntity
    {
        #region Members

        private Animation walking;
        private Animation dying;
        private Animation stopped;

        private Behaviour behaviour;

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
        public Enemy(Texture2D spriteSheet, Constants.EnemyType enemyType, Vector2 position)
        {
            this.enemyType = enemyType;
            this.Position = position;

            InitAnimations(spriteSheet);
            InitBehaviour();
            InitStats();
        }

        private void InitBehaviour()
        {
            behaviour = new Behaviour();
        }

        private void InitAnimations(Texture2D spriteSheet)
        {
            switch(enemyType)
            {
                case Constants.EnemyType.Grunt:
                    walking = new Animation(spriteSheet, 0, 50, 50, 0, 0, 100, false, true);
                    break;
            }


            currentAnimation = walking;
        }

        private void InitStats()
        {
            switch (enemyType)
            {
                case Constants.EnemyType.Grunt:
                    RotationAcceleration = 0.05f;
                    RotationSpeed = 0.2f;
                    WalkSpeed = 3f;
                    Acceleration = 0.25f;
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            currentAnimation.Animate(gameTime);
            UpdateRotation();
            behaviour.ApplyBehaviour(this);
            PhysicsHandler.ApplyCharacterPhysics(this);
        }

        private void HandleAnimations()
        {
            switch (CurrentState)
            {
                case Constants.CharacterState.Attacking:
                    break;
                case Constants.CharacterState.Dead:
                    break;
                case Constants.CharacterState.Disabled:
                    break;
                case Constants.CharacterState.Stopped:
                    currentAnimation = stopped;
                    break;
                case Constants.CharacterState.Walking:
                    currentAnimation = walking;
                    break;
            }
        }

        #endregion
    }
}
