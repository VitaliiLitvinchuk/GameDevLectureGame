namespace Assets.Code.Infrastructure.Services.Input
{
    public class InputService : IInputService
    {
        private const string AxisName = "Horizontal";
        private bool _enabled = false;

        public void Enable() => _enabled = true;

        public void Disable() => _enabled = false;

        public float GetMovement()
        {
            if (!_enabled) return 0f;

            return UnityEngine.Input.GetAxis(AxisName);
        }
    }
}