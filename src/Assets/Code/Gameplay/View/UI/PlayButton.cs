using Assets.Code.Gameplay.Sounds;
using Assets.Code.Infrastructure.GameStates.State;
using Assets.Code.Infrastructure.GameStates.StateMachine;
using UnityEngine;
using UnityEngine.Events;
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
            AudioManager.instance.Play(SoundType.PlayButton);
            AudioManager.instance.ChangeSceneSound(SoundType.LevelMusic);
            _stateMachine.Enter<LoadLevelState, string>(LevelName);
        }
    }
}