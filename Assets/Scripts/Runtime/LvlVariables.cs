using Bullet;
using Bullet.BulletBase;
using UnityEngine;

namespace Runtime
{
    public static class LvlVariables
    {
        public static Vector2 PlayerPosition;

        // цена выстрела с текущей модификацией
        public static int BulletCost = 1;

        public static void SetDefaultBulletCost() => BulletCost = 1;

        public static IBulletBehaviour BulletBehaviour;

        public static void SetDefaultBulletBehaviour() => BulletBehaviour = new SimpleBullet();

        public static float BulletRadius = 0f;
    }
}
