using Assets.Code.Gameplay.Services.Wallet;
using Assets.Code.Gameplay.Sounds;
using Assets.Code.Gameplay.View;
using Assets.Code.Infrastructure.Services.Random;
using Assets.Code.Infrastructure.Services.SaveLoad;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Logic
{
    public class DecreaseMoney : MonoBehaviour, ICollectable
    {
        [SerializeField]
        private MoveFadeDestroyer _moveFadeDestroyer;

        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        [SerializeField]
        private CircleCollider2D _circleCollider2D;

        [SerializeField]
        private int _decreaseMoneyFrom = 1;

        [SerializeField]
        private int _decreaseMoneyTo = 5;

        [Inject]
        private readonly IWalletService _walletService;

        [Inject]
        private readonly IRandomService _randomService;

        [Inject]
        private readonly ISaveLoadService _saveLoadService;

        public bool IsCollected { get; private set; }

        public void Collect(Collector collector)
        {
            _walletService?.SubtractCoins((int)Mathf.Round(_randomService.Range(_decreaseMoneyFrom, _decreaseMoneyTo + 1)));
            _saveLoadService?.SavePlayerProgress();
            IsCollected = true;
            AudioManager.instance.Play(SoundType.PickupCoin);

            if (_moveFadeDestroyer == null)
                return;

            _rigidbody2D.isKinematic = true;
            _rigidbody2D.velocity = Vector2.zero;
            _circleCollider2D.enabled = false;
            _moveFadeDestroyer.Destroy();
        }
    }
}