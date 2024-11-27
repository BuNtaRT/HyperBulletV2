using Lib;
using Runtime;

namespace Bonus.Perk
{
    public class PerkOnRoad : ItemOnRoadAnimationBase, IPickable
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
            GlobalEventsManager.InvokePickupPerk(_perk);
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
