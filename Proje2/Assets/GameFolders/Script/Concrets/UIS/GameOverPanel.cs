using System.Collections;
using System.Collections.Generic;
using Proje2.Managers;
using UnityEngine;

namespace Proje2.UIS
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButton()
        {
            GameManager.Instance.LoadScene("Game");
        }

        public void NoButton()
        {
            GameManager.Instance.LoadScene("Menu");

        }
    }
    
}

