using DG.Tweening;
using Lib;
using UnityEngine;

namespace Bonus
{
    public class ItemOnRoadBase : MonoBehaviour
    {
        [SerializeField]
        protected SpriteRenderer _icoRender;
        [SerializeField]
        private SpriteRenderer _bgRender;
        private Tween _animTween;
        protected TypeObj _objectType;
        private Color _colorBg;
        private Color _colorIco;

        protected void Init()
        {
            _colorBg = _bgRender.color;
            _colorIco = _icoRender.color;
        }

        protected void InitAnim()
        {
            _bgRender.color = _colorBg;
            _icoRender.color = _colorIco;

            _animTween = _bgRender.DOColor(new Color(_colorBg.r, _colorBg.g, _colorBg.b, 0), 1f).SetLoops(3, LoopType.Yoyo).OnComplete(() =>
            {
                _icoRender.DOColor(new Color(_colorIco.r, _colorIco.g, _colorIco.b, 0), 0.5f).OnComplete(() =>
                {
                    if (_objectType != TypeObj.None)
                        ObjectPool.Destroy(_objectType, gameObject);
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
