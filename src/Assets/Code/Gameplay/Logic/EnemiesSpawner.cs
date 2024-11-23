using System;
using UnityEngine;

namespace Assets.Code.Gameplay.Logic
{
    internal sealed class EnemiesSpawner : MonoBehaviour
    {
        [SerializeField]
        private float _timeToSpawn = 5f;
        [SerializeField]
        private GameObject _enemy;
        private float _timer;

        private void Start()
        {
            _timer = _timeToSpawn;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                SpawnEnemy();
                _timer = _timeToSpawn;
            }
        }

        private void SpawnEnemy()
        {
            if (_enemy != null)
                Instantiate(_enemy, gameObject.transform);
        }
    }
}
