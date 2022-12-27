using System;
using System.Collections;
using System.Collections.Generic;
using Proje2.Managers;
using UnityEngine;

namespace Proje2.UIS
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] private GameOverPanel _gameOverPanel;

        private void Awake()
        {
            _gameOverPanel.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameStop += HandleOnGameStop;

        }
        private void OnDisable()
        {
            GameManager.Instance.OnGameStop -= HandleOnGameStop;
        }

        private void HandleOnGameStop()
        {
           _gameOverPanel.gameObject.SetActive(true);
        }

       
    } 
}

