using System.Collections.Generic;

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
            _parts.Add(new OrderPart(bodyPart, orderPartCount));
        }
    }
}