using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Missle : Element
{
    public Transform target;
    private bool running = false;
    //public GameObject fxExplod;
    //public float power =100f;
    // Start is called before the first frame update
    public override void OnUpdate()
    {
        if (!running)
            return;
        if (target != null)
        {
            Vector3 dir = (target.position - transform.position).normalized;
            if(dir.magnitude<=0.1)
            {
                this.Explod();
            }
            this.transform.rotation = Quaternion.FromToRotation(Vector3.left, dir);
            this.transform.position += speed * Time.deltaTime * dir;

        }

    }

    public void Luncher()
    {
        running = true;
    }
    public void Explod()
    {
        Destroy(this.gameObject);
        if (this.target != null)
        {
            Player p = target.GetComponent<Player>();
            p.Damage(power);
        }
    }
}
