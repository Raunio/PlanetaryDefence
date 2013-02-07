using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetaryDefence.Gameplay.Entities;
using Microsoft.Xna.Framework;
using PlanetaryDefence.Engine;

namespace PlanetaryDefence.Gameplay.Behaviours
{
    public class Behaviour
    {
        #region Members

        private Enemy subject;
        private static Vector2 turretPos;

        #endregion

        #region Gets & Sets


        #endregion

        #region Methods
        /// <summary>
        /// Initialization is required by passing in turret position.
        /// </summary>
        /// <param name="turretPos"></param>
        public static void Initialize(Vector2 turretPosition)
        {
            turretPos = turretPosition;
        }

        /// <summary>
        /// Applies basic behaviour to enemy.
        /// </summary>
        /// <param name="subject">The enemy</param>
        public void ApplyBehaviour(Enemy subject)
        {
            subject.FacePoint(turretPos);
            subject.CurrentState = Constants.CharacterState.Walking;
        }

        #endregion

    }
}
