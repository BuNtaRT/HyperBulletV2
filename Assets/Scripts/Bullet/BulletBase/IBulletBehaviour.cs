using UnityEngine;

namespace Bullet.BulletBase
{
    public interface IBulletBehaviour
    {
        public BulletConfig GetConfig();

        //return: destroyConfirm
        public bool OnHit(BulletState state, Transform target);
        public void OnDie(BulletState state, Transform transform, bool force);
    }
}
