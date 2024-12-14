namespace Assets.Code.Infrastructure.Services.Input
{
    public interface IInputService
    {
        float GetMovement();
        bool GetJump();
        void Enable();
        void Disable();
    }
}