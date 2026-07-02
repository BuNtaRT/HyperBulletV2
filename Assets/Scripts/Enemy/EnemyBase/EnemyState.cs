using UnityEngine;

namespace Enemy.EnemyBase
{
    public class EnemyState
    {
        private readonly Transform _enemyObject;
        private readonly EnemyConfig _config;

        private float _speed;
        private int _hp;

        private EnemyLiveStatus _status;

        public EnemyState(Transform enemyObject, EnemyConfig config)
        {
            _config = config;
            _speed = config.Speed;
            _hp = config.Hp;

            _enemyObject = enemyObject;
        }

        //--------------------------- Здоровье

        public int GetHp() => _hp;

        public void Regeneration(int addHp) => _hp += addHp;

        public EnemyLiveStatus TakeDamage(int damage)
        {
            _hp = Mathf.Clamp(_hp - damage, 0, 1000);
            _status = _hp != 0 ? EnemyLiveStatus.Alive : EnemyLiveStatus.Death;
            return _status;
        }

        public EnemyLiveStatus GetStatus() => _status;

        //--------------------------- Скорость

        public float GetSpeed() => _speed;

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        public float ResetSpeed()
        {
            _speed = _config.Speed;
            return _speed;
        }
    }

    public struct EnemyConfig
    {
        public int Hp;
        public float Speed;
        public Color Color;
    }

    public enum EnemyLiveStatus
    {
        Alive = 0,
        Death = 1,
    }
}
