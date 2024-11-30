namespace Assets.Code.Infrastructure.Services.Input
{
    public interface IInputService
    {
        float GetMovement();
        void Enable();
        void Disable();
    }
}