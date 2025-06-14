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
            _sceneNammeToSwitch = sceneNameToSwitch;

            _button.onClick.AddListener(OnButtonClicked);
        }

        public void SetInteractable(bool interactable)
        {
            _button.interactable = interactable;
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
