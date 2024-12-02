using System;
using Runtime;
using UnityEngine;

namespace Bonus.Perk.UI
{
    public class RoadPerk : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer icon;

        [SerializeField] private Animator animator;

        public void SetPerk(PerkSO perk)
        {
            icon.enabled = true;
            icon.sprite = perk.ico;
            icon.color = perk.mainColor;
        }

        private void Awake()
        {
            GlobalEventsManager.OnPickupPerk.AddListener(OnPickupPerkChanged);
        }

        private void OnPickupPerkChanged(PerkSO perk, bool confirm)
        {
            if (!confirm)
                return;

            SetPerk(perk);
        }
    }
}