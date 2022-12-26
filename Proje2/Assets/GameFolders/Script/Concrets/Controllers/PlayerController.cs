using System;
using System.Collections;
using System.Collections.Generic;
using Proje2.Abstracts.Inputs;
using Proje2.Inputs;
using Proje2.Movements;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Proje2.Controllers
{
    public class PlayerController : MonoBehaviour
    {
      
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _jumpForce = 300f;
        [SerializeField] bool _isJump;

        HorizontalMover _horizontalMover;
        JumpWithRigibody _jump;
         IInputReader _input;
         private float _horizontal;

        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jump = new JumpWithRigibody(this);
            _input = new InputReader(GetComponent<PlayerInput>());
        }

        private void Update()
        {
            _horizontal = _input.Horizontal;
        }

        private void FixedUpdate()
        {
            _horizontalMover.TickFixed(_horizontal, _moveSpeed);

            if (_isJump)
            {
                _jump.TickFixed(_jumpForce);
            }

            _isJump = false;
        }
    }
}