using System.Collections.Generic;
using Runtime;
using UnityEngine.PlayerLoop;

namespace Bonus.Spells.UI
{
    public class SpellQueue
    {
        private int _currentIndex;
        private List<WheelItem> _items;

        public void Initialization(List<WheelItem> items)
        {
            GlobalEventsManager.OnPickupSpell.AddListener(OnPickupSpellChanged);
            _items = items;
        }

        private void OnPickupSpellChanged(SpellSO spell)
        {
            _items[_currentIndex].Set(spell);
            _currentIndex = (_currentIndex + 1) % _items.Count;
        }
    }
}
