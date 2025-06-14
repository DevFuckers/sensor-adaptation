using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Core.Arena
{
    public class ArenaDataProviderMock : IArenaDataProvider
    {
        public ArenaBootstrapArgs ArenaBootstrapArgs { get; private set; } = new()
        {
            PreyCount = 20,
        };
    }
}