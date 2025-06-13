using System;
using DevFuckers.Assets.Source.Scripts.Core.Player;
using UnityEngine;
using Zenject;

namespace DevFuckers.Assets.Source.Scripts.Core.OrderSystem
{
    public class OrderViewController : IDisposable
    {
        [Inject] private PlayerActiveOrdersModel _playerActiveOrdersModel;
        private OrderView _orderView;
        

        public OrderViewController(OrderView orderView)
        {
            _orderView = orderView;

            _orderView.OrderClicked += OnOrderClicked;
        }

        public void Dispose()
        {
            _orderView.OrderClicked -= OnOrderClicked;
        }

        private void OnOrderClicked(Order order, bool toAdd)
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
