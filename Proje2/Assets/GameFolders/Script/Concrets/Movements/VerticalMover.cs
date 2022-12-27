using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Proje2.Abstracts.Controllers;
using Proje2.Abstracts.Movements;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Proje2.Controllers
{
    public class VerticalMover:IMover
    {
        private IEntityController _entityController;
        private float _moveSpeed;

        public VerticalMover(EnemyController enemyController)
        {

            _entityController = enemyController;
            /*_moveSpeed = _entityController.MoveSpeed;*/
        }

        public void FixedTick(float vertical= 1)
        {

            _entityController.transform.Translate(Vector3.forward * vertical * _moveSpeed * Time.deltaTime);

        }
    }
}