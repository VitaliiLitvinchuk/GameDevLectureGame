using System;
using UnityEngine;

namespace Assets.Code.Gameplay.Logic
{
    internal sealed class Health : MonoBehaviour
    {
        [SerializeField]
        private float _currentHealth;

        public float CurrentHealth => _currentHealth;

        public float MaxHealth { get; internal set; }

        private void Start()
        {
            MaxHealth = _currentHealth;
        }

        public event Action Changed;

        public event Action Death;

        public void Substract(float healthToSubstract)
        {
            if (healthToSubstract <= 0)
                throw new ArgumentException($"Health to substract must be greater than 0.", nameof(healthToSubstract));

            _currentHealth -= healthToSubstract;

            Changed?.Invoke();

            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                Death?.Invoke();
            }
        }
    }
}