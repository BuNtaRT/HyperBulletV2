using Runtime;
using UnityEngine;

namespace Bonus.Perk.UI
{
    public class PerkAcceptor : MonoBehaviour
    {
        public void AcceptPerk()
        {
            var lastPerk = GlobalEventsManager.LastPickupPerk;
            GlobalEventsManager.InvokePickupPerk(lastPerk, true);
        }
    }
}