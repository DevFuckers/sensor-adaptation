using System;
using DevFuckers.Assets.Source.Scripts.Core.Mob;
using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Core.Arena
{
    public class ArenaPreyOffScreenCounter : MonoBehaviour
    {
        public event Action ThereIsNoPreyOnScreen = delegate { };

        [SerializeField] private BoxCollider2D _collider;

        private int _currentPreyOnScreenCount;
        private bool _isEnabled;

        void OnValidate()
        {
            if (_collider == null)
                Debug.LogWarning("ArenaPreyOffScreenCounter::OnValidate() collider is null");
        }

        private void Start()
        {
            _collider.isTrigger = true;
        }

        public void Init(int startPreyCountOnScreen)
        {
            _currentPreyOnScreenCount = startPreyCountOnScreen;
            _isEnabled = true;
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if (!_isEnabled)
                return;

            if (_collider.GetComponent<Prey>() != null)
            {
                _currentPreyOnScreenCount--;
                CheckPreyOnScreen();
            }
        }

        private void CheckPreyOnScreen()
        {
            if (_currentPreyOnScreenCount < 1)
                ThereIsNoPreyOnScreen.Invoke();
        }
    }
}
