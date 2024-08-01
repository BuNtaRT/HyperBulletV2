using Bullet.BulletBase;
using Lib;
using UnityEngine;
using Vault;

namespace Bullet
{
    public class SimpleBullet : IBulletBehaviour
    {
        public BulletConfig GetConfig()
        {
            BulletSO bullet = LoadPool.Load<BulletSO>(ResourcesPath.BulletSO("SimpleBullet"));
            return new BulletConfig(bullet);
        }

        public bool OnHit(BulletState state, Transform target) => true;

        public void OnDie(BulletState state, Transform transform, bool force) { }
    }
}
