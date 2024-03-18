using UnityEditor;
using UnityEngine;


    
    public enum Side
        { 
            None=0,
            Enemy,
            Player,
        }
public enum Enemy_type
{
    Normal_enemy,
    Swing_enemy,
    Boss,
}
public enum LEVEL_RESULT
{
    NONE,
    SUCCESS,
    FAILD,
}
public enum GAME_STATUS
{
    Ready,
    InGame,
    GameOver
}
