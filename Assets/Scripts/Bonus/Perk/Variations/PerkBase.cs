using Runtime;

namespace Bonus.Perk.Variations
{
    public class PerkBase
    {
        protected BonusLevel _level;

        protected PerkBase(string perkName)
        {
            if (LvlVariables.AvailablePerks.TryGetValue(perkName, out var level) && level != null)
                _level = level.Value;
            else
                _level = BonusLevel.First;
        }
    }
}
