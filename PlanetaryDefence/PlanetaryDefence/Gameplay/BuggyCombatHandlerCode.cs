using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetaryDefence.Gameplay.Entities;
using PlanetaryDefence.Gameplay.Entities.Turret;
using Microsoft.Xna.Framework;
/*
namespace PlanetaryDefence.Gameplay
{
    class BuggyCombatHandlerCode
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

            for (int E = 0; E < enemies.Count; E++)
            {
                if (turret.BoundingBox.Intersects(enemies[E].BoundingBox))
                {
                    enemies[E].Slay();
                    enemies.RemoveAt(E);
                    SoundEffectManager.Instance.GruntDeath();
                }
            }

            for (int p = 0; p < turretProjectiles.Count; p++)
            {
                for (int e = 0; e < enemies.Count; e++)
                {
                    for (int v = (int)turretProjectiles[p].TangentialVelocity; v > 0; v--)
                    {
                        if (turretProjectiles.Count > 0)
                        {
                            Vector2 point = turretProjectiles[p].Position - turretProjectiles[p].Direction * v;

                            if (enemies.Count > 0 && enemies[e].BoundingBox.Contains((int)point.X, (int)point.Y))
                            {
                                enemies[e].InflictDamage(turretProjectiles[p].Damage);

                                turretProjectiles[p].PenetratedEnemies.Add(enemies[e]);


                                if (enemies[e].CurrentHealth > 0)
                                    SoundEffectManager.Instance.GruntDamage();
                                else
                                {
                                    enemies[e].Slay();
                                    enemies.RemoveAt(e);
                                    SoundEffectManager.Instance.GruntDeath();

                                }

                                if (turretProjectiles[p].PenetratedEnemies.Count >= turretProjectiles[p].MaxPenetrations)
                                {
                                    turretProjectiles.RemoveAt(p);
                                    break;
                                }
                                else
                                {
                                    turretProjectiles[p].Damage -= turretProjectiles[p].PenetrationDamageReduction;
                                }

                            }
                        }
                    }

                    /*  if (enemies.Count > 0 && turretProjectiles.Count > 0 && turretProjectiles[p].BoundingBox.Intersects(enemies[e].BoundingBox) && !turretProjectiles[p].PenetratedEnemies.Contains(enemies[e]))
                      {
                          enemies[e].InflictDamage(turretProjectiles[p].Damage);

                          if(!turretProjectiles[p].PenetratedEnemies.Contains(enemies[e]))
                              turretProjectiles[p].PenetratedEnemies.Add(enemies[e]);


                          if (enemies[e].CurrentHealth > 0)
                              SoundEffectManager.Instance.GruntDamage();
                          else
                          {
                              enemies[e].Slay();
                              enemies.RemoveAt(e);
                              SoundEffectManager.Instance.GruntDeath();
                          }


                          if (turretProjectiles[p].PenetratedEnemies.Count >= turretProjectiles[p].MaxPenetrations)
                              turretProjectiles.RemoveAt(p);
                          else
                              turretProjectiles[p].Damage -= turretProjectiles[p].PenetrationDamageReduction;

                      }*/
//                }
//            }
//        }
//    }
//}
