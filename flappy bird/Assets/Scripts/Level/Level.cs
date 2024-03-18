using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    public int levelID;
    public string Name;
    public Boss boss ;
    //public UnitManager UnitManager;
    public float timer = 0;
    public float bossTime = 5f;
    float timeSinceLevelStart = 0;
    float levelStartTime = 0;
    Boss Boss = null;
    //public Player currentPlayer;

    //bool levelEnd = false;
    //bool result = false;

    public UnityAction<LEVEL_RESULT> OnLevelEnd;
    public LEVEL_RESULT result =LEVEL_RESULT.NONE;
  

    public List<SpawnRule> rules = new List<SpawnRule>();
    void Start()
    {
        StartCoroutine(RunLevel());
        //for (int i = 0; i < rules.Count; i++)
        //{
        //    SpawnRule rule = Instantiate<SpawnRule>(rules[i]);
        //    //rule.UnitManager = this.UnitManager;

        //}
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLevelStart = Time.realtimeSinceStartup - this.levelStartTime;

        if (this.result != LEVEL_RESULT.NONE)
            return;
        if (timeSinceLevelStart > bossTime)
        {
            if (Boss == null)
            {
                Boss = (Boss)UnitManager.Instance.GenerateEnemy(this.boss.gameObject);
                Boss.target = Game.Instance.player;
                Boss.Fly();
                Boss.Ondeath += Boss_Ondeath;
            }
        }
    }

    public void Boss_Ondeath(Unit sender)
    {
        this.result=LEVEL_RESULT.SUCCESS;
        if(this.OnLevelEnd != null)
            this.OnLevelEnd(this.result);
    }
    IEnumerator RunLevel()
    {
        UIManager.Instance.ShowLevelStart(string.Format("LEVEL {0} {1}", this.levelID, this.Name));

        yield return new WaitForSeconds(2f);
        for (int i = 0; i < rules.Count; i++)
        {
            SpawnRule rule = Instantiate<SpawnRule>(rules[i]);
            //rule.UnitManager = this.UnitManager;

        }
    }

}
