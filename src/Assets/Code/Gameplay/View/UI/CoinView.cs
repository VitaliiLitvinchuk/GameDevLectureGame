using Assets.Code.Gameplay.Logic;
using TMPro;
using UnityEngine;

namespace Assets.Code.Gameplay.View.UI
{
    public class CoinView : MonoBehaviour
    {
        [SerializeField]
        private Wallet _wallet;

        [SerializeField]
        private TextMeshProUGUI _text;
        private void Update()
        {
            _text.text = _wallet.Balance.ToString();
        }
    }
}