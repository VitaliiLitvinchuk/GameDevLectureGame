using Assets.Code.Gameplay.Markers;
using Assets.Code.Infrastructure.Factories;
using Assets.Code.Infrastructure.GameStates.Api;
using Assets.Code.Infrastructure.GameStates.StateMachine;
using Assets.Code.Infrastructure.Services.Scene;
using Assets.Code.Infrastructure.Services.StaticData;
using Assets.Code.StaticData;
using UnityEngine;

namespace Assets.Code.Infrastructure.GameStates.State
{
    public class LoadLevelState : IPayloadedEnterableState<string>
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _staticDataService;

        public LoadLevelState(ISceneLoader sceneLoader, IStateMachine stateMachine, IGameFactory gameFactory, IStaticDataService staticDataService)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
            _staticDataService = staticDataService;
        }

        public void Enter(string payload)
        {
            _sceneLoader.Load(payload);

            LevelData levelData = _staticDataService.GetLevelData(payload);

            GameObject player = _gameFactory.CreatePlayer(levelData.PlayerSpawnPoint);
            _gameFactory.CreateHud(player);

            _stateMachine.Enter<LevelState>();
        }
    }
}