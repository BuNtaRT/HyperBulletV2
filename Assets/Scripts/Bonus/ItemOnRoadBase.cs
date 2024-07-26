using DG.Tweening;
using Lib;
using UnityEngine;
using UnityEngine.Serialization;

namespace Bonus
{
    public class ItemOnRoadBase : MonoBehaviour
    {
        [FormerlySerializedAs("_icoRender")]
        [SerializeField]
        protected SpriteRenderer icoRender;

        [FormerlySerializedAs("_bgRender")]
        [SerializeField]
        private SpriteRenderer bgRender;
        private Tween _animTween;
        protected TypeObj ObjectType;
        private Color _colorBg;
        private Color _colorIco;

        protected void Init()
        {
            _colorBg = bgRender.color;
            _colorIco = icoRender.color;
        }

        protected void InitAnim()
        {
            bgRender.color = _colorBg;
            icoRender.color = _colorIco;

            _animTween = bgRender
                .DOColor(new Color(_colorBg.r, _colorBg.g, _colorBg.b, 0), 1f)
                .SetLoops(3, LoopType.Yoyo)
                .OnComplete(() =>
                {
                    icoRender
                        .DOColor(new Color(_colorIco.r, _colorIco.g, _colorIco.b, 0), 0.5f)
                        .OnComplete(() =>
                        {
                            if (ObjectType != TypeObj.None)
                                ObjectPool.Destroy(ObjectType, gameObject);
                            else
                                gameObject.SetActive(false);
                        });
                });
        }

        protected void End()
        {
            _animTween.Kill();
        }
    }
}
