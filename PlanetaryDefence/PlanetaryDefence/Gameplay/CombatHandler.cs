using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetaryDefence.Gameplay.Entities;
using PlanetaryDefence.Gameplay.Entities.Turret;
using Microsoft.Xna.Framework;
using PlanetaryDefence.Engine;

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

        private TimeSpan previousHitTime = TimeSpan.Zero;
        private TimeSpan hitRate = TimeSpan.FromMilliseconds(1000f);

        /// <summary>
        /// Gets or sets the area where projectiles are active.
        /// </summary>
        public Rectangle GameArea
        {
            get;
            set;
        }

        public int TotalScore
        {
            get;
            set;
        }

        public void Update(GameTime gameTime, Turret turret, List<Enemy> enemies)
        {
            List<Projectile> turretProjectiles = turret.ActiveProjectiles;
            
            for (int E = 0; E < enemies.Count; E++)
            {
                if (turret.BoundingBox.Intersects(enemies[E].BoundingBox))
                {
                    if (gameTime.TotalGameTime - previousHitTime > hitRate)
                    {
                        turret.CurrentHealth -= enemies[E].CollisionDamage;
                        enemies[E].CurrentHealth -= enemies[E].CollisionDamage;
                        
                        previousHitTime = gameTime.TotalGameTime;

                        if (enemies[E].CurrentHealth > 0)
                            SoundEffectManager.Instance.GruntDamage();
                        else
                        {
                            TotalScore -= enemies[E].ScorePoints;
                            enemies.RemoveAt(E);
                            SoundEffectManager.Instance.GruntDeath();
                        }

                        if (turret.CurrentHealth > 0)
                        {
                            //Play sound effect
                        }
                        else
                        {
                            turret.CurrentState = Constants.CharacterState.Dead;
                        }
                    }
                }
            }
            
            for (int p = 0; p < turretProjectiles.Count; p++)
            {
                bool projectileRemoved = false;

                if (!GameArea.Intersects(turretProjectiles[p].BoundingBox))
                {
                    projectileRemoved = true;
                    turretProjectiles.RemoveAt(p);
                }

                for (int e = 0; e < enemies.Count; e++)
                {                    
                    if (!projectileRemoved)
                    {
                        for (int v = (int)turretProjectiles[p].TangentialVelocity + turretProjectiles[p].BoundingBox.Width; v >= 0; v--)
                        {
                            Vector2 point = turretProjectiles[p].Position - turretProjectiles[p].Direction * v;

                            if (enemies[e].BoundingBox.Contains((int)point.X, (int)point.Y))
                            {
                                enemies[e].InflictDamage(turretProjectiles[p].Damage);


                                if (enemies[e].CurrentHealth > 0)
                                    SoundEffectManager.Instance.GruntDamage();
                                else
                                {
                                    enemies[e].Slay();
                                    TotalScore += enemies[e].ScorePoints;
                                    enemies.RemoveAt(e);
                                    
                                    SoundEffectManager.Instance.GruntDeath();

                                }
                                turretProjectiles.RemoveAt(p);
                                projectileRemoved = true;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
