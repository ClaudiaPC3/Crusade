using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Escalera : NetworkBehaviour
{
    public bool active = false;
    private float counter = 0;
    private bool touchPar = false, ismecast = false;
    
    public GameObject me;
    public GameObject[] jgsnet;

    public void Start()
    {
        jgsnet = GameObject.FindGameObjectsWithTag("Autho");

        if(me.GetComponentInParent<Movimiento>().id == GlobalData.ID)
        {
            ismecast = true;
        }
    }

    public void FixedUpdate()
    {
        if (active)
        {
            if (ismecast)
            {
                counter += Time.deltaTime;
                if (counter >= 0.1)
                {
                    me.GetComponent<PolygonCollider2D>().isTrigger = false;

                    active = false;
                    counter = 0;
                }
            }
            else
            {

            }  
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.tag == "Pared" && ismecast)
        {
            touchPar = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.gameObject.tag == "Pared" && ismecast)
        {
            touchPar = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(active && touchPar || active && !ismecast )
        {
            me.GetComponent<PolygonCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ismecast)
        {
            touchPar = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.gameObject.tag == "Pared" && ismecast)
        {
            counter = 0;
        }
    }
}
