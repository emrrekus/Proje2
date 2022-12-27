using System;
using System.Collections;
using System.Collections.Generic;
using Proje2.Abstracts.Utilities;
using Proje2.Controllers;
using Proje2.Enums;
using Unity.VisualScripting;
using UnityEngine;

namespace Proje2.Managers
{
    public class EnemyManager : SingletonMBObject<EnemyManager>
    {
        [SerializeField] private float _addDelayTime;
        [SerializeField] private EnemyController[] _enemyPrefabs;

        Dictionary<EnemyEnum, Queue<EnemyController>> _enemies = new Dictionary<EnemyEnum, Queue<EnemyController>>();
        public float AddDelayTime => _addDelayTime;
        public int Count => _enemyPrefabs.Length;

        private float _moveSpeed;
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
            for (int i = 0; i < _enemyPrefabs.Length; i++)
            {
                Queue<EnemyController> enemyControllers = new Queue<EnemyController>();
                for (int j = 0; j < 10; j++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[i]);
                    newEnemy.gameObject.SetActive(false);
                    newEnemy.transform.parent = this.transform;
                    enemyControllers.Enqueue(newEnemy);
                }

                _enemies.Add((EnemyEnum)i, enemyControllers);
            }
        }

        public void SetPool(EnemyController enemyController)
        {
            enemyController.gameObject.SetActive(false);
            enemyController.transform.parent = this.transform;

            Queue<EnemyController> enemyControllers = _enemies[enemyController.enemyType];
            enemyControllers.Enqueue(enemyController);
        }

        public EnemyController GetPool(EnemyEnum enemyType)
        {
            Queue<EnemyController> enemyControllers = _enemies[enemyType];
            if (enemyControllers.Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[(int)enemyType]);
                    enemyControllers.Enqueue(newEnemy);
                }
               
            }

            EnemyController enemyController = enemyControllers.Dequeue();
            enemyController.SetMoveSpeed(_moveSpeed);
            return enemyController;
        }

        public void SetMoveSpeed(float moveSpeed)
        {
            _moveSpeed = moveSpeed;
        }

        public void SetDelayTime(float delayTime)
        {
            _addDelayTime = delayTime;
        }
    }
}