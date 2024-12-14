using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Gameplay.View.UI
{
    public class PlayerHatChanger : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(ChangeHat);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void ChangeHat()
        {
        }
    }
}