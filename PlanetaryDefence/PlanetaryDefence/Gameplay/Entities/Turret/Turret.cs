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
        private TurretBody turretBody;
        //private TurretShield turretShield;

        private TurretBarrel mainBarrel;
        private TurretBarrel secondaryBarrel;

        private Vector2 mainBarrelOffset;
        private Vector2 secondaryBarrelOffset;

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

            Rotate();
        }

        public void FacePoint(Vector2 point)
        {
            this.facingPoint = point;
        }

        public void DrawTurret(SpriteBatch spriteBatch)
        {
            //turretShield.Draw(spriteBatch);
            mainBarrel.Draw(spriteBatch);
            secondaryBarrel.Draw(spriteBatch);

            turretBody.Draw(spriteBatch);           
        }

    }
}
