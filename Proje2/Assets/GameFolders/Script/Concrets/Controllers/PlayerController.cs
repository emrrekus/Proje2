using System;
using System.Collections;
using System.Collections.Generic;
using Proje2.Abstracts.Controllers;
using Proje2.Abstracts.Inputs;
using Proje2.Abstracts.Movements;
using Proje2.Inputs;
using Proje2.Managers;
using Proje2.Movements;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Proje2.Controllers
{
    public class PlayerController : MonoBehaviour,IEntityController
    {
        [SerializeField] private float _moveBoundary = 4.5f;
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _jumpForce = 300f;
        [SerializeField] bool _isJump;

        IMover _mover;
        IJump _jump;
        IInputReader _input;
        private float _horizontal;
        private bool _ısJump;
        private bool _isDead;

        public float MoveSpeed => _moveSpeed;
        public float MoveBoundary => _moveBoundary;

        private void Awake()
        {
            _mover = new HorizontalMover(this);
            _jump = new JumpWithRigibody(this);
            _input = new InputReader(GetComponent<PlayerInput>());
        }

        private void Update()
        {
            if(_isDead) return;
            _horizontal = _input.Horizontal;
            if (_input.IsJump)
            {
                _isJump = true;
            }
        }

        private void FixedUpdate()
        {
            _mover.FixedTick(_horizontal);

            if (_isJump)
            {
                _jump.FixedTick(_jumpForce);
            }

            _isJump = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            IEntityController enemyController = other.GetComponent<IEntityController>();
            if (enemyController != null)
            {
                _isDead = true;
                GameManager.Instance.StopGame();
            }
        }
    }
}