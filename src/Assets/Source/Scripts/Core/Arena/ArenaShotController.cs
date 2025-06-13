using DevFuckers.Assets.Source.Scripts.Core.OrderSystem;
using DevFuckers.Assets.Source.Scripts.Core.Player;
using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Core.Arena
{
    public class ArenaShotController
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
            _playerActiveOrdersModel.UpdateActiveOrders(bodyPart, count: 1);
        }

        public void OnDisable()
        {
            if (_arenaShotPerformer != null)
                _arenaShotPerformer.MobShot -= OnMobShot;
        }
    }
}
