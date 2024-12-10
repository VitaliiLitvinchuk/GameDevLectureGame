using Assets.Code.Gameplay.Logic;
using Assets.Code.Gameplay.View.UI;
using Assets.Code.Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Assets.Code.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IInstantiator _instantiator;

        public GameFactory(IStaticDataService staticDataService, IInstantiator instantiator)
        {
            _staticDataService = staticDataService;
            _instantiator = instantiator;
        }

        public GameObject CreatePlayer(Vector3 position)
        {
            GameObject player = _instantiator.InstantiatePrefab(_staticDataService.PlayerConfig.PlayerPrefab, position, Quaternion.identity, null);

            player.GetComponent<Health>().CurrentHealth = _staticDataService.PlayerConfig.StartHealth;

            return player;
        }

        public GameObject CreateHud(GameObject player)
        {
            Wallet wallet = player.GetComponent<Wallet>();
            Health health = player.GetComponent<Health>();

            var hud = _instantiator.InstantiatePrefabForComponent<Hud>(_staticDataService.HudConfig.HudPrefab);

            hud.SetUp(wallet, health);

            return hud.gameObject;
        }
    }
}