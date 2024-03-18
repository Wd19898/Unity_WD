using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SpawnRule : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    public Unit Monster;
    public float period;
    public float InitTime;

    public int MaxNum;
    public int HP;
    public int Attack;
    float timeSinceLevelStart = 0;
    float levelStartTime = 0;
    public int num = 0;
    float timer = 0;
    public ItemDropRule dropRule;
    ItemDropRule rule;

    //public UnitManager UnitManager;

    void Start()
    {
        this.levelStartTime = Time.realtimeSinceStartup;
        if(dropRule != null )
            rule = Instantiate<ItemDropRule>(dropRule);

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLevelStart= Time.realtimeSinceStartup-this.levelStartTime;
        if (num >= MaxNum)
            return;
        if(timeSinceLevelStart>InitTime)
        {

            timer += Time.deltaTime;
            if (timer > period)
            {
                timer = 0;

                Enemy enemy = UnitManager.Instance.GenerateEnemy(this.Monster.gameObject);
                enemy.HP = this.HP;
                enemy.attack = this.Attack;
                enemy.Ondeath += Enemy_OnDeath;
                num++;

            }
        }

    }

    private void Enemy_OnDeath(Unit sender)
    {
        if(rule!= null)
        //ItemDropRule rule = Instantiate<ItemDropRule>(dropRule);
           rule.Execute(sender.transform.position);
    }
}
