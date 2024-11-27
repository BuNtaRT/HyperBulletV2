using DG.Tweening;
using Enemy.EnemyBase;
using Lib;
using Runtime;
using UnityEngine;
using Vault;

namespace Bullet.BulletBase
{
    public class BulletBehavior : MonoBehaviour
    {
        private Tweener _moveTween;

        private BulletState _state;
        private IBulletBehaviour _bulletBehaviour;

        private void Awake()
        {
            _moveTween.Play();
        }

        public void Init(IBulletBehaviour behaviour, Vector2 target, float distance)
        {
            _bulletBehaviour = behaviour;

            BulletConfig config = behaviour.GetConfig();
            _state = new BulletState(transform, config);

            Vector2 bulletTarget = target.normalized * distance;

            float duration = Vector2.Distance(transform.position, bulletTarget) / config.Speed;

            _moveTween = transform
                .DOMove(bulletTarget, duration)
                .SetEase(Ease.Linear)
                .OnUpdate(OnMoveUpdate)
                .OnComplete(CompleteMove);
        }

        //--------------------------- Взаимодействие

        private void OnHit(Transform enemy)
        {
            EnemyBehaviour enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
            TakeBulletEnemyEffect enemyEffect = enemyBehaviour.TakeBullet(_state.GetConfig());

            // по хорошему тут можно сделать возврат интерфеса для изменения пули, но это если эффектов будет больше 3 хотя бы
            if (enemyEffect == TakeBulletEnemyEffect.None)
            {
                bool destroyConfirm = _bulletBehaviour.OnHit(_state, transform);
                if (destroyConfirm)
                {
                    _bulletBehaviour.OnDie(_state, transform, false);
                    Destroy();
                }
            }
            if (enemyEffect == TakeBulletEnemyEffect.Ricochet)
                Ricochet();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag(GameTags.ENEMY))
                return;

            OnHit(collision.transform);
        }

        //--------------------------- Изменение позиции

        private void OnMoveUpdate()
        {
            float elapsedTime = _moveTween.ElapsedPercentage();

            float deviation = _state.GetMoveDeviation(elapsedTime);

            Vector3 currentPosition = transform.position;
            currentPosition.x += deviation;
            transform.position = currentPosition;
        }

        private void Ricochet()
        {
            float distance = Vector2.Distance(transform.position, LvlVariables.PlayerPosition);
            Vector2 target = Vector2Tools.GetRandomPointOnCircle(transform.position, distance / 2);
            UpdateTarget(target, Ease.OutQuart);
        }

        private void UpdateTarget(Vector2 target, Ease ease)
        {
            _moveTween.Kill();

            float duration = Vector2.Distance(transform.position, target) / _state.GetSpeed();

            _moveTween = transform.DOMove(target, duration).SetEase(ease).OnUpdate(OnMoveUpdate);

            _moveTween.Play();
        }

        //--------------------------- Конечная

        private void CompleteMove()
        {
            _bulletBehaviour.OnDie(_state, transform, true);
            Destroy();
        }

        private void Destroy()
        {
            _moveTween.Kill();
            ObjectPool.Destroy(TypeObj.Bullet, gameObject);
        }
    }
}
