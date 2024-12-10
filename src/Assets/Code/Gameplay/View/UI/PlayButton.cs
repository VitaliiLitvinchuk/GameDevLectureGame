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

        private IStateMachine _stateMachine;

        [Inject]
        private void Constructor(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

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
            _stateMachine.Enter<LoadLevelState, string>(LevelName);
        }
    }
}