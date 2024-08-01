﻿using Bonus;
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
        private Shooting _shooting;
        private EnemyAvailableBehaviour _availableBehaviour;
        private SpawnerEnemy _spawnerEnemy;
        private SpawnTimer _spawnTimer;

        private BonusSpawner _bonusSpawner;
        private BonusClickHandler _bonusClickHandler;

        private void Awake()
        {
            Camera mainCamera = Camera.main;

            //--------------------------- Загрузка конфига уровня

            //todo: сделать загрузку из файла
            // представим что она уже сделана
            EnemiesConfiguration[] enemies = new EnemiesConfiguration[]
            {
                new EnemiesConfiguration { Name = "SimpleEnemyBh", Count = 2 },
            };

            float minSpawnTick = 1f;
            float maxSpawnTick = 1.5f;

            //--------------------------- Сброс статичных значений

            LoadPool.DropCache();
            LvlVariables.SetDefaultBulletBehaviour();

            //--------------------------- Инициализация спавнера

            EnemyAvailableBehaviour availableBehaviour = new EnemyAvailableBehaviour(enemies);
            _spawnerEnemy = new SpawnerEnemy();

            _spawnTimer = new SpawnTimer(
                availableBehaviour,
                _spawnerEnemy,
                minSpawnTick,
                maxSpawnTick
            );

            //--------------------------- Стрельба

            _shooting = new Shooting();

            //--------------------------- Установка дальности пули

            Vector3 worldTopRight = mainCamera!.ScreenToWorldPoint(
                new Vector3(Screen.width, Screen.height, mainCamera.nearClipPlane)
            );

            LvlVariables.BulletRadius = Vector2.Distance(worldTopRight, Vector2.zero) + 1f;

            //--------------------------- Бонусы

            _bonusSpawner = new BonusSpawner();
            _bonusClickHandler = new BonusClickHandler();
        }
    }

    public class LevelConfiguration
    {
        [JsonProperty("enemies")]
        public EnemiesConfiguration[] Enemies { get; set; }

        [JsonProperty("minTick")]
        public float MinTick { get; set; }

        [JsonProperty("maxTick")]
        public float MaxTick { get; set; }
    }

    public class EnemiesConfiguration
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("came")]
        public int Count { get; set; }
    }
}
