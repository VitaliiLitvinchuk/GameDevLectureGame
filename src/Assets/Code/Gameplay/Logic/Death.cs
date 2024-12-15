using Assets.Code.Gameplay.View.UI;
using Assets.Code.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Logic
{
    public class Death : MonoBehaviour
    {
        [SerializeField]
        private Health _health;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private Collider2D _collider2D;

        [SerializeField]
        private SpriteRenderer _renderer;

        [SerializeField]
        private float _forceOnDeath;

        [Inject]
        private readonly IInputService _inputService;

        public DeathMenu deathMenu;
        private bool onceDeathMenu = false;

        private void Update()
        {
            if (!_renderer.isVisible && !onceDeathMenu)
            {
                deathMenu.OnDeath();
                onceDeathMenu = true;
            }
        }

        private void OnValidate()
        {
            _health ??= GetComponent<Health>();
            _rigidbody ??= GetComponent<Rigidbody2D>();
            _collider2D ??= GetComponent<Collider2D>();
        }

        private void Awake()
        {
            _health.Death += OnDeath;
        }

        private void OnDestroy()
        {
            _health.Death -= OnDeath;
            deathMenu = null;
        }

        private void OnDeath()
        {
            _inputService.Disable();
            _rigidbody.AddForce(Vector2.up * _forceOnDeath, ForceMode2D.Impulse);
            _collider2D.enabled = false;
        }
    }
}