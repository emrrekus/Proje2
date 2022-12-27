using System;
using System.Collections;
using System.Collections.Generic;
using Proje2.Abstracts.Controllers;
using Proje2.Enums;
using Proje2.Managers;
using UnityEngine;

namespace Proje2.Controllers
{
    public class EnemyController : MyCharacterController, IEntityController
    {
        [SerializeField] private EnemyEnum _enemyEnum;
        [SerializeField] private float _maxLifeTime;
        
        
        private float _currentLifeTime = 0f;
        private VerticalMover _verticalMover;
        public EnemyEnum enemyType => _enemyEnum;
        private void Awake()
        {
            _verticalMover = new VerticalMover(this);
        }

        private void FixedUpdate()
        {
            _verticalMover.FixedTick();
        }

        private void Update()
        {
            _currentLifeTime += Time.deltaTime;
            if (_currentLifeTime > _maxLifeTime)
            {
                _currentLifeTime = 0f;
                KillYourself();
            }
        }

        private void KillYourself()
        {
            EnemyManager.Instance.SetPool(this);
        }

        public void SetMoveSpeed(float speed)
        {
            if(speed <_moveSpeed)return;
            _moveSpeed = speed;
        }
    }
}