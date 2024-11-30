using Assets.Code.Infrastructure.GameStates.Api;
using Assets.Code.Infrastructure.Services.Input;

namespace Assets.Code.Infrastructure.GameStates.State
{
    public class LevelState : IEnterableState, IExitableState
    {
        private readonly IInputService _inputService;

        public LevelState(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Enter()
        {
            _inputService.Enable();
        }

        public void Exit()
        {
            _inputService.Disable();
        }
    }
}