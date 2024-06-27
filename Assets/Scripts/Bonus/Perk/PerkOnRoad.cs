
using Lib;
using Runtime;

namespace Bonus.Perk
{
    public class PerkOnRoad : ItemOnRoadBase, IPickable
    {
        private PerkSO _perk;

        private void Awake()
        {
            _objectType = TypeObj.None;
            Init();
        }

        public void Set(PerkSO perk)
        {
            _perk = perk;
            _icoRender.sprite = perk.Ico;
            InitAnim();
        }

        public void Pick()
        {
            GlobalEventsManager.InvokPickupPerk(_perk);
            End();
            ObjectPool.Destroy(TypeObj.Perk, gameObject);
        }
    }
}