using Lib;
using Runtime;

namespace Bonus.Perk
{
    public class PerkBonus : ItemOnRoadAnimationBase, IPickable
    {
        private PerkSO _perk;

        public void Set(PerkSO perk)
        {
            _perk = perk;
            icoSprite.sprite = perk.ico;
            StartAnim(perk.mainColor, perk.secondColor, TimeExpired);
        }

        public void Pick()
        {
            GlobalEventsManager.InvokePickupPerk(_perk, false);
            Destroy();
        }

        private void TimeExpired() => Destroy();

        private void Destroy()
        {
            StopAnim();
            ObjectPool.Destroy(TypeObj.Perk, gameObject);
        }
    }
}