using System.Collections;
using Assets.Code.Infrastructure.Services.StaticData;
using Assets.Code.StaticData;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Logic
{
    public class Saw : MonoBehaviour
    {
        [SerializeField]
        private float rotationDuration = 1f;

        [Inject]
        private IStaticDataService _staticDataService;

        private SawConfig _sawConfig;

        private Tween _rotationTween;

        private void Start()
        {
            _sawConfig = _staticDataService.SawConfig;
            RotateSaw();
        }

        private void RotateSaw()
        {
            _rotationTween = transform.DORotate(new Vector3(0, 0, -360), rotationDuration, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart);
        }

        private void OnDestroy()
        {
            if (_rotationTween != null && _rotationTween.IsActive())
            {
                _rotationTween.Kill();
            }
            StopAllCoroutines();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Health playerHealth))
            {
                StartCoroutine(ApplyDamage(playerHealth));
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Health playerHealth))
            {
                StopAllCoroutines();
            }
        }

        private IEnumerator ApplyDamage(Health playerHealth)
        {
            while (true)
            {
                playerHealth.Substract(_sawConfig.DamageAmount);
                yield return new WaitForSeconds(_sawConfig.DamageInterval);
            }
        }
    }
}
