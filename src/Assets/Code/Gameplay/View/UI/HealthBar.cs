using System;
using Assets.Code.Gameplay.Logic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Gameplay.View.UI
{
    internal sealed class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Image _image;

        [SerializeField]
        private Health _playerHealth;

        private void Awake()
        {
            _playerHealth.Changed += OnHealthChanged;
        }

        private void OnDestroy()
        {
            _playerHealth.Changed -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            _image.fillAmount = _playerHealth.CurrentHealth / _playerHealth.MaxHealth;
        }
    }
}