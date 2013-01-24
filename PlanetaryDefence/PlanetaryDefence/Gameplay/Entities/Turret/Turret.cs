using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetaryDefence.Gameplay.Entities.Turret
{
    class Turret : Entity
    {
        private TurretBody turretBody;

        private TurretBarrel mainBarrel;
        private TurretBarrel secondaryBarrel;

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }

    }
}
