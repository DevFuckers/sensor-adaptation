using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DevFuckers.Assets.Source.Scripts.Core.OrderSystem
{
    public class OrderView : MonoBehaviour, IPointerClickHandler
    {
        public event Action<Order, bool> OrderClicked = delegate { };

        [SerializeField] private OrderPartView _orderPartPrefab;
        [SerializeField] private Transform _orderPartsParent;
        private Order _order;
        private bool _isSelected;

        public void Init(Order order)
        {
            if (order == null)
            {
                Debug.LogError("OrderView::InitModel()  Order model is null");
                return;
            }

            _order = order;

            foreach (var part in order.Parts)
                Instantiate(_orderPartPrefab, _orderPartsParent).Init(part);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            // show some visual effects or selecting

            OrderClicked.Invoke(_order, !_isSelected);

            _isSelected = !_isSelected;
        }
    }
}