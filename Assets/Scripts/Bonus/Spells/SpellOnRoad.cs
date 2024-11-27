using Lib;
using Runtime;

namespace Bonus.Spells
{
    public class SpellOnRoad : ItemOnRoadAnimationBase, IPickable
    {
        private SpellSO _spell;

        public void Set(SpellSO spell)
        {
            _spell = spell;
            icoSprite.sprite = spell.ico;
            StartAnim(spell.mainColor, spell.secondColor, TimeExpired);
        }

        public void Pick()
        {
            GlobalEventsManager.InvokePickupSpell(_spell);
            Destroy();
        }

        private void TimeExpired() => Destroy();

        private void Destroy()
        {
            StopAnim();
            ObjectPool.Destroy(TypeObj.Spell, gameObject);
        }
    }
}
