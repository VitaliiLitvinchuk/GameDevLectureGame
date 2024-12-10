using System;
using Assets.Code.Infrastructure.GameStates.Api;
using Assets.Code.Infrastructure.GameStates.Provider;

namespace Assets.Code.Infrastructure.GameStates.StateMachine
{
    public class StateMachine : IStateMachine
    {
        private IState _currentState;
        private IStateProvider _stateProvider;

        public StateMachine(IStateProvider stateProvider)
        {
            _stateProvider = stateProvider;
        }

        public void Enter<TState>() where TState : class, IEnterableState
        {
            var state = GetState<TState>();

            if (_currentState is IExitableState exitableState)
                exitableState.Exit();

            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedEnterableState<TPayload>
        {
            IPayloadedEnterableState<TPayload> state = GetState<TState>();

            if (_currentState is IExitableState exitableState)
                exitableState.Exit();

            state.Enter(payload);
        }

        private TState GetState<TState>() where TState : class, IState
        {
            return _stateProvider.GetState<TState>();
        }
    }
}