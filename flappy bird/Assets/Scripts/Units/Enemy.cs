using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Unit
{
    // Start is called before the first frame update
    
    ///public event DeathNotify Ondeath;
    
    public float Lifetime = 4f;
    public Enemy_type Enemy_type;
    public float Minrange=-3;
    public float Maxrange=1;
    float initY = 0;
    
    public override void OnStart()
    {
       
        this.ani = GetComponent<Animator>();
        this.Fly();
        initPos = this.transform.position;
        Destroy(this.gameObject, Lifetime);
        initY = Random.Range(Minrange, Maxrange);
        this.transform.localPosition = new Vector3(3, initY, 0);
    }
    
    
    // Update is called once per frame
    public override void OnUpdate()
    {
        //if (death)
        //    return;
        //if(Input.GetMouseButtonDown(0))
        //{
        //    rigidbodybird.velocity = Vector2.zero;
        //    rigidbodybird.AddForce(new Vector2(0, force),ForceMode2D.Force);
        //}
        //fireTimer += Time.deltaTime;
       
        float y = 0;
        
        if(this.Enemy_type==Enemy_type.Swing_enemy) 
        {
            y = Mathf.Sin(Time.timeSinceLevelLoad)*3;
        }
        //Vector2 pos = this.transform.position;
        this.transform.position = new Vector3(this.transform.position.x-Time.deltaTime * Speed, initY+y,0);
        this.Fire();
        //pos.x += Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        //pos.y += Input.GetAxis("Vertical") * Time.deltaTime * Speed;
        //this.transform.position = pos;
        //if (Input.GetButton("Fire1"))
        //{
        //    this.Fire();
        //}
    }
    //public void Fire()
    //{
    //    if (fireTimer > 1f / fireRate)
    //    {
    //        GameObject go = Instantiate(BulletTemplate);
    //        go.transform.position = this.transform.position;
    //        go.GetComponent<Element>().direction = -1;
    //        //SpriteRenderer[] sprs = go.GetComponentsInChildren<SpriteRenderer>();
    //        //for(int i=0; i<sprs.Length; i++)
    //        //{
    //        //    sprs[i].color = Color.red;
    //        //}
    //        fireTimer = 0f;
    //    }

    //}

    //public override void Die()
    //{
    //    this.death = true;
    //    if (this.Ondeath != null)
    //    {
    //        this.Ondeath();
    //    }
    //    this.ani.SetTrigger("die");
    //    Destroy(this.gameObject,0.2f);

    //}
    private void OnCollisionEnter2D(Collision2D col)
    {

        Debug.Log("Enemy:OncollisionEnter2D:" + col.gameObject.name + ";" + gameObject.name + ":" + Time.time);
        //this.Die();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        Element bullet = col.GetComponent<Element>();
        if (bullet == null)
        {
            return;
        }
        //if(col.gameObject.name.Equals("Scorearea"))
        //{

        //}
        //else
        //this.Die();
        Debug.Log("Enemy:OnTriggerExit2D:" + col.gameObject.name + ";" + gameObject.name + ":" + Time.time);
        if (bullet.side == Side.Player)
        {
            this.Die();
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Enemy:OnTriggerExit2D:" + col.gameObject.name + ";" + gameObject.name + ":" + Time.time);
        if (col.gameObject.name.Equals("Scorearea"))
        {
            if (this.OnScore != null)
                this.OnScore(1);
        }



    }
}

