using UnityEngine;
using Vault;

namespace Runtime.Dev
{
    public class GameStatusDev : MonoBehaviour
    {
        private GameStatus _gameStatus = GameStatus.Action;
        public GameStatus gameStatus = GameStatus.Action;


        private void Awake()
        {
            _gameStatus = gameStatus;
            GlobalEventsManager.InvokeGameStatus(gameStatus);
        }

        private void FixedUpdate()
        {
            if (_gameStatus != gameStatus)
            {
                _gameStatus = gameStatus;
                GlobalEventsManager.InvokeGameStatus(gameStatus);
            }
        }
    }
}