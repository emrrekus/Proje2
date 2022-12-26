using System;
using System.Collections;
using System.Collections.Generic;
using Proje2.Abstracts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Proje2.Managers
{
    public class GameManager : SingletonMBObject<GameManager>
    {
        private void Awake()
        {
            SingletonThisObject(this);
        }

        public void StopGame()
        {
            Time.timeScale = 0f;
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

