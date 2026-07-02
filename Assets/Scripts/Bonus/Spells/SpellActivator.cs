using Bonus.Combiner;
using Bonus.Spells.Variations;
using UnityEngine;

namespace Bonus.Spells
{
    public static class SpellActivator
    {
        public static void Activate(SpellBase spell)
        {
            if (typeof(ICombinableEffect).IsAssignableFrom(spell.GetType()))
            {
                Debug.Log("Реализует интерфейс!");
            }
            else if (typeof(ICombinableEffect).IsAssignableFrom(spell.GetType())) { }
        }
    }
}
