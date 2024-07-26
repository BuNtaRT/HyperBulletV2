using Lib;
using Runtime;

namespace Bonus.Perk
{
    public class PerkOnRoad : ItemOnRoadBase, IPickable
    {
        private PerkSO _perk;

        private void Awake()
        {
            ObjectType = TypeObj.None;
            Init();
        }

        public void Set(PerkSO perk)
        {
            _perk = perk;
            icoRender.sprite = perk.ico;
            InitAnim();
        }

        public void Pick()
        {
            GlobalEventsManager.InvokePickupPerk(_perk);
            End();
            ObjectPool.Destroy(TypeObj.Perk, gameObject);
        }
    }
}
