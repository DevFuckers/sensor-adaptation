using DevFuckers.Assets.Source.Scripts.Core.Menu;
using DevFuckers.Assets.Source.Scripts.Core.Player;
using DevFuckers.Assets.Source.Scripts.Infrastructure.Helpers;
using DevFuckers.Assets.Source.Scripts.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace DevFuckers.Assets.Source.Scripts.Core.Arena
{
    public class ArenaBootstrap : MonoBehaviour
    {
        [SerializeField] private ArenaActiveOrdersView _arenaActiveOrdersView;
        [SerializeField] private ArenaPreyOffScreenCounter _arenaPreyOffScreenCounter;
        [SerializeField] private ChangeSceneButton _endGameButton;

        [Inject] private InputHandler _inputHandler;
        [Inject] private PlayerActiveOrdersModel _playerActiveOrdersModel;

        private ArenaShotController _arenaShotController;
        private ArenaShotPerformer _arenaShotPerformer;
        private ArenaGameOverController _arenaGameOverController;

        void Start()
        {
            _arenaShotPerformer = new ArenaShotPerformer();
            _arenaShotController = new ArenaShotController();
            _arenaGameOverController = new ArenaGameOverController();

            _arenaShotPerformer.Init(_inputHandler);
            _arenaShotController.Init(_arenaShotPerformer, _playerActiveOrdersModel);
            _arenaActiveOrdersView.Init(_playerActiveOrdersModel);
            _arenaGameOverController.Init(_playerActiveOrdersModel, _arenaPreyOffScreenCounter, _endGameButton.gameObject);
            // _arenaPreyOffScreenCounter.Init(); нужен count 

            _endGameButton.StartListenToClick(AssetPaths.MENU_SCENE);
        }

        void OnDisable()
        {
            _arenaShotPerformer.OnDisable();
            _arenaShotController.OnDisable();
        }
    }
}
