using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayActive : MonoBehaviour
{
    public float delay = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delay()); 
    }

    // Update is called once per frame
   IEnumerator Delay()
    {
           yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
    }
}
