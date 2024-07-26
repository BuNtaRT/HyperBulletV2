using Lib;
using Runtime;

namespace Bonus.Spells
{
    public class SpellOnRoad : ItemOnRoadBase, IPickable
    {
        private SpellSO _spell;

        private void Awake()
        {
            ObjectType = TypeObj.Spell;
            Init();
        }

        public void Set(SpellSO spell)
        {
            _spell = spell;
            icoRender.sprite = spell.ico;
            InitAnim();
        }

        public void Pick()
        {
            GlobalEventsManager.InvokePickupSpell(_spell);
            End();
            ObjectPool.Destroy(TypeObj.Spell, gameObject);
        }
    }
}
