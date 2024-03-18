using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : Unit
{
    // Start is called before the first frame update


    //public event DeathNotify Ondeath;

    //void Start()
    //{
    //    this.ani = GetComponent<Animator>();
    //    this.Idle();
    //    initPos=this.transform.position;
    //}


    // Update is called once per frame
    public float invincibleTime = 3f;
    public float rebirthTimer = 0;

    public override void OnUpdate()
    {
        if (death)
            return;
        //if(Input.GetMouseButtonDown(0))
        //{
        //    rigidbodybird.velocity = Vector2.zero;
        //    rigidbodybird.AddForce(new Vector2(0, force),ForceMode2D.Force);
        //}
        fireTimer += Time.deltaTime;
        rebirthTimer += Time.deltaTime;

        Vector2 pos = this.transform.position;
        pos.x += Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        pos.y += Input.GetAxis("Vertical") * Time.deltaTime * Speed;
        this.transform.position=pos;
        if (Input.GetButton("Fire1")) 
        {
            this.Fire();
        }
    }
    public void Rebirth()
    {
        StartCoroutine(DoRebirth());
    }
    IEnumerator DoRebirth()
    {
        yield return new WaitForSeconds(2f);
        rebirthTimer = 0;

        this.Init();
        this.Fly();
    }
    public bool IsInvincible
    {
        get { return rebirthTimer < this.invincibleTime; }
    }
    //public void Fire()
    //{
    //    if (fireTimer > 1f / fireRate)
    //    {
    //        GameObject go = Instantiate(BulletTemplate);
    //        go.transform.position = this.transform.position;
    //        fireTimer = 0;
    //    }

    //}

    //public override void Die()
    //{
    //    this.death = true;
    //    if (this.Ondeath != null)
    //    {
    //        this.Ondeath();
    //    }
    //}
   
    private void OnCollisionEnter2D(Collision2D col)
    {
        
        Debug.Log("Player:OncollisionEnter2D:" + col.gameObject.name + ";" + gameObject.name + ":" + Time.time);
        //this.Die();
    }
     public void OnTriggerEnter2D(Collider2D col)
    {
        if (this.death)
            return;
        if (this.IsInvincible)
            return;
        Item item = col.gameObject.GetComponent<Item>();
        if (item != null)
        {
            item.Use(this);
        }
        Element bullet = col.GetComponent<Element>();
        Enemy enemy = col.GetComponent<Enemy>();
        if (bullet == null&&enemy==null)
        {
            return;
        }
        //if(col.gameObject.name.Equals("Scorearea"))
        //{

        //}
        //else
        //this.Die();
        Debug.Log("Player:OnTriggerExit2D:" + col.gameObject.name + ";" + gameObject.name + ":" + Time.time);
        if (bullet!=null&&bullet.side == Side.Enemy)
        {
            this.HP=this.HP-bullet.power;
            if(this.HP <=0)
            {
                this.Die();
            }
            
        }
        if (enemy != null)
        {
            this.HP = 0;
            if (this.HP <= 0)
            {
                this.Die();
            }

        }
         

    }

     public void OnTriggerExit2D(Collider2D col)
    {
        if (this.death)
            return;
        if (this.IsInvincible)
            return;
        //Debug.Log("Player:OnTriggerExit2D:" + col.gameObject.name + ";" + gameObject.name + ":" + Time.time);
        if (col.gameObject.name.Equals("Scorearea"))
        {
            if (this.OnScore != null)
                this.OnScore(1);
        }
        

    }
}
