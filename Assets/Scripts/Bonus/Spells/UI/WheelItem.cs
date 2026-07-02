using System;
using System.Collections.Generic;
using DG.Tweening;
using Runtime;
using UnityEngine;

namespace Bonus.Spells.UI
{
    public class WheelItem : MonoBehaviour
    {
        [Header("Animation")]
        [SerializeField]
        private float scaleUp = 1.2f;

        [SerializeField]
        private float moveBackDistance = 0.1f;

        [SerializeField]
        private float duration = 0.15f;

        [SerializeField]
        private Ease ease = Ease.OutQuad;

        [Header("Visual")]
        [SerializeField]
        private SpriteRenderer _icon;

        [SerializeField]
        private List<SpriteRenderer> _lines = new List<SpriteRenderer>();

        private Tween _interactTween;
        private Transform _item;

        private Vector3 _initialLocalPos;
        private Vector3 _initialLocalScale;

        private SpellSO _spell;

        private void Awake()
        {
            _item = transform;
            _initialLocalPos = _item.localPosition;
            _initialLocalScale = _item.localScale;
        }

        public void Set(SpellSO spell)
        {
            _spell = spell;
            _icon.sprite = spell.ico;
            _icon.color = spell.mainColor;

            foreach (var line in _lines)
            {
                line.color = spell.secondColor;
            }
        }

        public void Interact(bool start)
        {
            if (_spell == null)
                return;

            _interactTween?.Kill();

            if (start)
            {
                Vector3 targetPos = _initialLocalPos + Vector3.back * moveBackDistance;
                Vector3 targetScale = _initialLocalScale * scaleUp;

                PlayTween(targetPos, targetScale);
            }
            else
            {
                PlayTween(_initialLocalPos, _initialLocalScale);
            }
        }

        public void Select()
        {
            GlobalEventsManager.InvokeUseSpell(_spell);
            _spell = null;
            PlayTween(_initialLocalPos, _initialLocalScale);
        }

        private void PlayTween(Vector3 toPosition, Vector3 toScale)
        {
            _interactTween = DOTween
                .Sequence()
                .Join(_item.DOLocalMove(toPosition, duration).SetEase(ease))
                .Join(_item.DOScale(toScale, duration).SetEase(ease))
                .SetUpdate(true);
        }
    }
}
