using System.Threading.Tasks;
using Runtime.Base;
using UnityEngine;
using Vault;

namespace Enemy.Spawn
{
    public class SpawnTimer : GameStatusBase
    {
        private float _minSpawnTick;
        private float _maxSpawnTick;
        private bool _availableBehaviour = true;

        private EnemyAvailableBehaviour _behaviours;
        private SpawnerEnemy _spawner;

        public SpawnTimer(
            EnemyAvailableBehaviour behaviours,
            SpawnerEnemy spawner,
            float minSpawnTick,
            float maxSpawnTick
        )
        {
            _minSpawnTick = minSpawnTick;
            _maxSpawnTick = maxSpawnTick;
            _behaviours = behaviours;
            _spawner = spawner;

            StartSpawning();
        }

        private async void StartSpawning()
        {
            while (_availableBehaviour)
            {
                int delay = GetDelay();
                await Task.Delay(delay);

                CallSpawner();

                _availableBehaviour = _behaviours.HasBehaviour();
            }
        }

        private int GetDelay()
        {
            var delay = Random.Range(_minSpawnTick, _maxSpawnTick);
            return (int)(delay * 1000);
        }

        private void CallSpawner()
        {
            if (_currentStatus == GameStatus.Action)
                _spawner.Spawn(_behaviours.GetNext());
        }
    }
}
