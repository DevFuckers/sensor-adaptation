using System;
using DevFuckers.Assets.Source.Scripts.Core.Player;
using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Core.OrderSystem
{
    public class OrderViewClickHandler : IDisposable
    {
        private PlayerActiveOrdersModel _playerActiveOrdersModel;
        private OrderView _orderView;

        public OrderViewClickHandler(OrderView orderView, PlayerActiveOrdersModel playerActiveOrdersModel)
        {
            _orderView = orderView;
            _playerActiveOrdersModel = playerActiveOrdersModel;

            _orderView.OrderWidgetClicked += OnOrderWidgetClicked;
        }

        public void Dispose()
        {
            _orderView.OrderWidgetClicked -= OnOrderWidgetClicked;
        }

        private void OnOrderWidgetClicked(Order order, bool toAdd)
        {
            if (order == null)
            {
                Debug.LogError("OrderViewController::OnOrderClicked() order is null");
                return;
            }

            if (toAdd)
                _playerActiveOrdersModel.AddActiveOrder(order);
            else
                _playerActiveOrdersModel.RemoveActiveOrder(order);
        }
    }
}
