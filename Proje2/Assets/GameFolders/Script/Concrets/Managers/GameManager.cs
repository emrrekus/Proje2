using System;
using System.Collections;
using System.Collections.Generic;
using Proje2.Abstracts.Utilities;
using UnityEngine;

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

        public void LoadScene()
        {
            
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
    
}

