using Bonus.Perk;
using Bonus.Perk.Variations;
using Bullet.BulletBase;
using Enemy.EnemyBase;
using Runtime;

namespace Bonus.Combiner
{
    public class LifecycleEffectCombiner
    {
        private ICombinableEffect[] _staticEffects = new ICombinableEffect[1];

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
                $"Bonus.Perk.Variations.{perk.perkName}",
                new DefaultPerk()
            );

            _staticEffects[0].Init();
        }

        //--------------------------- События для комбинирования

        private void OnBulletCreatedChanged(BulletState bullet)
        {
            foreach (var combinableEffect in _staticEffects)
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
        }

        private void OnBulletHittingChanged(EventBulletHitting hitting)
        {
            foreach (var combinableEffect in _staticEffects)
            {
                combinableEffect?.OnHitting(hitting);
            }
        }
    }
}