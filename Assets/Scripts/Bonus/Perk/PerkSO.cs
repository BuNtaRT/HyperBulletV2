using UnityEngine;
using UnityEngine.Serialization;

namespace Bonus.Perk
{
    [CreateAssetMenu(fileName = "New Perk", menuName = "Bonus/Perk")]
    public class PerkSO : ScriptableObject
    {
        public PerkRarity rarity;

        [FormerlySerializedAs("NameRU")]
        public string nameRu;

        [FormerlySerializedAs("NameEU")]
        public string nameEu;

        [FormerlySerializedAs("DescriptionRU")]
        public string descriptionRu;

        [FormerlySerializedAs("DescriptionEU")]
        public string descriptionEu;

        [FormerlySerializedAs("Ico")]
        public Sprite ico;
        public PerkName perkName;

        [FormerlySerializedAs("GradientParticle")]
        public Gradient gradientParticle;

        [FormerlySerializedAs("MainColor")]
        public Color mainColor;
    }

    public enum PerkName : byte
    {
        // названия классов, точ в точ
        Prediction,
        ExtraSphere,
        FastBullet,
        SlowMoBullet,
        TwoXPowerBullet,
        BurstingBullet,
        RicochetBullet,
        SlowMoShoot,
        SuperPower,
        SuperDiscontr,
        ExplBullet,
        Clone,
        Healt,
        SuperPowerShealt,
        EmiBullet,
        TwoXDamage,
    }

    public enum PerkRarity : byte
    {
        Standart,
        Rare,
        Epic,
        Legendary
    }
}
