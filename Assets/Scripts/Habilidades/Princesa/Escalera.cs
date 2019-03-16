using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalera : MonoBehaviour
{
    public bool active = false, procdeac = false;
    private float counter = 0;
    
    public GameObject me;

    public void Update()
    {
        if (procdeac)
        {
            counter += Time.deltaTime;
            if (counter >= 0.1)
            {
                me.GetComponent<PolygonCollider2D>().isTrigger = false;
                active = false;
                procdeac = false;
                counter = 0;
            }
        }
    }

    // Update is called once per frame
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.gameObject.tag == "Pared" && active)
        {
            
            me.GetComponent<PolygonCollider2D>().isTrigger = true;            
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        procdeac = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.gameObject.tag == "Pared")
        {
            counter = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        procdeac = true; 
    }
}
