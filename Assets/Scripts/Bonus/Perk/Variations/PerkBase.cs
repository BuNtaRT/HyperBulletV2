using Runtime;

namespace Bonus.Perk.Variations
{
    public class PerkBase
    {
        protected PerkRarity _rarity;

        public PerkBase()
        {
        }

        public PerkBase(string perkName)
        {
            if (LvlVariables.AvailablePerks.TryGetValue(perkName, out var rarity) && rarity.Value != null)
                _rarity = rarity.Value;
            else _rarity = PerkRarity.Standard;
        }
    }
}