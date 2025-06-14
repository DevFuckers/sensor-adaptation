using DevFuckers.Assets.Source.Scripts.Core.Menu;
using DevFuckers.Assets.Source.Scripts.Core.Mob;
using DevFuckers.Assets.Source.Scripts.Core.Player;
using DevFuckers.Assets.Source.Scripts.Infrastructure.Helpers;
using DevFuckers.Assets.Source.Scripts.Infrastructure.Services.Input;
using DevFuckers.Source.Scripts.Core.Arena.PreySpawnState;
using UnityEngine;
using Zenject;

namespace DevFuckers.Assets.Source.Scripts.Core.Arena
{
    public class ArenaBootstrap : MonoBehaviour
    {
        [SerializeField] private string _endGameButtonSceneName = GameStaticData.MENU_SCENE;
        
        [SerializeField] private ArenaActiveOrdersView _arenaActiveOrdersView;
        [SerializeField] private ArenaPreyOffScreenCounter _arenaPreyOffScreenCounter;
        [SerializeField] private ChangeSceneButton _endGameButton;
        
        [Inject] private InputHandler _inputHandler;
        [Inject] private PlayerActiveOrdersModel _playerActiveOrdersModel;
        [Inject] private IArenaDataProvider _arenaDataProvider;
        [Inject] private PreySpawner _preySpawner;
        
        private ArenaShotController _arenaShotController;
        private ArenaShotPerformer _arenaShotPerformer;
        private ArenaGameOverController _arenaGameOverController;
        
        private IEnterState _spawnPreyState;

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

            _endGameButton.StartListenToClick(_endGameButtonSceneName);
            
            Debug.Log("ArenaBootstrap::Start() - Prey count: " + _arenaDataProvider.ArenaData.PreyCount);
            
            
            TestPreySpawner();
        }

        private void TestPreySpawner()
        {
            var data = new ArenaFullData
            {
                ArenaSize = new Vector2(100, 100),
                PreyCount = _arenaDataProvider.ArenaData.PreyCount,
            };
            
            _spawnPreyState = new PreySpawnState(data, _preySpawner);
            _spawnPreyState.Enter();
        }

        void OnDisable()
        {
            _arenaShotPerformer.OnDisable();
            _arenaShotController.OnDisable();
        }
    }
}
