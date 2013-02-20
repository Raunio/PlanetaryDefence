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
        /// Gets the type of the enemy.
        /// </summary>
        public Constants.EnemyType enemyType
        {
            get;
            private set;
        }

        public int collisionDamage
        {
            get;
            private set;
        }

        public int scorePoints
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

            this.Origin = new Vector2(currentAnimation.FrameWidth / 2, currentAnimation.FrameHeight / 2);
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
                    walking = new Animation(spriteSheet, 0, 64, 85, 0, 2, 100, false, true);
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
                    MaxHealth = 20;
                    CurrentHealth = 20;
                    collisionDamage = 10;
                    scorePoints = 10;
                    break;
            }
        }

        public void InflictDamage(float amount)
        {
            CurrentHealth -= amount;
        }

        public void Slay()
        {

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
