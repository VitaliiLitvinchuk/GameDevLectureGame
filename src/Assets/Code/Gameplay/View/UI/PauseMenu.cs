using Assets.Code.Data;
using Assets.Code.Gameplay.Sounds;
using Assets.Code.Infrastructure.GameStates.State;
using Assets.Code.Infrastructure.GameStates.StateMachine;
using Assets.Code.Infrastructure.Services.Sound;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Code.Gameplay.View.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject _contentPanel;

        [SerializeField]
        private GameObject _shadowPanel;

        [SerializeField]
        private Button _pauseButton;

        [Inject]
        private readonly IStateMachine _stateMachine;

        [Inject]
        private readonly ISoundService _soundService;

        private void Start()
        {
            _contentPanel.SetActive(false);
            _shadowPanel.SetActive(false);
        }

        public Button GetPauseButton() => _pauseButton;

        public void Pause()
        {
            _soundService.Play(SoundType.PlayButton);
            _contentPanel.SetActive(true);
            _shadowPanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void Home()
        {
            _soundService.Play(SoundType.PlayButton);
            _stateMachine.Enter<LoadProgressState>();
            Time.timeScale = 1;
        }

        public void Resume()
        {
            _soundService.Play(SoundType.PlayButton);
            _contentPanel.SetActive(false);
            _shadowPanel.SetActive(false);
            Time.timeScale = 1;
        }

        public void Restart()
        {
            _soundService.Play(SoundType.PlayButton);
            _stateMachine.Enter<LoadLevelState, string>("Level");
            Time.timeScale = 1;
        }
    }
}