using Runtime;
using UnityEngine;

namespace Bonus.Perk.UI
{
    public class RoadPerk : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer icon;

        [SerializeField]
        private Animator animator;

        public void SetPerk()
        {
            var perk = GlobalEventsManager.LastPickupPerk;

            icon.enabled = true;
            icon.sprite = perk.ico;
            icon.color = perk.mainColor;
        }
    }
}
