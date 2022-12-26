
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

namespace Proje2.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] private EnemyController _enemyPrefab;
        [Range(0.1f,5f)]
        [SerializeField] private float _min = 0.1f;
        [Range(6f,15f)]
        [SerializeField] private float _max = 15f;

        private float _currentSpawnTime = 0f;
        private float _maxSpawnTime;

        private void OnEnable()
        {
           GetRandomMaxTime();
        }
        

        private void Update()
        {
            _currentSpawnTime += Time.deltaTime;
            if (_currentSpawnTime > _maxSpawnTime)
            {
                Spawn();
            }
        }

        void Spawn()
        {
           EnemyController newEnemy= Instantiate(_enemyPrefab, transform.position, transform.rotation);
           newEnemy.transform.parent = this.transform;
            _currentSpawnTime = 0f;
            GetRandomMaxTime();
        }

        private void GetRandomMaxTime()
        {
            _maxSpawnTime = UnityEngine.Random.Range(_min,_max);
            
        }
    }
}