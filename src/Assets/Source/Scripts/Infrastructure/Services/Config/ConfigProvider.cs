using DevFuckers.Assets.Source.Scripts.Configs;
using DevFuckers.Assets.Source.Scripts.Infrastructure.Services.AssetLoad;
using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Infrastructure.Services.Config
{
    public class ConfigProvider
    {
        private readonly ResourcesAssetLoader _assetLoader;

        public ConfigProvider(ResourcesAssetLoader assetLoader)
        {
            _assetLoader = assetLoader;
        }

        public GlobalGameSettings GlobalGameSettings { get; private set; }

        public void LoadAll()
        {
            GlobalGameSettings = _assetLoader.Load<GlobalGameSettings>("Configs/GlobalSettings");

            if (GlobalGameSettings == null)
            {
                Debug.LogError("GlobalGameSettings not found, create default");
                GlobalGameSettings = new GlobalGameSettings();
            }
        }
    }
}
