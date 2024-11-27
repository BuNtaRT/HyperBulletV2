using Bullet.BulletBase;

namespace Enemy.EnemyBase
{
    public interface IEnemyBehavioral
    {
        public EnemyConfig GetConfig();
        public void OnEnterShield(EnemyState state);
        public void OnExitShield(EnemyState state);
        public void OnUpdate(EnemyState state);
        public TakeBulletEnemyEffect OnBullet(EnemyState state,BulletConfig bullet);
        public bool OnDie(EnemyState state);
    }
}