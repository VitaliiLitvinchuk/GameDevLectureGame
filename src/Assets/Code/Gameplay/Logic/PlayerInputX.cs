using Assets.Code.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Logic
{
    internal class PlayerInputX : MonoBehaviour
    {
        [SerializeField]
        private MoverX _moverX;

        [Inject]
        private IInputService _inputService;

        private void Update()
        {
            float movement = _inputService.GetMovement();

            _moverX.Move(movement);
        }
    }
}