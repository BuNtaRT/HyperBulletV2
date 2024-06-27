using Enemy.EnemyBase;
using UnityEngine;
using Vault;

namespace Bullet
{
    public class BulletInteraction : MonoBehaviour 
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(GameTag.ENEMY)) 
            {
                var enemy = collision.GetComponent<EnemyBehaviour>();
                enemy.TakeBullet();
            }
        }
    }
}