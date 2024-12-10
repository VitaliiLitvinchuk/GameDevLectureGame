using Assets.Code.Gameplay.Markers;
using Assets.Code.Infrastructure.Factories;
using Assets.Code.Infrastructure.GameStates.Api;
using Assets.Code.Infrastructure.GameStates.StateMachine;
using Assets.Code.Infrastructure.Services.Scene;
using Assets.Code.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Assets.Code.Infrastructure.GameStates.State
{
    public class LoadLevelState : IPayloadedEnterableState<string>
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(ISceneLoader sceneLoader, IStateMachine stateMachine, IGameFactory gameFactory)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
        }

        public void Enter(string payload)
        {
            _sceneLoader.Load(payload);

            GameObject player = PlayerSpawn();
            _gameFactory.CreateHud(player);

            _stateMachine.Enter<LevelState>();
        }

        private GameObject PlayerSpawn()
        {
            Vector3 playerSpawnPointPosition = Object.FindObjectOfType<PlayerSpawnPoint>().transform.position;

            return _gameFactory.CreatePlayer(playerSpawnPointPosition);
        }
    }
}