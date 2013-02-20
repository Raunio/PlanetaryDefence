using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetaryDefence.Gameplay.Entities;
using PlanetaryDefence.Gameplay.Entities.Turret;

namespace PlanetaryDefence.Gameplay
{
    class CombatHandler
    {
        private static CombatHandler instance;
        public static CombatHandler Instance
        {
            get
            {
                if (instance == null)
                    instance = new CombatHandler();

                return instance;
            }
        }

        public void Update(Turret turret, List<Enemy> enemies)
        {
            List<Projectile> turretProjectiles = turret.ActiveProjectiles;

            for (int p = 0; p < turretProjectiles.Count; p++)
            {
                for (int e = 0; e < enemies.Count; e++)
                {
                    if(turretProjectiles[p].BoundingBox.Intersects(enemies[e].BoundingBox))
                    {
                        enemies[e].InflictDamage(turretProjectiles[p].Damage);
                        turretProjectiles.RemoveAt(p);

                        if (enemies[e].CurrentHealth > 0)
                            SoundEffectManager.Instance.GruntDamage();
                        else
                        {
                            enemies.RemoveAt(e);
                            SoundEffectManager.Instance.GruntDeath();
                        }
                    }
                }
            }
        }
    }
}
