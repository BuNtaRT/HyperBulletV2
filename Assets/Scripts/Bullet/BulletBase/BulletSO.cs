using UnityEngine;
using UnityEngine.Serialization;

namespace Bullet.BulletBase
{
    [CreateAssetMenu(fileName = "New Bullet", menuName = "Ammo/Bullet")]
    public class BulletSO : ScriptableObject
    {
        [FormerlySerializedAs("Speed")]
        public float speed;

        [FormerlySerializedAs("Damage")]
        public int damage;

        [FormerlySerializedAs("Color")]
        public Color color;

        [FormerlySerializedAs("Trail")]
        public Gradient trail;

        [FormerlySerializedAs("CustomMove")]
        public bool customMove;

        [FormerlySerializedAs("MovePattern")]
        public AnimationCurve movePattern;
    }
}
