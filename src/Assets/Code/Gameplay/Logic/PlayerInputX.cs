using Assets.Code.Data;
using Assets.Code.Infrastructure.Services.Input;
using Assets.Code.Infrastructure.Services.Sound;
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

        [Inject]
        private readonly ISoundService _soundService;

        private void Update()
        {
            float movement = _inputService.GetMovement();
            _soundService.Play(SoundType.Run);
            _moverX.Move(movement);
        }
    }
}