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
        public static void ApplyCharacterPhysics(MovingEntity subject)
        {
            Rotate(subject);

            subject.Position += new Vector2(subject.Velocity.X, subject.Velocity.Y);
            subject.Rotation += subject.Velocity.Z;

            switch (subject.CurrentState)
            {
                case Constants.CharacterState.Walking:
                    Walk(subject);
                    break;
            }
            
        }

        public static void ApplyBulletPhysics(MovingEntity subject)
        {
            subject.Position += new Vector2(subject.Velocity.X, subject.Velocity.Y);
        }

        private static void Rotate(MovingEntity subject)
        {
            float velocityZ = subject.Velocity.Z;

            switch (subject.RotationDirection)
            {
                case Constants.EntityRotationDirection.Clockwise:
                    if(subject.Velocity.Z < subject.RotationSpeed)
                        velocityZ += subject.RotationAcceleration;
                    break;
                case Constants.EntityRotationDirection.Counterclockwise:
                    if(subject.Velocity.Z > -subject.RotationSpeed)
                        velocityZ -= subject.RotationAcceleration;
                    break;
                case Constants.EntityRotationDirection.None:
                    if (subject.Velocity.Z > subject.RotationAcceleration)
                        velocityZ -= subject.RotationAcceleration;
                    else if (subject.Velocity.Z < -subject.RotationAcceleration)
                        velocityZ += subject.RotationAcceleration;
                    else
                        velocityZ = 0;
                    break;
            }

            subject.Velocity = new Vector3(subject.Velocity.X, subject.Velocity.Y, velocityZ);
        }

        private static void Walk(MovingEntity subject)
        {
            if (subject.TangentialVelocity < subject.WalkSpeed)
                subject.TangentialVelocity += subject.Acceleration;

            else
                subject.TangentialVelocity = subject.WalkSpeed;

            float velocityX = (float)Math.Cos(subject.Rotation) * subject.TangentialVelocity;
            float velocityY = (float)Math.Sin(subject.Rotation) * subject.TangentialVelocity;

            subject.Velocity = new Vector3(velocityX, velocityY, subject.Velocity.Z);
        }

        private static void Run(MovingEntity entity)
        {

        }
    }
}
