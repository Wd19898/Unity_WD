using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Element : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Vector3 direction=Vector3.zero;
    public Side side;
    public float power=1;
    public float lifeTime;
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }
    public virtual void OnUpdate()
    {
        this.transform.position += speed * Time.deltaTime * direction;

        //this.transform.position += new Vector3(speed * Time.deltaTime * direction, 0, 0);
        //Debug.LogFormat("InScreen:{0}", Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(this.transform.position)));
        if (!GameUti.Instance.InScreen( this.transform.position)) 
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
