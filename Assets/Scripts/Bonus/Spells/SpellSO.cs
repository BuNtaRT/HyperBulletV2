using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Serialization;

namespace Bonus.Spells
{
    [CreateAssetMenu(fileName = "New Spell", menuName = "Bonus/Spell")]
    public class SpellSO : ScriptableObject
    {
        [FormerlySerializedAs("Id")]
        public string id;

        [FormerlySerializedAs("Price")]
        public int price;

        [FormerlySerializedAs("Type")]
        public SpellType type;

        [FormerlySerializedAs("Area")]
        public bool area;

        [FormerlySerializedAs("Ico")]
        public Sprite ico;

        [FormerlySerializedAs("Animation")]
        public PlayableAsset animation;

        [FormerlySerializedAs("MainColor")]
        public Color mainColor;

        [FormerlySerializedAs("SecondColor")]
        public Color secondColor;
    }

    public enum SpellType
    {
        Bullet,
        Hp,
        Gamemode,
    }
}
