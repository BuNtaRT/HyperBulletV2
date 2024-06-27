using DG.Tweening;
using Lib;
using Runtime;
using UnityEngine;

namespace Enemy.EnemyBase
{
    public class EnemyBehaviour : MonoBehaviour
    {
        public Tweener MoveTween;

        private EnemyState _state;
        private IEnemyBehavioral _enemyBehaviour;

        private void Awake()
        {
            MoveTween.Play();
        }

        public void Init(IEnemyBehavioral behaviour)
        {
            _enemyBehaviour = behaviour;

            var config = behaviour.GetConfig();
            _state = new EnemyState(transform, config);

            float speed = Vector2.Distance(transform.position, LvlVariables.PlayerPosition) / config.Speed;

            MoveTween = transform.DOMove(LvlVariables.PlayerPosition, speed)
                .SetEase(Ease.Linear)
                .OnUpdate(OnMoveUpdate);
        }


        //todo: Пока void, но нужно наверное возвращать поведение пули при столкновении

        public void TakeBullet()
        {
            //todo: нужно что бы пуля передавала свой конфиг и от туда брать урон
            _state.TakeDamage(1);
            //todo: еще нужно передать пулю сюда
            _enemyBehaviour.OnBullet(_state);

            if (_state.GetStatus() == EnemyLiveStatus.Death)
                OnDie();
        }

        public void EnterShield() => _enemyBehaviour.OnEnterShield(_state);
        public void ExitShield() => _enemyBehaviour.OnExitShield(_state);

        private void OnMoveUpdate() => _enemyBehaviour.OnUpdate(_state);

        private void OnDie()
        {
            var reallyDie = _enemyBehaviour.OnDie(_state);
            if (!reallyDie)
                return;

            MoveTween.Kill();

            //todo: можно кастомизировать дистанцию и время отлета назад, а так же Ease для каждого типа противника в конфиге
            float knockbackDistance = 2f;
            float knockbackDuration = 1f;

            Vector2 direction = ((Vector2)transform.position).normalized * -1;
            Vector2 knockbackPosition = (Vector2)transform.position + direction * knockbackDistance;
            transform.DOMove(knockbackPosition, knockbackDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(() => ObjectPool.Destroy(TypeObj.Enemy, gameObject));
        }
    }
}