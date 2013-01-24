using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PlanetaryDefence.Engine;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetaryDefence.Gameplay.Entities
{
    /// <summary>
    /// Base class for all game entities.
    /// </summary>
    public abstract class Entity
    {
        #region Members

        protected Animation currentAnimation;
        protected Vector2 facingPoint;
        
        #endregion

        #region Gets & Sets
        /// <summary>
        /// Gets or sets the position of the entity.
        /// </summary>
        public Vector2 Position
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the rotation of the entity in radians.
        /// </summary>
        public float Rotation
        {
            get;
            set;
        }
 
        /// <summary>
        /// Gets the bounding box of the entity. The bounding box is equal to the size of the current animation frame and is primarily used for collision detection.
        /// </summary>
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, currentAnimation.FrameWidth, currentAnimation.FrameHeight);
            }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Main draw method for all game entities. Draws the current frame of current animation.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentAnimation.spriteSheet,
                new Rectangle((int)Position.X, (int)Position.Y, currentAnimation.FrameWidth, currentAnimation.FrameHeight),
                currentAnimation.FrameRectangle, Color.White, Rotation, new Vector2(currentAnimation.FrameRectangle.Width / 2, currentAnimation.FrameRectangle.Height / 2),
                SpriteEffects.None, 0f);
        }

        public abstract void Update(GameTime gameTime);

        #endregion


    }
}
