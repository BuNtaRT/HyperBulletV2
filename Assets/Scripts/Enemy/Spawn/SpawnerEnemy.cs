using Enemy.EnemyBase;
using Lib;
using Runtime;
using UnityEngine;

namespace Enemy.Spawn
{
    public class SpawnerEnemy
    {
        private const float AREA_BORDERS = 1.2f;

        private Vector2[] _anglesCoordinate;
        private readonly Camera _mainCamera;

        public SpawnerEnemy()
        {
            _mainCamera = Camera.main;
            UpdateAngles();
            GlobalEventsManager.OnPlayerMove.AddListener(OnPlayerMoveChanged);
        }

        public Transform Spawn(IEnemyBehavioral behavior)
        {
            var sides = GetSide();
            var spawnPoint = GetPointOnSide(sides);

            var enemy = ObjectPool.SpawnObj(TypeObj.Enemy, spawnPoint);
            enemy.GetComponent<EnemyBehaviour>().Init(behavior);

            return enemy;
        }

        private void OnPlayerMoveChanged(EventMovePlayer movement)
        {
            if (movement.Stage == ProgressStage.Ended)
                UpdateAngles();
        }

        private void UpdateAngles()
        {
            var worldBottomLeft = _mainCamera!.ScreenToWorldPoint(
                new Vector3(0, 0, _mainCamera.nearClipPlane)
            );
            var worldBottomRight = _mainCamera.ScreenToWorldPoint(
                new Vector3(Screen.width, 0, _mainCamera.nearClipPlane)
            );
            var worldTopLeft = _mainCamera.ScreenToWorldPoint(
                new Vector3(0, Screen.height, _mainCamera.nearClipPlane)
            );
            var worldTopRight = _mainCamera.ScreenToWorldPoint(
                new Vector3(Screen.width, Screen.height, _mainCamera.nearClipPlane)
            );

            _anglesCoordinate = new[]
            {
                GetPointWithBorders(worldBottomLeft),
                GetPointWithBorders(worldTopLeft),
                GetPointWithBorders(worldTopRight),
                GetPointWithBorders(worldBottomRight)
            };
        }

        private Vector2 GetPointOnSide(Vector2[] sideDots)
        {
            var position = Random.Range(0, 1f);
            return Vector2.Lerp(sideDots[0], sideDots[1], position);
        }

        private Vector2[] GetSide()
        {
            var count = _anglesCoordinate.Length;
            var direction = Random.Range(0, 2) == 0 ? -1 : 1;

            var indexFirst = Random.Range(0, count);
            var indexSecond = (indexFirst + direction + count) % count;

            return new[] { _anglesCoordinate[indexFirst], _anglesCoordinate[indexSecond] };
        }

        private Vector2 GetPointWithBorders(Vector3 point) => point * AREA_BORDERS;
    }
}
