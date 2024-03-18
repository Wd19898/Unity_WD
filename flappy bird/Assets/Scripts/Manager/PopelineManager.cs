using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopelineManager : MonoBehaviour
{
    public GameObject template;
    List<Pineline> pipelines = new List<Pineline> ();
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Coroutine runner = null;
    public void Init()
    {
        for (int i = 0; i < pipelines.Count; i++)
        {
            Destroy(pipelines[i].gameObject);
        }
        pipelines.Clear ();
    }
    public void StratRun()
    {
        if(pipelines.Count == 0)
        runner = StartCoroutine(GeneratePipelines());
       
    }

    public void Stop()
    {
        StopCoroutine(runner);
        for (int i = 0; i < pipelines.Count; i++)
        {
            pipelines[i].enabled = false;
        }
    }
    IEnumerator GeneratePipelines()
    {
        for (int i = 0;i<3;i++)
        {
            if (pipelines.Count<3)
            GeneratePipeline();
            else
            {
                pipelines[i].enabled=true;
                pipelines[i].Init();
            }
            yield return new WaitForSeconds(speed);
        }
    }
    void GeneratePipeline()
    {
        if (pipelines.Count < 3)
        {
            GameObject obj = Instantiate(template, this.transform);
            Pineline p = obj.GetComponent<Pineline>();
            pipelines.Add(p);
        }
    }
   
}
