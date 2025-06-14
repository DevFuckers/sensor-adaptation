using System.Collections.Generic;
using DevFuckers.Assets.Source.Scripts.Core.OrderSystem;
using DevFuckers.Assets.Source.Scripts.Core.Player;
using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Core.Menu
{
    public class MenuSelectingOrderHandler : MonoBehaviour
    {
        private GameObject _playButtonObjectIfOrderSelected;
        private List<OrderView> _linkedViews;
        private PlayerActiveOrdersModel _playerActiveOrdersModel;

        public void Init(PlayerActiveOrdersModel playerActiveOrdersModel, GameObject playButtonObjectIfOrderSelected)
        {
            _playerActiveOrdersModel = playerActiveOrdersModel;
            _playButtonObjectIfOrderSelected = playButtonObjectIfOrderSelected;
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
            if (_playButtonObjectIfOrderSelected == null)
            {
                Debug.LogError("MenuSelectingOrderHandler::OnOrderClicked() playButton is null");
                return;
            }
            
            _playButtonObjectIfOrderSelected.SetActive(!_playerActiveOrdersModel.IsActiveOrdersEmpty());
        }
    }
}
