using Assets.Code.Infrastructure.Services.Random;
using Assets.Code.Infrastructure.Services.Scene;
using Zenject;

namespace Assets.Code.Infrastructure
{
    public class ProjectInstaller : MonoInstaller, IInitializable
    {
        public void Initialize()
        {
            Container.Resolve<ISceneLoader>().Load("Level");
        }

        public override void InstallBindings()
        {
            Container.Bind<IRandomService>().To<RandomService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<ProjectInstaller>().FromInstance(this).AsSingle();
        }
    }
}