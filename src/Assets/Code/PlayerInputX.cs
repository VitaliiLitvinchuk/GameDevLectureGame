using UnityEngine;

namespace Code
{
    internal class PlayerInputX : MonoBehaviour
    {
        private const string AxisName = "Horizontal";

        [SerializeField]
        private MoverX _moverX;

        private void Update()
        {
            float input = Input.GetAxis(AxisName);

            _moverX.Move(input);
        }
    }
}