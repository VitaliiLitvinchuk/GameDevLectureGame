using System;
using Assets.Code.Data;
using Assets.Code.Infrastructure.Services.Sound;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Logic
{
    public class Health : MonoBehaviour
    {
        public float CurrentHealth;

        public float MaxHealth { get; internal set; }

        [Inject]
        private readonly ISoundService _soundService;

        private void Start()
        {
            MaxHealth = CurrentHealth;
        }

        public event Action Changed;

        public event Action Death;

        public void Substract(float healthToSubstract)
        {
            if (healthToSubstract <= 0)
                throw new ArgumentException($"Health to substract must be greater than 0.", nameof(healthToSubstract));

            CurrentHealth -= healthToSubstract;
            _soundService.Play(SoundType.TakeDamage);
            Changed?.Invoke();

            if (CurrentHealth <= 0)
            {
                _soundService.Play(SoundType.Death);
                CurrentHealth = 0;
                Death?.Invoke();
            }
        }

        public void AddHealth(float healthToAdd)
        {
            if (healthToAdd <= 0)
                throw new ArgumentException($"Health to add must be greater than 0.", nameof(healthToAdd));

            CurrentHealth += healthToAdd;

            if (CurrentHealth > MaxHealth)
                CurrentHealth = MaxHealth;

            Changed?.Invoke();
        }
    }
}