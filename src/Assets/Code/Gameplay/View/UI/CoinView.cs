using System;
using Assets.Code.Gameplay.Logic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.View.UI
{
    public class CoinView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;
        private Wallet _wallet;

        internal void SetUp(Wallet wallet)
        {
            _wallet = wallet;
        }

        private void Update()
        {
            _text.text = _wallet.Balance.ToString();
        }
    }
}