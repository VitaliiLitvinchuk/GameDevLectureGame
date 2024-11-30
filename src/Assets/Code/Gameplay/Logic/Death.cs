using System;
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
        private float _forceOnDeath;

        private IInputService _inputService;

        [Inject]
        private void Constructor(IInputService inputService)
        {
            _inputService = inputService;
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
        }

        private void OnDeath()
        {
            _inputService.Disable();
            _rigidbody.AddForce(Vector2.up * _forceOnDeath, ForceMode2D.Impulse);
            _collider2D.enabled = false;
        }
    }
}