using System.Collections;
using System.Collections.Generic;
using Proje2.Managers;
using UnityEngine;

namespace Proje2.UIS
{
    public class MenuPanel : MonoBehaviour
    {
        public void DifficultyButton(int index)
        {
            GameManager.Instance.DifficultyIndex = index;
            GameManager.Instance.LoadScene("Game");
        }

        public void ExitButton()
        {
            GameManager.Instance.ExitGame();
            
        }
    }
}