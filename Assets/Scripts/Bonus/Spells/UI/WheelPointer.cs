using System;
using Runtime;
using Runtime.Base;
using UnityEngine;

namespace Bonus.Spells.UI
{
    public class WheelPointer : SwipeObjectBase
    {
        [SerializeField]
        private SpellsWheel _wheel;

        [SerializeField]
        private float _innerRadius = 1f;

        private bool _isWheelSwiped;
        private WheelItem _currentItem;
        private Transform _pointer;
        private float _slotAngle = 0;

        protected override void Awake()
        {
            base.Awake();
            _pointer = transform;
        }

        private void Start()
        {
            _slotAngle = 360f / LvlVariables.AvailableSpellsCount;
        }

        protected override void OnSwipeChanged(EventSwipe swipe)
        {
            base.OnSwipeChanged(swipe);

            if (swipe.Status == ProgressStage.Started)
            {
                Debug.Log(swipe.Start.magnitude);
                // Проверяем, что свайп начался внутри круга
                if (swipe.Start.magnitude <= _innerRadius)
                    _isWheelSwiped = true;
            }

            if (!_isWheelSwiped)
                return;

            if (swipe.Status == ProgressStage.Progress)
            {
                Vector2 direction = swipe.Current - (Vector2)_pointer.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                _pointer.rotation = Quaternion.Euler(0f, 0f, angle - 45f);

                float normalizedAngle = angle + 180f;
                if (normalizedAngle < 0)
                    normalizedAngle += 360f;
                int slotIndex =
                    Mathf.FloorToInt(normalizedAngle / _slotAngle)
                    % LvlVariables.AvailableSpellsCount;

                Debug.Log(slotIndex);

                var itemFromWheel = _wheel.GetByIndex(slotIndex);
                if (itemFromWheel != _currentItem)
                {
                    _currentItem?.Interact(false);
                    _currentItem = itemFromWheel;
                    _currentItem.Interact(true);
                }
            }
            else if (swipe.Status == ProgressStage.Ended)
            {
                _currentItem.Select();
                _isWheelSwiped = false;
                _currentItem = null;
            }
        }
    }
}
