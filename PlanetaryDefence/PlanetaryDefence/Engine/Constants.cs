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

        public const String PlasmaGunFire = "Audio/SoundEffects/plasmagun";
        
        #endregion

        #region Music

        public const String MenuMusic = "Music/MenuMusic";
        public const String Level1Music = "Music/Level1Music";

        #endregion

        #region Sprite Sheets

        public const String TurretMainBarrelSpritesheet = "Sprites/Entities/Turret/turretBarrel";
        public const String TurretSecondaryBarrelSheet = "Sprites/Entities/Turret/turretBarrel";
        public const String TurretBodySpritesheet = "Sprites/Entities/Turret/turretBody";
        public const String TurretShieldSpritesheet = "Sprites/Entities/Turret/turretShield";

        public const String ProjectileSpriteSheet = "Sprites/Entities/Projectiles/plasmaBall";

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

        public enum TurretBarrelState
        {
            Idle,
            Shooting,
            Reloading,
        }

        public enum TurretShieldState
        {
            Active,
            Disabled,
            Recharging,
            TakingHit,
        }

        public enum ProjectileType
        {
            PlasmaBall,
        }

        #endregion
    }
}
