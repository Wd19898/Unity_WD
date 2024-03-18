using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


     class GameUti:Singleton<GameUti>
    {
    public bool InScreen(Vector3 position)
    {
        return Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(position));
       
    }

}

