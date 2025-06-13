using System.Collections.Generic;
using DevFuckers.Assets.Source.Scripts.Core.OrderSystem;
using DevFuckers.Assets.Source.Scripts.Core.Player;
using DevFuckers.Assets.Source.Scripts.Infrastructure.Services.AssetLoad;
using UnityEngine;
using Zenject;

namespace DevFuckers.Assets.Source.Scripts.Core.Menu
{
    public class MenuBootstrap : MonoBehaviour
    {
        [Inject] private ResourcesAssetLoader _resourcesAssetLoader;
        [Inject] private PlayerActiveOrdersModel _activeOrdersModel;

        [SerializeField] private OrderDashboard _orderDashboard;
        [SerializeField] private MenuSelectingOrderHandler _menuSelectingOrderHandler;
        [SerializeField] private StartGameButton _startGameButton;
        [SerializeField, Min(1)] private int _availableOrdersCount = 1;

        private List<OrderViewClickHandler> _orderViewClickHandlers;

        void Start()
        {
            _orderViewClickHandlers = new List<OrderViewClickHandler>();
            List<OrderView> orderViews = _orderDashboard.InitOrderViews(_resourcesAssetLoader, _availableOrdersCount);
            _menuSelectingOrderHandler.Init(_activeOrdersModel);

            foreach (var view in orderViews)
            {
                OrderViewClickHandler orderViewClickHandler = new OrderViewClickHandler(view, _activeOrdersModel);
                _orderViewClickHandlers.Add(orderViewClickHandler);
                _menuSelectingOrderHandler.LinkOrderView(view);
            }

            _startGameButton.StartListenToClick();
        }

        void OnDisable()
        {
            _orderViewClickHandlers.ForEach(x => x.Dispose());
            _orderViewClickHandlers.Clear();

            _menuSelectingOrderHandler.UnlinkAll();
        }
    }
}
