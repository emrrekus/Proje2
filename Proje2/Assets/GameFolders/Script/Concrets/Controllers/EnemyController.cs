using System;
using System.Collections;
using System.Collections.Generic;
using Proje2.Abstracts.Controllers;
using Proje2.Managers;
using UnityEngine;

namespace Proje2.Controllers
{
    public class EnemyController : MyCharacterController, IEntityController
    {
        private VerticalMover _verticalMover;
        [SerializeField] private float _maxLifeTime;
        private float _currentLifeTime = 0f;


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
    }
}