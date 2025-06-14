using System;
using System.Collections.Generic;
using DevFuckers.Assets.Source.Scripts.Core.Player;
using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Core.OrderSystem
{
    public class OrderViewClickHandler : IDisposable
    {
        private PlayerActiveOrdersModel _playerActiveOrdersModel;
        private List<OrderView> _orderView;
        private OrderView _activeOrderView;

        public OrderViewClickHandler(List<OrderView> orderViews, PlayerActiveOrdersModel playerActiveOrdersModel)
        {
            _orderView = orderViews;
            _playerActiveOrdersModel = playerActiveOrdersModel;

            foreach (var view in _orderView)
                view.OrderWidgetClicked += OnOrderWidgetClicked;
        }

        public void Dispose()
        {
            foreach (var view in _orderView)
                view.OrderWidgetClicked -= OnOrderWidgetClicked;       
        }

        private void OnOrderWidgetClicked(OrderView widget, bool toAdd)
        {
            if (widget == null)
            {
                Debug.LogError("OrderViewController::OnOrderClicked() widget is null");
                return;
            }

            if (_activeOrderView == widget)
            {
                _playerActiveOrdersModel.RemoveActiveOrder(widget.Order);
                _activeOrderView.SetSelected(false);
                _activeOrderView = null;
            }
            else
            {
                if (_activeOrderView != null)
                {
                    _activeOrderView.SetSelected(false);
                    _playerActiveOrdersModel.RemoveActiveOrder(_activeOrderView.Order);
                }

                _playerActiveOrdersModel.AddActiveOrder(widget.Order);
                _activeOrderView = widget;
                _activeOrderView.SetSelected(true);
            }
        }
    }
}
