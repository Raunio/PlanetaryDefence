using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetaryDefence.Gameplay.Entities;
using Microsoft.Xna.Framework;

namespace PlanetaryDefence.Gameplay.Behaviour
{
    public class Behaviour
    {
        #region Members

        private Enemy subject;
        private Vector2 turretPosition;

        private static Behaviour instance;

        #endregion

        #region Gets & Sets

        public static Behaviour Instance
        {
            get
            {
                if (instance == null)
                    instance = new Behaviour();

                return instance;
            }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Initialization is required by passing in turret position.
        /// </summary>
        /// <param name="turretPosition"></param>
        public void Initialize(Vector2 turretPosition)
        {
            this.turretPosition = turretPosition;
        }

        /// <summary>
        /// Applies basic behaviour to enemy.
        /// </summary>
        /// <param name="subject">The enemy</param>
        public void ApplyBehaviour(Enemy subject)
        {
            subject.FacePoint(turretPosition);
            subject.currentState = Engine.Constants.CharacterState.Walking;
        }

        #endregion

    }
}
