using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    // Start is called before the first frame update
    public List<Level> levels;
    public int currentLevelID = 1;

    public Level level;
    //public UnitManager UnitManager;
    //public Player currentPlayer;


    //{
    //    get { return levels[currentLevelID - 1]; }
    //}
    public void LoadID(int levelID)
    {
       // this.currentLevelID = levelID;

       this.level = Instantiate<Level>(levels[levelID-1]);
        //this.level.UnitManager = this.UnitManager;
        //this.level.currentPlayer = this.currentPlayer;


    }
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
