using Assets.Code.Data;
using Assets.Code.Infrastructure.Services.Input;
using Assets.Code.Infrastructure.Services.PlayerInventory;
using UnityEditor.UIElements;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Logic
{
    public class Jump : MonoBehaviour
    {
        [SerializeField]
        private float _jumpForce = 1;
        [SerializeField]
        private Rigidbody2D _rigidbody2D;
        [SerializeField]
        private float _jumpDelay = 0.1f;
        [SerializeField]
        private LayerMask _groundLayer = 1 << 8;
        [Inject]
        private readonly IInputService _inputService;
        [Inject]
        private readonly IPlayerInventoryService playerInventoryService;

        private int _jumpCount = 0;
        private int _jumpLimit = 0;
        private float _nextJumpTime = 0;

        private void OnValidate()
        {
            _rigidbody2D ??= GetComponent<Rigidbody2D>();
        }

        private void Awake()
        {
            _jumpLimit = playerInventoryService.GetPlayerFeatureCount(PlayerFeatureType.Jump);
        }

        private void Update()
        {
            if (_jumpLimit >= _jumpCount)
            {
                if (Time.time > _nextJumpTime && _inputService.GetJump())
                {
                    _nextJumpTime = Time.time + _jumpDelay;
                    _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
                    _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                    ++_jumpCount;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if ((_groundLayer.value & (1 << collision.transform.gameObject.layer)) > 0)
            {
                _jumpCount = 0;
            }
        }
    }
}