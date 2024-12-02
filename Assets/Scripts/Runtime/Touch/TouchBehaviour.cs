using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.Touch
{
    public class TouchBehaviour : MonoBehaviour
    {
        private InputScheme _input;

        private Vector2 _beganTouch = Vector2.zero;

        private Camera _camera;
        private bool _isEmptyContact = true;

        private void Awake()
        {
            _camera = Camera.main;
            _input = new InputScheme();

            _input.Player.Contact.started += OnStartContact;
            _input.Player.Contact.canceled += OnEndContact;
            _input.Player.Position.performed += OnPosition;
            _input.Player.Tap.canceled += OnTap;
        }

        private void OnStartContact(InputAction.CallbackContext context)
        {
            Vector2 contact = _input.Player.Position.ReadValue<Vector2>();
            _beganTouch = contact;
        }

        private void OnPosition(InputAction.CallbackContext context)
        {
            Vector2 position = _input.Player.Position.ReadValue<Vector2>();

            if (_isEmptyContact && IsCorrectTouch(_beganTouch, position))
            {
                _isEmptyContact = false;
            }
            else if (!_isEmptyContact)
            {
                OnMoved(position, ProgressStage.Progress);
            }
        }

        private void OnEndContact(InputAction.CallbackContext context)
        {
            Vector2 position = _input.Player.Position.ReadValue<Vector2>();

            if (IsCorrectTouch(_beganTouch, position))
            {
                _isEmptyContact = true;
                _beganTouch = Vector2.zero;

                OnMoved(position, ProgressStage.Ended);
            }
        }

        private void OnTap(InputAction.CallbackContext context)
        {
            Vector2 contact = _input.Player.Position.ReadValue<Vector2>();
            Ray ray = _camera.ScreenPointToRay(contact);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            EventTouch touch = new EventTouch() { Collision = hit.transform, Position = hit.point };
            OnTouch(touch);
        }

        private void OnEnable()
        {
            if (_input == null)
                return;

            _input.Enable();
            _input.Player.Contact.started += OnStartContact;
            _input.Player.Contact.canceled += OnEndContact;
            _input.Player.Position.performed += OnPosition;
            _input.Player.Tap.canceled += OnTap;
        }

        private void OnDisable()
        {
            _input.Disable();
            _input.Player.Contact.started -= OnStartContact;
            _input.Player.Contact.canceled -= OnEndContact;
            _input.Player.Position.performed -= OnPosition;
            _input.Player.Tap.canceled -= OnTap;
        }

        private static bool IsCorrectTouch(Vector2 start, Vector2 end) =>
            start != Vector2.zero && (start - end).sqrMagnitude >= 0.5f;

        private void OnMoved(Vector2 current, ProgressStage status) =>
            GlobalEventsManager.InvokeSwipe(
                new EventSwipe()
                {
                    Current = current,
                    Start = _beganTouch,
                    Status = status
                }
            );

        private void OnTouch(EventTouch touch) => GlobalEventsManager.InvokeTouch(touch);
    }
}