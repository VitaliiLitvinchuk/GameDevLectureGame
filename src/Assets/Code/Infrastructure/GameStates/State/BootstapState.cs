using Assets.Code.Infrastructure.GameStates.Api;
using Assets.Code.Infrastructure.GameStates.StateMachine;
using Assets.Code.Infrastructure.Services.Scene;
using UnityEngine;

namespace Assets.Code.Infrastructure.GameStates.State
{
    public class BootstrapState : IEnterableState
    {
        private readonly IStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly string LevelName = "Level";
        private readonly string BootstrapSceneName = "BootstrapScene";

        public BootstrapState(IStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(BootstrapSceneName);
            _sceneLoader.Load(LevelName);
            _stateMachine.Enter<LevelState>();
        }
    }
}