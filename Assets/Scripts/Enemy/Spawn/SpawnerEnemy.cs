using Enemy.EnemyBase;
using Lib;
using UnityEngine;

namespace Enemy.Spawn
{
    public class SpawnerEnemy
    {
        private Vector2[] _anglesCoordinate;
        private float _areaBorders = 1.2f;

        public SpawnerEnemy(Camera camera)
        {
            var worldBottomLeft = camera.ScreenToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
            var worldBottomRight = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, camera.nearClipPlane));
            var worldTopLeft = camera.ScreenToWorldPoint(new Vector3(0, Screen.height, camera.nearClipPlane));
            var worldTopRight =
                camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.nearClipPlane));


            _anglesCoordinate = new[]
            {
                GetPointWithBorders(worldBottomLeft),
                GetPointWithBorders(worldTopLeft),
                GetPointWithBorders(worldTopRight),
                GetPointWithBorders(worldBottomRight)
            };
        }

        public Transform Spawn(IEnemyBehavioral behavior)
        {
            var sides = GetSide();
            var spawnPoint = GetPointOnSide(sides);

            var enemy = ObjectPool.SpawnObj(TypeObj.Enemy, spawnPoint);
            enemy.GetComponent<EnemyBehaviour>().Init(behavior);

            return enemy;
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

        private Vector2 GetPointWithBorders(Vector3 point) => point * _areaBorders;
    }
}