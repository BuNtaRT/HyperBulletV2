using UnityEngine;
using UnityEngine.Serialization;

namespace Bonus.Perk
{
    [CreateAssetMenu(fileName = "New Perk", menuName = "Bonus/Perk")]
    public class PerkSO : ScriptableObject
    {
        public PerkRarity defaultRarity;

        [FormerlySerializedAs("Name")] public string nameKey;

        [FormerlySerializedAs("Description")] public string descriptionKey;

        [FormerlySerializedAs("Ico")] public Sprite ico;

        public PerkName perkName;

        [FormerlySerializedAs("GradientParticle")]
        public Gradient gradientParticle;

        [FormerlySerializedAs("MainColor")] public Color mainColor;

        [FormerlySerializedAs("SecondColor")] public Color secondColor;
    }

    public enum PerkName : byte
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

    public enum PerkRarity : byte
    {
        Standard,
        Rare,
        Epic,
        Legendary
    }
}