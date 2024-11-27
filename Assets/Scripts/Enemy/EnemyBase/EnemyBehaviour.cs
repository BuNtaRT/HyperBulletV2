using Bullet.BulletBase;
using DG.Tweening;
using Lib;
using Runtime;
using UnityEngine;

namespace Enemy.EnemyBase
{
    public class EnemyBehaviour : MonoBehaviour
    {
        private Tweener _moveTween;

        private EnemyState _state;
        private IEnemyBehavioral _enemyBehaviour;

        private void Awake()
        {
            _moveTween.Play();
        }

        public void Init(IEnemyBehavioral behaviour)
        {
            _enemyBehaviour = behaviour;

            EnemyConfig config = behaviour.GetConfig();
            _state = new EnemyState(transform, config);

            float duration =
                Vector2.Distance(transform.position, LvlVariables.PlayerPosition) / config.Speed;

            _moveTween = transform
                .DOMove(LvlVariables.PlayerPosition, duration)
                .SetEase(Ease.Linear)
                .OnUpdate(OnMoveUpdate);
        }

        public TakeBulletEnemyEffect TakeBullet(BulletConfig bullet)
        {
            TakeBulletEnemyEffect effect = _enemyBehaviour.OnBullet(_state, bullet);

            // если нужен эффект с другим уроном, то это можно реализовать в поведении противника
            if (effect == TakeBulletEnemyEffect.None)
                _state.TakeDamage(bullet.Damage);

            if (_state.GetStatus() == EnemyLiveStatus.Death)
                OnDie();

            return effect;
        }

        public void EnterShield() => _enemyBehaviour.OnEnterShield(_state);

        public void ExitShield() => _enemyBehaviour.OnExitShield(_state);

        private void OnMoveUpdate() => _enemyBehaviour.OnUpdate(_state);

        private void OnDie()
        {
            bool reallyDie = _enemyBehaviour.OnDie(_state);
            if (!reallyDie)
                return;

            _moveTween.Kill();

            Vector2 diePosition = transform.position;
            //todo: можно кастомизировать дистанцию и время отлета назад, а так же Ease для каждого типа противника в конфиге
            float knockbackDistance = 1f;
            float knockbackDuration = 0.2f;

            Vector2 direction = ((Vector2)transform.position).normalized * -1;
            Vector2 knockbackPosition = (Vector2)transform.position - direction * knockbackDistance;
            transform
                .DOMove(knockbackPosition, knockbackDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(() => Destroy(diePosition));
        }

        private void Destroy(Vector2 position)
        {
            GlobalEventsManager.InvokeEnemyDie(position);
            ObjectPool.Destroy(TypeObj.Enemy, gameObject);
        }
    }

    public enum TakeBulletEnemyEffect
    {
        None,
        Ricochet,
    }
}
