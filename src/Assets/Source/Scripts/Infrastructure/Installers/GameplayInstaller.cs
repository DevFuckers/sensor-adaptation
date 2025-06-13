using DevFuckers.Assets.Source.Scripts.Core.Player;
using DevFuckers.Assets.Source.Scripts.Infrastructure.Services.AssetLoad;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // base.InstallBindings();

        Container.Bind<ResourcesAssetLoader>().AsSingle();
        Container.Bind<PlayerActiveOrdersModel>().AsSingle();
    }
}
