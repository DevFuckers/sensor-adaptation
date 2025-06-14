namespace DevFuckers.Assets.Source.Scripts.Core.OrderSystem
{
    public class OrderBuilder
    {
        private Order _order;

        public OrderBuilder()
        {
            _order = new Order();
        }

        public Order Create()
        {
            Order resultOrder = _order;

            Reset();

            return resultOrder;
        }

        private void Reset()
        {
            _order = new Order();
        }

        public OrderBuilder AddPart(BodyPart bodyPart, int count)
        {
            _order.AddPart(bodyPart, count);
            return this;
        }
    }
}