using UnityEngine.SceneManagement;

namespace Assets.Code.Infrastructure.Services.Scene
{
    public class SceneLoader : ISceneLoader
    {
        public void Load(string sceneName) => SceneManager.LoadScene(sceneName);
    }
}