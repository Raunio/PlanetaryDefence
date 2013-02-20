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
        protected Vector2 origin;
        
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
        /// <summary>
        /// Gets the origin of the entity.
        /// </summary>
        public Vector2 Origin
        {
            get
            {
                if (origin == null)
                    return new Vector2(currentAnimation.FrameWidth / 2, currentAnimation.FrameHeight / 2);
                else
                    return origin;
            }
            set
            {
                origin = value;
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
                currentAnimation.FrameRectangle, Color.White, Rotation, Origin, SpriteEffects.None, 0f);
        }

        public abstract void Update(GameTime gameTime);

        public void FacePoint(Vector2 point)
        {
            this.facingPoint = point;
        }

        #endregion


    }
}
