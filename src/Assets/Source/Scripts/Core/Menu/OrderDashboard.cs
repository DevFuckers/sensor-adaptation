using DevFuckers.Assets.Source.Scripts.Core.OrderSystem;
using DevFuckers.Assets.Source.Scripts.Infrastructure.Services.AssetLoad;
using UnityEngine;
using Zenject;

namespace DevFuckers
{
    public class OrderDashboard : MonoBehaviour
    {
        [Inject] private ResourcesAssetLoader _resourcesAssetLoader;
        [SerializeField] private RectTransform _dashboard;

        void Start()
        {
            OrderBuilder orderBuilder = new OrderBuilder();
            OrderFactory orderFactory = new OrderFactory(orderBuilder, _resourcesAssetLoader);

            Vector2 size = _dashboard.rect.size;

            for (int i = 0; i < 3; i++)
            {
                var view = orderFactory.CreateOrder();
                view.transform.SetParent(_dashboard.transform);
                view.transform.localPosition = GetRandomPosition(size, view.transform.localScale.x, view.transform.localScale.y);
            }
        }

        private Vector2 GetRandomPosition(Vector2 size, float xOffset, float yOffset)
        {
            float x = Random.Range((-size.x / 2f) + xOffset, (size.x / 2f) - xOffset);
            float y = Random.Range((-size.y / 2f) + yOffset, (size.y / 2f) - yOffset);
            return new Vector2(x, y);
        }

    }
}
