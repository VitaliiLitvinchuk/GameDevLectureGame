using Assets.Code.Data;
using Assets.Code.Infrastructure.GameStates.Api;
using Assets.Code.Infrastructure.GameStates.StateMachine;
using Assets.Code.Infrastructure.SaveLoad;
using Assets.Code.Infrastructure.SaveLoadRegistry;
using Assets.Code.Infrastructure.Services.Progress;
using Assets.Code.Infrastructure.Services.SaveLoad;

namespace Assets.Code.Infrastructure.GameStates.State
{
    public class LoadProgressState : IEnterableState
    {
        private readonly IProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IStateMachine _stateMachine;
        private readonly ISaveLoadRegistryService _saveLoadRegistryService;

        public LoadProgressState(ISaveLoadService saveLoadService, IProgressService progressService, IStateMachine stateMachine,
            ISaveLoadRegistryService saveLoadRegistryService)
        {
            _saveLoadService = saveLoadService;
            _progressService = progressService;
            _stateMachine = stateMachine;
            _saveLoadRegistryService = saveLoadRegistryService;
        }

        public void Enter()
        {
            PlayerProgress playerProgress = _saveLoadService.LoadPlayerProgress();

            _progressService.PlayerProgress = playerProgress == PlayerProgress.Empty ? PlayerProgress.New() : playerProgress;

            foreach (IReadProgress progressReader in _saveLoadRegistryService.ProgressReaders)
                progressReader.Read(_progressService.PlayerProgress);

            _stateMachine.Enter<MenuState>();
        }
    }
}