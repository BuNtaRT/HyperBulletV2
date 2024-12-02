using UnityEngine;
using UnityEngine.UI;
using Vault;

namespace Runtime.Dev
{
    public class GameStatusDev : MonoBehaviour
    {
        private GameStatus _gameStatus = GameStatus.Action;
        public GameStatus gameStatus = GameStatus.Action;

        public float gameTime = 1;

        public bool ShowEnergy = false;
        public Text EnergyScreen;

        private void Awake()
        {
            _gameStatus = gameStatus;
            GlobalEventsManager.InvokeGameStatus(gameStatus);

            Time.timeScale = gameTime;

            if (ShowEnergy)
            {
                EnergyScreen.transform.gameObject.SetActive(true);
            }
        }

        private void FixedUpdate()
        {
            if (_gameStatus != gameStatus)
            {
                _gameStatus = gameStatus;
                GlobalEventsManager.InvokeGameStatus(gameStatus);
            }

            EnergyScreen.text = LvlVariables.BulletCost.ToString();
        }
    }
}