using DevFuckers.Assets.Source.Scripts.Infrastructure.Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DevFuckers.Assets.Source.Scripts.Core.Menu
{
    public class ChangeSceneButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private string _sceneNammeToSwitch;

        private void Start()
        {
            _button.interactable = false;
        }

        public void StartListenToClick(string sceneNameToSwitch)
        {
            _button.interactable = true;
            _sceneNammeToSwitch = sceneNameToSwitch;

            _button.onClick.AddListener(OnButtonClicked);
        }

        void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void OnButtonClicked()
        {
            SceneManager.LoadScene(_sceneNammeToSwitch);
        }
    }
}
