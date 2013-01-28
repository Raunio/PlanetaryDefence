using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetaryDefence.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetaryDefence.Gameplay.Entities.Turret
{
    class TurretShield : Entity
    {
        private Constants.TurretShieldState shieldState;
        private Animation idleAnimation;
        private Animation hitAnimation;

        public TurretShield()
        {
            shieldState = Constants.TurretShieldState.Active;
        }

        public void LoadContent(ContentManager content)
        {
            idleAnimation = new Animation(content.Load<Texture2D>(Constants.TurretShieldSpritesheet), 0, 70, 70, 0, 0, 100, false, true);
            hitAnimation = new Animation(content.Load<Texture2D>(Constants.TurretShieldSpritesheet), 1, 1, 1, 1, 1, 100, false, false);

            currentAnimation = idleAnimation;
        }

        public override void Update(GameTime gameTime)
        {
            currentAnimation.Animate(gameTime);
        }

        private void HandleAnimations()
        {
            switch (shieldState)
            {
                case Constants.TurretShieldState.TakingHit:
                    currentAnimation = hitAnimation;
                    break;

                default:
                    currentAnimation = idleAnimation;
                    break;
            }
        }
    }
}
