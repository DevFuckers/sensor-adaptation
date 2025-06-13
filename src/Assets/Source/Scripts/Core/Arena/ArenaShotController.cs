using DevFuckers.Assets.Source.Scripts.Core.OrderSystem;
using DevFuckers.Assets.Source.Scripts.Core.Player;
using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Core.Arena
{
    public class ArenaShotController : MonoBehaviour
    {
        private ArenaShotPerformer _arenaShotPerformer;
        private PlayerActiveOrdersModel _playerActiveOrdersModel;

        public void Init(ArenaShotPerformer arenaShotPerformer, PlayerActiveOrdersModel playerActiveOrdersModel)
        {
            if (arenaShotPerformer == null)
            {
                Debug.LogError("ArenaShotController::Init() arenaShotPerformer is null");
                return;
            }

            if (playerActiveOrdersModel == null)
            {
                Debug.LogError("ArenaShotController::Init() playerActiveOrdersModel is null");
                return;
            }

            _arenaShotPerformer = arenaShotPerformer;
            _playerActiveOrdersModel = playerActiveOrdersModel;

            _arenaShotPerformer.MobShot += OnMobShot;
        }

        private void OnMobShot(BodyPart bodyPart)
        {
            if (bodyPart == BodyPart.None)
            {
                Debug.LogError("ArenaShotController::OnMobShot() bodyPart is nonoe");
                return;
            }
            
            _playerActiveOrdersModel.UpdateActiveOrders(bodyPart, count: 1);
        }

        void OnDisable()
        {
            _arenaShotPerformer.MobShot -= OnMobShot;
        }
    }
}
