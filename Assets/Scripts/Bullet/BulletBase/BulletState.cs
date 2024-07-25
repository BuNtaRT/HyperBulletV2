using UnityEngine;

namespace Bullet.BulletBase
{
    public class BulletState
    {
        private readonly Transform _bulletObject;
        private readonly BulletConfig _config;

        private int _damage;
        private float _speed;

        public BulletState(Transform bulletObject, BulletConfig config)
        {
            _config = config;

            _damage = config.Damage;
            _speed = config.Speed;
            _bulletObject = bulletObject;

            SetColor(config.Color);
            SetGradient(config.Trail);
        }

        public BulletConfig GetConfig() => _config;

        //--------------------------- Движение

        public float GetSpeed() => _speed;

        public float GetMoveDeviation(float percent)
        {
            if (!_config.CustomMove)
                return 0f;
            return _config.MovePattern.Evaluate(percent);
        }

        //--------------------------- Урон

        public int GetDamage() => _damage;

        public void SetDamage(int damage)
        {
            _damage = damage;
        }

        public void ResetDamage()
        {
            _damage = _config.Damage;
        }

        //--------------------------- Цвет

        private void SetColor(Color color)
        {
            var sprite = _bulletObject.GetComponent<SpriteRenderer>();
            sprite.color = color;
        }

        private void SetGradient(Gradient gradient)
        {
            var trail = _bulletObject.GetComponent<TrailRenderer>();
            trail.colorGradient = gradient;
        }
    }

    public class BulletConfig
    {
        public BulletConfig(BulletSO bullet)
        {
            Speed = bullet.Speed;
            Damage = bullet.Damage;
            Color = bullet.Color;
            Trail = bullet.Trail;
            CustomMove = bullet.CustomMove;
            MovePattern = bullet.MovePattern;
        }

        public float Speed;
        public int Damage;

        // public AudioClip FireAudio;
        // public AudioClip ProcessAudio;
        // public AudioClip EndAudio;

        public Color Color;
        public Gradient Trail;

        public bool CustomMove;
        public AnimationCurve MovePattern;
    }
}
