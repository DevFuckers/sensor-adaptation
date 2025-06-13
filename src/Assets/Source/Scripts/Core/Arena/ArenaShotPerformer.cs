using System;
using DevFuckers.Assets.Source.Scripts.Core.Mob;
using DevFuckers.Assets.Source.Scripts.Core.OrderSystem;
using DevFuckers.Assets.Source.Scripts.Infrastructure.Services.Input;
using UnityEngine;

namespace DevFuckers.Assets.Source.Scripts.Core.Arena
{
    public class ArenaShotPerformer
    {
        public event Action<BodyPart> MobShot = delegate { };
         
        private InputHandler _inputHandler;

    
        public void Init(InputHandler inputHandler)
        {
            if (inputHandler == null)
            {
                Debug.LogError("ArenaShotPerformer::Init() inputHandler is null");
                return;
            }

            _inputHandler = inputHandler;

            _inputHandler.Click += OnClickPerformed;
        }

        public void OnDisable()
        {
            if (_inputHandler != null)
                _inputHandler.Click -= OnClickPerformed;
        }

        private void OnClickPerformed()
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
#if UNITY_EDITOR                
                Debug.Log("Клик по: " + hit.collider.gameObject.name);
#endif
                MobShot.Invoke(hit.collider.GetComponent<Prey>().BodyPart);
            }
        }
    }
}
