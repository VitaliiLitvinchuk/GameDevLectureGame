using Assets.Code.Extensions;
using Assets.Code.Gameplay.Logic;
using UnityEngine;

namespace Assets.Code.Gameplay.View
{
    internal class MoveView : MonoBehaviour
    {
        [SerializeField]
        private MoverX _moverX;

        private void Update()
        {
            if (_moverX.Speed == 0) return;

            float x = _moverX.Speed < 0 ? -Mathf.Abs(transform.localScale.x) : Mathf.Abs(transform.localScale.x);

            transform.localScale = transform.localScale.WithX(x);
        }
    }
}
