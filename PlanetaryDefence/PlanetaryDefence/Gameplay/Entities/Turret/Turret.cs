using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PlanetaryDefence.Engine;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PlanetaryDefence.Gameplay.Entities.Turret
{
    class Turret : MovingEntity
    {
        #region Members
        private TurretBody turretBody;
        //private TurretShield turretShield;

        private TurretBarrel mainBarrel;
        private TurretBarrel secondaryBarrel;

        private Vector2 mainBarrelOffset;
        private Vector2 secondaryBarrelOffset;

        #endregion

        #region Gets & Sets

        public bool ShotInQueue
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        public Turret(Vector2 position)
        {
            this.Position = position;

            mainBarrel = new TurretBarrel();
            turretBody = new TurretBody();
            //turretShield = new TurretShield();
            secondaryBarrel = new TurretBarrel();

            turretBody.Position = position;
            //turretShield.Position = position;

            mainBarrel.Position = position + mainBarrelOffset;
            secondaryBarrel.Position = position + secondaryBarrelOffset;

            RotationAcceleration = 0.05f;
            RotationSpeed = 0.2f;

            RotationDirection = Constants.EntityRotationDirection.None;

            this.Origin = turretBody.Origin;
        }

        public void LoadContent(ContentManager content)
        {
            mainBarrel.LoadContent(content);
            secondaryBarrel.LoadContent(content);
            turretBody.LoadContent(content);
            //turretShield.LoadContent(content);

            currentAnimation = turretBody.BodyAnimation;
        }

        public override void Update(GameTime gameTime)
        {
            turretBody.Update(gameTime, Rotation);
            //turretShield.Update(gameTime);
            mainBarrel.Update(gameTime, Rotation);
            secondaryBarrel.Update(gameTime, Rotation);

            UpdateRotation();
        }

        public void DrawTurret(SpriteBatch spriteBatch)
        {
            //turretShield.Draw(spriteBatch);
            mainBarrel.Draw(spriteBatch);
            secondaryBarrel.Draw(spriteBatch);

            turretBody.Draw(spriteBatch);           
        }

        public void DrawProjectiles(SpriteBatch spriteBatch)
        {
            mainBarrel.DrawProjectiles(spriteBatch);
        }

        public void ShootMainBarrel(Vector2 point)
        {
            float diff = Rotation - TargetRotation < 0 ? TargetRotation - Rotation : Rotation - TargetRotation;

            if (diff < 0.25f)
            {
                mainBarrel.Shoot(point);
                ShotInQueue = false;
            }
            else
                ShotInQueue = true;

        }

        #endregion
    }
}
