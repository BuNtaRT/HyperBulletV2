using Bonus.Combiner;
using Bullet.BulletBase;
using Enemy.EnemyBase;
using Runtime;

namespace Bonus.Spells.Variations
{
    public class SpellBase
    {
        protected BonusLevel _level;

        protected SpellBase(string spellName)
        {
            if (LvlVariables.AvailableSpells.TryGetValue(spellName, out var level) && level != null)
                _level = level.Value;
            else
                _level = BonusLevel.First;
        }
    }
}
