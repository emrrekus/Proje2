using System;
using System.Collections;
using System.Collections.Generic;
using Proje2.Movements;
using Unity.VisualScripting;
using UnityEngine;

namespace Proje2.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]  float _horizontalDirection = 0f;
        [SerializeField]  float _moveSpeed = 10f;
        [SerializeField]  float _jumpForce = 300f;
        [SerializeField]  bool _isJump;
         HorizontalMover _horizontalMover;
         JumpWithRigibody _jump;
        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jump = new JumpWithRigibody(this);
        }

        private void FixedUpdate()
        {
            _horizontalMover.TickFixed(_horizontalDirection, _moveSpeed);

            if (_isJump)
            {
                
                _jump.TickFixed(_jumpForce);
                
            }
            _isJump = false;
        }
    }
}

