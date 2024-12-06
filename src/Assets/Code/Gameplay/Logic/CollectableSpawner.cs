using System;
using System.Collections;
using Assets.Code.Extensions;
using Assets.Code.Infrastructure.Services.Random;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.Logic
{
    public class CollectableSpawner : MonoBehaviour
    {
        [SerializeField]
        private float _timeToSpawn = 5f;

        [SerializeField]
        private GameObject _collectable = null;

        [SerializeField]
        private float _randomDeltaX = 2f;

        private IRandomService _randomService;

        [Inject]
        private void Constructor(IRandomService randomService)
        {
            _randomService = randomService;
        }

        private void Start()
        {
            if (_collectable == null)
                throw new InvalidOperationException("Enemy prefab is not set in the Enemies spawner.");

            StartCoroutine(SpawnEnemyCoroutine());
        }

        private IEnumerator SpawnEnemyCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_timeToSpawn);
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            Instantiate(_collectable, transform.position.WithX(GetRandomX()), Quaternion.identity, gameObject.transform);
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
