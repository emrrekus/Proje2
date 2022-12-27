using System;
using System.Collections;
using System.Collections.Generic;
using Proje2.Abstracts.Utilities;
using Proje2.SciptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Proje2.Managers
{
    public class GameManager : SingletonMBObject<GameManager>
    {
        [SerializeField] private LevelDifficultyData[] _levelDifficultyDatas;
        public event System.Action OnGameStop;
        public LevelDifficultyData LevelDifficultyData => _levelDifficultyDatas[DifficultyIndex];

        private int _difficultyIndex;

        public int DifficultyIndex
        {
            get => _difficultyIndex;
            set
            {
                if (_difficultyIndex < 0 || _difficultyIndex > _levelDifficultyDatas.Length)
                {
                    LoadSceneAsync("Menu");
                }
                else
                {
                    _difficultyIndex = value;
                }
            }
        }
         
        private void Awake()
        {
            SingletonThisObject(this);
        }

        public void StopGame()
        {
            Time.timeScale = 0f;
            
            OnGameStop?.Invoke();
        }

        public void LoadScene(string sceneName)
        {
            
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            Time.timeScale = 1f;
            yield return SceneManager.LoadSceneAsync(sceneName);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
    
}

