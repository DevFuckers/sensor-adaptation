using DevFuckers.Assets.Source.Scripts.Infrastructure.Helpers;
using DevFuckers.Assets.Source.Scripts.Infrastructure.Services.AssetLoad;
using UnityEngine;
using System;

namespace DevFuckers.Assets.Source.Scripts.Core.OrderSystem
{
    public class OrderFactory
    {
        private OrderBuilder _orderBuilder;
        private OrderView _orderViewPrefab;

        public OrderFactory(OrderBuilder orderBuilder, ResourcesAssetLoader resourcesAssetLoader)
        {
            _orderBuilder = orderBuilder;

            var orderViewPrefab = resourcesAssetLoader.Load<GameObject>(AssetPaths.ORDER_VIEW_PREFAB);
            _orderViewPrefab = orderViewPrefab.GetComponent<OrderView>();
        }

        public OrderView CreateOrder(int partCounts, int countForPart)
        {
            for (int i = 0; i < UnityEngine.Random.Range(1, partCounts); i++)
                _orderBuilder.AddPart(GetRandomBodyPart(), UnityEngine.Random.Range(1, countForPart));

            OrderView orderViewInstance = UnityEngine.Object.Instantiate(_orderViewPrefab, Vector3.zero, Quaternion.identity);
            orderViewInstance.Init(_orderBuilder.Create());

            return orderViewInstance;
        }

        private BodyPart GetRandomBodyPart()
        {
            System.Random random = new();
            Type type = typeof(BodyPart);

            Array values = type.GetEnumValues();

            int index = random.Next(values.Length);
            BodyPart value = (BodyPart)values.GetValue(index);
            return value;
        }
    }
}