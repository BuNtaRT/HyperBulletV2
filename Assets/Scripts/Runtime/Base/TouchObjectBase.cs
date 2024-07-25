using UnityEngine;
using Vault;

namespace Runtime.Base
{
    public class TouchObjectBase : MonoBehaviour
    {
        protected EventTouch _currentTouch;

        protected virtual void Awake() 
        {
            _currentTouch = GlobalEventsManager.LastTouch;
            GlobalEventsManager.OnTouch.AddListener(OnTouchChanged);
        }


        protected virtual void OnTouchChanged(EventTouch touch) =>
            _currentTouch = touch;
    }

    public class TouchBase
    {
        protected EventTouch _currentTouch;

        public TouchBase()
        {
            _currentTouch = GlobalEventsManager.LastTouch;
            GlobalEventsManager.OnTouch.AddListener(OnTouchChanged);
        }


        protected virtual void OnTouchChanged(EventTouch touch) =>
            _currentTouch = touch;
    }

    public class TouchGameStatusObjectBase : TouchObjectBase
    {
        protected GameStatus _currentStatus = GameStatus.None;

        protected override void Awake()
        {
            _currentStatus = GlobalEventsManager.LastGameStatus;
            GlobalEventsManager.OnGameStatus.AddListener(OnGameStatusChanged);
            base.Awake();

        }

        protected virtual void OnGameStatusChanged(GameStatus status) =>
            _currentStatus = status;
    }

    public class TouchGameStatusBase : TouchBase 
    {
        protected GameStatus _currentStatus;

        protected TouchGameStatusBase(): base()
        {
            _currentStatus = GlobalEventsManager.LastGameStatus;
            GlobalEventsManager.OnGameStatus.AddListener(OnGameStatusChanged);
        }

        protected virtual void OnGameStatusChanged(GameStatus status) =>
            _currentStatus = status;

    }
}