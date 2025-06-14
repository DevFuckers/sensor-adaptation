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

        [SerializeField] private OrderDashboard _orderDashboard;
        [SerializeField] private MenuSelectingOrderHandler _menuSelectingOrderHandler;
        [SerializeField] private ChangeSceneButton _startGameButton;

        private OrderViewClickHandler _orderViewClickHandler;

        void Start()
        {
            _configProvider.LoadAll();

            List<OrderView> orderViews = _orderDashboard.InitOrderViews(_resourcesAssetLoader, _configProvider.GlobalGameSettings);
            _orderViewClickHandler = new OrderViewClickHandler(orderViews, _activeOrdersModel);

            _menuSelectingOrderHandler.Init(_activeOrdersModel, _startGameButton);

            foreach (var view in orderViews)
                _menuSelectingOrderHandler.LinkOrderView(view);

            _startGameButton.StartListenToClick(AssetPaths.GAMEPLAY_SCENE);
        }

        void OnDisable()
        {
            _orderViewClickHandler.Dispose();

            _menuSelectingOrderHandler.UnlinkAll();
        }
    }
}
