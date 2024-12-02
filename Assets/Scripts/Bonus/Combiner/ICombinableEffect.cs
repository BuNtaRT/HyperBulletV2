using Bullet.BulletBase;
using Enemy.EnemyBase;
using Runtime;

namespace Bonus.Combiner
{
    public interface ICombinableEffect
    {
        public void Init();
        public void Deactivate();

        public void OnCreatedBullet(BulletState bullet);
        public void OnCreatedEnemy(EnemyState enemy);
        public void OnHitting(EventBulletHitting enemy);
    }
}