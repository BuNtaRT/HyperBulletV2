using Bonus.Combiner;
using Bullet.BulletBase;
using Enemy.EnemyBase;
using Runtime;

namespace Bonus.Spells.Variations
{
    public class DefaultSpell : ICombinableEffect
    {
        public void Init() { }

        public void Deactivate() { }

        public void OnCreatedBullet(BulletState bullet) { }

        public void OnCreatedEnemy(EnemyState enemy) { }

        public void OnHitting(EventBulletHitting enemy) { }
    }
}
