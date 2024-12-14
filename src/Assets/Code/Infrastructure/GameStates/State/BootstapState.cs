using Assets.Code.Gameplay.Services.Wallet;
using Assets.Code.Infrastructure.GameStates.Api;
using Assets.Code.Infrastructure.GameStates.StateMachine;
using Assets.Code.Infrastructure.SaveLoadRegistry;
using Assets.Code.Infrastructure.Services.PlayerInventory;
using Assets.Code.Infrastructure.Services.Scene;
using Assets.Code.Infrastructure.Services.Shop;
using Assets.Code.Infrastructure.Services.StaticData;

namespace Assets.Code.Infrastructure.GameStates.State
{
    public class BootstrapState : IEnterableState
    {
        private readonly string BootstrapSceneName = "BootstrapScene";
        private readonly IStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IStaticDataService _staticDataService;
        private readonly IWalletService _walletService;
        private readonly IPlayerInventoryService _playerInventoryService;
        private readonly ISaveLoadRegistryService _saveLoadRegistryService;

        public BootstrapState(IStateMachine stateMachine, ISceneLoader sceneLoader, IStaticDataService staticDataService,
            IWalletService walletService, ISaveLoadRegistryService saveLoadRegistryService, IPlayerInventoryService playerInventoryService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
            _walletService = walletService;
            _saveLoadRegistryService = saveLoadRegistryService;
            _playerInventoryService = playerInventoryService;
        }

        public void Enter()
        {
            _sceneLoader.Load(BootstrapSceneName);
            _staticDataService.LoadAll();

            RegisterSaversWorkers();

            _stateMachine.Enter<LoadProgressState>();
        }

        private void RegisterSaversWorkers()
        {
            _saveLoadRegistryService.RegisterAsProgressReader(_walletService);
            _saveLoadRegistryService.RegisterAsProgressWriter(_walletService);

            _saveLoadRegistryService.RegisterAsProgressReader(_playerInventoryService);
            _saveLoadRegistryService.RegisterAsProgressWriter(_playerInventoryService);
        }
    }
}