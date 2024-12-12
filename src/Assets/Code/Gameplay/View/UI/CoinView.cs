using Assets.Code.Gameplay.Services.Wallet;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.View.UI
{
    public class CoinView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        [Inject]
        private IWalletService _wallet;

        private void Update()
        {
            _text.text = _wallet.Balance.ToString();
        }
    }
}