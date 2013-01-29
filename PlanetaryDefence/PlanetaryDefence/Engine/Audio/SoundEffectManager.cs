using System;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using PlanetaryDefence.Engine;

namespace PlanetaryDefence
{
    class SoundEffectManager
    {
        private static SoundEffectManager instance = null;
        private ContentManager content;

        private SoundEffect menuSelect;
        private SoundEffect menuIndexChange;
        private SoundEffect plasmaGunFire;

        private SoundEffectManager() { }

        public void Initialize() { }

        public static SoundEffectManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new SoundEffectManager();

                return instance;
            }
        }

        public void LoadContent(ContentManager content)
        {
            this.content = content;
            plasmaGunFire = content.Load<SoundEffect>(Constants.PlasmaGunFire);
            Console.WriteLine("SoundEffects loaded.");
        }

        public void IndexChange()
        {
            if (Globals.SoundsEnabled) menuIndexChange.Play();
        }

        public void IndexSelect()
        {
            if (Globals.SoundsEnabled) menuSelect.Play();
        }

        public void PlasmaGunFire()
        {
            if (Globals.SoundsEnabled) plasmaGunFire.Play();
        }

        public void PlaySound(string asset)
        {
            SoundEffect sound = content.Load<SoundEffect>(asset);

            if (Globals.SoundsEnabled) sound.Play();
        }

    }
}
