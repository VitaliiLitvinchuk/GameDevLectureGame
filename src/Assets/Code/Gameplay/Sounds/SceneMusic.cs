using Assets.Code.Data;
using Assets.Code.Infrastructure.Services.Sound;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Sounds
{
    public class SceneMusic : MonoBehaviour
    {
        [SerializeField]
        private SoundType type;

        [Inject]
        private readonly ISoundService _soundService;

        private void Awake()
        {
            _soundService.ChangeSceneSound(type);
        }
    }
}