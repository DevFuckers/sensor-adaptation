using System.Collections.Generic;
using DevFuckers.Assets.Source.Scripts.Core.OrderSystem;
using ModestTree;
using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Core.Player
{
    public class PlayerActiveOrdersModel
    {
        private List<Order> _orders;

        public PlayerActiveOrdersModel()
        {
            _orders = new List<Order>();
        }

        public void AddActiveOrder(Order order)
        {
            if (order == null)
            {
                Debug.LogError("PlayerActiveOrdersModel::AddActiveOrder() order is null");
                return;
            }

            _orders.Add(order);
        }

        public void RemoveActiveOrder(Order order)
        {
            if (order == null)
            {
                Debug.LogError("PlayerActiveOrdersModel::RemoveActiveOrder() order is null");
                return;
            }

            _orders.Remove(order);
        }

        public void UpdateActiveOrders(BodyPart bodyPart, int count = 1)
        {
            if (_orders.Count == 0)
            {
                Debug.LogError("PlayerActiveOrdersModel::UpdateActiveOrders() orders is empty");
                return;
            }

            List<Order> ordersToRemove = new();

            foreach (var order in _orders)
            {
                var partsToRemove = new List<OrderPart>();

                foreach (var part in order.Parts)
                {
                    if (part.BodyPart == bodyPart)
                    {
                        part.Count -= count;

                        if (part.Count <= 0)
                            partsToRemove.Add(part);
                    }
                }

                foreach (var partToRemove in partsToRemove)
                {
                    order.Remove(partToRemove);
                }

                if (IsOrderEmpty(order))
                {
                    ordersToRemove.Add(order);
                }
            }

            foreach (var orderToRemove in ordersToRemove)
            {
                RemoveActiveOrder(orderToRemove);
            }
        }

        public bool IsActiveOrdersEmpty()
            => _orders.Count == 0;

        private bool IsOrderEmpty(Order order)
        {
            if (order == null)
            {
                Debug.LogError("PlayerActiveOrdersModel::IsOrderEmpty() - order is null");
                return true;
            }

            return order.Parts == null || order.Parts.IsEmpty();
        }
    }
}
