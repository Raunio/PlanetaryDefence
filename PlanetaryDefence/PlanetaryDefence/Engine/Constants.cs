using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetaryDefence.Engine
{
    public class Constants
    {
        #region Levels

        #endregion

        #region Fonts
        public const String GameFont = "Fonts/GameFont";
        #endregion

        #region Sound Effects

        public const String MenuSelectedIndexChange = "SoundEffects/MenuSelectedIndexChange";
        public const String MenuIndexSelected = "SoundEffects/MenuIndexSelected";
        
        #endregion

        #region Music

        public const String MenuMusic = "Music/MenuMusic";
        public const String Level1Music = "Music/Level1Music";

        #endregion

        #region Sprite Sheets

        #endregion

        #region Background Images

        #endregion

        #region Other Textures

        #endregion

        #region Visual Effects

        #endregion

        #region Enumerations

        public enum EntityRotationDirection
        {
            Clockwise,
            Counterclockwise,
            None,
        }

        public enum CharacterState
        {
            Stopped,
            Walking,
            Attacking,
            Disabled,
            Dead,
        }

        #endregion
    }
}
