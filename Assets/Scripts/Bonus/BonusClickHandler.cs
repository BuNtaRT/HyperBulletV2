using Runtime;
using Runtime.Base;
using Vault;

namespace Bonus
{
    //обрабатывает нажатия и отлавливает нажатия на бонусы
    public class BonusClickHandler : TouchBase
    {
        protected override void OnTouchChanged(EventTouch touch)
        {
            base.OnTouchChanged(touch);
            if (!touch.Collision.CompareTag(GameTags.BONUS))
                return;

            var bonus = touch.Collision.GetComponent<IPickable>();
            bonus.Pick();
        }
    }
}