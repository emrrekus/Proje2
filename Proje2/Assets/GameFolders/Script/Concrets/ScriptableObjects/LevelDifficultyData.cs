using System.Collections;
using System.Collections.Generic;
using Proje2.Controllers;
using UnityEngine;

namespace Proje2.SciptableObjects
{
    [CreateAssetMenu(fileName = "Level Difficulty",menuName = "Create Difficulty/Create New",order = 1)]
    public class LevelDifficultyData : ScriptableObject
    {
        [SerializeField] private FloorController _floorPrefab;
        [SerializeField] private GameObject _spawnersPrefab;
        [SerializeField] private Material _skyboxMaterial;
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _addDelayTime = 50f;

        public FloorController FloorCPrefab => _floorPrefab;
        public GameObject SpawnerPrefab => _spawnersPrefab;
        public Material SkyboxMaterial => _skyboxMaterial;
        public float MoveSpeed => _moveSpeed;
        public float DelayTime => _addDelayTime;
    }
}

