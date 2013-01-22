using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ProjectMercury;

namespace PlanetaryDefence.Engine.Particle_Effects
{
    class VisualEffectManager
    {
        private ContentManager content;
        private GraphicsDeviceManager graphics;

        private List<VisualEffect> Effects = new List<VisualEffect>();

        private static VisualEffectManager instance;

        public static VisualEffectManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new VisualEffectManager();

                return instance;
            }
        }
        /// <summary>
        /// Initialization by passing the contentmanager and graphics object.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="graphics"></param>
        public void Initialize(ContentManager content, GraphicsDeviceManager graphics)
        {
            this.content = content;
            this.graphics = graphics;
        }
        /// <summary>
        /// Update all effects.
        /// </summary>
        /// <param name="gameTime"></param>
        public void UpdateEffects(GameTime gameTime)
        {
            foreach (VisualEffect e in Effects)
            {
                e.Trigger(gameTime);
                e.Update(gameTime);
            }

            CleanEffects();
        }
        /// <summary>
        /// Draws all effetcs.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void DrawEffects(SpriteBatch spriteBatch)
        {
            foreach (VisualEffect e in Effects)
                e.Draw(spriteBatch);
        }
        /// <summary>
        /// Search for dead effects and remove them.
        /// </summary>
        private void CleanEffects()
        {
            for (int i = 0; i < Effects.Count; i++)
                if (!Effects[i].IsAlive)
                    Effects.RemoveAt(i);
        }

        public void CreateEffect(string asset, Vector2 position, int Lifetime)
        {
            VisualEffect e = new VisualEffect(asset);
            e.Initialize(content, graphics);
            e.Position = position;
            e.Lifetime = Lifetime;
            Effects.Add(e);
        }
        
    }
}
