using System.Collections.Generic;
using Bonus.Perk;
using Bullet;
using Bullet.BulletBase;
using UnityEngine;

namespace Runtime
{
    public static class LvlVariables
    {
        public static Vector2 PlayerPosition;

        //--------------------------- Цены пули
        private static float _bulletCost = 1f;

        public static float BulletCost
        {
            get => _bulletCost;
            private set { }
        }

        public static void ResetBulletCost() => _bulletCost = 1f;
        public static void SetBulletCost(float cost) => _bulletCost = cost;

        //--------------------------- Поведение и фундаметальные параметры пули

        public static IBulletBehaviour BulletBehaviour;

        public static void SetDefaultBulletBehaviour() => BulletBehaviour = new SimpleBullet();

        public static float BulletRadius = 0f;

        public static int BonusSpawnChance = 100;


        public static string[] AvailableSpells;


        //--------------------------- Перки

        public static Dictionary<string, PerkRarity?> AvailablePerks;
    }
}