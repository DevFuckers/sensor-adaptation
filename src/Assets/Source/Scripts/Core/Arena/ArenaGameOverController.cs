using System;
using DevFuckers.Assets.Source.Scripts.Core.Player;
using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Core.Arena
{
    public class ArenaGameOverController
    {
        public event Action GameWin = delegate { };
        public event Action GameLose = delegate { };

        private PlayerActiveOrdersModel _playerActiveOrdersModel;
        private ArenaPreyOffScreenCounter _arenaPreyOffScreenCounter;
        private GameObject _gameOverButton;

        public void Init(PlayerActiveOrdersModel playerActiveOrdersModel, ArenaPreyOffScreenCounter arenaPreyOffScreenCounter, GameObject gameOverButton)
        {
            _playerActiveOrdersModel = playerActiveOrdersModel;
            _arenaPreyOffScreenCounter = arenaPreyOffScreenCounter;
            _gameOverButton = gameOverButton;

            _playerActiveOrdersModel.ActiveOrdersChanged += CheckWinConditions;
            _arenaPreyOffScreenCounter.ThereIsNoPreyOnScreen += PerformLose;
            _gameOverButton.SetActive(false);
        }

        private void CheckWinConditions()
        {
            if (_playerActiveOrdersModel == null)
            {
                Debug.LogError("ArenaGameOverController::CheckWinConditions() playerActiveOrdersModel is null");
                return;
            }

            if (_playerActiveOrdersModel.IsActiveOrdersEmpty())
                PerformWin();
        }

        private void PerformLose()
        {
            _gameOverButton.SetActive(true);
        }

        private void PerformWin()
        {
            _gameOverButton.SetActive(true);
        }
    }
}
