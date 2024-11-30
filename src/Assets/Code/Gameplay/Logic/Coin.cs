using UnityEngine;

namespace Assets.Code.Gameplay.Logic
{
    public class Coin : MonoBehaviour, ICollectable
    {
        public bool IsCollected { get; private set; }

        public void Collect(Collector collector)
        {
            collector
                .GetComponent<Wallet>()
                .AddCoin();

            Destroy(gameObject);
        }
    }
}