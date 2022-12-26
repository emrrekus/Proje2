using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Proje2.Abstracts.Utilities
{
    public abstract class SingletonMBObject<T> : MonoBehaviour where T:Component
    {
        public static T Instance { get; private set; }

        public void SingletonThisObject(T entity)
        {
            if (Instance == null)
            {
                Instance = entity;
                    DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }
    }
}