using System.Collections;
using Assets.Code.Extensions;
using Assets.Code.Infrastructure.Services.Random;
using Assets.Code.Infrastructure.Services.StaticData;
using Assets.Code.StaticData;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Logic
{
    public class SawSpawner : MonoBehaviour
    {
        [SerializeField]
        private float _randomDeltaX = 2f;

        [Inject]
        private readonly IRandomService _randomService;

        [Inject]
        private readonly IInstantiator _instantiator;

        [Inject]
        private readonly IStaticDataService _staticDataService;

        private SawConfig _sawConfig;

        private void Start()
        {
            _sawConfig = _staticDataService.SawConfig;
            StartCoroutine(SpawnSawCoroutine());
        }

        private IEnumerator SpawnSawCoroutine()
        {
            while (true)
            {
                Vector3 position = transform.position.WithX(GetRandomX());

                ShowDangerIcon(position);
                yield return new WaitForSeconds(_sawConfig.ShowDangerTime);

                SpawnSaw(position);
                yield return new WaitForSeconds(_sawConfig.DurationExist + _sawConfig.DurationIn);
            }
        }

        private void ShowDangerIcon(Vector3 position)
        {
            GameObject dangerIcon = _instantiator.InstantiatePrefab(_sawConfig.DangerIcon, position + Vector3.up * 1.5f, Quaternion.identity, transform);

            SpriteRenderer renderer = dangerIcon.GetComponent<SpriteRenderer>();
            renderer.color = new Color(1, 1, 1, 0);
            Tween tween = renderer.DOFade(1f, _sawConfig.ShowDangerTime * 0.8f);
            tween.OnComplete(() =>
            {
                Destroy(dangerIcon);
                tween.Kill();
            });
        }

        private void SpawnSaw(Vector3 position)
        {
            GameObject saw = _instantiator.InstantiatePrefab(_sawConfig.SawPrefab, position, Quaternion.identity, transform);

            Vector3 startPos = saw.transform.position;

            saw.transform.DOMoveY(position.y + 0.75f, _sawConfig.DurationIn).SetEase(Ease.OutBack)
                .OnComplete(() =>
                {
                    saw.transform.DOMoveY(startPos.y, _sawConfig.DurationExist).SetEase(Ease.InBack)
                        .OnComplete(() => Destroy(saw));
                });
        }

        private float GetRandomX()
        {
            var (minRange, maxRange) = GetRandomDeltaXRange();
            return _randomService.Range(minRange, maxRange);
        }

        public (float Min, float Max) GetRandomDeltaXRange()
        {
            return (Min: -_randomDeltaX, Max: _randomDeltaX);
        }
    }
}
