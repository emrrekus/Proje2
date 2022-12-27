using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Proje2.Abstracts.Controllers
{
    public abstract class MyCharacterController : MonoBehaviour
    {
        [SerializeField] private float _moveBoundary = 4.5f;
        [SerializeField] protected float _moveSpeed = 10f;
        public float MoveSpeed => _moveSpeed;
        public float MoveBoundary => _moveBoundary;
    }
}

