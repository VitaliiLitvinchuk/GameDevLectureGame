using Assets.Code.Infrastructure.GameStates.Api;
using Assets.Code.Infrastructure.GameStates.StateMachine;
using Assets.Code.Infrastructure.Services.Scene;
using Assets.Code.Infrastructure.Services.StaticData;

namespace Assets.Code.Infrastructure.GameStates.State
{
    public class BootstrapState : IEnterableState
    {
        private readonly IStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly string BootstrapSceneName = "BootstrapScene";
        private readonly IStaticDataService _staticDataService;

        public BootstrapState(IStateMachine stateMachine, ISceneLoader sceneLoader, IStaticDataService staticDataService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            _sceneLoader.Load(BootstrapSceneName);
            _staticDataService.LoadAll();

            _stateMachine.Enter<MenuState>();
        }
    }
}