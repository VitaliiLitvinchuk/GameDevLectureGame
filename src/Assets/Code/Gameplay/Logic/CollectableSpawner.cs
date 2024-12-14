using System;
using System.Collections;
using System.Collections.Generic;
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
        private float _randomDeltaX = 2f;

        [SerializeField]
        private List<GameObject> _collectables;

        [Inject]
        private readonly IRandomService _randomService;

        [Inject]
        private readonly IInstantiator _instantiator;

        private void Start()
        {
            if (_collectables.Count == 0)
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
            GameObject collectable = _randomService.ChooseFromList(_collectables);

            _instantiator.InstantiatePrefab(collectable, transform.position.WithX(GetRandomX()), Quaternion.identity, gameObject.transform);
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
