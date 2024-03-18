using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pineline : MonoBehaviour
{
    public float speed;
    public float Minrange;
    public float Maxrange;
    float t = 0;
    // Start is called before the first frame update
    void Start()
    {
       this.Init();
       
    }
    public void Init()
    {
        float y = Random.Range(Minrange, Maxrange);
        this.transform.localPosition = new Vector3(3, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.position += new Vector3(-speed,0) *Time.deltaTime;
        t += Time.deltaTime;
        if(t > 6f)
        {
            t = 0;
            this.Init();
        }
    }
}
