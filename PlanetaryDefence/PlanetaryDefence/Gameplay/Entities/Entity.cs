using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PlanetaryDefence.Engine;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetaryDefence.Engine.Entities
{
    /// <summary>
    /// Base class for all game entities.
    /// </summary>
    public abstract class Entity
    {
        #region Members
        protected Animation currentAnimation;
        protected float rotation;
        #endregion

        #region Gets & Sets
        /// <summary>
        /// Gets the position of the entity.
        /// </summary>
        public Vector2 Position
        {
            get;
            protected set;
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
                currentAnimation.FrameRectangle, Color.White, rotation, new Vector2(currentAnimation.FrameRectangle.Width / 2, currentAnimation.FrameRectangle.Height / 2),
                SpriteEffects.None, 0f);
        }

        public abstract void Update(GameTime gameTime);
        #endregion


    }
}
