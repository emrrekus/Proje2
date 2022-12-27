using System.Collections;
using System.Collections.Generic;
using Proje2.Abstracts.Utilities;
using Proje2.Controllers;
using UnityEngine;

namespace Proje2.Managers
{
    public class EnemyManager : SingletonMBObject<EnemyManager>
    {
        [SerializeField] private EnemyController _enemyPrefab;

        private Queue<EnemyController> _enemies = new Queue<EnemyController>();

        private void Awake()
        {
            SingletonThisObject(this);
        }

        private void Start()
        {
            InitalizePool();
        }

        private void InitalizePool()
        {
            for (int i = 0; i < 10; i++)
            {
                EnemyController newEnemy = Instantiate(_enemyPrefab);
                newEnemy.gameObject.SetActive(false);
                newEnemy.transform.parent = this.transform;
                _enemies.Enqueue(newEnemy);
            }
        }

        public void SetPool(EnemyController enemyController)
        {
            enemyController.gameObject.SetActive(false);
            enemyController.transform.parent = this.transform;
            _enemies.Enqueue(enemyController);
        }

        public EnemyController GetPool()
        {
            if (_enemies.Count == 0)
            {
                InitalizePool();
            }

            return _enemies.Dequeue();
        }
    }
}