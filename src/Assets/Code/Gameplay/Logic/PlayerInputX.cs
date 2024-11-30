using Assets.Code.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Logic
{
    internal class PlayerInputX : MonoBehaviour
    {
        [SerializeField]
        private MoverX _moverX;
        private IInputService _inputService;

        [Inject]
        private void Constructor(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            float movement = _inputService.GetMovement();

            _moverX.Move(movement);
        }
    }
}