using DevFuckers.Assets.Source.Scripts.Infrastructure.Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DevFuckers.Assets.Source.Scripts.Core.Menu
{
    public class StartGameButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Start()
        {
            _button.interactable = false;
        }

        public void StartListenToClick()
        {
            _button.interactable = true;
            _button.onClick.AddListener(OnButtonClicked);
        }

        void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void OnButtonClicked()
        {
            SceneManager.LoadScene(AssetPaths.GAMEPLAY_SCENE);
        }
    }
}
