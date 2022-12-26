using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Proje2.Controllers
{
    public class VerticalMover
    {
        private EnemyController _enemyController;
        private float _moveSpeed;

        public VerticalMover(EnemyController enemyController)
        {

            _enemyController = enemyController;
            _moveSpeed = _enemyController.MoveSpeed;
        }

        public void FixedTick(float vertical= 1)
        {

            _enemyController.transform.Translate(Vector3.back * vertical * _moveSpeed * Time.deltaTime);

        }
    }
}