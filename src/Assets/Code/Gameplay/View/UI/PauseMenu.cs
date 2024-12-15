using Assets.Code.Infrastructure.GameStates.State;
using Assets.Code.Infrastructure.GameStates.StateMachine;
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
        private IStateMachine _stateMachine;

        private void Start()
        {
            _contentPanel.SetActive(false);
            _shadowPanel.SetActive(false);
        }

        public Button GetPauseButton() => _pauseButton;

        public void Pause()
        {
            _contentPanel.SetActive(true);
            _shadowPanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void Home()
        {
            _stateMachine.Enter<LoadProgressState>();
            Time.timeScale = 1;
        }

        public void Resume()
        {
            _contentPanel.SetActive(false);
            _shadowPanel.SetActive(false);
            Time.timeScale = 1;
        }

        public void Restart()
        {
            _stateMachine.Enter<LoadLevelState, string>("Level");
            Time.timeScale = 1;
        }
    }
}