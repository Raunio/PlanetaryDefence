using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PlanetaryDefence.Gameplay.Entities;
using PlanetaryDefence.Gameplay;

namespace PlanetaryDefence.Engine.Physics
{
    public class PhysicsHandler
    {
        public static void ApplyPhysics(Enemy subject)
        {
            Rotate(subject);

            float velocityX = (float)Math.Cos(subject.Rotation) * subject.TangentialVelocity;
            float velocityY = (float)Math.Sin(subject.Rotation) * subject.TangentialVelocity;

            subject.Position += new Vector2(subject.Velocity.X, subject.Velocity.Y);

            
        }

        private static void Rotate(Enemy subject)
        {
            float velocityZ = subject.Velocity.Z;

            switch (subject.RotationDirection)
            {
                case Constants.EntityRotationDirection.Clockwise:
                    velocityZ += subject.RotationAcceleration;
                    break;
                case Constants.EntityRotationDirection.Counterclockwise:
                    velocityZ -= subject.RotationAcceleration;
                    break;
                case Constants.EntityRotationDirection.None:
                    velocityZ = 0f;
                    break;
            }

            subject.Velocity = new Vector3(subject.Velocity.X, subject.Velocity.Y, velocityZ);
        }

        private static void Walk(Enemy subject)
        {
            if (subject.TangentialVelocity < subject.WalkSpeed)
                subject.TangentialVelocity += subject.Acceleration;

            else
                subject.TangentialVelocity = subject.WalkSpeed;
        }

        private static void Run(Entity entity)
        {

        }
    }
}
