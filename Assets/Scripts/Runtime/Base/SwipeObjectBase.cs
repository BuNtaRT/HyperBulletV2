using UnityEngine;
using Vault;

namespace Runtime.Base
{
    public class SwipeObjectBase : MonoBehaviour
    {
        protected EventSwipe CurrentSwipe;

        protected virtual void Awake()
        {
            CurrentSwipe = GlobalEventsManager.LastSwipe;
            GlobalEventsManager.OnSwipe.AddListener(OnSwipeChanged);
        }

        protected virtual void OnSwipeChanged(EventSwipe swipe) => CurrentSwipe = swipe;
    }

    public class SwipeBase
    {
        protected EventSwipe CurrentSwipe;

        public SwipeBase()
        {
            CurrentSwipe = GlobalEventsManager.LastSwipe;
            GlobalEventsManager.OnSwipe.AddListener(OnSwipeChanged);
        }

        protected virtual void OnSwipeChanged(EventSwipe swipe) => CurrentSwipe = swipe;
    }
}
