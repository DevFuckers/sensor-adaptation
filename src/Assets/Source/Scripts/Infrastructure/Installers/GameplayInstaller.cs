using DevFuckers.Assets.Source.Scripts.Core.Player;
using DevFuckers.Assets.Source.Scripts.Infrastructure.Services.AssetLoad;
using DevFuckers.Assets.Source.Scripts.Infrastructure.Services.Input;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ResourcesAssetLoader>().AsSingle();
        Container.Bind<PlayerActiveOrdersModel>().AsSingle();
        Container.Bind<InputHandler>().AsSingle();
    }
}
