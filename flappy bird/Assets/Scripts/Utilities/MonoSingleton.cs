using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class MonoSingleton<T>:MonoBehaviour where T : MonoBehaviour,new() 
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                //instance = new T ();
                instance = FindObjectOfType<T>();
            }
            return instance;
        }
    }
}

