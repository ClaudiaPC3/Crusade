using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalera : MonoBehaviour
{
    public bool active = false;
    private float counter = 0;
    private bool touchPar = false;
    public GameObject me;

    public void Update()
    {
        if (active)
        {
            counter += Time.deltaTime;
            if (counter >= 0.1)
            {
                me.GetComponent<PolygonCollider2D>().isTrigger = false;
                active = false;
                counter = 0;
            }
        }
    }

    

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.tag == "Pared")
        {
            touchPar = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.gameObject.tag == "Pared")
        {
            touchPar = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(active && touchPar)
        {
            me.GetComponent<PolygonCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        touchPar = false;        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.gameObject.tag == "Pared")
        {
            counter = 0;
        }
    }
}
