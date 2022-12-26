using System.Collections;
using System.Collections.Generic;
using Proje2.Managers;
using UnityEngine;

namespace Proje2.UIS
{
    public class MenuPanel : MonoBehaviour
    {
        public void StartButton()
        {
            GameManager.Instance.LoadScene();
        }

        public void ExitButton()
        {
            GameManager.Instance.ExitGame();
            
        }
    }
}