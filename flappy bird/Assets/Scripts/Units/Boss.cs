using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class Boss : Enemy
{
    // Start is called before the first frame update
    public GameObject missleTemplate;
    //public GameObject bulletTemplate;
    public Transform firePoint2;
    public Transform firePoint3;
    public float fireRate2 = 10f;
    public Transform battery;
    public Missle missle =null;
    //GameObject missle = null;
    public float fireTimer2 = 0;
    public float fireTimer3 = 0;
    public Unit target;
    public float UltCd = 5f;


    IEnumerator Enter()
    {
        this.transform.position=new Vector3 (15,0,0);
        yield return MoveTo(new Vector3(5, 0, 0));
        //yield return MoveTo(new Vector3(5, 4, 0));
        //yield return MoveTo(new Vector3(5, 0, 0));

        

        yield return Attack();

    }
    IEnumerator Attack()
    {
        
        while (true)
        {
            fireTimer += Time.deltaTime;

            fireTimer2 += Time.deltaTime;
            Fire();
            FireBattery();
            fireTimer3 += Time.deltaTime;

            if ( fireTimer3 > UltCd ) 
            {

                yield return UltraAttack();
                fireTimer3 = 0;


            }
        
        yield return null;

        }
    }
    IEnumerator MoveTo(Vector3 Pos)
    {
        while (true)
        { 
        Vector3 dir = (Pos - transform.position).normalized;
        if (dir.magnitude < 0.1)
        {
            break; 
        }
        this.transform.position += Speed * Time.deltaTime * dir.normalized;
            yield return null;
        }
    }
    public void OnMissleLoad()
    {
        //missle = Instantiate(missleTemplate, firePoint3);
        GameObject go = Instantiate(missleTemplate, firePoint3);
        missle = go.GetComponent<Missle>();
        missle.target = this.target.transform;
    }
    public void OnMissleLauncher()
    {
        if(missle==null)
            return;

        missle.transform.SetParent(null);
        missle.Luncher();

    }
    public override void OnUpdate()
    {
        if (target != null)
        {
            Vector3 dir = (target.transform.position - battery.position).normalized;
            
            battery.transform.rotation = Quaternion.FromToRotation(Vector3.left, dir);

        }
    }
    public override void OnStart()
    {
       //this.isFlying=true;
       this.Fly();
       StartCoroutine(Enter());
    }
    IEnumerator UltraAttack()
    {
        yield return MoveTo(new Vector3(5, 5, 0));
        yield return FireMissle();

        yield return MoveTo(new Vector3(5, 0, 0));

    }
    IEnumerator FireMissle()
    {
        ani.SetTrigger("skill");
        yield return new WaitForSeconds(1f);


    }
    public void FireBattery()
    {


        if (fireTimer2 > 1f / fireRate2)

        {
        GameObject go = Instantiate(BulletTemplate, firePoint2.position,battery.rotation);
        Element bullent = go.GetComponent<Element>();
        bullent.direction=(target.transform.position- firePoint2.position).normalized;
        fireTimer2 = 0f;

        }
    }
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
            this.Damage(bullet.power);
        }

    }

    

}
