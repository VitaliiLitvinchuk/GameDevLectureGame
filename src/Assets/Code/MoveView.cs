using Code;
using UnityEngine;

namespace Assets.Code
{
    internal class MoveView : MonoBehaviour
    {
        [SerializeField]
        private MoverX _moverX;

        private void Update()
        {
            Vector3 scale = transform.localScale;

            scale.x = _moverX.Speed < 0 ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);

            transform.localScale = scale;
        }
    }
}
