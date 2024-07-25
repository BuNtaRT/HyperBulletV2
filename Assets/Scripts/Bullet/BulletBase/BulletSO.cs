using UnityEngine;

namespace Bullet.BulletBase
{
    [CreateAssetMenu(fileName = "New Bullet", menuName = "Ammo/Bullet")]
    public class BulletSO : ScriptableObject
    {
        public float Speed;
        public int Damage;

        public Color Color;
        public Gradient Trail;

        public bool CustomMove;
        public AnimationCurve MovePattern;
    }
}
