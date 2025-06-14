using DevFuckers.Assets.Source.Scripts.Core.Arena;
using DevFuckers.Assets.Source.Scripts.Core.Mob;
using DevFuckers.Source.Scripts.Data.Dynamic;
using UnityEngine;

namespace DevFuckers.Source.Scripts.Core.Arena.PreySpawnState
{
    public class PreySpawnState : IEnterState
    {
        private readonly PreySpawner _preySpawner;
        private readonly ArenaData _arenaData;

        public PreySpawnState(ArenaData arenaData, PreySpawner preySpawner)
        {
            _arenaData = arenaData;
            _preySpawner = preySpawner;
        }

        public void Enter()
        {
            Debug.Log("PreySpawnState:: Enter");
            SpawnPreys();
        }

        private void SpawnPreys()
        {
            for (int i = 0; i < _arenaData.PreyCount; i++)
            {
                var preyId = (PreyId)Random.Range(0, System.Enum.GetValues(typeof(PreyId)).Length);

                Vector3 spawnPosition = new Vector3(
                    Random.Range(-_arenaData.ArenaSize.x / 2, _arenaData.ArenaSize.x / 2),
                    Random.Range(-_arenaData.ArenaSize.y / 2, _arenaData.ArenaSize.y / 2),
                    0);

                _preySpawner.SpawnPrey(preyId, spawnPosition);
            }
        }
    }
}