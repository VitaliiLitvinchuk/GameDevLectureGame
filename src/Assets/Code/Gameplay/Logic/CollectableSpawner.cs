using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Data;
using Assets.Code.Extensions;
using Assets.Code.Infrastructure.Services.Random;
using Assets.Code.Infrastructure.Services.StaticData;
using Assets.Code.StaticData;
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

        [Inject]
        private readonly IRandomService _randomService;

        [Inject]
        private readonly IInstantiator _instantiator;

        [Inject]
        private readonly IStaticDataService _staticDataService;

        private Dictionary<GeneralCollectablePriorityType, RandomCollectableSpawnerConfig> _collectablesConfigs;

        private List<GeneralCollectablePriorityType> _priorityTypes = new();

        private void Awake()
        {
            _collectablesConfigs = _staticDataService.CollectableSpawnerConfigs;

            foreach (var key in _collectablesConfigs.Keys)
            {
                _priorityTypes.AddRange(Enumerable.Range(0, _collectablesConfigs[key].Count).Select(_ => key));
            }

            _priorityTypes.Sort((a, b) => _randomService.Range(0, 2) == 0 ? -1 : 1);
        }

        private void Start()
        {
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
            GeneralCollectablePriorityType priorityType = _randomService.ChooseFromList(_priorityTypes);
            GameObject collectable = _randomService.ChooseFromList(_collectablesConfigs[priorityType].CollectablePrefabs);

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
