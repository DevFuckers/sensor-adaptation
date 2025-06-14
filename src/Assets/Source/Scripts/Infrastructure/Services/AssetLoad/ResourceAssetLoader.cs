using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Infrastructure.Services.AssetLoad
{
    public class ResourcesAssetLoader
    {
        public T Load<T>(string path) where T : Object
        {
            var loadedAsset = Resources.Load<T>(path);

            if (loadedAsset == null)
                Debug.LogError("ResourcesAssetLoader::Load() Can't load asset on path: " + path);

            return loadedAsset;
        }

        public void Unload<T>(string path) where T : Object
        {
            // Implement unloading logic here
            Resources.UnloadAsset(Resources.Load<T>(path));
        }
    }
}
