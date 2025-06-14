using System.Collections.Generic;
using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Core.Mob
{
    [CreateAssetMenu(fileName = FileName, menuName = "Configs/" + FileName)]
    public class PreySpawnerConfig : ScriptableObject
    {
        public const string FileName = nameof(PreySpawnerConfig);
        [field: SerializeField] public List<KeyValue<PreyId, Prey>> PreyList { get; private set; }
    }
}