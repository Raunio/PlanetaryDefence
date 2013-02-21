using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using PlanetaryDefence.Engine;
using Microsoft.Xna.Framework;

namespace PlanetaryDefence.Gameplay.Entities
{
    class GroundClutter : Entity
    {
        private Random random;
        /// <summary>
        /// Random
        /// </summary>
        public GroundClutter(Texture2D texture, Constants.ClutterType type)
        {
            random = new Random();
            switch (type)
            {
                case Constants.ClutterType.Bush:
                    currentAnimation = new Animation(texture, 0, 48, 48, 0, 0, 100, false, true);
                    break;
                case Constants.ClutterType.Rock:
                    currentAnimation = new Animation(texture, 0, 32, 32, 0, 0, 100, false, true);
                    break;
            }

            this.Position = new Vector2(random.Next(-200, 800), random.Next(-200, 800));

            currentAnimation.Animate(new GameTime());
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
