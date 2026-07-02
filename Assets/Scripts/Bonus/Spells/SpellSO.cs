using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Serialization;

namespace Bonus.Spells
{
    [CreateAssetMenu(fileName = "New Spell", menuName = "Bonus/Spell")]
    public class SpellSO : ScriptableObject
    {
        public BonusRarity rarity;

        public SpellType type;

        public byte maxLevel;

        public Sprite ico;

        public Color mainColor;

        public Color secondColor;
    }

    public enum SpellType
    {
        SwordThrow,
    }
}
