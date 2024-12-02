using Bullet.BulletBase;
using Lib;
using Runtime;
using Runtime.Base;
using UnityEngine;
using Vault;

namespace Player.Shoot
{
    public class Shooting : TouchGameStatusBase
    {
        private float _energy = 500;

        //todo: передавать патроны после загрузки сцены
        public Shooting()
            : base()
        {
        }

        protected override void OnTouchChanged(EventTouch touch)
        {
            if (touch.Collision.CompareTag(GameTags.BONUS))
                return;

            base.OnTouchChanged(touch);
            if (CurrentStatus != GameStatus.Action || _energy < LvlVariables.BulletCost)
                return;

            Debug.Log("bulletCost - " + LvlVariables.BulletCost);

            _energy -= LvlVariables.BulletCost;
            var bullet = ObjectPool.SpawnObj(TypeObj.Bullet, LvlVariables.PlayerPosition);
            var behaviour = bullet.GetComponent<BulletBehavior>();

            behaviour.Init(LvlVariables.BulletBehaviour, touch.Position, LvlVariables.BulletRadius);
        }
    }
}