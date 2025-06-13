namespace DevFuckers.Assets.Source.Scripts.Core.OrderSystem
{
    public class OrderPart
    {
        public BodyPart BodyPart { get; }
        public int Count { get; }

        public OrderPart(BodyPart bodyPart, int count)
        {
            BodyPart = bodyPart;
            Count = count;
        }
    }
}