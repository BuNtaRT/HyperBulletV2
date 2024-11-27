using Runtime;
using Runtime.Base;
using UnityEngine;
using Vault;

namespace Player
{
    public class PlayerRotation : TouchGameStatusObjectBase
    {
        private Transform _player;

        private void Start()
        {
            _player = transform;
        }

        protected override void OnTouchChanged(EventTouch touch)
        {
            base.OnTouchChanged(touch);

            if (CurrentStatus == GameStatus.Action)
            {
                Vector2 direction = touch.Position - (Vector2)transform.position;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                _player.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }
}
