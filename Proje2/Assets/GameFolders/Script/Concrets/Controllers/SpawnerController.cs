using System.Collections;
using System.Collections.Generic;
using Proje2.Enums;
using Proje2.Managers;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

namespace Proje2.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [Range(0.1f, 5f)] [SerializeField] private float _min = 0.1f;
        [Range(6f, 15f)] [SerializeField] private float _max = 15f;

        private float _currentSpawnTime = 0f;
        private float _maxSpawnTime;
        private int _index = 0;
        private float _maxAddEnemyTime;
        public bool CanIncrease => _index < EnemyManager.Instance.Count;

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
            if(!CanIncrease) return;

            if (_maxAddEnemyTime < Time.time)
            {
                _maxAddEnemyTime = Time.time + EnemyManager.Instance.AddDelayTime;
                IncreaseIndex();
                
            }
        }

      
        void Spawn()
        {
           EnemyController newEnemy = EnemyManager.Instance.GetPool((EnemyEnum)UnityEngine.Random.Range(0,_index));
            newEnemy.transform.parent = this.transform;
            newEnemy.transform.position = this.transform.position;
            newEnemy.gameObject.SetActive(true);
            _currentSpawnTime = 0f;
            GetRandomMaxTime();
            
        }

        private void GetRandomMaxTime()
        {
            _maxSpawnTime = UnityEngine.Random.Range(_min, _max);
        }
        private void IncreaseIndex()
        {
            if (CanIncrease)
            {
                _index++;
            }
        }

    }
}