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
       
       

        public HorizontalMover(IEntityController entityController)
        {
            _playerController = entityController;
            
        }

        public void FixedTick(float horizontal)
        {
            if (horizontal == 0f)
            {
                return;
            }

            _playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime *_playerController.MoveSpeed);
            float xBoundary = Mathf.Clamp(_playerController.transform.position.x, -_playerController.MoveBoundary, _playerController.MoveBoundary);
            _playerController.transform.position = new Vector3(xBoundary, _playerController.transform.position.y,_playerController.transform.position.z);
        }

       
    }
}