using UnityEngine;

namespace Assets.Code.Gameplay.Logic
{
    public class Mace : MonoBehaviour, ICollectable
    {
        [SerializeField]
        private float _healthToSubstract = 10;

        public bool IsCollected { get; private set; }

        public void Collect(Collector collector)
        {
            IsCollected = true;
            collector.GetComponent<Health>().Substract(_healthToSubstract);
        }
    }
}