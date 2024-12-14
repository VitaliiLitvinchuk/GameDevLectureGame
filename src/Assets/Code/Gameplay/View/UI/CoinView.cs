using Assets.Code.Gameplay.Services.Wallet;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.View.UI
{
    public class CoinView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        [SerializeField]
        private PunchAnimator _punchAnimator;

        [Inject]
        private IWalletService _wallet;

        private int _lastValue;

        private void Update()
        {
            int newValue = _wallet.Balance;

            if (_lastValue != newValue)
                _punchAnimator.Animate();

            _text.text = _wallet.Balance.ToString();
            _lastValue = newValue;
        }
    }
}