using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{
    // Start is called before the first frame update
    //public Side Side;
    //public int life=3;
    public Rigidbody2D rigidbodybird;
    public float Speed = 5f;
    public float fireRate = 10f;
    public Animator ani;
    protected bool death = false;
    public delegate void DeathNotify(Unit sender);
    //public delegate void DeathNotify(Unit sender);
    //public event DeathNotify Ondeath;
    protected Vector3 initPos;
    public UnityAction<int> OnScore;
    public GameObject BulletTemplate;
    //public Transform firePoint;
    //protected Vector3 initPos;
    //public bool isFlying = false;
    public float HP = 1000f;
    public float MaxHP = 50f;
    public float fireTimer = 0;
    public event DeathNotify Ondeath;
    public Side Side;
    public Transform firePoint;
    public float attack;
    public int life = 3;

    void Start()
    {
        this.ani = GetComponent<Animator>();
        this.Idle();
        initPos = this.transform.position;
        this.Init();
        OnStart();
    }
    public virtual void OnStart()
    {

    }
    public void Init()
    {
        this.transform.position = initPos;
        
        this.Idle();
        this.HP = this.MaxHP;
        this.death = false;
    }
    public void Fire()
    {

        if (fireTimer > 1f / fireRate)
        {
            GameObject go = Instantiate(BulletTemplate);
            go.transform.position = firePoint.position;
            go.GetComponent<Element>().direction = this.Side == Side.Player ? Vector3.right : Vector3.left; 
            //        //SpriteRenderer[] sprs = go.GetComponentsInChildren<SpriteRenderer>();
            //        //for(int i=0; i<sprs.Length; i++)
            //        //{
            //        //    sprs[i].color = Color.red;
            //        //}
            fireTimer = 0f;
        }

    }

    public void Idle()
    {  

        this.rigidbodybird.simulated = false;
        this.ani.SetTrigger("Idle");
    }
    public void Fly()
    {

        this.rigidbodybird.simulated = true;
        this.ani.SetTrigger("fly");
    }
    public virtual void Die()
    {
        this.death = true;
        this.life--;

        if (this.Ondeath != null)
        {
            this.Ondeath(this);
        }
        this.ani.SetTrigger("die");
        if(this.Side!= Side.Player) 
          Destroy(this.gameObject, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (death)
            return;
        //if (!isFlying)
            //return;
        //if(Input.GetMouseButtonDown(0))
        //{
        //    rigidbodybird.velocity = Vector2.zero;
        //    rigidbodybird.AddForce(new Vector2(0, force),ForceMode2D.Force);
        //}
        fireTimer += Time.deltaTime;
        OnUpdate();
    }
    public virtual void OnUpdate()
    {

    }
    public void Damage(float power)
    {
        this.HP -= power;
        if(this.HP < 0)
        {
            this.Die();
        }
    }
    public void AddHP(int hp)
    {
        this.HP += hp;
        if(this.HP>MaxHP)
        {
            this.HP = MaxHP;
        }
    }
}
