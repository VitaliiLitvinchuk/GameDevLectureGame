using Assets.Code.Data;
using Assets.Code.Gameplay.Sounds;
using Assets.Code.Gameplay.View;
using Assets.Code.Infrastructure.Services.Random;
using Assets.Code.Infrastructure.Services.Sound;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Logic
{
    public class Aid : MonoBehaviour, ICollectable
    {
        [SerializeField]
        private MoveFadeDestroyer _moveFadeDestroyer;

        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        [SerializeField]
        private CircleCollider2D _circleCollider2D;

        [SerializeField]
        private float _randomHealthFrom = 1;

        [SerializeField]
        private float _randomHealthTo = 10;

        [Inject]
        private readonly IRandomService _randomService;

        [Inject]
        private readonly ISoundService _soundService;

        public bool IsCollected { get; private set; }

        public void Collect(Collector collector)
        {
            IsCollected = true;
            _soundService.Play(SoundType.TakeDamage);

            float randomHealth = _randomService.RoundRange(_randomHealthFrom, _randomHealthTo + 1);
            collector.GetComponent<Health>().AddHealth(randomHealth);

            if (_moveFadeDestroyer == null)
                return;

            _rigidbody2D.isKinematic = true;
            _rigidbody2D.velocity = Vector2.zero;
            _circleCollider2D.enabled = false;
            _moveFadeDestroyer.Destroy();
        }
    }
}