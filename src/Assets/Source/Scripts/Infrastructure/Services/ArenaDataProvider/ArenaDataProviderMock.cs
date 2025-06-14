namespace DevFuckers.Assets.Source.Scripts.Core.Arena
{
    public class ArenaDataProviderMock : IArenaDataProvider
    {
        public ArenaData ArenaData { get; private set; } = new()
        {
            PreyCount = 10
        };
    }
}