using Assets.Code.Data;
using Assets.Code.Infrastructure.GameStates.State;
using Assets.Code.Infrastructure.GameStates.StateMachine;
using Assets.Code.Infrastructure.Services.Sound;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Code.Gameplay.View.UI
{
    public class PlayButton : MonoBehaviour
    {
        private const string LevelName = "Level";
        [SerializeField]
        private Button _button;

        [Inject]
        private readonly IStateMachine _stateMachine;

        [Inject]
        private readonly ISoundService _soundService;

        private void Awake()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            _soundService.Play(SoundType.PlayButton);
            _stateMachine.Enter<LoadLevelState, string>(LevelName);
        }
    }
}