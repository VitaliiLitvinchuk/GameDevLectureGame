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

        private void Update()
        {
            _image.fillAmount = _playerHealth.CurrentHealth / _playerHealth.MaxHealth;
        }
    }
}