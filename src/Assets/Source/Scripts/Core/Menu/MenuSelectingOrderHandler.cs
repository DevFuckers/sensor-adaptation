using System.Collections.Generic;
using DevFuckers.Assets.Source.Scripts.Core.OrderSystem;
using DevFuckers.Assets.Source.Scripts.Core.Player;
using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Core.Menu
{
    public class MenuSelectingOrderHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _playButtonObjectIfOrderSelected;
        private List<OrderView> _linkedViews;
        private PlayerActiveOrdersModel _playerActiveOrdersModel;

        public void Init(PlayerActiveOrdersModel playerActiveOrdersModel)
        {
            _playerActiveOrdersModel = playerActiveOrdersModel;
            _linkedViews = new List<OrderView>();

            _playButtonObjectIfOrderSelected.SetActive(!_playerActiveOrdersModel.IsActiveOrdersEmpty());
        }

        public void LinkOrderView(OrderView orderView)
        {
            if (orderView == null)
            {
                Debug.LogError("MenuSelectingOrderHandler::LinkOrderView() resourcesAssetLoader is null");
                return;
            }

            orderView.OrderWidgetClicked += OnOrderClicked;
            _linkedViews.Add(orderView);
        }

        public void UnlinkAll()
        {
            foreach (var view in _linkedViews)
                view.OrderWidgetClicked -= OnOrderClicked;

            _linkedViews.Clear();
        }

        private void OnOrderClicked(Order order, bool isSelected)
        {
            _playButtonObjectIfOrderSelected.SetActive(!_playerActiveOrdersModel.IsActiveOrdersEmpty());
        }
    }
}
