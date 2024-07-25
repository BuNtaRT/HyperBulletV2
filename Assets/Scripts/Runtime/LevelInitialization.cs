using Enemy.Behaviours;
using Enemy.Spawn;
using Lib;
using Newtonsoft.Json;
using Player.Shoot;
using UnityEngine;

namespace Runtime
{
    public class LevelInitialization : MonoBehaviour
    {
        private SpawnerEnemy _spawnerEnemy;
        private Shooting _shooting;

        private void Awake()
        {
            Camera mainCamera = Camera.main;

            //--------------------------- Загрузка конфига уровня

            // представим что она уже сделана
            int enemies = 10;
            float minSpawnTick = 1f;
            float maxSpawnTick = 1.5f;

            //--------------------------- Сброс статичных значений

            LoadPool.DropCache();
            LvlVariables.SetDefaultBulletBehaviour();

            //--------------------------- Инициализация сценариев

            _spawnerEnemy = new SpawnerEnemy();
            _shooting = new Shooting();

            _spawnerEnemy.Spawn(new SimpleEnemyBH());

            //--------------------------- Установка дальности пули

            var worldTopRight = mainCamera.ScreenToWorldPoint(
                new Vector3(Screen.width, Screen.height, mainCamera.nearClipPlane)
            );

            LvlVariables.BulletRadius = Vector2.Distance(worldTopRight, Vector2.zero) + 1f;
        }
    }

    class LevelConfiguration
    {
        [JsonProperty("enemies")]
        public EnemiesConfiguration[] Enemies { get; set; }

        [JsonProperty("minTick")]
        public float MinTick { get; set; }

        [JsonProperty("maxTick")]
        public float MaxTick { get; set; }
    }

    class EnemiesConfiguration
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("came")]
        public int Count { get; set; }
    }
}
