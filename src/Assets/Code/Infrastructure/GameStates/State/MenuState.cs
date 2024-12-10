using Assets.Code.Infrastructure.GameStates.Api;
using Assets.Code.Infrastructure.Services.Scene;

namespace Assets.Code.Infrastructure.GameStates.State
{
    public class MenuState : IEnterableState
    {
        private const string MenuSceneName = "Menu";
        private readonly ISceneLoader _sceneLoader;

        public MenuState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(MenuSceneName);
        }
    }
}