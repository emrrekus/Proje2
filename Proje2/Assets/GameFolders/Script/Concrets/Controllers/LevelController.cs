using System;
using System.Collections;
using System.Collections.Generic;
using Proje2.Managers;
using Proje2.SciptableObjects;
using UnityEngine;

namespace  Proje2.Controllers
{
    public class LevelController : MonoBehaviour
    {
        private LevelDifficultyData _levelDifficultyData;

        private void Awake()
        {
            _levelDifficultyData = GameManager.Instance.LevelDifficultyData;
        }

        private void Start()
        {
            RenderSettings.skybox = _levelDifficultyData.SkyboxMaterial;
            Instantiate(_levelDifficultyData.FloorCPrefab);
            Instantiate(_levelDifficultyData.SpawnerPrefab);
            EnemyManager.Instance.SetMoveSpeed(_levelDifficultyData.MoveSpeed);
            EnemyManager.Instance.SetDelayTime(_levelDifficultyData.DelayTime);
        }
    }
    
}

