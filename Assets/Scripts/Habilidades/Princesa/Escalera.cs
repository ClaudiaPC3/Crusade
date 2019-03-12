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
            if (counter >= 0.2)
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
            me.transform.position = new Vector3(collision.transform.gameObject.transform.position.x+14, collision.transform.gameObject.transform.position.y - 14, 0);            
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.gameObject.tag == "Pared")
        {
            procdeac = false;
            counter = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        procdeac = true; 
    }
}
