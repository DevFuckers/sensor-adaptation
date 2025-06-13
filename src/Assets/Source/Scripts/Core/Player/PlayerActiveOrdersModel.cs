using System.Collections.Generic;
using DevFuckers.Assets.Source.Scripts.Core.OrderSystem;

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
            _orders.Add(order);
        }

        public void RemoveActiveOrder(Order order)
        {
            _orders.Remove(order);
        }

        public List<Order> GetActiveOrders()
        { 
            return _orders;
        }
    }
}
