using System;

namespace DevFuckers.Assets.Source.Scripts.Core.OrderSystem
{
    public class OrderPart
    {
        private int _count;

        public BodyPart BodyPart { get; }
        public int Count
        {
            get => _count;
            
            set
            {
                _count = Math.Clamp(value, 0, 100); // 100 - max count
            }
        }

        public OrderPart(BodyPart bodyPart, int count)
        {
            BodyPart = bodyPart;
            Count = count;
        }
    }
}