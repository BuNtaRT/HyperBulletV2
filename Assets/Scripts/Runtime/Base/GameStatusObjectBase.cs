using UnityEngine;
using Vault;

namespace Runtime.Base
{
    public class GameStatusObjectBase : MonoBehaviour
    {
        protected GameStatus CurrentStatus = GameStatus.None;

        protected virtual void Awake()
        {
            CurrentStatus = GlobalEventsManager.LastGameStatus;
            GlobalEventsManager.OnGameStatus.AddListener(OnGameStatusChanged);
        }

        protected virtual void OnGameStatusChanged(GameStatus status) => CurrentStatus = status;
    }

    public class GameStatusBase
    {
        protected GameStatus CurrentStatus;

        public GameStatusBase()
        {
            CurrentStatus = GlobalEventsManager.LastGameStatus;
            GlobalEventsManager.OnGameStatus.AddListener(OnGameStatusChanged);
        }

        protected virtual void OnGameStatusChanged(GameStatus status) => CurrentStatus = status;
    }
}
