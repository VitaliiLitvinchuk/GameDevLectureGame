using Assets.Code.Gameplay.Services.Wallet;
using Assets.Code.Gameplay.Sounds;
using Assets.Code.Gameplay.View;
using Assets.Code.Infrastructure.Services.SaveLoad;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Logic
{
    public class Coin : MonoBehaviour, ICollectable
    {
        [SerializeField]
        private MoveFadeDestroyer _moveFadeDestroyer;

        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        [SerializeField]
        private BoxCollider2D _boxCollider2D;

        public bool IsCollected { get; private set; }

        [Inject]
        private readonly IWalletService _walletService;
        [Inject]
        private readonly ISaveLoadService _saveLoadService;

        public void Collect(Collector collector)
        {
            _walletService?.AddCoin();
            _saveLoadService?.SavePlayerProgress();
            IsCollected = true;
            AudioManager.instance.Play(SoundType.PickupCoin);

            if (_moveFadeDestroyer == null)
                return;

            _rigidbody2D.isKinematic = true;
            _rigidbody2D.velocity = Vector2.zero;
            _boxCollider2D.enabled = false;
            _moveFadeDestroyer.Destroy();
        }
    }
}