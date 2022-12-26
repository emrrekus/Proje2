using System.Collections;
using System.Collections.Generic;
using Proje2.Controllers;
using UnityEngine;

namespace Proje2.Movements
{
    public class HorizontalMover
    {
        private PlayerController _playerController;
        private float _moveSpeed;
        private float _moveBoundary;

        public HorizontalMover(PlayerController playerController)
        {
            _playerController = playerController;
            _moveSpeed = _playerController.MoveSpeed;
            _moveBoundary = _playerController.MoveBoundary;
        }

        public void TickFixed(float horizontal, float moveSpeed)
        {
            if (horizontal == 0f)
            {
                return;
            }

            _playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime *_moveSpeed);
            float xBoundary = Mathf.Clamp(_playerController.transform.position.x, -_moveBoundary, _moveBoundary);
            _playerController.transform.position = new Vector3(xBoundary, _playerController.transform.position.y,_playerController.transform.position.z);
        }
    }
}