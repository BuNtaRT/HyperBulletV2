using UnityEngine;
using UnityEngine.Playables;

namespace Bonus.Spells
{
    [CreateAssetMenu(fileName = "New Spell", menuName = "Bonus/Spell")]

    public class SpellSO : ScriptableObject
    {
        public string Id;
        public int Price;
        public SpellType Type;
        public bool Area;
        public Sprite Ico;
        public PlayableAsset Animation;
    }

    public enum SpellType 
    {
        bullet,
        hp,
        gamemode,
    }
}