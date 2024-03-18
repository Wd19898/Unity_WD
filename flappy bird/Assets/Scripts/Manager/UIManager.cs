using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>

{
    // Start is called before the first frame update
    public GameObject PanelStart;
    public GameObject PanelGame;
    public GameObject PanelOver;
    public Text uiScore;
    //public Text uiScoreover;
    public Slider hpbar;
    public Text uiLevelName;
    public Text uiLevelStartName;
    public GameObject uiLevelStart;
    public GameObject uiLevelEnd;
    void Start()
    {
        this.PanelStart.SetActive(true);
        this.uiLevelStart.SetActive(false);
    }

    // Update is called once per frame
    public void UpdateScore(int score)
    {
        this.uiScore.text = score.ToString();
        //this.uiScoreover.text = score.ToString();
    }
    public void ShowLevelStart(string name)
    {
        this.uiLevelName.text = name;
        this.uiLevelStartName.text = name;
        uiLevelStart.SetActive(true);
        //Destroy(go, 2f);
            //string.Format("LEVEL {0} {1}", level.levelID, level.Name); ;

    }

    public void UpdateUI()
    {
        this.PanelStart.SetActive(Game.Instance.status == GAME_STATUS.Ready);
        this.PanelGame.SetActive(Game.Instance.status == GAME_STATUS.InGame);
        this.PanelOver.SetActive(Game.Instance.status == GAME_STATUS.GameOver);
        this.hpbar.value = Game.Instance.player.HP;

    }
    void Update()
    {
        this.hpbar.value = Mathf.Lerp(this.hpbar.value, Game.Instance.player.HP, 0.1f);
        if (Game.Instance.player != null)
            this.uiScore.text = Game.Instance.player.life.ToString();

    }
}
