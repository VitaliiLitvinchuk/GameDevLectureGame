using Assets.Code.Gameplay.Sounds;
using Assets.Code.Infrastructure.GameStates.State;
using Assets.Code.Infrastructure.GameStates.StateMachine;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.View.UI
{
    public class DeathMenu : MonoBehaviour
    {
        [Inject]
        private readonly IStateMachine _stateMachine;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void OnDeath()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        public void Home()
        {
            AudioManager.instance.Play(SoundType.PlayButton);
            _stateMachine.Enter<LoadProgressState>();
            Time.timeScale = 1;
        }

        public void Restart()
        {
            AudioManager.instance.Play(SoundType.PlayButton);
            _stateMachine.Enter<LoadLevelState, string>("Level");
            Time.timeScale = 1;
        }
    }
}