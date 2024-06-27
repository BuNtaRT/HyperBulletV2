using UnityEngine;
using Vault;

namespace Runtime.Base
{
    public class GameStatusObjectBase : MonoBehaviour
    {
        protected GameStatus _currentStatus = GameStatus.None;

        protected virtual void Awake()
        {
            _currentStatus = GlobalEventsManager.LastGameStatus;
            GlobalEventsManager.OnGameStatus.AddListener(OnGameStatusChanged);
        }

        protected virtual void OnGameStatusChanged(GameStatus status) =>
            _currentStatus = status;
    }


    public class GameStatusBase
    {
        protected GameStatus _currentStatus;

        public GameStatusBase()
        {
            _currentStatus = GlobalEventsManager.LastGameStatus;
            GlobalEventsManager.OnGameStatus.AddListener(OnGameStatusChanged);
        }

        protected virtual void OnGameStatusChanged(GameStatus status) =>
            _currentStatus = status;
    }
}