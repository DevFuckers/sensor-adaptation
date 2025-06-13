using DevFuckers.Assets.Source.Scripts.Core.Player;
using DevFuckers.Assets.Source.Scripts.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace DevFuckers.Assets.Source.Scripts.Core.Arena
{
    public class ArenaBootstrap : MonoBehaviour
    {
        [SerializeField] private ArenaActiveOrdersView _arenaActiveOrdersView;

        [Inject] private InputHandler _inputHandler;
        [Inject] private PlayerActiveOrdersModel _playerActiveOrdersModel;

        private ArenaShotController _arenaShotController;
        private ArenaShotPerformer _arenaShotPerformer;

        void Start()
        {
            _arenaShotPerformer = new ArenaShotPerformer();
            _arenaShotController = new ArenaShotController();

            _arenaShotPerformer.Init(_inputHandler);
            _arenaShotController.Init(_arenaShotPerformer, _playerActiveOrdersModel);
            _arenaActiveOrdersView.Init(_playerActiveOrdersModel);
        }

        void OnDisable()
        {
            _arenaShotPerformer.OnDisable();
            _arenaShotController.OnDisable();
        }
    }
}
