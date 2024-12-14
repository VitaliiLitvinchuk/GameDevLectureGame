using System;
using Assets.Code.Gameplay.Services.Wallet;
using Assets.Code.Infrastructure.Factories;
using Assets.Code.Infrastructure.GameStates.Provider;
using Assets.Code.Infrastructure.GameStates.State;
using Assets.Code.Infrastructure.GameStates.StateMachine;
using Assets.Code.Infrastructure.SaveLoadRegistry;
using Assets.Code.Infrastructure.Services.Input;
using Assets.Code.Infrastructure.Services.PlayerInventory;
using Assets.Code.Infrastructure.Services.Progress;
using Assets.Code.Infrastructure.Services.Random;
using Assets.Code.Infrastructure.Services.SaveLoad;
using Assets.Code.Infrastructure.Services.Scene;
using Assets.Code.Infrastructure.Services.Shop;
using Assets.Code.Infrastructure.Services.StaticData;
using Zenject;

namespace Assets.Code.Infrastructure
{
    public class ProjectInstaller : MonoInstaller, IInitializable
    {
        public void Initialize()
        {
            // Container.Resolve<ISceneLoader>().Load("Level");
            Container
                .Resolve<IStateMachine>()
                .Enter<BootstrapState>();
        }

        public override void InstallBindings()
        {
            BindInfrastructureServices();
            BindFactories();
            BindGameplayServices();
            BindGameStates();

            Container.BindInterfacesAndSelfTo<ProjectInstaller>().FromInstance(this).AsSingle();
        }

        private void BindGameplayServices()
        {
            Container.Bind<IWalletService>().To<WalletService>().AsSingle();
            Container.Bind<IShopService>().To<ShopService>().AsSingle();
            Container.Bind<IPlayerInventoryService>().To<PlayerInventoryService>().AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
        }

        private void BindGameStates()
        {
            Container.Bind<IStateProvider>().To<StateProvider>().AsSingle();
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();

            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadLevelState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelState>().AsSingle();
            Container.BindInterfacesAndSelfTo<MenuState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadProgressState>().AsSingle();
        }

        private void BindInfrastructureServices()
        {
            Container.Bind<IRandomService>().To<RandomService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IInputService>().To<InputService>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<IProgressService>().To<ProgressService>().AsSingle();
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
            Container.Bind<ISaveLoadRegistryService>().To<SaveLoadRegistryService>().AsSingle();
        }
    }
}