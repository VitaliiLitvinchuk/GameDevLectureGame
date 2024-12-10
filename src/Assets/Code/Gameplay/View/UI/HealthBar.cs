using System;
using Assets.Code.Gameplay.Logic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Code.Gameplay.View.UI
{
    internal sealed class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Image _image;
        private Health _health;

        private void OnDestroy()
        {
            _health.Changed -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            _image.fillAmount = _health.CurrentHealth / _health.MaxHealth;
        }

        public void SetUp(Health health)
        {
            _health = health;
            _health.Changed += OnHealthChanged;
        }
    }
}