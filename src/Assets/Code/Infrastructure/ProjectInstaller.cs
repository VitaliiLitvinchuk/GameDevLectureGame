using Assets.Code.Infrastructure.GameStates.Provider;
using Assets.Code.Infrastructure.GameStates.State;
using Assets.Code.Infrastructure.GameStates.StateMachine;
using Assets.Code.Infrastructure.Services.Input;
using Assets.Code.Infrastructure.Services.Random;
using Assets.Code.Infrastructure.Services.Scene;
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
            BindGameStates();

            Container.BindInterfacesAndSelfTo<ProjectInstaller>().FromInstance(this).AsSingle();
        }

        private void BindGameStates()
        {
            Container.Bind<IStateProvider>().To<StateProvider>().AsSingle();
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();

            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelState>().AsSingle();
        }

        private void BindInfrastructureServices()
        {
            Container.Bind<IRandomService>().To<RandomService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IInputService>().To<InputService>().AsSingle();
        }
    }
}