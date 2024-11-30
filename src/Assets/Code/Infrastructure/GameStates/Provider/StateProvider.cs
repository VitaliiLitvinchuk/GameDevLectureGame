using Assets.Code.Infrastructure.GameStates.Api;
using Zenject;

namespace Assets.Code.Infrastructure.GameStates.Provider
{
    public class StateProvider : IStateProvider
    {
        private readonly DiContainer _container;

        public StateProvider(DiContainer container)
        {
            _container = container;
        }

        public TState GetState<TState>() where TState : IEnterableState
        {
            return _container.Resolve<TState>();
        }
    }
}