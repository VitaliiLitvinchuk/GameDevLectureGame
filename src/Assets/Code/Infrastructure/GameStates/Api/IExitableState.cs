namespace Assets.Code.Infrastructure.GameStates.Api
{
    public interface IExitableState : IState
    {
        void Exit();
    }
}