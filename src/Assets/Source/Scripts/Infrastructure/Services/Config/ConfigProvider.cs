using System.Collections.Generic;
using System.Linq;
using DevFuckers.Assets.Source.Scripts.Configs;
using DevFuckers.Assets.Source.Scripts.Core.Mob;
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
        public Dictionary<PreyId, Prey> PreyPrefabs { get; private set; }

        public void LoadAll()
        {
            GlobalGameSettings = _assetLoader.Load<GlobalGameSettings>("Configs/GlobalSettings");

            LoadPreyPrefabs();
            
            if (GlobalGameSettings == null)
            {
                Debug.LogError("GlobalGameSettings not found, create default");
                GlobalGameSettings = new GlobalGameSettings();
            }
        }

        private void LoadPreyPrefabs()
        {
            PreyPrefabs = _assetLoader
                .Load<PreySpawnerConfig>("Configs/" + PreySpawnerConfig.FileName)
                .PreyList.ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
