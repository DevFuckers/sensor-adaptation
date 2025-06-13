using System;

namespace DevFuckers.Assets.Source.Scripts.Infrastructure.Services.Input
{
    public class InputHandler : IDisposable
    {
        public event Action Click = delegate { };

        private PlayerInput _input;
        private PlayerInput Input => _input ??= new PlayerInput();

        public InputHandler()
        {
            Input.Enable();
            Input.Player.Attack.performed += context => Click?.Invoke();
        }

        public void Dispose()
        {
            Input.Player.Attack.performed -= context => Click?.Invoke();
        }
    }
}
