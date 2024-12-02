using Bonus.Combiner;
using Bullet.BulletBase;
using Enemy.EnemyBase;
using Runtime;

namespace Bonus.Perk.Variations
{
    public class Discount : PerkBase, ICombinableEffect
    {
        public Discount() : base(PerkName.Discount.ToString())
        {
        }


        public void Init()
        {
            LvlVariables.SetBulletCost(LvlVariables.BulletCost * 0.8f);
        }

        public void Deactivate()
        {
            LvlVariables.ResetBulletCost();
        }

        public void OnCreatedBullet(BulletState bullet)
        {
        }

        public void OnCreatedEnemy(EnemyState enemy)
        {
        }

        public void OnHitting(EventBulletHitting enemy)
        {
        }
    }
}