using UnityEngine;
using Vault;

namespace Runtime.Base
{
    public class TouchObjectBase : MonoBehaviour
    {
        protected EventTouch CurrentTouch;

        protected virtual void Awake()
        {
            CurrentTouch = GlobalEventsManager.LastTouch;
            GlobalEventsManager.OnTouch.AddListener(OnTouchChanged);
        }

        protected virtual void OnTouchChanged(EventTouch touch) => CurrentTouch = touch;
    }

    public class TouchBase
    {
        protected EventTouch CurrentTouch;

        public TouchBase()
        {
            CurrentTouch = GlobalEventsManager.LastTouch;
            GlobalEventsManager.OnTouch.AddListener(OnTouchChanged);
        }

        protected virtual void OnTouchChanged(EventTouch touch) => CurrentTouch = touch;
    }

    public class TouchGameStatusObjectBase : TouchObjectBase
    {
        protected GameStatus CurrentStatus = GameStatus.None;

        protected override void Awake()
        {
            CurrentStatus = GlobalEventsManager.LastGameStatus;
            GlobalEventsManager.OnGameStatus.AddListener(OnGameStatusChanged);
            base.Awake();
        }

        protected virtual void OnGameStatusChanged(GameStatus status) => CurrentStatus = status;
    }

    public class TouchGameStatusBase : TouchBase
    {
        protected GameStatus CurrentStatus;

        protected TouchGameStatusBase()
            : base()
        {
            CurrentStatus = GlobalEventsManager.LastGameStatus;
            GlobalEventsManager.OnGameStatus.AddListener(OnGameStatusChanged);
        }

        protected virtual void OnGameStatusChanged(GameStatus status) => CurrentStatus = status;
    }
}
