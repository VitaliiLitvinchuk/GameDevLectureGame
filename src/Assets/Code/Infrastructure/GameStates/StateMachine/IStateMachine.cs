using Assets.Code.Infrastructure.GameStates.Api;

namespace Assets.Code.Infrastructure.GameStates.StateMachine
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : IEnterableState;
    }
}