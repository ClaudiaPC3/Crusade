using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Chicle : NetworkBehaviour
{
    private bool cont = false, coll = false;

    
    public int idCast = 0;

    private float counter = 0;
    public Sprite chicle, paredsp;
    public GameObject me;
    private GameObject pared = null;
    private GameObject[] chicles;
    
    

    private void Start()
    {
        chicles = GameObject.FindGameObjectsWithTag("Chicle");
        if (chicles.Length > 4)
        {
            Destroy(chicles[0]);
        }
        Debug.Log(idCast);
    }



    private void Update()
    {
        if (!coll)
        {
            counter += Time.deltaTime;
            if(counter >= 1)
            {
                Destroy(me);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if((collision.transform.gameObject.tag == "Pared"|| collision.transform.gameObject.tag == "Cemento") &&!cont)
        {
            pared = collision.transform.gameObject;
            pared.GetComponent<SpriteRenderer>().sprite = chicle;
            coll = true;
            collision.transform.gameObject.GetComponent<ChicleAct>().ischicle = true;
            collision.transform.gameObject.GetComponent<ChicleAct>().jugCast = idCast;
            collision.transform.gameObject.GetComponent<ChicleAct>().miChi = me;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.gameObject.tag == "Chicle")
        Destroy(me);
    }

    private void OnDestroy()
    {
        if(pared != null)
        {
            pared.GetComponent<ChicleAct>().ischicle = false;
            pared.GetComponent<SpriteRenderer>().sprite = paredsp;
            pared.GetComponent<ChicleAct>().jugCast = 0;

        }
    }

}
