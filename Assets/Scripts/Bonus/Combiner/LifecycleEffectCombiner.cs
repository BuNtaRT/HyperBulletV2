using System.Collections.Generic;
using Bonus.Perk;
using Bonus.Perk.Variations;
using Bonus.Spells;
using Bonus.Spells.Variations;
using Bullet.BulletBase;
using Enemy.EnemyBase;
using Runtime;

namespace Bonus.Combiner
{
    public class LifecycleEffectCombiner
    {
        private ICombinableEffect[] _staticEffects = new ICombinableEffect[1];
        private List<ICombinableEffect> _dynamicEffects = new List<ICombinableEffect>();

        public LifecycleEffectCombiner()
        {
            GlobalEventsManager.OnPickupPerk.AddListener(OnPickupPerkChanged);

            GlobalEventsManager.OnBulletCreated.AddListener(OnBulletCreatedChanged);
            GlobalEventsManager.OnEnemyCreated.AddListener(OnEnemyCreatedChanged);
            GlobalEventsManager.OnBulletHitting.AddListener(OnBulletHittingChanged);
        }

        //--------------------------- Постоянные эффекты

        private void OnPickupPerkChanged(PerkSO perk, bool confirmed)
        {
            if (!confirmed)
                return;

            _staticEffects[0]?.Deactivate();

            _staticEffects[0] = Instance.GetByName<ICombinableEffect>(
                $"Bonus.Perk.Variations.{perk.type}",
                new DefaultPerk()
            );

            _staticEffects[0].Init();
        }

        //--------------------------- Временные эффекты

        private void OnUseSpell(SpellSO spell)
        {
            var effect = Instance.GetByName<ICombinableEffect>(
                $"Bonus.Spell.Variations.{spell.type}",
                new DefaultSpell()
            );

            effect.Init();
            _dynamicEffects.Add(effect);
        }

        private void OnRemoveSpell(ICombinableEffect effect)
        {
            effect?.Deactivate();
            _dynamicEffects.Remove(effect);
        }

        //--------------------------- События для комбинирования

        private void OnBulletCreatedChanged(BulletState bullet)
        {
            foreach (var combinableEffect in _staticEffects)
            {
                combinableEffect?.OnCreatedBullet(bullet);
            }
            foreach (var combinableEffect in _dynamicEffects)
            {
                combinableEffect?.OnCreatedBullet(bullet);
            }
        }

        private void OnEnemyCreatedChanged(EnemyState enemy)
        {
            foreach (var combinableEffect in _staticEffects)
            {
                combinableEffect?.OnCreatedEnemy(enemy);
            }
            foreach (var combinableEffect in _dynamicEffects)
            {
                combinableEffect?.OnCreatedEnemy(enemy);
            }
        }

        private void OnBulletHittingChanged(EventBulletHitting hitting)
        {
            foreach (var combinableEffect in _staticEffects)
            {
                combinableEffect?.OnHitting(hitting);
            }
            foreach (var combinableEffect in _dynamicEffects)
            {
                combinableEffect?.OnHitting(hitting);
            }
        }
    }
}
