using Assets.Code.Gameplay.Logic;
using UnityEngine;

namespace Assets.Code.Gameplay.View
{
    internal sealed class PlayerAnimator : MonoBehaviour
    {
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private MoverX _moverX;

        private void Update()
        {
            _animator.SetBool(IsRunning, _moverX.IsMoving);
        }
    }
}
