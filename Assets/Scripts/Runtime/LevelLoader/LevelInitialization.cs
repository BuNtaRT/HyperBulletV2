using System.Collections.Generic;
using Bonus;
using Bonus.Combiner;
using Bonus.Perk;
using Enemy.Spawn;
using Lib;
using Newtonsoft.Json;
using Player.Shoot;
using UnityEngine;

namespace Runtime.LevelLoader
{
    public class LevelInitialization : MonoBehaviour
    {
        private Shooting _shooting;
        private EnemyAvailableBehaviour _availableBehaviour;
        private SpawnerEnemy _spawnerEnemy;
        private SpawnTimer _spawnTimer;

        private BonusSpawner _bonusSpawner;
        private BonusClickHandler _bonusClickHandler;

        private LifecycleEffectCombiner _effectCombiner;

        private void Awake()
        {
            Camera mainCamera = Camera.main;

            //--------------------------- todo: загрузка эффектов на уровне


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

            //--------------------------- Перки

            // LvlVariables.AvailablePerks = PerkIOOperator.GetActivePerks();
            LvlVariables.AvailablePerks = new Dictionary<string, PerkRarity?>()
                { { PerkName.Discount.ToString(), PerkRarity.Standard } };

            //--------------------------- Бонусы

            _bonusSpawner = new BonusSpawner();
            _bonusClickHandler = new BonusClickHandler();

            //--------------------------- Комбинатор

            _effectCombiner = new LifecycleEffectCombiner();
        }
    }

    public class LevelConfiguration
    {
        [JsonProperty("enemies")] public EnemiesConfiguration[] Enemies { get; set; }

        [JsonProperty("minTick")] public float MinTick { get; set; }

        [JsonProperty("maxTick")] public float MaxTick { get; set; }
    }

    public class EnemiesConfiguration
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("count")] public int Count { get; set; }
    }
}