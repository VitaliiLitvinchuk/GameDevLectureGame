using Assets.Code.Gameplay.Logic;
using Assets.Code.Gameplay.View;
using Assets.Code.Gameplay.View.UI;
using Assets.Code.Infrastructure.Services.PlayerInventory;
using Assets.Code.Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Assets.Code.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IInstantiator _instantiator;
        private readonly IPlayerInventoryService _playerInventoryService;

        public GameFactory(IStaticDataService staticDataService, IInstantiator instantiator, IPlayerInventoryService playerInventoryService)
        {
            _staticDataService = staticDataService;
            _instantiator = instantiator;
            _playerInventoryService = playerInventoryService;
        }

        public GameObject CreatePlayer(Vector3 position)
        {
            GameObject player = _instantiator.InstantiatePrefab(_staticDataService.PlayerConfig.PlayerPrefab, position, Quaternion.identity, null);
            player.GetComponent<Health>().CurrentHealth = _staticDataService.PlayerConfig.StartHealth;
            player.GetComponentInChildren<Hat>().SetHat(_playerInventoryService.SelectedHat);

            CreateMenus(player);

            return player;
        }

        private void CreateMenus(GameObject player)
        {
            GameObject pauseMenu = _instantiator.InstantiatePrefab(_staticDataService.PlayerConfig.PauseMenuPrefab, Vector3.zero, Quaternion.identity, player.transform);

            GameObject deathMenu = _instantiator.InstantiatePrefab(_staticDataService.PlayerConfig.DeathMenuPrefab, Vector3.zero, Quaternion.identity, player.transform);

            player.GetComponent<Death>().deathMenu = deathMenu.GetComponent<DeathMenu>();
        }

        public GameObject CreateHud(GameObject player)
        {
            Health health = player.GetComponent<Health>();

            Hud hud = _instantiator.InstantiatePrefabForComponent<Hud>(_staticDataService.HudConfig.HudPrefab, player.transform);
            hud.SetUp(health);

            return hud.gameObject;
        }
    }
}