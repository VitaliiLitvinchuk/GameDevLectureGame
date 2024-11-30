using UnityEngine;

namespace Assets.Code.Gameplay.Logic
{
    public sealed class Collector : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.TryGetComponent(out ICollectable collectable))
                return;

            if (collectable.IsCollected)
                return;

            collectable.Collect(this);
        }
    }
}