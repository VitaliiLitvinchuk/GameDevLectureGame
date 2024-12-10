using Assets.Code.Infrastructure.GameStates.Api;

namespace Assets.Code.Infrastructure.GameStates.StateMachine
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : class, IEnterableState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedEnterableState<TPayload>;
    }
}