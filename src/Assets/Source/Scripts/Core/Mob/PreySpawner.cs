using System.Collections.Generic;
using DevFuckers.Assets.Source.Scripts.Infrastructure.Services.Config;
using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Core.Mob
{
    public class PreySpawner
    {
        private readonly Dictionary<PreyId, Prey> _preyPrefabs;
        
        public PreySpawner(ConfigProvider configProvider)
        {
            _preyPrefabs = configProvider.PreyPrefabs;
            Debug.Log("PreySpawner initialized with " + _preyPrefabs.Count + " prey types.");
        }
        
        public void SpawnPrey(PreyId preyId, Vector3 position)
        {
            Prey preyToSpawn = null;

            switch (preyId)
            {
                case PreyId.EyeGuy:
                    preyToSpawn = _preyPrefabs[PreyId.EyeGuy];
                    break;
                case PreyId.EarGuy:
                    preyToSpawn = _preyPrefabs[PreyId.EarGuy];
                    break;
                case PreyId.NoseGuy:
                    preyToSpawn = _preyPrefabs[PreyId.NoseGuy];
                    break;
                default:
                    Debug.LogError("Unknown PreyType: " + preyId);
                    return;
            }

            if (preyToSpawn != null) 
                Object.Instantiate(preyToSpawn, position, Quaternion.identity);
        }
    }
}
