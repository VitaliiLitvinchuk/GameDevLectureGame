using UnityEngine;

namespace Assets.Code.Gameplay.Logic
{
    internal sealed class DestroyBelowY : MonoBehaviour
    {
        [SerializeField]
        private float _y = -10f;

        private void Update()
        {
            if (transform.position.y < _y)
                Destroy(gameObject);
        }
    }
}