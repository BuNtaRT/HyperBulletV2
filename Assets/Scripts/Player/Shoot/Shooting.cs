using Bullet.BulletBase;
using Lib;
using Runtime;
using Runtime.Base;
using Vault;

namespace Player.Shoot
{
    public class Shooting : TouchGameStatusBase
    {
        private int _ammo = 500;

        //todo: передавать патроны после загрузки сцены
        public Shooting()
            : base() { }

        protected override void OnTouchChanged(EventTouch touch)
        {
            base.OnTouchChanged(touch);
            if (CurrentStatus != GameStatus.Action || _ammo < LvlVariables.BulletCost)
                return;

            _ammo -= LvlVariables.BulletCost;
            var bullet = ObjectPool.SpawnObj(TypeObj.Bullet, LvlVariables.PlayerPosition);
            var behaviour = bullet.GetComponent<BulletBehavior>();

            behaviour.Init(LvlVariables.BulletBehaviour, touch.Position, LvlVariables.BulletRadius);
        }
    }
}
