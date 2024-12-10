using Assets.Code.Infrastructure.GameStates.Api;

namespace Assets.Code.Infrastructure.GameStates.Provider
{
    public interface IStateProvider
    {
        TState GetState<TState>() where TState : class, IState;
    }
}