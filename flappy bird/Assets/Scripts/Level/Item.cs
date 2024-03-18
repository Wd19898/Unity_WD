using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int AddHP = 10;
    public GameObject bullet;
    public float lifeTime = 30;
    public float dropSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, -dropSpeed * Time.deltaTime, 0);
    }
    public void Use(Unit target)
    {
        target.AddHP(AddHP);
        Destroy(this.gameObject);
    }
}
