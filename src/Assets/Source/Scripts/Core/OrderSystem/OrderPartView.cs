using TMPro;
using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Core.OrderSystem
{
    public class OrderPartView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _orderPartName;
        [SerializeField] private TMP_Text _orderPartCount;

        public void Init(OrderPart orderPart)
        {
            if (orderPart == null)
            {
                Debug.LogError("OrderPartView::Init() orderPart is null");
                return;
            }
            
            _orderPartName.text = orderPart.BodyPart.ToString();
            _orderPartCount.text = orderPart.Count.ToString();
        }
    }
}
