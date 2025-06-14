using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Configs
{
    [CreateAssetMenu(fileName = "GlobalSettings", menuName = "GameSettings")]
    public class GlobalGameSettings : ScriptableObject
    {
        [Header("Order & Dashboard")]
        [field: SerializeField] public int DashboardOrderMaxCount { get; private set; } = 3;
        [field: SerializeField] public int OrderMaxParts { get; private set; } = 3;
        [field: SerializeField] public int OrderMaxCountForPart { get; private set; } = 5;

        [Header("Arena")]
        [field: SerializeField] public int ArenaMaxPreyOnScreen { get; private set; } = 25;
    }
}
