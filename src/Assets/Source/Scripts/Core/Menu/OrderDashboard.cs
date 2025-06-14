using System.Collections.Generic;
using DevFuckers.Assets.Source.Scripts.Configs;
using DevFuckers.Assets.Source.Scripts.Core.OrderSystem;
using DevFuckers.Assets.Source.Scripts.Infrastructure.Services.AssetLoad;
using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Core.Menu
{
    public class OrderDashboard : MonoBehaviour
    {
        [SerializeField] private RectTransform _dashboard;

        public List<OrderView> InitOrderViews(ResourcesAssetLoader resourcesAssetLoader, GlobalGameSettings gameSettings)
        {
            if (resourcesAssetLoader == null)
            {
                Debug.LogError("OrderDashboard::InitOrderViews() resourcesAssetLoader is null");
                return null;
            }

            List<OrderView> orderViewList = new List<OrderView>();
            OrderBuilder orderBuilder = new OrderBuilder();
            OrderFactory orderFactory = new OrderFactory(orderBuilder, resourcesAssetLoader);

            Vector2 size = _dashboard.rect.size;

            for (int i = 0; i < gameSettings.DashboardOrderMaxCount; i++)
            {
                var view = orderFactory.CreateOrder(gameSettings.OrderMaxParts, gameSettings.OrderMaxCountForPart);
                view.transform.SetParent(_dashboard.transform);
                orderViewList.Add(view);
            }

            return orderViewList;
        }

        private Vector2 GetRandomPosition(Vector2 size, float xOffset, float yOffset)
        {
            float x = Random.Range(-size.x / 2f + xOffset, size.x / 2f - xOffset);
            float y = Random.Range(-size.y / 2f + yOffset, size.y / 2f - yOffset);
            return new Vector2(x, y);
        }

    }
}
