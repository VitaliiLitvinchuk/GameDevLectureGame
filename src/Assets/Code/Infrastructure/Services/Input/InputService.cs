using UnityEngine;

namespace Assets.Code.Infrastructure.Services.Input
{
    public class InputService : IInputService
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string JumpButtonName = "Jump";
        private bool _enabled = false;

        public void Enable() => _enabled = true;

        public void Disable() => _enabled = false;

        public float GetMovement()
        {
            if (!_enabled) return 0f;

            return UnityEngine.Input.GetAxis(HorizontalAxisName);
        }

        public bool GetJump()
        {
            if (!_enabled) return false;

            return UnityEngine.Input.GetButton(JumpButtonName);
        }
    }

}