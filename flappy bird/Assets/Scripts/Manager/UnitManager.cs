using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoSingleton<UnitManager>
{
    // Start is called before the first frame update
    public GameObject EnemyTemplate;
    public GameObject Enemy2Template;
    public GameObject Enemy3Template;
    public List<Enemy> enemys = new List<Enemy>();
    public float speed=1f;
    public float speed2 = 3f;
    public float speed3 = 5f;
    //public float Minrange;
    //public float Maxrange;
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    Coroutine runner = null;
    //public void Begin()
    //{
    //    runner = StartCoroutine(GenerateEnemys());
    //}

    //int timer1 = 0;
    //int timer2 = 0;
    //int timer3 = 0;
    //IEnumerator GenerateEnemys()
    //{
    //   while (true) 
    //    { 
    //        if (timer1 >speed) 
    //        { 
    //            GenerateEnemy(EnemyTemplate);
    //            timer1 = 0;
    //        }
    //        if (timer2 > speed2)
    //        {
    //            GenerateEnemy(Enemy2Template);
    //            timer2 = 0;
    //        }
    //        if (timer3 > speed3)
    //        {
    //            GenerateEnemy(Enemy3Template);
    //            timer3 = 0;
    //        }
    //        timer1++;
    //        timer2++;
    //        timer3++;
    //    yield return new WaitForSeconds(1f);
    //    }
    //}
    public void Stop()
    {
        StopCoroutine(runner);
        this.enemys.Clear();
    }

    public Enemy GenerateEnemy(GameObject templates)
    {
        if (templates == null)
            return null;
            GameObject obj = Instantiate(templates, this.transform);
            Enemy p = obj.GetComponent<Enemy>();
            enemys.Add(p);
        return p;
        //float y = Random.Range(Minrange, Maxrange);
        //this.transform.localPosition = new Vector3(3, y, 0);
    }
}
