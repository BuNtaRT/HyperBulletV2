
using Lib;
using Runtime;

namespace Bonus.Spells
{
    public class SpellOnRoad : ItemOnRoadBase, IPickable
    {
        private SpellSO _spell;

        private void Awake()
        {
            _objectType = TypeObj.Spell;
            Init();
        }

        public void Set(SpellSO spell)
        {
            _spell = spell;
            _icoRender.sprite = spell.Ico;
            InitAnim();
        }

        public void Pick()
        {
            GlobalEventsManager.InvokPickupSpell(_spell);
            End();
            ObjectPool.Destroy(TypeObj.Spell, gameObject);
        }

    }
}
