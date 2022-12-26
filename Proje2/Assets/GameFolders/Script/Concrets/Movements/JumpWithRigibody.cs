using System.Collections;
using System.Collections.Generic;
using Proje2.Controllers;
using UnityEngine;

namespace Proje2.Movements
{
    public class JumpWithRigibody : MonoBehaviour
    {
        private Rigidbody _rb;
        private PlayerController _playerController;

        public JumpWithRigibody(PlayerController playerController)
        {
            _rb = playerController.GetComponent<Rigidbody>();
        }

        public void TickFixed(float jumpForce)
        {
            if(_rb.velocity.y!=0) return;
            
            _rb.velocity= Vector3.zero;
            _rb.AddForce(Vector3.up * Time.deltaTime * jumpForce);
        }
    } 
}

