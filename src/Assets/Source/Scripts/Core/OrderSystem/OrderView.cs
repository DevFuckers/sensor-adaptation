using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DevFuckers.Assets.Source.Scripts.Core.OrderSystem
{
    public class OrderView : MonoBehaviour, IPointerClickHandler
    {
        public event Action<OrderView, bool> OrderWidgetClicked = delegate { };

        [SerializeField] private OrderPartView _orderPartPrefab;
        [SerializeField] private Transform _orderPartsParent;
        [SerializeField] private GameObject _selectingWidget;
        private Order _order;
        private bool _isSelected;

        public Order Order => _order;

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

            if (_selectingWidget != null)
                _selectingWidget.SetActive(_isSelected);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OrderWidgetClicked.Invoke(this, !_isSelected);

            _isSelected = !_isSelected;

            // show some visual effects or selecting
        }

        public void SetSelected(bool isSelected)
        {
            _selectingWidget.SetActive(isSelected);
        }
    }
}