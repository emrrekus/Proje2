using System.Collections;
using System.Collections.Generic;
using Proje2.Controllers;
using UnityEngine;

namespace Proje2.Movements
{
    public class HorizontalMover
    {
        private PlayerController _playerController;

        public HorizontalMover(PlayerController playerController)
        {

            _playerController = playerController;
        }

        public void TickFixed(float horizontal, float moveSpeed)
        {

            if (horizontal == 0f)
            {
                return;
            }
            
            _playerController.transform.Translate(Vector3.right*horizontal*Time.deltaTime*moveSpeed);
            
        }
    }
}