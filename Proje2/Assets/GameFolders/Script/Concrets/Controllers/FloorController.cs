using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proje2.Controllers
{
    public class FloorController : MonoBehaviour
    {
        private Material _material;
        [Range(0.5f,2f)]
        [SerializeField] private float _moveSpeed = 0.5f;
        private void Awake()
        {
            _material = GetComponentInChildren<MeshRenderer>().material;
        }

        private void Update()
        {
            _material.mainTextureOffset += Vector2.up * Time.deltaTime * _moveSpeed;
        }
    }
    
}

