using Enemy.EnemyBase;
using UnityEngine;
using Vault;

namespace Enemy.Behaviours
{
    public class SimpleEnemyBH : IEnemyBehavioral
    {
        public EnemyConfig GetConfig()
        {
            var config = new EnemyConfig()
            {
                Color = EnemyColors.Auaq,
                Speed = 1.3f + PlayerPrefs.GetFloat(PlayerPrefsKey.SPEED_UP),
                Hp = 1
            };

            return config;
        }

        public void OnBullet(EnemyState state)
        {
        }

        public bool OnDie(EnemyState state) => true;

        public void OnEnterShield(EnemyState state)
        {
        }

        public void OnExitShield(EnemyState state)
        {
        }

        public void OnUpdate(EnemyState state)
        {
        }
    }
}