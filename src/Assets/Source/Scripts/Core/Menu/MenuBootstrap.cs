using System.Collections.Generic;
using DevFuckers.Assets.Source.Scripts.Core.OrderSystem;
using DevFuckers.Assets.Source.Scripts.Core.Player;
using DevFuckers.Assets.Source.Scripts.Infrastructure.Helpers;
using DevFuckers.Assets.Source.Scripts.Infrastructure.Services.AssetLoad;
using DevFuckers.Assets.Source.Scripts.Infrastructure.Services.Config;
using UnityEngine;
using Zenject;

namespace DevFuckers.Assets.Source.Scripts.Core.Menu
{
    public class MenuBootstrap : MonoBehaviour
    {
        [Inject] private ResourcesAssetLoader _resourcesAssetLoader;
        [Inject] private PlayerActiveOrdersModel _activeOrdersModel;
        [Inject] private ConfigProvider _configProvider;

        [SerializeField] private string _startGameButtonSceneName = GameStaticData.GAMEPLAY_SCENE;
        
        [SerializeField] private OrderDashboard _orderDashboard;
        [SerializeField] private MenuSelectingOrderHandler _menuSelectingOrderHandler;
        [SerializeField] private ChangeSceneButton _startGameButton;

        private List<OrderViewClickHandler> _orderViewClickHandlers;

        void Start()
        {
            _configProvider.LoadAll();

            _orderViewClickHandlers = new List<OrderViewClickHandler>();
            List<OrderView> orderViews = _orderDashboard.InitOrderViews(_resourcesAssetLoader, _configProvider.GlobalGameSettings);

            _menuSelectingOrderHandler.Init(_activeOrdersModel, _startGameButton.gameObject);

            foreach (var view in orderViews)
            {
                OrderViewClickHandler orderViewClickHandler = new OrderViewClickHandler(view, _activeOrdersModel);
                _orderViewClickHandlers.Add(orderViewClickHandler);
                _menuSelectingOrderHandler.LinkOrderView(view);
            }

            _startGameButton.StartListenToClick(_startGameButtonSceneName);
        }

        void OnDisable()
        {
            _orderViewClickHandlers.ForEach(x => x.Dispose());
            _orderViewClickHandlers.Clear();

            _menuSelectingOrderHandler.UnlinkAll();
        }
    }
}
