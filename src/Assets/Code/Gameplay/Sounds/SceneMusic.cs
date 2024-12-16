using UnityEngine;

namespace Assets.Code.Gameplay.Sounds
{
    public class SceneMusic : MonoBehaviour
    {
        [SerializeField]
        private SoundType type;

        private void Awake()
        {
            if (AudioManager.instance == null) return;

            AudioManager.instance.ChangeSceneSound(type);
        }
    }
}