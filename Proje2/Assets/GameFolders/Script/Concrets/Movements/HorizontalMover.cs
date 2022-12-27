using System.Collections;
using System.Collections.Generic;
using Proje2.Abstracts.Controllers;
using Proje2.Abstracts.Movements;
using Proje2.Controllers;
using UnityEngine;

namespace Proje2.Movements
{
    public class HorizontalMover: IMover
    {
        private IEntityController _playerController;
        private float _moveSpeed;
        private float _moveBoundary;

        public HorizontalMover(IEntityController entityController)
        {
            _playerController = entityController;
            _moveSpeed = _playerController.MoveSpeed;
            _moveBoundary = _playerController.MoveBoundary;
        }

        public void FixedTick(float horizontal)
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