using Enemy.Behaviours;
using Enemy.Spawn;
using UnityEngine;

namespace Runtime
{
    public class LevelInitialization : MonoBehaviour
    {
        private SpawnerEnemy _spawnerEnemy;

        private void Awake()
        {
            Camera mainCamera = Camera.main;

            _spawnerEnemy = new SpawnerEnemy(mainCamera);

            _spawnerEnemy.Spawn(new SimpleEnemyBH());
        }
    }
}