using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoSingleton<Game>
{
    //public enum GAME_STATUS
    //{
    //    Ready,
    //    InGame,
    //    GameOver
    //}
    public GAME_STATUS status;
    public  GAME_STATUS Status
    {
        get { return status; }
        set { status = value; 
             UIManager.Instance.UpdateUI();
        }
    }
    //public GameObject PanelStart;
    //public GameObject PanelGame;
    //public GameObject PanelOver;   
    public PopelineManager PinelineManager;
    //public UnitManager UnitManager;
    //public LevelManager LevelManager;
    public Player player;
    //public int score;
    //public Text uiScore;
    //public Text uiScoreover;
    //public Slider hpbar;
    //public Text uiLevelName;
    //public List<Level> levels;
    public int currentLevelID = 1;
    //public Level level
    //{
    //    get { return levels[currentLevelID-1]; }
    //}
    //public int Score
    //{ 
    //    get { return score; }
    //    set 
    //    { 
    //    this.score = value;
    //    UIManager.Instance.UpdateScore(this.score);
    //    //this.uiScore.text=this.score.ToString();
    //    //this.uiScoreover.text = this.score.ToString();
    //    }
    //}
    // Start is called before the first frame update
    void Start()
    {
        //this.PanelStart.SetActive(true);
        this.Status = GAME_STATUS.Ready;
        this.player.Ondeath += Player_Ondeath;
        //this.player.OnScore = OnplayerScore;
        //this.player= Instantiate(player, gameObject.transform);

        //InitPlayer();
        //Level level1 = Resources.Load<Level>("Level1");
        //Level level2 = Resources.Load<Level>("Level2");

    }
    //void OnplayerScore(int score)
    //{
    //    this.Score += score;
    //}

    private void Player_Ondeath(Unit sender)
    {
        if (player.life <= 0)
        {
            this.Status = GAME_STATUS.GameOver;
            UnitManager.Instance.Stop();

        }
        else
        {
            player.Rebirth();
            
        }
        this.PinelineManager.Stop();
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //    this.hpbar.value = Mathf.Lerp(this.hpbar.value, this.player.HP, 0.1f);
    //    if(player!= null)
    //       this.uiScore.text = player.life.ToString();
    //}

    public void StartGame()
    {
        this.Status = GAME_STATUS.InGame;

        PinelineManager.StratRun();
        Debug.LogFormat("StartGame:{0}", this.status);
        //UnitManager.Begin();
        player.Fly();
        //this.hpbar.value = this.player.HP;
        //this.LevelManager.UnitManager = this.UnitManager;
        //this.LevelManager.currentPlayer = this.player;
        LoadLevel();
       
    }

    private void LoadLevel()
    {
        LevelManager.Instance.LoadID(this.currentLevelID);
        //this.uiLevelName.text = string.Format("LEVEL {0} {1}", LevelManager.Instance.level.levelID, LevelManager.Instance.level.Name); ;
        LevelManager.Instance.level.OnLevelEnd = OnLevelEnd;
        
    }

    public  void OnLevelEnd(LEVEL_RESULT result)
    {
        if(result==LEVEL_RESULT.SUCCESS)
        {
            this.currentLevelID++;
            this.LoadLevel();
        }
        else
        {
            this.status = GAME_STATUS.GameOver;
            UIManager.Instance.UpdateUI();
        }
        
    }

    //public void UpdateUI()
    //{
    //    this.PanelStart.SetActive(this.status == GAME_STATUS.Ready);
    //    this.PanelGame.SetActive(this.status == GAME_STATUS.InGame);
    //    this.PanelOver.SetActive(this.status == GAME_STATUS.GameOver);
    //}
    public void Restart()
    {
        this.Status= GAME_STATUS.Ready;
        UIManager.Instance.UpdateUI();
        this.PinelineManager.Init();
        this.player.Init();
    }
}
