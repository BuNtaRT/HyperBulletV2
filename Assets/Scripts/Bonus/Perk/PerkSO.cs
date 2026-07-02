using UnityEngine;
using UnityEngine.Serialization;

namespace Bonus.Perk
{
    [CreateAssetMenu(fileName = "New Perk", menuName = "Bonus/Perk")]
    public class PerkSO : ScriptableObject
    {
        public BonusRarity rarity;

        public byte maxLevel;

        public string nameKey;

        public string descriptionKey;

        public Sprite ico;

        public PerkType type;

        public Gradient gradientParticle;

        public Color mainColor;

        public Color secondColor;
    }

    public enum PerkType : byte
    {
        Discount,
        // ExtraSphere,
        // FastBullet,
        // SlowMoBullet,
        // TwoXPowerBullet,
        // BurstingBullet,
        // RicochetBullet,
        // SlowMoShoot,
        // SuperPower,
        // SuperDiscontr,
        // ExplBullet,
        // Clone,
        // Healt,
        // SuperPowerShealt,
        // EmiBullet,
        // TwoXDamage,
    }
}
