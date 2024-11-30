namespace Assets.Code.Infrastructure.GameStates.Api
{
    public interface IEnterableState : IState
    {
        void Enter();
    }
}