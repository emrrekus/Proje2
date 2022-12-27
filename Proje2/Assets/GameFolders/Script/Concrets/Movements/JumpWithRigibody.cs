using System.Collections;
using System.Collections.Generic;
using Proje2.Abstracts.Movements;
using Proje2.Controllers;
using UnityEngine;

namespace Proje2.Movements
{
    public class JumpWithRigibody : MonoBehaviour,IJump
    {
        private Rigidbody _rb;
        private PlayerController _playerController;

        public bool CanJump => _rb.velocity.y != 0f;
        
        public JumpWithRigibody(PlayerController playerController)
        {
            _rb = playerController.GetComponent<Rigidbody>();
        }

        public void FixedTick(float jumpForce)
        {
            if(CanJump) return;
            
            _rb.velocity= Vector3.zero;
            _rb.AddForce(Vector3.up * Time.deltaTime * jumpForce);
        }

       
    } 
}

