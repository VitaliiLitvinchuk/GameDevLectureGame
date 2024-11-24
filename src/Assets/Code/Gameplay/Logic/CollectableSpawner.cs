using System;
using System.Collections;
using UnityEngine;

namespace Assets.Code.Gameplay.Logic
{
    internal sealed class CollectableSpawner : MonoBehaviour
    {
        [SerializeField]
        private float _timeToSpawn = 5f;
        [SerializeField]
        private GameObject _enemy = null;

        private void Start()
        {
            if (_enemy == null)
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
            Instantiate(_enemy, gameObject.transform);
        }
    }
}
