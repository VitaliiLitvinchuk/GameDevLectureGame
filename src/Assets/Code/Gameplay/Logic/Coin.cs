using Assets.Code.Gameplay.Services.Wallet;
using Assets.Code.Infrastructure.Services.SaveLoad;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Logic
{
    public class Coin : MonoBehaviour, ICollectable
    {
        public bool IsCollected { get; private set; }

        [Inject]
        private readonly IWalletService _walletService;
        [Inject]
        private readonly ISaveLoadService _saveLoadService;

        public void Collect(Collector collector)
        {
            _walletService?.AddCoin();
            _saveLoadService?.SavePlayerProgress();
            Destroy(gameObject);
        }
    }
}