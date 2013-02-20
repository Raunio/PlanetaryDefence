using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PlanetaryDefence.Engine;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetaryDefence.Gameplay.Entities.Turret
{
    public class TurretBody : Entity
    {
        private int armorValue;

        public TurretBody()
        {
            
        }

        public void LoadContent(ContentManager content)
        {
            currentAnimation = new Animation(content.Load<Texture2D>(Constants.TurretBodySpritesheet), 0, 75, 66, 0, 0, 100, false, true);
            this.Origin = currentAnimation.Origin;
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime, float rotation)
        {
            currentAnimation.Animate(gameTime);
            this.Rotation = rotation;
        }

        public Animation BodyAnimation
        {
            get
            {
                return currentAnimation;
            }
        }
    }
}
