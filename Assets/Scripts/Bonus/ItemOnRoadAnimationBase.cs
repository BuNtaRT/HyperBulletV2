using System;
using DG.Tweening;
using Lib;
using UnityEngine;

namespace Bonus
{
    public class ItemOnRoadAnimationBase : MonoBehaviour
    {
        [SerializeField]
        protected SpriteRenderer icoSprite;

        [SerializeField]
        private SpriteRenderer backgroundSprite;

        private Tween _animTween;

        protected void StartAnim(Color iconColor, Color backgroundColor, Action endCallback)
        {
            backgroundSprite.color = backgroundColor;
            icoSprite.color = iconColor;

            var icoSpriteColor = ColorTools.SetAlpha(icoSprite.color, 0);
            var backgroundSpriteColor = ColorTools.SetAlpha(backgroundSprite.color, 0.1f);

            _animTween = backgroundSprite
                .DOColor(backgroundSpriteColor, 1f)
                .SetLoops(3, LoopType.Yoyo)
                .OnComplete(() =>
                {
                    icoSprite.DOColor(icoSpriteColor, 0.5f).OnComplete(() => endCallback());
                });
        }

        protected void StopAnim()
        {
            _animTween.Kill();
        }
    }
}
