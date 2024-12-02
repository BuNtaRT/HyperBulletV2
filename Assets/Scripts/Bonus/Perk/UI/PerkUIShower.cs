using Runtime;
using UnityEngine;
using UnityEngine.UI;
using Vault;

namespace Bonus.Perk.UI
{
    public class PerkUIShower : MonoBehaviour
    {
        [SerializeField] private GameObject perkWindow;

        [SerializeField] private Image icon;
        [SerializeField] private Image background;

        [SerializeField] private ParticleSystem trail1;
        [SerializeField] private ParticleSystem trail2;

        [SerializeField] private Text title;
        [SerializeField] private Text description;

        private Vector3 _startTrail1Position;
        private Vector3 _startTrail2Position;

        private void Awake()
        {
            _startTrail1Position = trail1.transform.localPosition;
            _startTrail2Position = trail2.transform.localPosition;
            GlobalEventsManager.OnPickupPerk.AddListener(OnPickupPerkChanged);
        }

        public void CloseBonusWindow()
        {
            GlobalEventsManager.InvokeGameStatus(GameStatus.Action);
            trail1.transform.localPosition = _startTrail1Position;
            trail2.transform.localPosition = _startTrail2Position;
            perkWindow.SetActive(false);
        }

        private void OnPickupPerkChanged(PerkSO perk, bool confirmed)
        {
            if (confirmed)
                return;

            var gradient = GetGradient(perk);

            title.text = Localization.GetByKey(perk.nameKey);
            description.text = Localization.GetByKey(perk.descriptionKey);

            title.color = perk.mainColor;

            var effect1 = trail1.colorOverLifetime;
            effect1.color = gradient;
            var effect2 = trail2.colorOverLifetime;
            effect2.color = gradient;

            background.color = perk.mainColor;
            icon.sprite = perk.ico;

            perkWindow.SetActive(true);
        }

        private Gradient GetGradient(PerkSO spell)
        {
            Gradient gradient = new Gradient();
            var colors = new GradientColorKey[2];
            colors[0] = new GradientColorKey(spell.mainColor, 0.0f);
            colors[1] = new GradientColorKey(spell.secondColor, 0.8f);
            var alphas = new GradientAlphaKey[2];
            alphas[0] = new GradientAlphaKey(1.0f, 0.0f);
            alphas[1] = new GradientAlphaKey(0.0f, 1.0f);
            gradient.SetKeys(colors, alphas);

            return gradient;
        }
    }
}