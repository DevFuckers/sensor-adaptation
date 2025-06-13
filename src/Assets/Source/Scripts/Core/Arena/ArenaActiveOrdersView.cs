using System;
using System.Collections.Generic;
using DevFuckers.Assets.Source.Scripts.Core.OrderSystem;
using DevFuckers.Assets.Source.Scripts.Core.Player;
using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Core.Arena
{
    public class ArenaActiveOrdersView : MonoBehaviour
    {
        [SerializeField] private OrderPartView _orderPartPrefab;
        [SerializeField] private Transform _orderPartsParent;
        private PlayerActiveOrdersModel _playerActiveOrdersModel;
        private List<OrderPartView> _orderPartViews = new List<OrderPartView>();
        private readonly Dictionary<OrderPart, OrderPartView> _activeViews = new();

        public void Init(PlayerActiveOrdersModel playerActiveOrdersModel)
        {
            _playerActiveOrdersModel = playerActiveOrdersModel;

            _playerActiveOrdersModel.ActiveOrdersChanged += OnActiveOrdersChanged;

            OnActiveOrdersChanged();
        }

        private void OnActiveOrdersChanged()
        {
            var currentParts = new HashSet<OrderPart>();
            
            // Собрать актуальные части
            foreach (var order in _playerActiveOrdersModel.ActiveOrders)
            {
                foreach (var part in order.Parts)
                {
                    currentParts.Add(part);

                    if (_activeViews.TryGetValue(part, out var view))
                    {
                        view.Init(part); // Обновить существующий
                    }
                    else
                    {
                        var newView = Instantiate(_orderPartPrefab, _orderPartsParent);
                        newView.Init(part);
                        _activeViews[part] = newView;
                    }
                }
            }

            // Удалить старые, которых больше нет
            var toRemove = new List<OrderPart>();
            foreach (var kvp in _activeViews)
            {
                if (!currentParts.Contains(kvp.Key))
                {
                    Destroy(kvp.Value.gameObject);
                    toRemove.Add(kvp.Key);
                }
            }

            foreach (var part in toRemove)
                _activeViews.Remove(part);
        }
    }
}
