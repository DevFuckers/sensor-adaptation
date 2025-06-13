using System.Collections.Generic;
using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Core.OrderSystem
{
    public class Order
    {
        private List<OrderPart> _parts;

        public IEnumerable<OrderPart> Parts => _parts;

        public Order()
        {
            _parts = new List<OrderPart>();
        }

        public void Add(BodyPart bodyPart, int orderPartCount)
        {
            if (orderPartCount < 1)
                return;

            _parts.Add(new OrderPart(bodyPart, orderPartCount));
        }

        public void Remove(OrderPart orderPart)
        {
            if (orderPart == null)
            {
                Debug.LogError("Order::Remove() orderPart is null");
                return;
            }

            _parts.Remove(orderPart);
        }
    }
}